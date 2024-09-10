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
            groupBox1 = new GroupBox();
            portField = new TextBox();
            label7 = new Label();
            label6 = new Label();
            addressField = new TextBox();
            groupBox2 = new GroupBox();
            comboBarrelRetrType = new ComboBox();
            label17 = new Label();
            label14 = new Label();
            cannyBarrelYField = new TextBox();
            label15 = new Label();
            cannyBarrelXField = new TextBox();
            label16 = new Label();
            label11 = new Label();
            elementBarrelYField = new TextBox();
            label12 = new Label();
            elementBarrelXField = new TextBox();
            label13 = new Label();
            label10 = new Label();
            blurBarrelYField = new TextBox();
            label9 = new Label();
            blurBarrelXField = new TextBox();
            label8 = new Label();
            groupBox3 = new GroupBox();
            comboBoardRetrType = new ComboBox();
            label18 = new Label();
            label19 = new Label();
            cannyBoardYField = new TextBox();
            label20 = new Label();
            cannyBoardXField = new TextBox();
            label21 = new Label();
            label22 = new Label();
            elementBoardYField = new TextBox();
            label23 = new Label();
            elementBoardXField = new TextBox();
            label24 = new Label();
            label25 = new Label();
            blurBoardYField = new TextBox();
            label26 = new Label();
            blurBoardXField = new TextBox();
            label27 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
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
            // groupBox1
            // 
            groupBox1.Controls.Add(portField);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(addressField);
            groupBox1.Location = new Point(21, 169);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(810, 69);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Настройка сокета";
            // 
            // portField
            // 
            portField.Location = new Point(323, 31);
            portField.Name = "portField";
            portField.Size = new Size(70, 23);
            portField.TabIndex = 10;
            portField.TextChanged += portField_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(282, 36);
            label7.Name = "label7";
            label7.Size = new Size(35, 15);
            label7.TabIndex = 9;
            label7.Text = "Порт";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 34);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 8;
            label6.Text = "Адрес";
            // 
            // addressField
            // 
            addressField.Location = new Point(79, 31);
            addressField.Name = "addressField";
            addressField.Size = new Size(192, 23);
            addressField.TabIndex = 0;
            addressField.TextChanged += addressField_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBarrelRetrType);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(cannyBarrelYField);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(cannyBarrelXField);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(elementBarrelYField);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(elementBarrelXField);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(blurBarrelYField);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(blurBarrelXField);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(21, 244);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(476, 225);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Настройки для сканера бочек";
            // 
            // comboBarrelRetrType
            // 
            comboBarrelRetrType.FormattingEnabled = true;
            comboBarrelRetrType.Location = new Point(213, 131);
            comboBarrelRetrType.Name = "comboBarrelRetrType";
            comboBarrelRetrType.Size = new Size(180, 23);
            comboBarrelRetrType.TabIndex = 16;
            comboBarrelRetrType.SelectedIndexChanged += comboBarrelRetrType_SelectedIndexChanged;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(6, 134);
            label17.Name = "label17";
            label17.Size = new Size(201, 15);
            label17.TabIndex = 15;
            label17.Text = "Нaстройки типа выборки контуров";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(372, 97);
            label14.Name = "label14";
            label14.Size = new Size(14, 15);
            label14.TabIndex = 14;
            label14.Text = "Y";
            // 
            // cannyBarrelYField
            // 
            cannyBarrelYField.Location = new Point(289, 94);
            cannyBarrelYField.Name = "cannyBarrelYField";
            cannyBarrelYField.Size = new Size(77, 23);
            cannyBarrelYField.TabIndex = 13;
            cannyBarrelYField.TextChanged += cannyBarrelYField_TextChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(269, 97);
            label15.Name = "label15";
            label15.Size = new Size(14, 15);
            label15.TabIndex = 12;
            label15.Text = "X";
            // 
            // cannyBarrelXField
            // 
            cannyBarrelXField.Location = new Point(186, 94);
            cannyBarrelXField.Name = "cannyBarrelXField";
            cannyBarrelXField.Size = new Size(77, 23);
            cannyBarrelXField.TabIndex = 11;
            cannyBarrelXField.TextChanged += cannyBarrelXField_TextChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 97);
            label16.Name = "label16";
            label16.Size = new Size(176, 15);
            label16.TabIndex = 10;
            label16.Text = "Нaстройки для фильтра Кэнни";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(314, 68);
            label11.Name = "label11";
            label11.Size = new Size(14, 15);
            label11.TabIndex = 9;
            label11.Text = "Y";
            // 
            // elementBarrelYField
            // 
            elementBarrelYField.Location = new Point(231, 65);
            elementBarrelYField.Name = "elementBarrelYField";
            elementBarrelYField.Size = new Size(77, 23);
            elementBarrelYField.TabIndex = 8;
            elementBarrelYField.TextChanged += elementBarrelYField_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(211, 68);
            label12.Name = "label12";
            label12.Size = new Size(14, 15);
            label12.TabIndex = 7;
            label12.Text = "X";
            // 
            // elementBarrelXField
            // 
            elementBarrelXField.Location = new Point(128, 65);
            elementBarrelXField.Name = "elementBarrelXField";
            elementBarrelXField.Size = new Size(77, 23);
            elementBarrelXField.TabIndex = 6;
            elementBarrelXField.TextChanged += elementBarrelXField_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 68);
            label13.Name = "label13";
            label13.Size = new Size(117, 15);
            label13.TabIndex = 5;
            label13.Text = "Нaстройки для ядра";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(334, 39);
            label10.Name = "label10";
            label10.Size = new Size(14, 15);
            label10.TabIndex = 4;
            label10.Text = "Y";
            // 
            // blurBarrelYField
            // 
            blurBarrelYField.Location = new Point(251, 36);
            blurBarrelYField.Name = "blurBarrelYField";
            blurBarrelYField.Size = new Size(77, 23);
            blurBarrelYField.TabIndex = 3;
            blurBarrelYField.TextChanged += blurBarrelYField_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(231, 39);
            label9.Name = "label9";
            label9.Size = new Size(14, 15);
            label9.TabIndex = 2;
            label9.Text = "X";
            // 
            // blurBarrelXField
            // 
            blurBarrelXField.Location = new Point(148, 36);
            blurBarrelXField.Name = "blurBarrelXField";
            blurBarrelXField.Size = new Size(77, 23);
            blurBarrelXField.TabIndex = 1;
            blurBarrelXField.TextChanged += blurBarrelXField_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 39);
            label8.Name = "label8";
            label8.Size = new Size(142, 15);
            label8.TabIndex = 0;
            label8.Text = "Нaстройки сглаживания";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(comboBoardRetrType);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(label19);
            groupBox3.Controls.Add(cannyBoardYField);
            groupBox3.Controls.Add(label20);
            groupBox3.Controls.Add(cannyBoardXField);
            groupBox3.Controls.Add(label21);
            groupBox3.Controls.Add(label22);
            groupBox3.Controls.Add(elementBoardYField);
            groupBox3.Controls.Add(label23);
            groupBox3.Controls.Add(elementBoardXField);
            groupBox3.Controls.Add(label24);
            groupBox3.Controls.Add(label25);
            groupBox3.Controls.Add(blurBoardYField);
            groupBox3.Controls.Add(label26);
            groupBox3.Controls.Add(blurBoardXField);
            groupBox3.Controls.Add(label27);
            groupBox3.Location = new Point(513, 244);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(476, 225);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Настройки для сканера досок";
            // 
            // comboBoardRetrType
            // 
            comboBoardRetrType.FormattingEnabled = true;
            comboBoardRetrType.Location = new Point(227, 128);
            comboBoardRetrType.Name = "comboBoardRetrType";
            comboBoardRetrType.Size = new Size(180, 23);
            comboBoardRetrType.TabIndex = 33;
            comboBoardRetrType.SelectedIndexChanged += comboBoardRetrType_SelectedIndexChanged;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(20, 131);
            label18.Name = "label18";
            label18.Size = new Size(201, 15);
            label18.TabIndex = 32;
            label18.Text = "Нaстройки типа выборки контуров";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(386, 94);
            label19.Name = "label19";
            label19.Size = new Size(14, 15);
            label19.TabIndex = 31;
            label19.Text = "Y";
            // 
            // cannyBoardYField
            // 
            cannyBoardYField.Location = new Point(303, 91);
            cannyBoardYField.Name = "cannyBoardYField";
            cannyBoardYField.Size = new Size(77, 23);
            cannyBoardYField.TabIndex = 30;
            cannyBoardYField.TextChanged += cannyBoardYField_TextChanged;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(283, 94);
            label20.Name = "label20";
            label20.Size = new Size(14, 15);
            label20.TabIndex = 29;
            label20.Text = "X";
            // 
            // cannyBoardXField
            // 
            cannyBoardXField.Location = new Point(200, 91);
            cannyBoardXField.Name = "cannyBoardXField";
            cannyBoardXField.Size = new Size(77, 23);
            cannyBoardXField.TabIndex = 28;
            cannyBoardXField.TextChanged += cannyBoardXField_TextChanged;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(20, 94);
            label21.Name = "label21";
            label21.Size = new Size(176, 15);
            label21.TabIndex = 27;
            label21.Text = "Нaстройки для фильтра Кэнни";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(328, 65);
            label22.Name = "label22";
            label22.Size = new Size(14, 15);
            label22.TabIndex = 26;
            label22.Text = "Y";
            // 
            // elementBoardYField
            // 
            elementBoardYField.Location = new Point(245, 62);
            elementBoardYField.Name = "elementBoardYField";
            elementBoardYField.Size = new Size(77, 23);
            elementBoardYField.TabIndex = 25;
            elementBoardYField.TextChanged += elementBoardYField_TextChanged;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(225, 65);
            label23.Name = "label23";
            label23.Size = new Size(14, 15);
            label23.TabIndex = 24;
            label23.Text = "X";
            // 
            // elementBoardXField
            // 
            elementBoardXField.Location = new Point(142, 62);
            elementBoardXField.Name = "elementBoardXField";
            elementBoardXField.Size = new Size(77, 23);
            elementBoardXField.TabIndex = 23;
            elementBoardXField.TextChanged += elementBoardXField_TextChanged;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(20, 65);
            label24.Name = "label24";
            label24.Size = new Size(117, 15);
            label24.TabIndex = 22;
            label24.Text = "Нaстройки для ядра";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(348, 36);
            label25.Name = "label25";
            label25.Size = new Size(14, 15);
            label25.TabIndex = 21;
            label25.Text = "Y";
            // 
            // blurBoardYField
            // 
            blurBoardYField.Location = new Point(265, 33);
            blurBoardYField.Name = "blurBoardYField";
            blurBoardYField.Size = new Size(77, 23);
            blurBoardYField.TabIndex = 20;
            blurBoardYField.TextChanged += blurBoardYField_TextChanged;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(245, 36);
            label26.Name = "label26";
            label26.Size = new Size(14, 15);
            label26.TabIndex = 19;
            label26.Text = "X";
            // 
            // blurBoardXField
            // 
            blurBoardXField.Location = new Point(162, 33);
            blurBoardXField.Name = "blurBoardXField";
            blurBoardXField.Size = new Size(77, 23);
            blurBoardXField.TabIndex = 18;
            blurBoardXField.TextChanged += blurBoardXField_TextChanged;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(20, 36);
            label27.Name = "label27";
            label27.Size = new Size(142, 15);
            label27.TabIndex = 17;
            label27.Text = "Нaстройки сглаживания";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 492);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
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
        private GroupBox groupBox1;
        private TextBox portField;
        private Label label7;
        private Label label6;
        private TextBox addressField;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label10;
        private TextBox blurBarrelYField;
        private Label label9;
        private TextBox blurBarrelXField;
        private Label label8;
        private Label label14;
        private TextBox cannyBarrelYField;
        private Label label15;
        private TextBox cannyBarrelXField;
        private Label label16;
        private Label label11;
        private TextBox elementBarrelYField;
        private Label label12;
        private TextBox elementBarrelXField;
        private Label label13;
        private ComboBox comboBarrelRetrType;
        private Label label17;
        private ComboBox comboBoardRetrType;
        private Label label18;
        private Label label19;
        private TextBox cannyBoardYField;
        private Label label20;
        private TextBox cannyBoardXField;
        private Label label21;
        private Label label22;
        private TextBox elementBoardYField;
        private Label label23;
        private TextBox elementBoardXField;
        private Label label24;
        private Label label25;
        private TextBox blurBoardYField;
        private Label label26;
        private TextBox blurBoardXField;
        private Label label27;
    }
}