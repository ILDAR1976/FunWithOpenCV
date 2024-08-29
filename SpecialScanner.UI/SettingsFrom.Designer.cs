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
            sourceFolderPathFieldForBarrels = new TextBox();
            label1 = new Label();
            samplesFolderPathFieldForBarrels = new TextBox();
            label2 = new Label();
            sourceFolderPathButtonForBarrels = new Button();
            samplesFolderPathButtonForBarrels = new Button();
            openFileDialogSource = new OpenFileDialog();
            folderBrowserDialogSample = new FolderBrowserDialog();
            Camera_Selection = new ComboBox();
            label3 = new Label();
            label5 = new Label();
            sourceFolderPathVideoFieldForBarrels = new TextBox();
            sourceFolderPathVideoButtonForBarrels = new Button();
            sourceFolderPathButtonForBoards = new Button();
            label4 = new Label();
            sourceFolderPathFieldForBoards = new TextBox();
            SuspendLayout();
            // 
            // sourceFolderPathFieldForBarrels
            // 
            sourceFolderPathFieldForBarrels.Location = new Point(303, 13);
            sourceFolderPathFieldForBarrels.Name = "sourceFolderPathFieldForBarrels";
            sourceFolderPathFieldForBarrels.Size = new Size(497, 23);
            sourceFolderPathFieldForBarrels.TabIndex = 0;
            sourceFolderPathFieldForBarrels.TextChanged += sourceFolderPathField_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(269, 15);
            label1.TabIndex = 1;
            label1.Text = "Путь к файлу изображения объектов для бочек";
            // 
            // samplesFolderPathFieldForBarrels
            // 
            samplesFolderPathFieldForBarrels.Location = new Point(310, 63);
            samplesFolderPathFieldForBarrels.Name = "samplesFolderPathFieldForBarrels";
            samplesFolderPathFieldForBarrels.Size = new Size(497, 23);
            samplesFolderPathFieldForBarrels.TabIndex = 2;
            samplesFolderPathFieldForBarrels.TextChanged += samplesFolderPathField_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 65);
            label2.Name = "label2";
            label2.Size = new Size(280, 15);
            label2.TabIndex = 3;
            label2.Text = "Путь к файлам изображений образцов для бочек";
            // 
            // sourceFolderPathButtonForBarrels
            // 
            sourceFolderPathButtonForBarrels.Location = new Point(796, 12);
            sourceFolderPathButtonForBarrels.Name = "sourceFolderPathButtonForBarrels";
            sourceFolderPathButtonForBarrels.Size = new Size(25, 23);
            sourceFolderPathButtonForBarrels.TabIndex = 4;
            sourceFolderPathButtonForBarrels.Text = "...";
            sourceFolderPathButtonForBarrels.UseVisualStyleBackColor = true;
            sourceFolderPathButtonForBarrels.Click += sourceFolderPathButton_Click;
            // 
            // samplesFolderPathButtonForBarrels
            // 
            samplesFolderPathButtonForBarrels.Location = new Point(806, 63);
            samplesFolderPathButtonForBarrels.Name = "samplesFolderPathButtonForBarrels";
            samplesFolderPathButtonForBarrels.Size = new Size(25, 23);
            samplesFolderPathButtonForBarrels.TabIndex = 5;
            samplesFolderPathButtonForBarrels.Text = "...";
            samplesFolderPathButtonForBarrels.UseVisualStyleBackColor = true;
            samplesFolderPathButtonForBarrels.Click += samplesFolderPathButton_Click;
            // 
            // openFileDialogSource
            // 
            openFileDialogSource.FileName = "openFileDialog1";
            // 
            // Camera_Selection
            // 
            Camera_Selection.FormattingEnabled = true;
            Camera_Selection.Location = new Point(73, 123);
            Camera_Selection.Name = "Camera_Selection";
            Camera_Selection.Size = new Size(497, 23);
            Camera_Selection.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 126);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 7;
            label3.Text = "Камеры";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 41);
            label5.Name = "label5";
            label5.Size = new Size(301, 15);
            label5.TabIndex = 9;
            label5.Text = "Путь к видеофайлу изображения объектов для бочек";
            // 
            // sourceFolderPathVideoFieldForBarrels
            // 
            sourceFolderPathVideoFieldForBarrels.Location = new Point(329, 38);
            sourceFolderPathVideoFieldForBarrels.Name = "sourceFolderPathVideoFieldForBarrels";
            sourceFolderPathVideoFieldForBarrels.Size = new Size(478, 23);
            sourceFolderPathVideoFieldForBarrels.TabIndex = 10;
            sourceFolderPathVideoFieldForBarrels.TextChanged += sourceFolderPathVideoField_TextChanged;
            // 
            // sourceFolderPathVideoButtonForBarrels
            // 
            sourceFolderPathVideoButtonForBarrels.Location = new Point(806, 39);
            sourceFolderPathVideoButtonForBarrels.Name = "sourceFolderPathVideoButtonForBarrels";
            sourceFolderPathVideoButtonForBarrels.Size = new Size(25, 23);
            sourceFolderPathVideoButtonForBarrels.TabIndex = 11;
            sourceFolderPathVideoButtonForBarrels.Text = "...";
            sourceFolderPathVideoButtonForBarrels.UseVisualStyleBackColor = true;
            sourceFolderPathVideoButtonForBarrels.Click += sourceFolderPathVideoButton_Click;
            // 
            // sourceFolderPathButtonForBoards
            // 
            sourceFolderPathButtonForBoards.Location = new Point(796, 93);
            sourceFolderPathButtonForBoards.Name = "sourceFolderPathButtonForBoards";
            sourceFolderPathButtonForBoards.Size = new Size(25, 23);
            sourceFolderPathButtonForBoards.TabIndex = 14;
            sourceFolderPathButtonForBoards.Text = "...";
            sourceFolderPathButtonForBoards.UseVisualStyleBackColor = true;
            sourceFolderPathButtonForBoards.Click += sourceFolderPathButtonForBoards_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 96);
            label4.Name = "label4";
            label4.Size = new Size(268, 15);
            label4.TabIndex = 13;
            label4.Text = "Путь к файлу изображения объектов для досок";
            // 
            // sourceFolderPathFieldForBoards
            // 
            sourceFolderPathFieldForBoards.Location = new Point(303, 94);
            sourceFolderPathFieldForBoards.Name = "sourceFolderPathFieldForBoards";
            sourceFolderPathFieldForBoards.Size = new Size(497, 23);
            sourceFolderPathFieldForBoards.TabIndex = 12;
            sourceFolderPathFieldForBoards.TextChanged += sourceFolderPathFieldForBoards_TextChanged;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 450);
            Controls.Add(sourceFolderPathButtonForBoards);
            Controls.Add(label4);
            Controls.Add(sourceFolderPathFieldForBoards);
            Controls.Add(sourceFolderPathVideoButtonForBarrels);
            Controls.Add(sourceFolderPathVideoFieldForBarrels);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(Camera_Selection);
            Controls.Add(samplesFolderPathButtonForBarrels);
            Controls.Add(sourceFolderPathButtonForBarrels);
            Controls.Add(label2);
            Controls.Add(samplesFolderPathFieldForBarrels);
            Controls.Add(label1);
            Controls.Add(sourceFolderPathFieldForBarrels);
            Name = "SettingsForm";
            Text = "Settings";
            FormClosing += SettingsFrom_FormClosing;
            Load += SettingsFrom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox sourceFolderPathFieldForBarrels;
        private Label label1;
        private TextBox samplesFolderPathFieldForBarrels;
        private Label label2;
        private Button sourceFolderPathButtonForBarrels;
        private Button samplesFolderPathButtonForBarrels;
        private OpenFileDialog openFileDialogSource;
        private FolderBrowserDialog folderBrowserDialogSample;
        private ComboBox Camera_Selection;
        private Label label3;
        private Label label5;
        private TextBox sourceFolderPathVideoFieldForBarrels;
        private Button sourceFolderPathVideoButtonForBarrels;
        private Button sourceFolderPathButtonForBoards;
        private Label label4;
        private TextBox sourceFolderPathFieldForBoards;
    }
}