using Emgu.CV.CvEnum;
using Emgu.CV;
using SpecialScanner.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace SpecialScanner.UI
{
    public partial class ScannerBarrels : Form
    {
        private delegate void DisplayImageDelegate(Bitmap Image);
        private Emgu.CV.VideoCapture _capture = null;
        private bool _captureInProgress = false;
        private int CameraDevice = 0;
        private IScannerToolsBarrel _scannerTools = new ScannerToolsRelease();
        private Mat current_image = null;
        public ScannerBarrels()
        {
            InitializeComponent();
        }
        private void DisplayImage(Bitmap Image)
        {
            if (jobImage.InvokeRequired)
            {
                try
                {
                    DisplayImageDelegate DI = new DisplayImageDelegate(DisplayImage);
                    this.BeginInvoke(DI, new object[] { Image });
                }
                catch (Exception excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            else
            {
                jobImage.Image = Image;
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
            string message = String.Empty;

            bool ret = _capture.Read(out_image);

            (out_image, message) = _scannerTools.BarrelsScannerOnVideo(out_image);

            int total = 0;

            if (!ret)
            {
                _captureInProgress = false;
                btnScanning.Text = "Сканирование из видеофайла - Запуск";
            }

            viewTotalContours.Invoke((Action)delegate
            {
                viewTotalContours.Text = "Количество найденных контуров: " + message;
            });

            CvInvoke.Resize(out_image, out_image, new Size(jobImage.Width, jobImage.Height));

            Bitmap frame = out_image.ToBitmap();

            DisplayImage(frame);


        }
        private void btnScanning_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {
                    //stop the capture
                    btnScanning.Text = "Сканирование из видеофайла - Запуск"; //Change text on button
                    //Slider_Enable(false);
                    _capture.Pause(); //Pause the capture
                    _captureInProgress = false; //Flag the state of the camera
                }
                else
                {
                    SetupCapture(Settings.Instance.SourceFolderPathVideoForBarrels);

                    btnScanning.Text = "Сканирование из видеофайла - Стоп"; //Change text on button
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
                btnScanning_Click(null, null);
            }



        }
        private void ScannerBarrels_Paint(object sender, PaintEventArgs e)
        {
            if (current_image != null)
            {
                CvInvoke.Resize(current_image, current_image, new Size(jobImage.Width, jobImage.Height));
                Bitmap image = current_image.ToBitmap();
                DisplayImage(image);
            }
        }
        
    }
}
