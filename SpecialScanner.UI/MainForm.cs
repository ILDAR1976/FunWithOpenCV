using SpecialScanner.Model;
using System;

namespace SpecialScanner.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void openSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getFormByName("SettingsFrom") == null)
            {
                SettingsFrom form = new SettingsFrom();
                form.Name = "Настройки";
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
            if (getFormByName("SettingsFrom") == null)
                this.openSettingsToolStripMenuItem.Enabled = true;
            else
                this.openSettingsToolStripMenuItem.Enabled = false;

            if (getFormByName("ScannerFrom") == null)
                this.openScannerToolStripMenuItem.Enabled = true;
            else
                this.openScannerToolStripMenuItem.Enabled = false;


        }

        private void openScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getFormByName("ScannerFrom") == null)
            {
                ScannerForm form = new ScannerForm();
                form.Name = "Сканер";
                form.MdiParent = this;
                form.Show();
                this.openScannerToolStripMenuItem.Enabled = false;
            }
        }
    }
}
