namespace ImageProcessingForm
{
    partial class Morfolojik
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
            comboBox1 = new ComboBox();
            label1 = new Label();
            btnAdd = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            btnDel = new FontAwesome.Sharp.IconButton();
            btnStart = new FontAwesome.Sharp.IconButton();
            btnUndo = new FontAwesome.Sharp.IconButton();
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
            beforePic.Location = new Point(13, 12);
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
            afterPic.Location = new Point(620, 12);
            afterPic.Margin = new Padding(4, 3, 4, 3);
            afterPic.Name = "afterPic";
            afterPic.Size = new Size(588, 561);
            afterPic.TabIndex = 6;
            afterPic.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 12F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(209, 603);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(255, 36);
            comboBox1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(13, 603);
            label1.Name = "label1";
            label1.Size = new Size(190, 28);
            label1.TabIndex = 8;
            label1.Text = "Morfolojik İşlemler : ";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(68, 195, 52);
            btnAdd.Font = new Font("Segoe UI", 7.8F);
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnAdd.IconColor = Color.Black;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.IconSize = 32;
            btnAdd.Location = new Point(1166, 589);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(48, 49);
            btnAdd.TabIndex = 25;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(68, 195, 52);
            btnSave.Font = new Font("Segoe UI", 7.8F);
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.Black;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.IconSize = 32;
            btnSave.Location = new Point(1166, 699);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(48, 49);
            btnSave.TabIndex = 24;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.FromArgb(68, 195, 52);
            btnDel.Font = new Font("Segoe UI", 7.8F);
            btnDel.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDel.IconColor = Color.Black;
            btnDel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDel.IconSize = 32;
            btnDel.Location = new Point(1166, 644);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(48, 49);
            btnDel.TabIndex = 23;
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = SystemColors.ActiveCaptionText;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnStart.IconColor = Color.FromArgb(68, 195, 52);
            btnStart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStart.IconSize = 72;
            btnStart.Location = new Point(787, 626);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(77, 82);
            btnStart.TabIndex = 26;
            btnStart.UseVisualStyleBackColor = false;
            // 
            // btnUndo
            // 
            btnUndo.BackColor = SystemColors.ActiveCaptionText;
            btnUndo.FlatAppearance.BorderColor = SystemColors.ActiveCaptionText;
            btnUndo.FlatAppearance.BorderSize = 0;
            btnUndo.FlatStyle = FlatStyle.Flat;
            btnUndo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnUndo.ForeColor = SystemColors.ActiveCaptionText;
            btnUndo.IconChar = FontAwesome.Sharp.IconChar.RotateBack;
            btnUndo.IconColor = Color.FromArgb(68, 195, 52);
            btnUndo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUndo.IconSize = 82;
            btnUndo.Location = new Point(882, 631);
            btnUndo.Margin = new Padding(4, 3, 4, 3);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(80, 77);
            btnUndo.TabIndex = 27;
            btnUndo.UseVisualStyleBackColor = false;
            // 
            // Morfolojik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1226, 764);
            Controls.Add(btnUndo);
            Controls.Add(btnStart);
            Controls.Add(btnAdd);
            Controls.Add(btnSave);
            Controls.Add(btnDel);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(afterPic);
            Controls.Add(beforePic);
            Name = "Morfolojik";
            Text = "Morfolojik";
            ((System.ComponentModel.ISupportInitialize)beforePic).EndInit();
            ((System.ComponentModel.ISupportInitialize)afterPic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox beforePic;
        private FontAwesome.Sharp.IconPictureBox afterPic;
        private ComboBox comboBox1;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnDel;
        private FontAwesome.Sharp.IconButton btnStart;
        private FontAwesome.Sharp.IconButton btnUndo;
    }
}