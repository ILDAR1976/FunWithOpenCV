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

namespace SpecialScanner.UI
{
    public partial class ScannerForm : Form
    {
        private Emgu.CV.VideoCapture _capture = null;

        public ScannerForm()
        {
            InitializeComponent();

        }

        private void ScannerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
