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
        Video_Device[] WebCams;

        public ScannerForm()
        {
            InitializeComponent();
            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            WebCams = new Video_Device[_SystemCamereas.Length];

            for (int i = 0; i < _SystemCamereas.Length; i++)
            {
                WebCams[i] = new Video_Device(i, _SystemCamereas[i].Name, _SystemCamereas[i].ClassID); //fill web cam array
                Settings.Instance.Cameras.Add(WebCams[i].ToString());
            }

        }
    }
}
