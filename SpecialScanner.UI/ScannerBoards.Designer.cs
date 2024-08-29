namespace SpecialScanner.UI
{
    partial class ScannerBoards
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
            jobImage = new PictureBox();
            panel2 = new Panel();
            btnScannerBoard = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)jobImage).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(jobImage);
            panel1.Location = new Point(1, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1041, 417);
            panel1.TabIndex = 0;
            // 
            // jobImage
            // 
            jobImage.Dock = DockStyle.Fill;
            jobImage.Location = new Point(0, 0);
            jobImage.Name = "jobImage";
            jobImage.Size = new Size(1039, 415);
            jobImage.SizeMode = PictureBoxSizeMode.AutoSize;
            jobImage.TabIndex = 0;
            jobImage.TabStop = false;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btnScannerBoard);
            panel2.Location = new Point(1, 427);
            panel2.Name = "panel2";
            panel2.Size = new Size(1041, 119);
            panel2.TabIndex = 1;
            // 
            // btnScannerBoard
            // 
            btnScannerBoard.Location = new Point(11, 14);
            btnScannerBoard.Name = "btnScannerBoard";
            btnScannerBoard.Size = new Size(230, 23);
            btnScannerBoard.TabIndex = 0;
            btnScannerBoard.Text = "Сканировать доску";
            btnScannerBoard.UseVisualStyleBackColor = true;
            btnScannerBoard.Click += btnScannerBoard_Click;
            // 
            // ScannerBoards
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 549);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ScannerBoards";
            Text = "ScannerBoard";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)jobImage).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox jobImage;
        private Button btnScannerBoard;
    }
}