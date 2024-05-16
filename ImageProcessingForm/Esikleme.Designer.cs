namespace ImageProcessingForm
{
    partial class Esikleme
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
            blokBoyutu = new Label();
            btnSave = new FontAwesome.Sharp.IconButton();
            btnDel = new FontAwesome.Sharp.IconButton();
            btnAdd = new FontAwesome.Sharp.IconButton();
            btnStart = new FontAwesome.Sharp.IconButton();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)beforePic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)afterPic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            beforePic.Location = new Point(13, 2);
            beforePic.Margin = new Padding(4, 3, 4, 3);
            beforePic.Name = "beforePic";
            beforePic.Size = new Size(588, 561);
            beforePic.TabIndex = 4;
            beforePic.TabStop = false;
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
            afterPic.Location = new Point(616, 2);
            afterPic.Margin = new Padding(4, 3, 4, 3);
            afterPic.Name = "afterPic";
            afterPic.Size = new Size(588, 561);
            afterPic.TabIndex = 5;
            afterPic.TabStop = false;
            // 
            // blokBoyutu
            // 
            blokBoyutu.Location = new Point(0, 0);
            blokBoyutu.Name = "blokBoyutu";
            blokBoyutu.Size = new Size(100, 23);
            blokBoyutu.TabIndex = 27;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(68, 195, 52);
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.Black;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.Location = new Point(789, 598);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(139, 78);
            btnSave.TabIndex = 14;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.AutoSizeChanged += btnSave_Click_1;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.FromArgb(68, 195, 52);
            btnDel.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDel.IconColor = Color.Black;
            btnDel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDel.Location = new Point(934, 598);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(129, 78);
            btnDel.TabIndex = 15;
            btnDel.UseVisualStyleBackColor = false;
            btnDel.AutoSizeChanged += btnDel_Click_1;
            btnDel.Click += btnDel_Click_1;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(68, 195, 52);
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnAdd.IconColor = Color.Black;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.Location = new Point(1069, 598);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(135, 78);
            btnAdd.TabIndex = 16;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.AutoSizeChanged += btnAdd_Click;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(68, 195, 52);
            btnStart.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnStart.IconColor = Color.Black;
            btnStart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStart.Location = new Point(656, 598);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(127, 78);
            btnStart.TabIndex = 23;
            btnStart.UseVisualStyleBackColor = false;
            btnStart.AutoSizeChanged += btnStart_Click;
            btnStart.Click += btnStart_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(192, 599);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 28;
          
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(58, 598);
            label1.Name = "label1";
            label1.Size = new Size(128, 28);
            label1.TabIndex = 29;
            label1.Text = "EŞİK DEĞER :";
            // 
            // Esikleme
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1222, 705);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(btnStart);
            Controls.Add(blokBoyutu);
            Controls.Add(btnAdd);
            Controls.Add(btnDel);
            Controls.Add(btnSave);
            Controls.Add(afterPic);
            Controls.Add(beforePic);
            Name = "Esikleme";
            Text = "Esikleme";
            ((System.ComponentModel.ISupportInitialize)beforePic).EndInit();
            ((System.ComponentModel.ISupportInitialize)afterPic).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox beforePic;
        private FontAwesome.Sharp.IconPictureBox afterPic;
        private Label blokBoyutu;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnDel;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnStart;
        private NumericUpDown numericUpDown1;
        private Label label1;
    }
}