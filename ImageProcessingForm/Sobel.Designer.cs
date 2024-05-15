namespace ImageProcessingForm
{
    partial class Sobel
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
            btnAdd = new FontAwesome.Sharp.IconButton();
            btnDel = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            label2 = new Label();
            radioButton1horizontal = new RadioButton();
            radioButton2vertical = new RadioButton();
            radioButton3both = new RadioButton();
            label3 = new Label();
            textBox1esik = new TextBox();
            btnStart = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)beforePic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)afterPic).BeginInit();
            SuspendLayout();
            // 
            // beforePic
            // 
            beforePic.Location = new Point(24, 2);
            beforePic.Name = "beforePic";
            beforePic.Size = new Size(588, 561);
            beforePic.TabIndex = 0;
            beforePic.TabStop = false;
            beforePic.Click += beforePic_Click;
            // 
            // afterPic
            // 
            afterPic.Location = new Point(630, 2);
            afterPic.Name = "afterPic";
            afterPic.Size = new Size(588, 561);
            afterPic.TabIndex = 1;
            afterPic.TabStop = false;
            afterPic.Click += afterPic_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(68, 195, 52);
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnAdd.IconColor = Color.Black;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.Location = new Point(1094, 577);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(124, 62);
            btnAdd.TabIndex = 20;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.FromArgb(68, 195, 52);
            btnDel.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDel.IconColor = Color.Black;
            btnDel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDel.Location = new Point(1094, 645);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(124, 63);
            btnDel.TabIndex = 21;
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(68, 195, 52);
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.Black;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.Location = new Point(1094, 714);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 69);
            btnSave.TabIndex = 22;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 25;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(61, 599);
            label2.Name = "label2";
            label2.Size = new Size(244, 29);
            label2.TabIndex = 26;
            label2.Text = "Kenar Tespiti Yönü:";
            // 
            // radioButton1horizontal
            // 
            radioButton1horizontal.AutoSize = true;
            radioButton1horizontal.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold);
            radioButton1horizontal.ForeColor = SystemColors.ButtonFace;
            radioButton1horizontal.Location = new Point(72, 686);
            radioButton1horizontal.Name = "radioButton1horizontal";
            radioButton1horizontal.Size = new Size(152, 33);
            radioButton1horizontal.TabIndex = 27;
            radioButton1horizontal.TabStop = true;
            radioButton1horizontal.Text = "Horizontal";
            radioButton1horizontal.UseVisualStyleBackColor = true;
            radioButton1horizontal.CheckedChanged += radioButton1horizontal_CheckedChanged;
            // 
            // radioButton2vertical
            // 
            radioButton2vertical.AutoSize = true;
            radioButton2vertical.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold);
            radioButton2vertical.ForeColor = SystemColors.ButtonFace;
            radioButton2vertical.Location = new Point(72, 727);
            radioButton2vertical.Name = "radioButton2vertical";
            radioButton2vertical.Size = new Size(122, 33);
            radioButton2vertical.TabIndex = 28;
            radioButton2vertical.TabStop = true;
            radioButton2vertical.Text = "Vertical";
            radioButton2vertical.UseVisualStyleBackColor = true;
            radioButton2vertical.CheckedChanged += radioButton2vertical_CheckedChanged;
            // 
            // radioButton3both
            // 
            radioButton3both.AutoSize = true;
            radioButton3both.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold);
            radioButton3both.ForeColor = SystemColors.ButtonFace;
            radioButton3both.Location = new Point(72, 643);
            radioButton3both.Name = "radioButton3both";
            radioButton3both.Size = new Size(87, 33);
            radioButton3both.TabIndex = 29;
            radioButton3both.TabStop = true;
            radioButton3both.Text = "Both";
            radioButton3both.UseVisualStyleBackColor = true;
            radioButton3both.CheckedChanged += radioButton3both_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(392, 610);
            label3.Name = "label3";
            label3.Size = new Size(146, 29);
            label3.TabIndex = 30;
            label3.Text = "Eşik değer:";
            // 
            // textBox1esik
            // 
            textBox1esik.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold);
            textBox1esik.Location = new Point(392, 656);
            textBox1esik.Multiline = true;
            textBox1esik.Name = "textBox1esik";
            textBox1esik.Size = new Size(146, 34);
            textBox1esik.TabIndex = 31;
            textBox1esik.TextChanged += textBox1esik_TextChanged;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(68, 195, 52);
            btnStart.ForeColor = Color.FromArgb(68, 195, 52);
            btnStart.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnStart.IconColor = Color.Black;
            btnStart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStart.IconSize = 55;
            btnStart.Location = new Point(708, 619);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(95, 89);
            btnStart.TabIndex = 24;
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // Sobel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1237, 795);
            Controls.Add(textBox1esik);
            Controls.Add(label3);
            Controls.Add(radioButton3both);
            Controls.Add(radioButton2vertical);
            Controls.Add(radioButton1horizontal);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnStart);
            Controls.Add(btnSave);
            Controls.Add(btnDel);
            Controls.Add(btnAdd);
            Controls.Add(afterPic);
            Controls.Add(beforePic);
            Name = "Sobel";
            Text = "Sobel";
            ((System.ComponentModel.ISupportInitialize)beforePic).EndInit();
            ((System.ComponentModel.ISupportInitialize)afterPic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox beforePic;
        private PictureBox afterPic;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnDel;
        private FontAwesome.Sharp.IconButton btnSave;
        private Label label1;
        private Label label2;
        private RadioButton radioButton1horizontal;
        private RadioButton radioButton2vertical;
        private RadioButton radioButton3both;
        private Label label3;
        private TextBox textBox1esik;
        private FontAwesome.Sharp.IconButton btnStart;
    }
}