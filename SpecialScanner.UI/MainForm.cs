using SpecialScanner.Model;
using System;

namespace SpecialScanner.UI
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            InitializeCustomerSettings();
        }

        private void InitializeCustomerSettings()
        {
            for (int i = 0; i < Settings.Instance._SystemCameras.Length; i++)
            {
                Settings.Instance.WebCams[i] = new Video_Device(i,
                    Settings.Instance._SystemCameras[i].Name,
                    Settings.Instance._SystemCameras[i].ClassID);
            }

            if (!File.Exists(Settings.Instance.SETTINGS_FILE_PATH))
            {
                Settings.Instance.SaveJson();
            }

            Settings.Instance.LoadJson();

        }

        private void openSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getFormByName("SettingsFrom") == null)
            {

                SettingsForm form = new SettingsForm();
                form.Name = "SettingsForm";
                form.Text = "Настройки";
                form.MdiParent = this;
                form.Show();
                this.openSettingsToolStripMenuItem.Enabled = false;
            }

        }

        private Form getFormByName(string formName)
        {
            foreach (Form itemForm in this.MdiChildren)
            {
                if (itemForm.Name.Equals(formName)) return itemForm;
            }
            return null;
        }

        private void MainMenu_Paint(object sender, PaintEventArgs e)
        {
            if (getFormByName("SettingsForm") == null)
                this.openSettingsToolStripMenuItem.Enabled = true;
            else
                this.openSettingsToolStripMenuItem.Enabled = false;

            if (getFormByName("ScannerForm") == null)
                this.openScannerToolStripMenuItem.Enabled = true;
            else
                this.openScannerToolStripMenuItem.Enabled = false;

            if (getFormByName("ScannerBarrelsForm") == null)
                this.openScannerBarrelsToolStripMenuItem.Enabled = true;
            else
                this.openScannerBarrelsToolStripMenuItem.Enabled = false;

            if (getFormByName("ScannerBoardsForm") == null)
                this.openScannerBoardsToolStripMenuItem.Enabled = true;
            else
                this.openScannerBoardsToolStripMenuItem.Enabled = false;


        }

        private void openScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getFormByName("ScannerFrom") == null)
            {

                ScannerForm form = new ScannerForm();
                form.Name = "ScannerForm";
                form.Text = "Сканер";
                form.MdiParent = this;
                form.Show();
                this.openScannerToolStripMenuItem.Enabled = false;
            }
        }

        private void openScannerBarrelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getFormByName("ScannerBarrels") == null)
            {
                ScannerBarrels form = new ScannerBarrels();
                form.Name = "ScannerBarrelsForm";
                form.Text = "Сканер бочек";
                form.MdiParent = this;
                form.Show();
                this.openScannerBarrelsToolStripMenuItem.Enabled = false;
            }
        }

        private void openScannerBoardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getFormByName("ScannerBarrels") == null)
            {
                ScannerBoards form = new ScannerBoards();
                form.Name = "ScannerBoardsForm";
                form.Text = "Сканер досок";
                form.MdiParent = this;
                form.Show();
                this.openScannerBoardsToolStripMenuItem.Enabled = false;
            }
        }
    }
}
