namespace SpecialScanner.UI
{
    partial class ScannerBarrels
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
            panel2 = new Panel();
            viewTotalContours = new Label();
            btnScanning = new Button();
            panel1 = new Panel();
            jobImage = new PictureBox();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)jobImage).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(viewTotalContours);
            panel2.Controls.Add(btnScanning);
            panel2.Location = new Point(12, 301);
            panel2.Name = "panel2";
            panel2.Size = new Size(971, 192);
            panel2.TabIndex = 1;
            // 
            // viewTotalContours
            // 
            viewTotalContours.AutoSize = true;
            viewTotalContours.Location = new Point(14, 46);
            viewTotalContours.Name = "viewTotalContours";
            viewTotalContours.Size = new Size(202, 15);
            viewTotalContours.TabIndex = 1;
            viewTotalContours.Text = "Количество найденных контуров: 0";
            // 
            // btnScanning
            // 
            btnScanning.Location = new Point(14, 9);
            btnScanning.Name = "btnScanning";
            btnScanning.Size = new Size(263, 23);
            btnScanning.TabIndex = 0;
            btnScanning.Text = "Сканирование из видеофайла - Запуск";
            btnScanning.UseVisualStyleBackColor = true;
            btnScanning.Click += btnScanning_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoSize = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(jobImage);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(971, 283);
            panel1.TabIndex = 0;
            // 
            // jobImage
            // 
            jobImage.Dock = DockStyle.Fill;
            jobImage.Location = new Point(0, 0);
            jobImage.Name = "jobImage";
            jobImage.Size = new Size(969, 281);
            jobImage.SizeMode = PictureBoxSizeMode.AutoSize;
            jobImage.TabIndex = 0;
            jobImage.TabStop = false;
            // 
            // ScannerBarrels
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 503);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ScannerBarrels";
            Text = "ScannerBarrels";
            Paint += ScannerBarrels_Paint;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)jobImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel2;
        private Button btnScanning;
        private Label viewTotalContours;
        private Panel panel1;
        private PictureBox jobImage;
    }
}