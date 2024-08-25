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
        private IScannerTools _scannerTools = new ScannerToolsRelease();
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
                catch (Exception ex)
                {
                }
            }
            else
            {
                jobImage.Image = Image;
            }
        }

        private void btnScanning_Click(object sender, EventArgs e)
        {
            Mat main_image = new Mat();
            string message = String.Empty;

            main_image = _scannerTools.BarrelsScanner(ref message);

            CvInvoke.Resize(main_image, main_image, new Size(jobImage.Width, jobImage.Height));
            Bitmap image = main_image.ToBitmap();
            
            current_image = main_image;
            
            DisplayImage(image);

            viewTotalContours.Text = "Количество найденных контуров: " + message;
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
