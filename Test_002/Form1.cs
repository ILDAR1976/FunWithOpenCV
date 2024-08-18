using Emgu.CV.CvEnum;
using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using DirectShowLib;

namespace Test_002
{
    public partial class Form1 : Form
    {

        private Emgu.CV.VideoCapture _capture = null; //Camera
        private bool _captureInProgress = false; //Variable to track camera state
        int CameraDevice = 0; //Variable to track camera device selected
        Video_Device[] WebCams; //List containing all the camera available

        int Brightness_Store = 0;
        int Contrast_Store = 0;
        int Sharpness_Store = 0;


        private delegate void DisplayImageDelegate(Bitmap Image);

        public Form1()
        {
            InitializeComponent();

            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            WebCams = new Video_Device[_SystemCamereas.Length];


            for (int i = 0; i < _SystemCamereas.Length; i++)
            {
                WebCams[i] = new Video_Device(i, _SystemCamereas[i].Name, _SystemCamereas[i].ClassID); //fill web cam array
                Camera_Selection.Items.Add(WebCams[i].ToString());
            }
            if (Camera_Selection.Items.Count > 0)
            {
                Camera_Selection.SelectedIndex = 0; //Set the selected device the default
                
            }

        }

        private void DisplayImage(Bitmap Image)
        {
            if (captureBox.InvokeRequired)
            {
                try
                {
                    DisplayImageDelegate DI = new DisplayImageDelegate(DisplayImage);
                    this.BeginInvoke(DI, new object[] { Image });
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                captureBox.Image = Image;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            



            var main_image = CvInvoke.Imread(@"W:\projects\JOB\WoodSortA\WoodSort\Test_001\resource\cards\main_image\cards.JPG");





            //var main_image = CvInvoke.Imread(@"W:\projects\JOB\WoodSortA\WoodSort\Test_001\resource\barrels\main_image\opencv_barrels_one.jpg");
            Mat gray_image = new Mat();
            CvInvoke.CvtColor(main_image, gray_image, ColorConversion.Bgr2Gray);

            var contours = findContoursOfCards(gray_image);
            var cardsLocation = findCoordinatesOfCards(contours, main_image);

            drawRectangleAroundCards(cardsLocation, main_image);


            //showImage(main_image);


            Bitmap image = main_image.ToBitmap();

            DisplayImage(image);
        }

        private void SetupCapture(int Camera_Identifier)
        {
            //update the selected device
            CameraDevice = Camera_Identifier;

            //Dispose of Capture if it was created before
            if (_capture != null) _capture.Dispose();
            try
            {
                //Set up capture device
                _capture = new Emgu.CV.VideoCapture(CameraDevice);
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            //***If you want to access the image data the use the following method call***/
            //Image<Bgr, Byte> frame = new Image<Bgr,byte>(_capture.RetrieveBgrFrame().ToBitmap());
            
            
            Mat out_image = new Mat();
            
            _capture.Read(out_image);

            Bitmap frame = out_image.ToBitmap();
            //if (RetrieveBgrFrame.Checked)
            //{
            //Image<Bgr, Byte> frame = _capture.RetrieveBgrFrame();
            //    //because we are using an autosize picturebox we need to do a thread safe update
            
            DisplayImage(frame);
            //}
            //else if (RetrieveGrayFrame.Checked)
            //{
            //    Image<Gray, Byte> frame = _capture.RetrieveGrayFrame();
            //    //because we are using an autosize picturebox we need to do a thread safe update
            //    DisplayImage(frame.ToBitmap());
            //}
        }



        private void RetrieveCaptureInformation()
        {
            richTextBox1.Clear();
            richTextBox1.AppendText("Camera: " + WebCams[CameraDevice].Device_Name + " (-1 = Unknown)\n\n");




        }


        private void showImage(Mat img)
        {
            CvInvoke.Imshow("Cards Image", img);
            CvInvoke.WaitKey(0);
        }

        private Emgu.CV.Util.VectorOfVectorOfPoint findContoursOfCards(Mat imgGrayscale)
        {
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
            var cardsCoordinates = new Dictionary<string, List<int>>();
            for (int i = 0; i < contours.Size; i++)
            {
                var rect = CvInvoke.BoundingRectangle(contours[i]);

                if (rect.Width > 20 || rect.Height > 30)
                {
                    var cropRect = new Rectangle(rect.X - 15, rect.Y - 15, rect.Width + 15, rect.Height + 15);
                    //var cropRect = new Rectangle(rect.X, rect.Y, rect.Width + 15, rect.Height + 15);

                    Mat imgCrop = new Mat(image.Clone(), cropRect); // here is cropper image

                    //showImage(imgCrop);

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
            Dictionary<string, int> correctMatchesDic = new Dictionary<string, int>();

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

        private void drawRectangleAroundCards(Dictionary<string, List<int>> cardsCoodinates, Mat image)
        {
            foreach (var (key, value) in cardsCoodinates)
            {
                string str = key.Split(",")[0].Replace("[", "").Replace("]", "");
                var rect = new Rectangle(value[0], value[1], value[2], value[3]);
                CvInvoke.Rectangle(image, rect, new MCvScalar(255, 255, 0), 2);
                CvInvoke.PutText(image, str, new Point(rect.X, rect.Y - 10), FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
            }

            //CvInvoke.Imshow("Cards Image", image);
            //CvInvoke.WaitKey(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {
                    //stop the capture
                    //captureButton.Text = "Start Capture"; //Change text on button
                    //Slider_Enable(false);
                    _capture.Pause(); //Pause the capture
                    _captureInProgress = false; //Flag the state of the camera
                }
                else
                {
                    //Check to see if the selected device has changed
                    if (Camera_Selection.SelectedIndex != CameraDevice)
                    {
                        SetupCapture(Camera_Selection.SelectedIndex); //Setup capture with the new device
                    }

                    RetrieveCaptureInformation(); //Get Camera information
                    //captureButton.Text = "Stop"; //Change text on button
                    //StoreCameraSettings(); //Save Camera Settings
                    //Slider_Enable(true);  //Enable User Controls
                    _capture.Start(); //Start the capture
                    _captureInProgress = true; //Flag the state of the camera
                }

            }
            else
            {
                //set up capture with selected device
                SetupCapture(Camera_Selection.SelectedIndex);
                //Be lazy and Recall this method to start camera
                //captureButtonClick(null, null);
            }

        }
    }
}
