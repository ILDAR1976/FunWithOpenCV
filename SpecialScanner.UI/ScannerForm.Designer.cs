namespace SpecialScanner.UI
{
    partial class ScannerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            captureBox = new PictureBox();
            btnCameraСapture = new Button();
            groupVideoCupture = new GroupBox();
            btnVideoСapture = new Button();
            lstProcessReport = new RichTextBox();
            groupPictureCapture = new GroupBox();
            btnPictureCapture = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)captureBox).BeginInit();
            groupVideoCupture.SuspendLayout();
            groupPictureCapture.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(captureBox);
            panel1.Location = new Point(597, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(579, 520);
            panel1.TabIndex = 0;
            // 
            // captureBox
            // 
            captureBox.Location = new Point(3, 3);
            captureBox.Name = "captureBox";
            captureBox.Size = new Size(571, 512);
            captureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            captureBox.TabIndex = 0;
            captureBox.TabStop = false;
            // 
            // btnCameraСapture
            // 
            btnCameraСapture.Location = new Point(6, 22);
            btnCameraСapture.Name = "btnCameraСapture";
            btnCameraСapture.Size = new Size(331, 23);
            btnCameraСapture.TabIndex = 1;
            btnCameraСapture.Text = "Сканирование видео с камеры - Запуск";
            btnCameraСapture.UseVisualStyleBackColor = true;
            btnCameraСapture.Click += btnCameraСapture_Click;
            // 
            // groupVideoCupture
            // 
            groupVideoCupture.Controls.Add(btnVideoСapture);
            groupVideoCupture.Controls.Add(lstProcessReport);
            groupVideoCupture.Controls.Add(btnCameraСapture);
            groupVideoCupture.Location = new Point(12, 12);
            groupVideoCupture.Name = "groupVideoCupture";
            groupVideoCupture.Size = new Size(579, 259);
            groupVideoCupture.TabIndex = 2;
            groupVideoCupture.TabStop = false;
            groupVideoCupture.Text = "Сканирование видео";
            // 
            // btnVideoСapture
            // 
            btnVideoСapture.Location = new Point(6, 49);
            btnVideoСapture.Name = "btnVideoСapture";
            btnVideoСapture.Size = new Size(331, 23);
            btnVideoСapture.TabIndex = 3;
            btnVideoСapture.Text = "Сканирование видео из файла - Запуск";
            btnVideoСapture.UseVisualStyleBackColor = true;
            btnVideoСapture.Click += btnVideoСapture_Click;
            // 
            // lstProcessReport
            // 
            lstProcessReport.Location = new Point(347, 17);
            lstProcessReport.Name = "lstProcessReport";
            lstProcessReport.Size = new Size(226, 236);
            lstProcessReport.TabIndex = 2;
            lstProcessReport.Text = "";
            // 
            // groupPictureCapture
            // 
            groupPictureCapture.Controls.Add(btnPictureCapture);
            groupPictureCapture.Location = new Point(12, 273);
            groupPictureCapture.Name = "groupPictureCapture";
            groupPictureCapture.Size = new Size(579, 259);
            groupPictureCapture.TabIndex = 3;
            groupPictureCapture.TabStop = false;
            groupPictureCapture.Text = "Сканирование изображений";
            // 
            // btnPictureCapture
            // 
            btnPictureCapture.Location = new Point(6, 22);
            btnPictureCapture.Name = "btnPictureCapture";
            btnPictureCapture.Size = new Size(331, 23);
            btnPictureCapture.TabIndex = 1;
            btnPictureCapture.Text = "Сканирование изображений";
            btnPictureCapture.UseVisualStyleBackColor = true;
            btnPictureCapture.Click += btnPictureCapture_Click;
            // 
            // ScannerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1188, 544);
            Controls.Add(groupPictureCapture);
            Controls.Add(groupVideoCupture);
            Controls.Add(panel1);
            Name = "ScannerForm";
            Text = "ScannerForm";
            Load += ScannerForm_Load;
            Paint += ScannerForm_Paint;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)captureBox).EndInit();
            groupVideoCupture.ResumeLayout(false);
            groupPictureCapture.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox captureBox;
        private Button btnCameraСapture;
        private GroupBox groupVideoCupture;
        private GroupBox groupPictureCapture;
        private Button btnPictureCapture;
        private RichTextBox lstProcessReport;
        private Button btnVideoСapture;
    }
}