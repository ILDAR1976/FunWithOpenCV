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
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms.VisualStyles;

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
        private bool _dataSendFlag = false;
        IPAddress ipAddress = IPAddress.Parse(Settings.Instance.Address);
        string remotePort = Settings.Instance.Port;
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

        private async void btnScannerBoard_Click(object sender, EventArgs e)
        {
            Mat main_image = new Mat();
            string message = String.Empty;

            (main_image, message) = _scannerTools.BoardScanner();

            CvInvoke.Resize(main_image, main_image, new Size(jobImage.Width, jobImage.Height));

            Bitmap image = main_image.ToBitmap();

            current_image = main_image;

            DisplayImage(image);

            viewTotalContours.Text = "Количество найденных контуров: " + message;

            if (_dataSendFlag)
            {
                await SendMessageAsync(message);
            }
            
        }

        private void ScannerBoards_Resize(object sender, EventArgs e)
        {
            if (current_image != null)
            {
                CvInvoke.Resize(current_image, current_image, new Size(jobImage.Width, jobImage.Height));
                Bitmap image = current_image.ToBitmap();
                DisplayImage(image);
            }
        }

        private void btnDataSend_Click(object sender, EventArgs e)
        {
            if (_dataSendFlag)
            {
                _dataSendFlag = false;
                btnDataSend.Text = "Отправка данных - Выключена";
            } else
            {
                _dataSendFlag = true;
                btnDataSend.Text = "Отправка данных - Включена";
            }
        }

        private async Task SendMessageAsync(string message)
        {
            using Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            var board = new Board();

            board.BoardBrand = "Simple board";
            board.АmountKnots = int.Parse(message);

            byte[] data = BoardTools.DataToJson(board);

            if (ipAddress != null && remotePort != string.Empty)
            {
                await sender.SendToAsync(data, new IPEndPoint(ipAddress, int.Parse(remotePort)));
            }
            
        }
    }
}
