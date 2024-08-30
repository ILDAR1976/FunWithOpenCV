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
            viewTotalContours = new Label();
            btnScannerBoard = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)jobImage).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(viewTotalContours);
            panel2.Controls.Add(btnScannerBoard);
            panel2.Location = new Point(1, 427);
            panel2.Name = "panel2";
            panel2.Size = new Size(1041, 119);
            panel2.TabIndex = 1;
            // 
            // viewTotalContours
            // 
            viewTotalContours.AutoSize = true;
            viewTotalContours.Location = new Point(278, 16);
            viewTotalContours.Name = "viewTotalContours";
            viewTotalContours.Size = new Size(202, 15);
            viewTotalContours.TabIndex = 1;
            viewTotalContours.Text = "Количество найденных контуров: 0";
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
            Resize += ScannerBoards_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)jobImage).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox jobImage;
        private Button btnScannerBoard;
        private Label viewTotalContours;
    }
}