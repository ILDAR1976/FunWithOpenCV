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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Instance.SaveJson();
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
            sourceFolderPathFieldForBarrels.Text = Settings.Instance.SourceFolderPathForBarrels;
            sourceFolderPathVideoFieldForBarrels.Text = Settings.Instance.SourceFolderPathVideoForBarrels;
            samplesFolderPathFieldForBarrels.Text = Settings.Instance.SamplesFolderPathForBarrels;
            sourceFolderPathFieldForBoards.Text = Settings.Instance.SourceFolderPathForBoards;

            for (int i = 0; i < Settings.Instance.WebCams.Length; i++)
            {
                Settings.Instance.WebCams[i] = Settings.Instance.WebCams[i];
                Camera_Selection.Items.Add(Settings.Instance.WebCams[i]);
            }

            Camera_Selection.SelectedIndex = Settings.Instance.WebCameraIndex;
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
    }
}

