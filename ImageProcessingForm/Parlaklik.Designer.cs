namespace ImageProcessingForm
{
    partial class Parlaklik
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
            ıconButton1 = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            btnUndo = new FontAwesome.Sharp.IconButton();
            btnApply = new FontAwesome.Sharp.IconButton();
            btnAdd = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            btnDel = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)afterPic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)beforePic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            afterPic.Location = new Point(649, 21);
            afterPic.Margin = new Padding(4, 3, 4, 3);
            afterPic.Name = "afterPic";
            afterPic.Size = new Size(588, 561);
            afterPic.TabIndex = 3;
            afterPic.TabStop = false;
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
            beforePic.Location = new Point(55, 21);
            beforePic.Margin = new Padding(4, 3, 4, 3);
            beforePic.Name = "beforePic";
            beforePic.Size = new Size(588, 561);
            beforePic.TabIndex = 2;
            beforePic.TabStop = false;
            // 
            // ıconButton1
            // 
            ıconButton1.FlatAppearance.BorderSize = 0;
            ıconButton1.FlatStyle = FlatStyle.Flat;
            ıconButton1.IconChar = FontAwesome.Sharp.IconChar.Sun;
            ıconButton1.IconColor = Color.White;
            ıconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconButton1.IconSize = 58;
            ıconButton1.Location = new Point(113, 602);
            ıconButton1.Margin = new Padding(4, 3, 4, 3);
            ıconButton1.Name = "ıconButton1";
            ıconButton1.Size = new Size(118, 67);
            ıconButton1.TabIndex = 4;
            ıconButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(219, 610);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(131, 35);
            label1.TabIndex = 5;
            label1.Text = "Parlaklık : ";
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.Black;
            numericUpDown1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            numericUpDown1.ForeColor = Color.White;
            numericUpDown1.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown1.Location = new Point(380, 610);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 38);
            numericUpDown1.TabIndex = 6;
            // 
            // btnUndo
            // 
            btnUndo.BackColor = Color.FromArgb(68, 195, 52);
            btnUndo.FlatAppearance.BorderColor = Color.FromArgb(5, 117, 8);
            btnUndo.FlatAppearance.BorderSize = 3;
            btnUndo.FlatStyle = FlatStyle.Flat;
            btnUndo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnUndo.ForeColor = Color.FromArgb(5, 117, 8);
            btnUndo.IconChar = FontAwesome.Sharp.IconChar.RotateBack;
            btnUndo.IconColor = Color.Black;
            btnUndo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUndo.IconSize = 52;
            btnUndo.Location = new Point(358, 678);
            btnUndo.Margin = new Padding(4, 3, 4, 3);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(60, 60);
            btnUndo.TabIndex = 7;
            btnUndo.UseVisualStyleBackColor = false;
            btnUndo.Click += btnUndo_Click;
            // 
            // btnApply
            // 
            btnApply.BackColor = Color.FromArgb(68, 195, 52);
            btnApply.FlatAppearance.BorderColor = Color.FromArgb(5, 117, 8);
            btnApply.FlatAppearance.BorderSize = 3;
            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.ForeColor = Color.Transparent;
            btnApply.IconChar = FontAwesome.Sharp.IconChar.Check;
            btnApply.IconColor = Color.Black;
            btnApply.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnApply.IconSize = 52;
            btnApply.Location = new Point(255, 678);
            btnApply.Margin = new Padding(4, 3, 4, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(60, 60);
            btnApply.TabIndex = 8;
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += btnApply_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(68, 195, 52);
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnAdd.IconColor = Color.Black;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.Location = new Point(1046, 640);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(173, 78);
            btnAdd.TabIndex = 11;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(68, 195, 52);
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.Black;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.Location = new Point(688, 640);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(173, 78);
            btnSave.TabIndex = 10;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.FromArgb(68, 195, 52);
            btnDel.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDel.IconColor = Color.Black;
            btnDel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDel.Location = new Point(867, 640);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(173, 78);
            btnDel.TabIndex = 9;
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click_1;
            // 
            // Parlaklik
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1278, 786);
            Controls.Add(btnAdd);
            Controls.Add(btnSave);
            Controls.Add(btnDel);
            Controls.Add(btnApply);
            Controls.Add(btnUndo);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Controls.Add(ıconButton1);
            Controls.Add(afterPic);
            Controls.Add(beforePic);
            Font = new Font("Segoe Script", 9F);
            ForeColor = SystemColors.Control;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Parlaklik";
            Text = "Parlaklik";
            ((System.ComponentModel.ISupportInitialize)afterPic).EndInit();
            ((System.ComponentModel.ISupportInitialize)beforePic).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox afterPic;
        private FontAwesome.Sharp.IconPictureBox beforePic;
        private FontAwesome.Sharp.IconButton ıconButton1;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private FontAwesome.Sharp.IconButton btnUndo;
        private FontAwesome.Sharp.IconButton btnApply;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnDel;
    }
}