namespace SpecialScanner.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainMenu = new MenuStrip();
            mainJobToolStripMenuItem = new ToolStripMenuItem();
            openScannerToolStripMenuItem = new ToolStripMenuItem();
            openScannerBarrelsToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            openSettingsToolStripMenuItem = new ToolStripMenuItem();
            MainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenu
            // 
            MainMenu.Items.AddRange(new ToolStripItem[] { mainJobToolStripMenuItem, settingsToolStripMenuItem });
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Size = new Size(1221, 24);
            MainMenu.TabIndex = 0;
            MainMenu.Text = "menuStrip1";
            MainMenu.Paint += MainMenu_Paint;
            // 
            // mainJobToolStripMenuItem
            // 
            mainJobToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openScannerToolStripMenuItem, openScannerBarrelsToolStripMenuItem });
            mainJobToolStripMenuItem.Name = "mainJobToolStripMenuItem";
            mainJobToolStripMenuItem.Size = new Size(57, 20);
            mainJobToolStripMenuItem.Text = "Работа";
            // 
            // openScannerToolStripMenuItem
            // 
            openScannerToolStripMenuItem.Name = "openScannerToolStripMenuItem";
            openScannerToolStripMenuItem.Size = new Size(182, 22);
            openScannerToolStripMenuItem.Text = "Сканировать";
            openScannerToolStripMenuItem.Click += openScannerToolStripMenuItem_Click;
            // 
            // openScannerBarrelsToolStripMenuItem
            // 
            openScannerBarrelsToolStripMenuItem.Name = "openScannerBarrelsToolStripMenuItem";
            openScannerBarrelsToolStripMenuItem.Size = new Size(182, 22);
            openScannerBarrelsToolStripMenuItem.Text = "Сканировать бочки";
            openScannerBarrelsToolStripMenuItem.Click += openScannerBarrelsToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openSettingsToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(79, 20);
            settingsToolStripMenuItem.Text = "Настройки";
            // 
            // openSettingsToolStripMenuItem
            // 
            openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            openSettingsToolStripMenuItem.Size = new Size(180, 22);
            openSettingsToolStripMenuItem.Text = "Открыть";
            openSettingsToolStripMenuItem.Click += openSettingsToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1221, 546);
            Controls.Add(MainMenu);
            IsMdiContainer = true;
            MainMenuStrip = MainMenu;
            Name = "MainForm";
            Text = "Scanner";
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MainMenu;
        private ToolStripMenuItem mainJobToolStripMenuItem;
        private ToolStripMenuItem openScannerToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem openSettingsToolStripMenuItem;
        private ToolStripMenuItem openScannerBarrelsToolStripMenuItem;
    }
}
