namespace Test_002
{
    partial class Form1
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
            button1 = new Button();
            button2 = new Button();
            Camera_Selection = new ComboBox();
            captureBox = new PictureBox();
            richTextBox1 = new RichTextBox();
            RetrieveGrayFrame = new CheckBox();
            RetrieveBgrFrame = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)captureBox).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 23);
            button1.Name = "button1";
            button1.Size = new Size(347, 23);
            button1.TabIndex = 0;
            button1.Text = "Распознавание бочек";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(15, 77);
            button2.Name = "button2";
            button2.Size = new Size(344, 23);
            button2.TabIndex = 2;
            button2.Text = "Запуск камеры";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Camera_Selection
            // 
            Camera_Selection.FormattingEnabled = true;
            Camera_Selection.Location = new Point(16, 132);
            Camera_Selection.Name = "Camera_Selection";
            Camera_Selection.Size = new Size(343, 23);
            Camera_Selection.TabIndex = 3;
            // 
            // captureBox
            // 
            captureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            captureBox.Location = new Point(382, 23);
            captureBox.Name = "captureBox";
            captureBox.Size = new Size(406, 415);
            captureBox.TabIndex = 4;
            captureBox.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(16, 206);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(343, 232);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            // 
            // RetrieveGrayFrame
            // 
            RetrieveGrayFrame.AutoSize = true;
            RetrieveGrayFrame.Location = new Point(18, 165);
            RetrieveGrayFrame.Name = "RetrieveGrayFrame";
            RetrieveGrayFrame.Size = new Size(125, 19);
            RetrieveGrayFrame.TabIndex = 6;
            RetrieveGrayFrame.Text = "RetrieveGrayFrame";
            RetrieveGrayFrame.UseVisualStyleBackColor = true;
            // 
            // RetrieveBgrFrame
            // 
            RetrieveBgrFrame.AutoSize = true;
            RetrieveBgrFrame.Location = new Point(18, 181);
            RetrieveBgrFrame.Name = "RetrieveBgrFrame";
            RetrieveBgrFrame.Size = new Size(119, 19);
            RetrieveBgrFrame.TabIndex = 7;
            RetrieveBgrFrame.Text = "RetrieveBgrFrame";
            RetrieveBgrFrame.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RetrieveBgrFrame);
            Controls.Add(RetrieveGrayFrame);
            Controls.Add(richTextBox1);
            Controls.Add(captureBox);
            Controls.Add(Camera_Selection);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "OpenCV";
            ((System.ComponentModel.ISupportInitialize)captureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private ComboBox Camera_Selection;
        private PictureBox captureBox;
        private RichTextBox richTextBox1;
        private CheckBox RetrieveGrayFrame;
        private CheckBox RetrieveBgrFrame;
    }
}
