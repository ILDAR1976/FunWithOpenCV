using Emgu.CV.CvEnum;
using Emgu.CV;
using SpecialScanner.Model;

namespace SpecialScanner.UI
{
    public partial class ScannerForm : Form
    {
        private delegate void DisplayImageDelegate(Bitmap Image);
        private Emgu.CV.VideoCapture _capture = null;
        private bool _captureInProgress = false;
        private int CameraDevice = 0;
        private IScannerToolsGeneral _scannerTools = new ScannerToolsRelease(true);
        private Mat current_image = null;

        public ScannerForm()
        {
            InitializeComponent();

        }

        private void btnCameraСapture_Click(object sender, EventArgs e)
        {
            btnPictureCapture.Enabled = false;
            btnVideoСapture.Enabled = false;

            try
            {
                if (_capture != null)
                {
                    SetupCapture(Settings.Instance.CameraIndex);
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

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetupCapture(int Camera_Identifier)
        {
            try
            {
                CameraDevice = Camera_Identifier;
                if (_capture != null) _capture.Dispose();
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
            try
            {
                if (_capture != null) _capture.Dispose();
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

            int total = 0;

            if (!ret)
            {
                try
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

                    _capture.Dispose();
                    _captureInProgress = false;

                } catch ( Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (enableScannerBox.Checked)
            {
                Mat gray_image = new Mat();
                CvInvoke.CvtColor(out_image, gray_image, ColorConversion.Bgr2Gray);

                var contours = _scannerTools.findContoursOfObjects(gray_image);
                var objectLocation = _scannerTools.findCoordinatesOfObjects(contours, out_image);

                _scannerTools.drawRectangleAroundObjects(objectLocation, out_image);

            }

            if (enableDrawContoursBox.Checked && !enableScannerBox.Checked)
            {
                _scannerTools.WatchContours(out_image, ref total, true);
            }

            viewTotalContours.Invoke((Action)delegate
            {
                viewTotalContours.Text = "Количество найденных контуров: " + total.ToString();
            });

            CvInvoke.Resize(out_image, out_image, new Size(captureBox.Width, captureBox.Height));

            current_image = out_image;

            Bitmap frame = out_image.ToBitmap();

            DisplayImage(frame);


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

        private void btnPictureCapture_Click(object sender, EventArgs e)
        {
            btnCameraСapture.Enabled = false;
            btnVideoСapture.Enabled = false;

            var main_image = CvInvoke.Imread(Settings.Instance.SourceFolderPathForBarrels);
            Mat gray_image = new Mat();
            CvInvoke.CvtColor(main_image, gray_image, ColorConversion.Bgr2Gray);

            var contours = _scannerTools.findContoursOfObjects(gray_image);
            var objectLocation = _scannerTools.findCoordinatesOfObjects(contours, main_image);

            int total = 0;

            if (enableDrawContoursBox.Checked && !enableScannerBox.Checked)
            {
                _scannerTools.WatchContours(main_image, ref total);
            }

            viewTotalContours.Invoke((Action)delegate
            {
                viewTotalContours.Text = "Количество найденных контуров: " + total.ToString();
            });

            _scannerTools.drawRectangleAroundObjects(objectLocation, main_image);

            CvInvoke.Resize(main_image, main_image, new Size(571, 512));

            Bitmap image = main_image.ToBitmap();

            DisplayImage(image);

            btnCameraСapture.Enabled = true;
            btnVideoСapture.Enabled = true;

        }

        private void btnVideoСapture_Click(object sender, EventArgs e)
        {
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
                    SetupCapture(Settings.Instance.SourceFolderPathVideoForBarrels);

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
                SetupCapture(Settings.Instance.SourceFolderPathVideoForBarrels);
                //Be lazy and Recall this method to start camera
                btnVideoСapture_Click(null, null);
            }
        }

        private void ScannerForm_Paint(object sender, PaintEventArgs e)
        {
            if (current_image != null)
            {
                CvInvoke.Resize(current_image, current_image, new Size(captureBox.Width, captureBox.Height));
                Bitmap image = current_image.ToBitmap();
                DisplayImage(image);
            }
        }
    }
}
