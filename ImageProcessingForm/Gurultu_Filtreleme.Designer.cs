namespace ImageProcessingForm
{
    partial class Gurultu_Filtreleme
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
            btnStart = new FontAwesome.Sharp.IconButton();
            btnUndo = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            btnDel = new FontAwesome.Sharp.IconButton();
            btnAdd = new FontAwesome.Sharp.IconButton();
            ıconButton1pepper = new FontAwesome.Sharp.IconButton();
            ıconButton2salt = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            radioButton1mean = new RadioButton();
            radioButton1median = new RadioButton();
            ıconButton1saltpepper = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)beforePic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)afterPic).BeginInit();
            SuspendLayout();
            // 
            // beforePic
            // 
            beforePic.Location = new Point(12, 12);
            beforePic.Name = "beforePic";
            beforePic.Size = new Size(588, 561);
            beforePic.TabIndex = 0;
            beforePic.TabStop = false;
            beforePic.Click += beforePic_Click;
            // 
            // afterPic
            // 
            afterPic.Location = new Point(617, 12);
            afterPic.Name = "afterPic";
            afterPic.Size = new Size(588, 561);
            afterPic.TabIndex = 1;
            afterPic.TabStop = false;
            afterPic.Click += afterPic_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(68, 195, 52);
            btnStart.IconChar = FontAwesome.Sharp.IconChar.Broom;
            btnStart.IconColor = Color.Black;
            btnStart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStart.Location = new Point(561, 634);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(91, 90);
            btnStart.TabIndex = 15;
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnUndo
            // 
            btnUndo.BackColor = Color.FromArgb(68, 195, 52);
            btnUndo.IconChar = FontAwesome.Sharp.IconChar.RotateBack;
            btnUndo.IconColor = Color.Black;
            btnUndo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUndo.Location = new Point(682, 634);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(89, 90);
            btnUndo.TabIndex = 16;
            btnUndo.UseVisualStyleBackColor = false;
            btnUndo.Click += btnUndo_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(68, 195, 52);
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.Black;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.Location = new Point(1042, 716);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 69);
            btnSave.TabIndex = 17;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.FromArgb(68, 195, 52);
            btnDel.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDel.IconColor = Color.Black;
            btnDel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDel.Location = new Point(1042, 647);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(124, 63);
            btnDel.TabIndex = 18;
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(68, 195, 52);
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnAdd.IconColor = Color.Black;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.Location = new Point(1042, 579);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(124, 62);
            btnAdd.TabIndex = 19;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // ıconButton1pepper
            // 
            ıconButton1pepper.BackColor = Color.FromArgb(68, 195, 52);
            ıconButton1pepper.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            ıconButton1pepper.IconChar = FontAwesome.Sharp.IconChar.None;
            ıconButton1pepper.IconColor = Color.Black;
            ıconButton1pepper.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconButton1pepper.Location = new Point(79, 730);
            ıconButton1pepper.Name = "ıconButton1pepper";
            ıconButton1pepper.Size = new Size(130, 45);
            ıconButton1pepper.TabIndex = 20;
            ıconButton1pepper.Text = "PEPPER";
            ıconButton1pepper.UseVisualStyleBackColor = false;
            ıconButton1pepper.Click += ıconButton1pepper_Click;
            // 
            // ıconButton2salt
            // 
            ıconButton2salt.BackColor = Color.FromArgb(68, 195, 52);
            ıconButton2salt.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            ıconButton2salt.IconChar = FontAwesome.Sharp.IconChar.None;
            ıconButton2salt.IconColor = Color.Black;
            ıconButton2salt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconButton2salt.Location = new Point(79, 675);
            ıconButton2salt.Name = "ıconButton2salt";
            ıconButton2salt.Size = new Size(130, 49);
            ıconButton2salt.TabIndex = 21;
            ıconButton2salt.Text = "SALT";
            ıconButton2salt.UseVisualStyleBackColor = false;
            ıconButton2salt.Click += ıconButton2salt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(320, 603);
            label1.Name = "label1";
            label1.Size = new Size(128, 38);
            label1.TabIndex = 22;
            label1.Text = "Filtreler:";
            // 
            // radioButton1mean
            // 
            radioButton1mean.AutoSize = true;
            radioButton1mean.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            radioButton1mean.ForeColor = SystemColors.ButtonFace;
            radioButton1mean.Location = new Point(320, 668);
            radioButton1mean.Name = "radioButton1mean";
            radioButton1mean.Size = new Size(112, 42);
            radioButton1mean.TabIndex = 23;
            radioButton1mean.TabStop = true;
            radioButton1mean.Text = "Mean";
            radioButton1mean.UseVisualStyleBackColor = true;
            radioButton1mean.CheckedChanged += radioButton1mean_CheckedChanged;
            // 
            // radioButton1median
            // 
            radioButton1median.AutoSize = true;
            radioButton1median.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            radioButton1median.ForeColor = SystemColors.ButtonFace;
            radioButton1median.Location = new Point(320, 723);
            radioButton1median.Name = "radioButton1median";
            radioButton1median.Size = new Size(137, 42);
            radioButton1median.TabIndex = 24;
            radioButton1median.TabStop = true;
            radioButton1median.Text = "Median";
            radioButton1median.UseVisualStyleBackColor = true;
            radioButton1median.CheckedChanged += radioButton1median_CheckedChanged;
            // 
            // ıconButton1saltpepper
            // 
            ıconButton1saltpepper.BackColor = Color.FromArgb(68, 195, 52);
            ıconButton1saltpepper.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            ıconButton1saltpepper.IconChar = FontAwesome.Sharp.IconChar.None;
            ıconButton1saltpepper.IconColor = Color.Black;
            ıconButton1saltpepper.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconButton1saltpepper.Location = new Point(45, 603);
            ıconButton1saltpepper.Name = "ıconButton1saltpepper";
            ıconButton1saltpepper.Size = new Size(205, 66);
            ıconButton1saltpepper.TabIndex = 25;
            ıconButton1saltpepper.Text = "Salt+Pepper";
            ıconButton1saltpepper.UseVisualStyleBackColor = false;
            ıconButton1saltpepper.Click += ıconButton1saltpepper_Click;
            // 
            // Gurultu_Filtreleme
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1221, 797);
            Controls.Add(ıconButton1saltpepper);
            Controls.Add(radioButton1median);
            Controls.Add(radioButton1mean);
            Controls.Add(label1);
            Controls.Add(ıconButton2salt);
            Controls.Add(ıconButton1pepper);
            Controls.Add(btnAdd);
            Controls.Add(btnDel);
            Controls.Add(btnSave);
            Controls.Add(btnUndo);
            Controls.Add(btnStart);
            Controls.Add(afterPic);
            Controls.Add(beforePic);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Gurultu_Filtreleme";
            Text = "Gurultu_Filtreleme";
            ((System.ComponentModel.ISupportInitialize)beforePic).EndInit();
            ((System.ComponentModel.ISupportInitialize)afterPic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox beforePic;
        private PictureBox afterPic;
        private FontAwesome.Sharp.IconButton btnStart;
        private FontAwesome.Sharp.IconButton btnUndo;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnDel;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton ıconButton1pepper;
        private FontAwesome.Sharp.IconButton ıconButton2salt;
        private Label label1;
        private RadioButton radioButton1mean;
        private RadioButton radioButton1median;
        private FontAwesome.Sharp.IconButton ıconButton1saltpepper;
    }
}