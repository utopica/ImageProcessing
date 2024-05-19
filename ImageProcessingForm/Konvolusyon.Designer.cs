namespace ImageProcessingForm
{
    partial class Konvolusyon
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
            beforePic = new FontAwesome.Sharp.IconPictureBox();
            afterPic = new FontAwesome.Sharp.IconPictureBox();
            btnStart = new FontAwesome.Sharp.IconButton();
            BtnSave = new FontAwesome.Sharp.IconButton();
            btnAdd = new FontAwesome.Sharp.IconButton();
            btnDel = new FontAwesome.Sharp.IconButton();
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)beforePic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)afterPic).BeginInit();
            SuspendLayout();
            // 
            // beforePic
            // 
            beforePic.BackColor = SystemColors.ActiveCaptionText;
            beforePic.BackgroundImageLayout = ImageLayout.Stretch;
            beforePic.BorderStyle = BorderStyle.FixedSingle;
            beforePic.ForeColor = SystemColors.Control;
            beforePic.IconChar = FontAwesome.Sharp.IconChar.None;
            beforePic.IconColor = SystemColors.Control;
            beforePic.IconFont = FontAwesome.Sharp.IconFont.Auto;
            beforePic.IconSize = 561;
            beforePic.Location = new Point(52, 12);
            beforePic.Margin = new Padding(4, 3, 4, 3);
            beforePic.Name = "beforePic";
            beforePic.Size = new Size(588, 561);
            beforePic.TabIndex = 6;
            beforePic.TabStop = false;
            beforePic.Click += beforePic_Click;
            // 
            // afterPic
            // 
            afterPic.BackColor = SystemColors.ActiveCaptionText;
            afterPic.BorderStyle = BorderStyle.FixedSingle;
            afterPic.ForeColor = SystemColors.Control;
            afterPic.IconChar = FontAwesome.Sharp.IconChar.None;
            afterPic.IconColor = SystemColors.Control;
            afterPic.IconFont = FontAwesome.Sharp.IconFont.Auto;
            afterPic.IconSize = 561;
            afterPic.Location = new Point(695, 12);
            afterPic.Margin = new Padding(4, 3, 4, 3);
            afterPic.Name = "afterPic";
            afterPic.Size = new Size(588, 561);
            afterPic.TabIndex = 7;
            afterPic.TabStop = false;
            afterPic.Click += afterPic_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(68, 195, 52);
            btnStart.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnStart.IconColor = Color.Black;
            btnStart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStart.IconSize = 30;
            btnStart.Location = new Point(808, 579);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(99, 47);
            btnStart.TabIndex = 29;
            btnStart.TabStop = false;
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.FromArgb(68, 195, 52);
            BtnSave.Font = new Font("Segoe UI", 7.8F);
            BtnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnSave.IconColor = Color.Black;
            BtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnSave.IconSize = 32;
            BtnSave.Location = new Point(931, 579);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(103, 49);
            BtnSave.TabIndex = 30;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(68, 195, 52);
            btnAdd.Font = new Font("Segoe UI", 7.8F);
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnAdd.IconColor = Color.Black;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.IconSize = 32;
            btnAdd.Location = new Point(1058, 579);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(103, 49);
            btnAdd.TabIndex = 31;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.FromArgb(68, 195, 52);
            btnDel.Font = new Font("Segoe UI", 7.8F);
            btnDel.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDel.IconColor = Color.Black;
            btnDel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDel.IconSize = 32;
            btnDel.Location = new Point(1180, 579);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(103, 49);
            btnDel.TabIndex = 32;
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(330, 594);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(178, 27);
            textBox1.TabIndex = 33;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(63, 590);
            label1.Name = "label1";
            label1.Size = new Size(267, 31);
            label1.TabIndex = 34;
            label1.Text = "kernel boyutu(1,3,5...)  :";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(330, 635);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(178, 27);
            textBox2.TabIndex = 35;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.White;
            label2.Location = new Point(63, 631);
            label2.Name = "label2";
            label2.Size = new Size(170, 31);
            label2.TabIndex = 36;
            label2.Text = "sigma değeri  :";
            // 
            // Konvolusyon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1369, 674);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(btnDel);
            Controls.Add(btnAdd);
            Controls.Add(BtnSave);
            Controls.Add(btnStart);
            Controls.Add(afterPic);
            Controls.Add(beforePic);
            Name = "Konvolusyon";
            Text = "Konvolusyon";
            ((System.ComponentModel.ISupportInitialize)beforePic).EndInit();
            ((System.ComponentModel.ISupportInitialize)afterPic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox beforePic;
        private FontAwesome.Sharp.IconPictureBox afterPic;
        private FontAwesome.Sharp.IconButton btnStart;
        private FontAwesome.Sharp.IconButton BtnSave;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnDel;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label2;
    }
}