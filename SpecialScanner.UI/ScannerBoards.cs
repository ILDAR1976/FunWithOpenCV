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
        private IScannerToolsBarrel _scannerTools = new ScannerToolsRelease();
        private Mat current_image = null;
        public ScannerBoards()
        {
            InitializeComponent();
        }

        private void btnScannerBoard_Click(object sender, EventArgs e)
        {

        }
    }
}
