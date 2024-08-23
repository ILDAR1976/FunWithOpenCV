using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.CvEnum;
using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
using System.Drawing;
using DirectShowLib;
using SpecialScanner.Model;
using Emgu.CV.Dnn;

namespace SpecialScanner.UI
{
    public partial class ScannerForm : Form
    {
        private delegate void DisplayImageDelegate(Bitmap Image);
        private Emgu.CV.VideoCapture _capture = null;
        private bool _captureInProgress = false;
        private int CameraDevice = 0;

        public ScannerForm()
        {
            InitializeComponent();

        }

        private void btnCameraСapture_Click(object sender, EventArgs e)
        {
            btnPictureCapture.Enabled = false;
            btnVideoСapture.Enabled = false;

            if (_capture != null)
            {
                if (_captureInProgress)
                {
                    btnCameraСapture.Text = "Сканирование с видеокамеры - Запуск"; //Change text on button
                    _capture.Pause(); 
                    _captureInProgress = false; 
                    btnPictureCapture.Enabled = true;
                    btnVideoСapture.Enabled = true;

                }
                else
                {
                    //Check to see if the selected device has changed
                    if (Settings.Instance.CameraIndex != CameraDevice)
                    {
                        SetupCapture(Settings.Instance.CameraIndex); //Setup capture with the new device
                    }

                    RetrieveCaptureInformation(); //Get Camera information
                    btnCameraСapture.Text = "Сканирование с видеокамеры - Стоп"; //Change text on button
                    //StoreCameraSettings(); //Save Camera Settings
                    //Slider_Enable(true);  //Enable User Controls
                    _capture.Start(); //Start the capture
                    _captureInProgress = true; //Flag the state of the camera
                }

            }
            else
            {
                //set up capture with selected device
                SetupCapture(Settings.Instance.CameraIndex);
                //Be lazy and Recall this method to start camera
                btnCameraСapture_Click(null, null);
            }
        }

