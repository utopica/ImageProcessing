namespace ImageProcessingForm
{
    partial class Kirpma
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
            label1 = new Label();
            label2 = new Label();
            lblWidth = new Label();
            lblHeight = new Label();
            txtWidthStart = new TextBox();
            txtHeightStart = new TextBox();
            txtWidthEnd = new TextBox();
            txtHeightEnd = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            btnCrop = new FontAwesome.Sharp.IconButton();
            label5 = new Label();
            btnAdd = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            btnDel = new FontAwesome.Sharp.IconButton();
            btnUndo = new FontAwesome.Sharp.IconButton();
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
            afterPic.Location = new Point(649, 21);
            afterPic.Margin = new Padding(4, 3, 4, 3);
            afterPic.Name = "afterPic";
            afterPic.Size = new Size(588, 561);
            afterPic.TabIndex = 5;
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
            beforePic.TabIndex = 4;
            beforePic.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 11F);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(55, 585);
            label1.Name = "label1";
            label1.Size = new Size(91, 24);
            label1.TabIndex = 6;
            label1.Text = "Genişlik : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11F);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(224, 585);
            label2.Name = "label2";
            label2.Size = new Size(103, 24);
            label2.TabIndex = 7;
            label2.Text = "Yükseklik : ";
            // 
            // lblWidth
            // 
            lblWidth.AutoSize = true;
            lblWidth.Font = new Font("Microsoft Sans Serif", 11F);
            lblWidth.ForeColor = SystemColors.Control;
            lblWidth.Location = new Point(152, 585);
            lblWidth.Name = "lblWidth";
            lblWidth.Size = new Size(20, 24);
            lblWidth.TabIndex = 8;
            lblWidth.Text = "0";
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Font = new Font("Microsoft Sans Serif", 11F);
            lblHeight.ForeColor = SystemColors.Control;
            lblHeight.Location = new Point(333, 585);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(20, 24);
            lblHeight.TabIndex = 9;
            lblHeight.Text = "0";
            // 
            // txtWidthStart
            // 
            txtWidthStart.Font = new Font("Segoe UI", 12F);
            txtWidthStart.Location = new Point(444, 680);
            txtWidthStart.Name = "txtWidthStart";
            txtWidthStart.Size = new Size(138, 34);
            txtWidthStart.TabIndex = 10;
            // 
            // txtHeightStart
            // 
            txtHeightStart.Font = new Font("Segoe UI", 12F);
            txtHeightStart.Location = new Point(444, 726);
            txtHeightStart.Name = "txtHeightStart";
            txtHeightStart.Size = new Size(138, 34);
            txtHeightStart.TabIndex = 11;
            // 
            // txtWidthEnd
            // 
            txtWidthEnd.Font = new Font("Segoe UI", 12F);
            txtWidthEnd.Location = new Point(631, 680);
            txtWidthEnd.Name = "txtWidthEnd";
            txtWidthEnd.Size = new Size(138, 34);
            txtWidthEnd.TabIndex = 12;
            // 
            // txtHeightEnd
            // 
            txtHeightEnd.Font = new Font("Segoe UI", 12F);
            txtHeightEnd.Location = new Point(631, 726);
            txtHeightEnd.Name = "txtHeightEnd";
            txtHeightEnd.Size = new Size(138, 34);
            txtHeightEnd.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(281, 726);
            label6.Name = "label6";
            label6.Size = new Size(126, 31);
            label6.TabIndex = 15;
            label6.Text = "Yükseklik : ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(281, 678);
            label7.Name = "label7";
            label7.Size = new Size(113, 31);
            label7.TabIndex = 16;
            label7.Text = "Genişlik : ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(467, 640);
            label8.Name = "label8";
            label8.Size = new Size(102, 28);
            label8.TabIndex = 17;
            label8.Text = "Başlangıç ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(683, 640);
            label9.Name = "label9";
            label9.Size = new Size(47, 28);
            label9.TabIndex = 18;
            label9.Text = "Son";
            // 
            // btnCrop
            // 
            btnCrop.BackColor = Color.FromArgb(68, 195, 52);
            btnCrop.FlatAppearance.BorderColor = Color.FromArgb(5, 117, 8);
            btnCrop.FlatAppearance.BorderSize = 2;
            btnCrop.FlatStyle = FlatStyle.Flat;
            btnCrop.ForeColor = Color.Transparent;
            btnCrop.IconChar = FontAwesome.Sharp.IconChar.Crop;
            btnCrop.IconColor = Color.Black;
            btnCrop.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCrop.IconSize = 58;
            btnCrop.Location = new Point(843, 680);
            btnCrop.Name = "btnCrop";
            btnCrop.Size = new Size(80, 77);
            btnCrop.TabIndex = 19;
            btnCrop.TextAlign = ContentAlignment.BottomCenter;
            btnCrop.UseVisualStyleBackColor = false;
            btnCrop.Click += btnCrop_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(55, 698);
            label5.Name = "label5";
            label5.Size = new Size(168, 31);
            label5.TabIndex = 14;
            label5.Text = "Kırpılacak Alan";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(68, 195, 52);
            btnAdd.Font = new Font("Segoe UI", 7.8F);
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnAdd.IconColor = Color.Black;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.IconSize = 32;
            btnAdd.Location = new Point(1189, 606);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(48, 49);
            btnAdd.TabIndex = 22;
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
            btnSave.Location = new Point(1189, 716);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(48, 49);
            btnSave.TabIndex = 21;
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
            btnDel.Location = new Point(1189, 661);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(48, 49);
            btnDel.TabIndex = 20;
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
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
            btnUndo.IconSize = 58;
            btnUndo.Location = new Point(937, 680);
            btnUndo.Margin = new Padding(4, 3, 4, 3);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(80, 77);
            btnUndo.TabIndex = 23;
            btnUndo.UseVisualStyleBackColor = false;
            // 
            // Kirpma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1278, 786);
            Controls.Add(btnUndo);
            Controls.Add(btnAdd);
            Controls.Add(btnSave);
            Controls.Add(btnDel);
            Controls.Add(btnCrop);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtHeightEnd);
            Controls.Add(txtWidthEnd);
            Controls.Add(txtHeightStart);
            Controls.Add(txtWidthStart);
            Controls.Add(lblHeight);
            Controls.Add(lblWidth);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(afterPic);
            Controls.Add(beforePic);
            Name = "Kirpma";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kirpma";
            ((System.ComponentModel.ISupportInitialize)afterPic).EndInit();
            ((System.ComponentModel.ISupportInitialize)beforePic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox afterPic;
        private FontAwesome.Sharp.IconPictureBox beforePic;
        private Label label1;
        private Label label2;
        private Label lblWidth;
        private Label lblHeight;
        private TextBox txtWidthStart;
        private TextBox txtHeightStart;
        private TextBox txtWidthEnd;
        private TextBox txtHeightEnd;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private FontAwesome.Sharp.IconButton btnCrop;
        private Label label5;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnDel;
        private FontAwesome.Sharp.IconButton btnUndo;
    }
}