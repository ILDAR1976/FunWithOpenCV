using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using SpecialScanner.Model;
using Emgu.CV.CvEnum;

namespace SpecialScanner.UI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsTools.SaveJson();
        }

        private void sourceFolderPathField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.SourceFolderPathForBarrels = sourceFolderPathFieldForBarrels.Text;
        }

        private void samplesFolderPathField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.SamplesFolderPathForBarrels = samplesFolderPathFieldForBarrels.Text;
        }

        private void sourceFolderPathButton_Click(object sender, EventArgs e)
        {
            openFileDialogSource.Filter = "Text files (*.jpg)|*.jpg";
            openFileDialogSource.Title = "Открыть .jpg файлы";
            if (openFileDialogSource.ShowDialog() == DialogResult.OK)
            {
                sourceFolderPathFieldForBarrels.Text = openFileDialogSource.FileName;
            }
        }

        private void samplesFolderPathButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogSample.ShowDialog() == DialogResult.OK)
            {
                samplesFolderPathFieldForBarrels.Text = folderBrowserDialogSample.SelectedPath.ToString();
            }
        }

        private void SettingsFrom_Load(object sender, EventArgs e)
        {

            var BarrelRetrType = (int)Settings.Instance.BarrelRetrType;
            var BoardRetrType = (int)Settings.Instance.BoardRetrType;

            comboBarrelRetrType.DataSource = Enum.GetValues(typeof(RetrType));
            comboBoardRetrType.DataSource = Enum.GetValues(typeof(RetrType));

            Settings.Instance.BarrelRetrType = (RetrType)BarrelRetrType;
            Settings.Instance.BoardRetrType = (RetrType)BoardRetrType;


            sourceFolderPathFieldForBarrels.Text = Settings.Instance.SourceFolderPathForBarrels;
            sourceFolderPathVideoFieldForBarrels.Text = Settings.Instance.SourceFolderPathVideoForBarrels;
            samplesFolderPathFieldForBarrels.Text = Settings.Instance.SamplesFolderPathForBarrels;
            sourceFolderPathFieldForBoards.Text = Settings.Instance.SourceFolderPathForBoards;
            addressField.Text = Settings.Instance.Address;
            portField.Text = Settings.Instance.Port;

            for (int i = 0; i < Settings.Instance.WebCams.Length; i++)
            {
                Settings.Instance.WebCams[i] = Settings.Instance.WebCams[i];
                Camera_Selection.Items.Add(Settings.Instance.WebCams[i]);
            }

            Camera_Selection.SelectedIndex = Settings.Instance.WebCameraIndex;

            blurBarrelXField.Text = Settings.Instance.BarrelBlurSizeX.ToString();
            blurBarrelYField.Text = Settings.Instance.BarrelBlurSizeY.ToString();
            elementBarrelXField.Text = Settings.Instance.BarrelElementSizeX.ToString();
            elementBarrelYField.Text = Settings.Instance.BarrelElementSizeY.ToString();
            cannyBarrelXField.Text = Settings.Instance.BarrelCannyX.ToString();
            cannyBarrelYField.Text = Settings.Instance.BarrelCannyY.ToString();


            blurBoardXField.Text = Settings.Instance.BoardBlurSizeX.ToString();
            blurBoardYField.Text = Settings.Instance.BoardBlurSizeY.ToString();
            elementBoardXField.Text = Settings.Instance.BoardElementSizeX.ToString();
            elementBoardYField.Text = Settings.Instance.BoardElementSizeY.ToString();
            cannyBoardXField.Text = Settings.Instance.BoardCannyX.ToString();
            cannyBoardYField.Text = Settings.Instance.BoardCannyY.ToString();

            comboBarrelRetrType.SelectedIndex = (int)Settings.Instance.BarrelRetrType;
            comboBoardRetrType.SelectedIndex = (int)Settings.Instance.BoardRetrType;

        }

        private void sourceFolderPathVideoField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.SourceFolderPathVideoForBarrels = sourceFolderPathVideoFieldForBarrels.Text;
        }

        private void sourceFolderPathVideoButton_Click(object sender, EventArgs e)
        {
            openFileDialogSource.Filter = "Text files (*.mp4)|*.mp4";
            openFileDialogSource.Title = "Открыть .mp4 файлы";
            if (openFileDialogSource.ShowDialog() == DialogResult.OK)
            {
                sourceFolderPathVideoFieldForBarrels.Text = openFileDialogSource.FileName;
            }
        }

        private void sourceFolderPathButtonForBoards_Click(object sender, EventArgs e)
        {
            openFileDialogSource.Filter = "Text files (*.jpg)|*.jpg";
            openFileDialogSource.Title = "Открыть .jpg файлы";
            if (openFileDialogSource.ShowDialog() == DialogResult.OK)
            {
                sourceFolderPathFieldForBoards.Text = openFileDialogSource.FileName;
            }
        }

        private void sourceFolderPathFieldForBoards_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.SourceFolderPathForBoards = sourceFolderPathFieldForBoards.Text;
        }

        private void addressField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.Address = addressField.Text;
        }

        private void portField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.Port = portField.Text;
        }

        private void blurBarrelXField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.BarrelBlurSizeX = int.Parse(blurBarrelXField.Text);
        }

        private void blurBarrelYField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.BarrelBlurSizeY = int.Parse(blurBarrelYField.Text);
        }

        private void elementBarrelXField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.BarrelElementSizeX = int.Parse(elementBarrelXField.Text);
        }

        private void elementBarrelYField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.BarrelElementSizeY = int.Parse(elementBarrelYField.Text);
        }

        private void cannyBarrelXField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.BarrelCannyX = int.Parse(cannyBarrelXField.Text);
        }

        private void cannyBarrelYField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.BarrelCannyY = int.Parse(cannyBarrelYField.Text);
        }

        private void comboBarrelRetrType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Instance.BarrelRetrType = (RetrType)comboBarrelRetrType.SelectedIndex;
        }

        private void blurBoardXField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.BoardBlurSizeX = int.Parse(blurBarrelXField.Text);
        }

        private void blurBoardYField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.BoardBlurSizeY = int.Parse(blurBarrelYField.Text);
        }

        private void elementBoardXField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.BoardElementSizeX = int.Parse(elementBoardXField.Text);
        }

        private void elementBoardYField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.BoardElementSizeY = int.Parse(elementBoardYField.Text);
        }

        private void cannyBoardXField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.BoardCannyX = int.Parse(cannyBoardXField.Text);
        }

        private void cannyBoardYField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.BoardCannyY = int.Parse(cannyBoardYField.Text);
        }

        private void comboBoardRetrType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Instance.BoardRetrType = (RetrType)comboBoardRetrType.SelectedIndex;
        }
    }
}

