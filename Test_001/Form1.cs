using System;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using System.Threading;
using System.Runtime.InteropServices;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using static System.Net.Mime.MediaTypeNames;
using Emgu.CV.Aruco;
using Emgu.CV.Features2D;
using System.Globalization;
using System.Security.Policy;
using Emgu.CV.Util;
using System.Diagnostics;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;


namespace Test_001
{
    public partial class Form1 : Form
    {
        private Capture _capture;
        private VideoCapture capture;

        //private HaarCascade _face;
        private CascadeClassifier _cascadeClassifier;

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String win1 = "Test Window"; //The name of the window
            CvInvoke.NamedWindow(win1); //Create the window using the specific name

            Mat img = new Mat(200, 400, DepthType.Cv8U, 3); //Create a 3 channel image of 400x200
            img.SetTo(new Bgr(255, 0, 0).MCvScalar); // set it to Blue color

            //Draw "Hello, world." on the image using the specific font
            CvInvoke.PutText(
               img,
               "Hello, world",
               new System.Drawing.Point(10, 80),
               FontFace.HersheyComplex,
               1.0,
               new Bgr(0, 255, 0).MCvScalar);


            CvInvoke.Imshow(win1, img); //Show the image
            CvInvoke.WaitKey(0);  //Wait for the key pressing event
            CvInvoke.DestroyAllWindows(); //Destroy all windows if key is pressed


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //_cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_alt_tree.xml");


            //using (var imageFrame = capture.QueryFrame().ToImage<Bgr, Byte>())
            //{
            //    if (imageFrame != null)
            //    {
            //        var grayframe = imageFrame.Convert<Gray, byte>();
            //        var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual face detection happens here


            //        foreach (var face in faces)
            //        {
            //            imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them

            //        }
            //    }
            //    //imgCamUser.Image = imageFrame;
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var main_image = CvInvoke.Imread(@"W:\projects\JOB\WoodSortA\WoodSort\Test_001\resource\cards\main_image\cards.JPG");
            //var main_image = CvInvoke.Imread(@"W:\projects\JOB\WoodSortA\WoodSort\Test_001\resource\barrels\main_image\opencv_barrels_one.jpg");
            Mat gray_image = new Mat();
            CvInvoke.CvtColor(main_image, gray_image, ColorConversion.Bgr2Gray);

            var contours = findContoursOfCards(gray_image);
            var cardsLocation = findCoordinatesOfCards(contours, main_image);

            drawRectangleAroundCards(cardsLocation, main_image);
        }

        private void showImage(Mat img)
        {
            CvInvoke.Imshow("Cards Image", img);
            CvInvoke.WaitKey(0);
        }


        private Emgu.CV.Util.VectorOfVectorOfPoint findContoursOfCards(Mat imgGrayscale) {
            Mat imgBlurred = new Mat();
            CvInvoke.GaussianBlur(imgGrayscale, imgBlurred, new Size(3, 3), 0);

            Mat imgThresh = new Mat();

            CvInvoke.Threshold(imgBlurred, imgThresh, 215, 255, ThresholdType.Binary);
            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();

            Mat hierarchy = new Mat();
            CvInvoke.FindContours(imgThresh, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);
           
            return contours;
        }

        private Dictionary<string, List<int>> findCoordinatesOfCards(Emgu.CV.Util.VectorOfVectorOfPoint contours, Mat image)
        {
            var cardsCoordinates = new Dictionary<string,List<int>>();
            for (int i = 0; i < contours.Size; i++)
            {
                var rect = CvInvoke.BoundingRectangle(contours[i]);

                if (rect.Width > 20 || rect.Height > 30)
                {
                    var cropRect = new Rectangle(rect.X - 15, rect.Y - 15, rect.Width + 15, rect.Height + 15);
                    //var cropRect = new Rectangle(rect.X, rect.Y, rect.Width + 15, rect.Height + 15);

                    Mat imgCrop = new Mat(image.Clone(), cropRect); // here is cropper image

                    String cardsName = findFeatures(imgCrop);
                    if (cardsName.Equals(""))
                    {
                        continue;
                    }
                    
                    var coords = new List<int>();
                    coords.Add(rect.X - 15);
                    coords.Add(rect.Y - 15);
                    coords.Add(rect.Width + 15);
                    coords.Add(rect.Height + 15);
                    cardsCoordinates.TryAdd(cardsName, coords);
                    if (cardsCoordinates.ContainsKey(cardsName))
                    {
                        cardsCoordinates[cardsName] = coords;
                    }
                }
            }
            return cardsCoordinates;
        }

        private String findFeatures(Mat img1)
        {
            string directory = @"W:\projects\JOB\WoodSortA\WoodSort\Test_001\resource\cards\sample\";
            //string directory = @"W:\projects\JOB\WoodSortA\WoodSort\Test_001\resource\barrels\sample\";
            var filePaths = Directory.GetFiles(directory, "*.*");
            Dictionary<string, int> correctMatchesDic = new Dictionary<string,int>();

            foreach (string path in filePaths)
            {
                var img2 = CvInvoke.Imread(path);

                ORB orb = new ORB();

                Mat des1 = new Mat();
                Mat des2 = new Mat();
                VectorOfKeyPoint kp1 = new VectorOfKeyPoint();
                VectorOfKeyPoint kp2 = new VectorOfKeyPoint();

                orb.DetectAndCompute(img1, null, kp1, des1, false);
                orb.DetectAndCompute(img2, null, kp2, des2, false);

                BFMatcher bf = new BFMatcher(DistanceType.L2);
                VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch();
                bf.KnnMatch(des1, des2, matches, 2);
                List<double> correctMatches = new List<double>();
                for (int i = 0; i < matches.Size; i++)
                {
                    VectorOfDMatch vector = matches[i];
                    if (vector[0].Distance < 0.75 * vector[1].Distance)
                    {
                        correctMatches.Add(vector[0].Distance);
                        String strKey = path.Split("\\").Last().Split(".")[0];
                        correctMatchesDic.TryAdd(strKey, correctMatches.Count);
                        if (correctMatchesDic.ContainsKey(strKey))
                        {
                            correctMatchesDic[strKey] = correctMatches.Count;
                        }
                    }
                }
                

            }
            correctMatchesDic = correctMatchesDic.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            return correctMatchesDic.ToList()[0].ToString();
        }

        private void drawRectangleAroundCards(Dictionary<string, List<int>>  cardsCoodinates, Mat image)
        {
            foreach (var (key,value) in cardsCoodinates)
            {
                string str = key.Split(",")[0].Replace("[","").Replace("]","");
                var rect = new Rectangle(value[0], value[1], value[2], value[3]);
                CvInvoke.Rectangle(image, rect, new MCvScalar(255, 255, 0), 2);
                CvInvoke.PutText(image, str, new Point(rect.X, rect.Y - 10), FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255),2);
            }

            CvInvoke.Imshow("Cards Image", image);
            CvInvoke.WaitKey(0);
        }

    }
}