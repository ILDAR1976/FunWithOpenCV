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

namespace SpecialScanner.UI
{
    public partial class ScannerBoards : Form
    {
        private delegate void DisplayImageDelegate(Bitmap Image);
        private Emgu.CV.VideoCapture _capture = null;
        private bool _captureInProgress = false;
        private int CameraDevice = 0;
        private IScannerToolsBoard _scannerTools = new ScannerToolsRelease();
        private Mat current_image = null;
        public ScannerBoards()
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

        private void btnScannerBoard_Click(object sender, EventArgs e)
        {
            Mat main_image = new Mat();
            string message = String.Empty;

            (main_image, message) = _scannerTools.BoardScanner();

            CvInvoke.Resize(main_image, main_image, new Size(jobImage.Width, jobImage.Height));
            Bitmap image = main_image.ToBitmap();

            current_image = main_image;

            DisplayImage(image);

            viewTotalContours.Text = "Количество найденных контуров: " + message;
        }
    }
}
