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
            LoadJson();
        }

        private void SaveJson()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Settings));

            using (var file = new FileStream("settings.json", FileMode.Create))
            {
                jsonFormatter.WriteObject(file, Settings.Instance);
            }

        }

        private void LoadJson()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Settings));

            if (!File.Exists("settings.json"))
            {
                SaveJson();
            }

            using (var file = new FileStream("settings.json", FileMode.OpenOrCreate))
            {
                var settings = jsonFormatter.ReadObject(file);
                Settings.Instance.SourceFolderPath = ((Settings)settings).SourceFolderPath;
                Settings.Instance.SamplesFolderPath = ((Settings)settings).SamplesFolderPath;

                sourceFolderPathField.Text = Settings.Instance.SourceFolderPath;
                samplesFolderPathField.Text = Settings.Instance.SamplesFolderPath;

                foreach (var camera in ((Settings)settings).Cameras)
                {
                    Settings.Instance.Cameras.Add(camera);
                    Camera_Selection.Items.Add(camera.ToString());
                }

                if (Settings.Instance.Cameras.Count > 0)
                {
                    Camera_Selection.SelectedIndex = 0;
                }
            }
        }
        private void SettingsFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveJson();
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
            openFileDialogSource.Title = "Open .jpg file";
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
    }
}

