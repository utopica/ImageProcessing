namespace ImageProcessingForm
{
    partial class Dondurme
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
            btnDel = new FontAwesome.Sharp.IconButton();
            btnAdd = new FontAwesome.Sharp.IconButton();
            BtnSave = new FontAwesome.Sharp.IconButton();
            btnStart = new FontAwesome.Sharp.IconButton();
            txtAngle = new TextBox();
            label1 = new Label();
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
            beforePic.Location = new Point(97, 2);
            beforePic.Margin = new Padding(4, 3, 4, 3);
            beforePic.Name = "beforePic";
            beforePic.Size = new Size(588, 561);
            beforePic.TabIndex = 5;
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
            afterPic.Location = new Point(693, 2);
            afterPic.Margin = new Padding(4, 3, 4, 3);
            afterPic.Name = "afterPic";
            afterPic.Size = new Size(588, 561);
            afterPic.TabIndex = 6;
            afterPic.TabStop = false;
            afterPic.Click += afterPic_Click;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.FromArgb(68, 195, 52);
            btnDel.Font = new Font("Segoe UI", 7.8F);
            btnDel.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDel.IconColor = Color.Black;
            btnDel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDel.IconSize = 32;
            btnDel.Location = new Point(1161, 591);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(103, 49);
            btnDel.TabIndex = 25;
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(68, 195, 52);
            btnAdd.Font = new Font("Segoe UI", 7.8F);
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnAdd.IconColor = Color.Black;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.IconSize = 32;
            btnAdd.Location = new Point(1025, 592);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(103, 49);
            btnAdd.TabIndex = 26;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.FromArgb(68, 195, 52);
            BtnSave.Font = new Font("Segoe UI", 7.8F);
            BtnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnSave.IconColor = Color.Black;
            BtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnSave.IconSize = 32;
            BtnSave.Location = new Point(896, 592);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(103, 49);
            BtnSave.TabIndex = 27;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(68, 195, 52);
            btnStart.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnStart.IconColor = Color.Black;
            btnStart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStart.IconSize = 30;
            btnStart.Location = new Point(771, 591);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(99, 47);
            btnStart.TabIndex = 28;
            btnStart.TabStop = false;
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // txtAngle
            // 
            txtAngle.Location = new Point(301, 582);
            txtAngle.Name = "txtAngle";
            txtAngle.Size = new Size(193, 27);
            txtAngle.TabIndex = 29;
            txtAngle.TextChanged += txtAngle_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 30;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.White;
            label2.Location = new Point(97, 578);
            label2.Name = "label2";
            label2.Size = new Size(188, 31);
            label2.TabIndex = 31;
            label2.Text = "Döndürme açısı:";
            // 
            // Dondurme
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1381, 707);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAngle);
            Controls.Add(btnStart);
            Controls.Add(BtnSave);
            Controls.Add(btnAdd);
            Controls.Add(btnDel);
            Controls.Add(afterPic);
            Controls.Add(beforePic);
            Name = "Dondurme";
            Text = "Dondurme";
            ((System.ComponentModel.ISupportInitialize)beforePic).EndInit();
            ((System.ComponentModel.ISupportInitialize)afterPic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox beforePic;
        private FontAwesome.Sharp.IconPictureBox afterPic;
        private FontAwesome.Sharp.IconButton btnDel;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton BtnSave;
        private FontAwesome.Sharp.IconButton btnStart;
        private TextBox txtAngle;
        private Label label1;
        private Label label2;
    }
}