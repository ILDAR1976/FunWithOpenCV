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

namespace SpecialScanner.UI
{
    public partial class SettingsFrom : Form
    {
        public SettingsFrom()
        {
            InitializeComponent();
        }

        private void SettingsFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Instance.SaveJson();
        }

        private void sourceFolderPathField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.SourceFolderPath = sourceFolderPathField.Text;
        }

        private void samplesFolderPathField_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.SamplesFolderPath = samplesFolderPathField.Text;
        }

        private void sourceFolderPathButton_Click(object sender, EventArgs e)
        {
            openFileDialogSource.Filter = "Text files (*.jpg)|*.jpg";
            openFileDialogSource.Title = "Открыть .jpg файлы";
            if (openFileDialogSource.ShowDialog() == DialogResult.OK)
            {
                sourceFolderPathField.Text = openFileDialogSource.FileName;
            }
        }

        private void samplesFolderPathButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogSample.ShowDialog() == DialogResult.OK)
            {
                samplesFolderPathField.Text = folderBrowserDialogSample.SelectedPath.ToString();
            }
        }

        private void SettingsFrom_Load(object sender, EventArgs e)
        {
            sourceFolderPathField.Text = Settings.Instance.SourceFolderPath;
            samplesFolderPathField.Text = Settings.Instance.SamplesFolderPath;

            for (int i = 0; i < Settings.Instance.WebCams.Length; i++)
            {
                Settings.Instance.WebCams[i] = Settings.Instance.WebCams[i];
                Camera_Selection.Items.Add(Settings.Instance.WebCams[i]);
            }

            Camera_Selection.SelectedIndex = Settings.Instance.WebCameraIndex;
        }
    }
}

