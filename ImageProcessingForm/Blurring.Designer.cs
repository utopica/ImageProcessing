namespace ImageProcessingForm
{
    partial class Blurring
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
            afterPic = new FontAwesome.Sharp.IconPictureBox();
            beforePic = new FontAwesome.Sharp.IconPictureBox();
            btnAdd = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            btnDel = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            textBox1 = new TextBox();
            btnStart = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)afterPic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)beforePic).BeginInit();
            SuspendLayout();
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
            afterPic.Location = new Point(645, 12);
            afterPic.Margin = new Padding(4, 3, 4, 3);
            afterPic.Name = "afterPic";
            afterPic.Size = new Size(588, 561);
            afterPic.TabIndex = 7;
            afterPic.TabStop = false;
            afterPic.Click += afterPic_Click;
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
            beforePic.Location = new Point(51, 12);
            beforePic.Margin = new Padding(4, 3, 4, 3);
            beforePic.Name = "beforePic";
            beforePic.Size = new Size(588, 561);
            beforePic.TabIndex = 6;
            beforePic.TabStop = false;
            beforePic.Click += beforePic_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(68, 195, 52);
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnAdd.IconColor = Color.Black;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.Location = new Point(1095, 614);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 85);
            btnAdd.TabIndex = 17;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(68, 195, 52);
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.Black;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.Location = new Point(823, 614);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 85);
            btnSave.TabIndex = 16;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.FromArgb(68, 195, 52);
            btnDel.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDel.IconColor = Color.Black;
            btnDel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDel.Location = new Point(959, 614);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(130, 85);
            btnDel.TabIndex = 15;
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(51, 628);
            label1.Name = "label1";
            label1.Size = new Size(200, 31);
            label1.TabIndex = 18;
            label1.Text = "Bulanıklık Miktarı:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(266, 628);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(179, 37);
            textBox1.TabIndex = 19;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(68, 195, 52);
            btnStart.ForeColor = Color.FromArgb(68, 195, 52);
            btnStart.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnStart.IconColor = Color.Black;
            btnStart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStart.IconSize = 55;
            btnStart.Location = new Point(691, 614);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(126, 85);
            btnStart.TabIndex = 25;
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // Blurring
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1278, 786);
            Controls.Add(btnStart);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            Controls.Add(btnSave);
            Controls.Add(btnDel);
            Controls.Add(afterPic);
            Controls.Add(beforePic);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Blurring";
            Text = "Blurring";
            ((System.ComponentModel.ISupportInitialize)afterPic).EndInit();
            ((System.ComponentModel.ISupportInitialize)beforePic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox afterPic;
        private FontAwesome.Sharp.IconPictureBox beforePic;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnDel;
        private Label label1;
        private TextBox textBox1;
        private FontAwesome.Sharp.IconButton btnStart;
    }
}