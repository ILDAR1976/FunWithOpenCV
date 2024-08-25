namespace SpecialScanner.UI
{
    partial class SettingsForm
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
            sourceFolderPathField = new TextBox();
            label1 = new Label();
            samplesFolderPathField = new TextBox();
            label2 = new Label();
            sourceFolderPathButton = new Button();
            samplesFolderPathButton = new Button();
            openFileDialogSource = new OpenFileDialog();
            folderBrowserDialogSample = new FolderBrowserDialog();
            Camera_Selection = new ComboBox();
            label3 = new Label();
            label5 = new Label();
            sourceFolderPathVideoField = new TextBox();
            sourceFolderPathVideoButton = new Button();
            SuspendLayout();
            // 
            // sourceFolderPathField
            // 
            sourceFolderPathField.Location = new Point(231, 12);
            sourceFolderPathField.Name = "sourceFolderPathField";
            sourceFolderPathField.Size = new Size(497, 23);
            sourceFolderPathField.TabIndex = 0;
            sourceFolderPathField.TextChanged += sourceFolderPathField_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(214, 15);
            label1.TabIndex = 1;
            label1.Text = "Путь  к файлу изображения объектов";
            // 
            // samplesFolderPathField
            // 
            samplesFolderPathField.Location = new Point(238, 62);
            samplesFolderPathField.Name = "samplesFolderPathField";
            samplesFolderPathField.Size = new Size(497, 23);
            samplesFolderPathField.TabIndex = 2;
            samplesFolderPathField.TextChanged += samplesFolderPathField_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 65);
            label2.Name = "label2";
            label2.Size = new Size(222, 15);
            label2.TabIndex = 3;
            label2.Text = "Путь к файлам изображений образцов";
            // 
            // sourceFolderPathButton
            // 
            sourceFolderPathButton.Location = new Point(724, 11);
            sourceFolderPathButton.Name = "sourceFolderPathButton";
            sourceFolderPathButton.Size = new Size(25, 23);
            sourceFolderPathButton.TabIndex = 4;
            sourceFolderPathButton.Text = "...";
            sourceFolderPathButton.UseVisualStyleBackColor = true;
            sourceFolderPathButton.Click += sourceFolderPathButton_Click;
            // 
            // samplesFolderPathButton
            // 
            samplesFolderPathButton.Location = new Point(734, 62);
            samplesFolderPathButton.Name = "samplesFolderPathButton";
            samplesFolderPathButton.Size = new Size(25, 23);
            samplesFolderPathButton.TabIndex = 5;
            samplesFolderPathButton.Text = "...";
            samplesFolderPathButton.UseVisualStyleBackColor = true;
            samplesFolderPathButton.Click += samplesFolderPathButton_Click;
            // 
            // openFileDialogSource
            // 
            openFileDialogSource.FileName = "openFileDialog1";
            // 
            // Camera_Selection
            // 
            Camera_Selection.FormattingEnabled = true;
            Camera_Selection.Location = new Point(74, 106);
            Camera_Selection.Name = "Camera_Selection";
            Camera_Selection.Size = new Size(497, 23);
            Camera_Selection.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 109);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 7;
            label3.Text = "Камеры";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 38);
            label5.Name = "label5";
            label5.Size = new Size(243, 15);
            label5.TabIndex = 9;
            label5.Text = "Путь к видеофайлу изображения объектов";
            // 
            // sourceFolderPathVideoField
            // 
            sourceFolderPathVideoField.Location = new Point(257, 37);
            sourceFolderPathVideoField.Name = "sourceFolderPathVideoField";
            sourceFolderPathVideoField.Size = new Size(478, 23);
            sourceFolderPathVideoField.TabIndex = 10;
            sourceFolderPathVideoField.TextChanged += sourceFolderPathVideoField_TextChanged;
            // 
            // sourceFolderPathVideoButton
            // 
            sourceFolderPathVideoButton.Location = new Point(734, 38);
            sourceFolderPathVideoButton.Name = "sourceFolderPathVideoButton";
            sourceFolderPathVideoButton.Size = new Size(25, 23);
            sourceFolderPathVideoButton.TabIndex = 11;
            sourceFolderPathVideoButton.Text = "...";
            sourceFolderPathVideoButton.UseVisualStyleBackColor = true;
            sourceFolderPathVideoButton.Click += sourceFolderPathVideoButton_Click;
            // 
            // SettingsFrom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(sourceFolderPathVideoButton);
            Controls.Add(sourceFolderPathVideoField);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(Camera_Selection);
            Controls.Add(samplesFolderPathButton);
            Controls.Add(sourceFolderPathButton);
            Controls.Add(label2);
            Controls.Add(samplesFolderPathField);
            Controls.Add(label1);
            Controls.Add(sourceFolderPathField);
            Name = "SettingsFrom";
            Text = "Settings";
            FormClosing += SettingsFrom_FormClosing;
            Load += SettingsFrom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox sourceFolderPathField;
        private Label label1;
        private TextBox samplesFolderPathField;
        private Label label2;
        private Button sourceFolderPathButton;
        private Button samplesFolderPathButton;
        private OpenFileDialog openFileDialogSource;
        private FolderBrowserDialog folderBrowserDialogSample;
        private ComboBox Camera_Selection;
        private Label label3;
        private Label label5;
        private TextBox sourceFolderPathVideoField;
        private Button sourceFolderPathVideoButton;
    }
}