        private void SetupCapture(int Camera_Identifier)
        {
            CameraDevice = Camera_Identifier;
            if (_capture != null) _capture.Dispose();
            try
            {
                _capture = new Emgu.CV.VideoCapture(CameraDevice);
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void SetupCapture(string Path)
        {

            if (_capture != null) _capture.Dispose();
            try
            {
                _capture = new Emgu.CV.VideoCapture(Path);
                _capture.ImageGrabbed += ProcessFrame;

            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Mat out_image = new Mat();

            bool ret = _capture.Read(out_image);

            if (!ret)
            {

               btnCameraСapture.Invoke((Action)delegate
               {
                   btnCameraСapture.Enabled = true;
                   btnCameraСapture.Text = "Сканирование с видеокамеры - Запуск";
               });

                btnPictureCapture.Invoke((Action)delegate
                {
                    btnPictureCapture.Enabled = true;
                    btnVideoСapture.Text = "Сканирование из видеофайла - Запуск";
                });

                _capture = null;
                _captureInProgress = false;
            }

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
            lstProcessReport.Clear();
            lstProcessReport.AppendText("Camera: " + Settings.Instance.WebCams[CameraDevice].Device_Name + " (-1 = Unknown)\n\n");
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

        private Emgu.CV.Util.VectorOfVectorOfPoint findContoursOfObjects(Mat imgGrayscale)
        {
            Mat imgBlurred = new Mat();
            CvInvoke.GaussianBlur(imgGrayscale, imgBlurred, new Size(3, 3), 0);

            //Mat imgThresh = new Mat();

            //CvInvoke.Threshold(imgBlurred, imgThresh, 215, 255, ThresholdType.Binary);
            //Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();

            //Mat hierarchy = new Mat();
            //CvInvoke.FindContours(imgThresh, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);


            Mat edges = new Mat();
            CvInvoke.Canny(imgBlurred, edges, 10, 250);

            //show(edges);

            Mat kernel = new Mat();
            kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(7, 7), new Point(1, 1));

            //show(kernel);

            Mat closed = new Mat();
            CvInvoke.MorphologyEx(edges, closed, Emgu.CV.CvEnum.MorphOp.Close, kernel, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar());

            //show(closed);

            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
            CvInvoke.FindContours(closed, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);



            return contours;
        }

        private Dictionary<string, List<int>> findCoordinatesOfObjects(Emgu.CV.Util.VectorOfVectorOfPoint contours, Mat image)
        {
            var cardsCoordinates = new Dictionary<string, List<int>>();
            for (int i = 0; i < contours.Size; i++)
            {
                var rect = CvInvoke.BoundingRectangle(contours[i]);

                if (rect.Width > 20 || rect.Height > 30)
                {

                    if (rect.X - 15 < 0 || rect.Y - 15 < 0)
                    {
                        continue;
                    }

                    var cropRect = new Rectangle(rect.X - 15, rect.Y - 15, rect.Width + 15, rect.Height + 15);
                    Mat imgCrop = new Mat(image.Clone(), cropRect);

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
            string directory = Settings.Instance.SamplesFolderPath;

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

        private void show(Mat img)
        {
            CvInvoke.Imshow("Look", img);
            CvInvoke.WaitKey(0);
        }

        private void drawRectangleAroundObjects(Dictionary<string, List<int>> cardsCoodinates, Mat image)
        {
            foreach (var (key, value) in cardsCoodinates)
            {
                string str = key.Split(",")[0].Replace("[", "").Replace("]", "");
                var rect = new Rectangle(value[0], value[1], value[2], value[3]);
                CvInvoke.Rectangle(image, rect, new MCvScalar(255, 255, 0), 2);
                CvInvoke.PutText(image, str, new Point(rect.X, rect.Y - 10), FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
            }

        }

        private void btnPictureCapture_Click(object sender, EventArgs e)
        {
            btnCameraСapture.Enabled = false;
            btnVideoСapture.Enabled = false;

            var main_image = CvInvoke.Imread(Settings.Instance.SourceFolderPath);
            Mat gray_image = new Mat();
            CvInvoke.CvtColor(main_image, gray_image, ColorConversion.Bgr2Gray);

            var contours = findContoursOfObjects(gray_image);
            //CvInvoke.DrawContours(main_image, contours, -1, new MCvScalar(0, 0, 255), 10);
            //show(main_image);
            var cardsLocation = findCoordinatesOfObjects(contours, main_image);

            drawRectangleAroundObjects(cardsLocation, main_image);

            Bitmap image = main_image.ToBitmap();

            DisplayImage(image);

            btnCameraСapture.Enabled = true;
            btnVideoСapture.Enabled = true;

        }

        private void btnVideoСapture_Click(object sender, EventArgs e)
        {

            //var fps = videoCaupture.Get(Emgu.CV.CvEnum.CapProp.Fps);
            //var frameCount = videoCaupture.Get(Emgu.CV.CvEnum.CapProp.FrameCount);
            //var frameWidth = videoCaupture.Get(Emgu.CV.CvEnum.CapProp.FrameWidth);
            //var frameHeight = videoCaupture.Get(Emgu.CV.CvEnum.CapProp.FrameHeight);
            //var frame = new Mat();

            btnCameraСapture.Enabled = false;
            btnPictureCapture.Enabled = false;

            if (_capture != null)
            {
                if (_captureInProgress)
                {
                    //stop the capture
                    btnVideoСapture.Text = "Сканирование из видеофайла - Запуск"; //Change text on button
                    //Slider_Enable(false);
                    _capture.Pause(); //Pause the capture
                    _captureInProgress = false; //Flag the state of the camera
                }
                else
                {
                    SetupCapture(Settings.Instance.SourceFolderPathVideo);

                    btnVideoСapture.Text = "Сканирование из видеофайла - Стоп"; //Change text on button
                    //StoreCameraSettings(); //Save Camera Settings
                    //Slider_Enable(true);  //Enable User Controls
                    _capture.Start(); //Start the capture
                    _captureInProgress = true; //Flag the state of the camera
                }

            }
            else
            {
                //set up capture with selected device
                SetupCapture(Settings.Instance.SourceFolderPathVideo);
                //Be lazy and Recall this method to start camera
                btnVideoСapture_Click(null, null);
            }


        }

    }
}
