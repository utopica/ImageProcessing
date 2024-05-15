namespace ImageProcessingForm
{
    partial class histogram
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
            beforePic = new PictureBox();
            afterPic = new PictureBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            radioButton1red = new RadioButton();
            radioButton2blue = new RadioButton();
            radioButton1green = new RadioButton();
            radioButton1gray = new RadioButton();
            label3 = new Label();
            btnSave = new FontAwesome.Sharp.IconButton();
            btnDel = new FontAwesome.Sharp.IconButton();
            btnAdd = new FontAwesome.Sharp.IconButton();
            btnStart = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)beforePic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)afterPic).BeginInit();
            SuspendLayout();
            // 
            // beforePic
            // 
            beforePic.BackgroundImageLayout = ImageLayout.Stretch;
            beforePic.BorderStyle = BorderStyle.FixedSingle;
            beforePic.Location = new Point(55, 21);
            beforePic.Margin = new Padding(4, 3, 4, 3);
            beforePic.Name = "beforePic";
            beforePic.Size = new Size(588, 561);
            beforePic.TabIndex = 0;
            beforePic.TabStop = false;
            // 
            // afterPic
            // 
            afterPic.BackgroundImageLayout = ImageLayout.Stretch;
            afterPic.BorderStyle = BorderStyle.FixedSingle;
            afterPic.Location = new Point(649, 21);
            afterPic.Margin = new Padding(4, 3, 4, 3);
            afterPic.Name = "afterPic";
            afterPic.Size = new Size(588, 561);
            afterPic.TabIndex = 1;
            afterPic.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(55, 613);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(294, 28);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(428, 600);
            label2.Name = "label2";
            label2.Size = new Size(93, 28);
            label2.TabIndex = 4;
            label2.Text = "Channel:";
            // 
            // radioButton1red
            // 
            radioButton1red.AutoSize = true;
            radioButton1red.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            radioButton1red.ForeColor = SystemColors.ButtonFace;
            radioButton1red.Location = new Point(428, 658);
            radioButton1red.Name = "radioButton1red";
            radioButton1red.Size = new Size(67, 32);
            radioButton1red.TabIndex = 5;
            radioButton1red.TabStop = true;
            radioButton1red.Text = "Red";
            radioButton1red.UseVisualStyleBackColor = true;
            radioButton1red.CheckedChanged += radioButton1red_CheckedChanged;
            // 
            // radioButton2blue
            // 
            radioButton2blue.AutoSize = true;
            radioButton2blue.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            radioButton2blue.ForeColor = SystemColors.ButtonFace;
            radioButton2blue.Location = new Point(428, 686);
            radioButton2blue.Name = "radioButton2blue";
            radioButton2blue.Size = new Size(73, 32);
            radioButton2blue.TabIndex = 6;
            radioButton2blue.TabStop = true;
            radioButton2blue.Text = "Blue";
            radioButton2blue.UseVisualStyleBackColor = true;
            radioButton2blue.CheckedChanged += radioButton2blue_CheckedChanged;
            // 
            // radioButton1green
            // 
            radioButton1green.AutoSize = true;
            radioButton1green.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            radioButton1green.ForeColor = SystemColors.ButtonFace;
            radioButton1green.Location = new Point(428, 714);
            radioButton1green.Name = "radioButton1green";
            radioButton1green.Size = new Size(88, 32);
            radioButton1green.TabIndex = 7;
            radioButton1green.TabStop = true;
            radioButton1green.Text = "Green";
            radioButton1green.UseVisualStyleBackColor = true;
            radioButton1green.CheckedChanged += radioButton1green_CheckedChanged;
            // 
            // radioButton1gray
            // 
            radioButton1gray.AutoSize = true;
            radioButton1gray.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            radioButton1gray.ForeColor = SystemColors.ButtonFace;
            radioButton1gray.Location = new Point(428, 631);
            radioButton1gray.Name = "radioButton1gray";
            radioButton1gray.Size = new Size(188, 32);
            radioButton1gray.TabIndex = 8;
            radioButton1gray.TabStop = true;
            radioButton1gray.Text = "Luminosity(Gray)";
            radioButton1gray.UseVisualStyleBackColor = true;
            radioButton1gray.CheckedChanged += radioButton1gray_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 9;
            label3.Text = "label3";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(68, 195, 52);
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.Black;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.Location = new Point(926, 624);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(93, 76);
            btnSave.TabIndex = 10;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.FromArgb(68, 195, 52);
            btnDel.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDel.IconColor = Color.Black;
            btnDel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDel.Location = new Point(1035, 624);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(90, 76);
            btnDel.TabIndex = 11;
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(68, 195, 52);
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnAdd.IconColor = Color.Black;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.Location = new Point(1141, 624);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 76);
            btnAdd.TabIndex = 12;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(68, 195, 52);
            btnStart.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnStart.IconColor = Color.Black;
            btnStart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStart.Location = new Point(817, 624);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(86, 76);
            btnStart.TabIndex = 14;
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // histogram
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1281, 765);
            Controls.Add(btnStart);
            Controls.Add(btnAdd);
            Controls.Add(btnDel);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(radioButton1gray);
            Controls.Add(radioButton1green);
            Controls.Add(radioButton2blue);
            Controls.Add(radioButton1red);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(afterPic);
            Controls.Add(beforePic);
            Name = "histogram";
            Text = "histogram";
            ((System.ComponentModel.ISupportInitialize)beforePic).EndInit();
            ((System.ComponentModel.ISupportInitialize)afterPic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox beforePic;
        private PictureBox afterPic;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private RadioButton radioButton1red;
        private RadioButton radioButton2blue;
        private RadioButton radioButton1green;
        private RadioButton radioButton1gray;
        private Label label3;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnDel;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnStart;
    }
}