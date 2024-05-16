namespace ImageProcessingForm
{
    partial class Histogram
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
            radioGerme = new RadioButton();
            radioGenisletme = new RadioButton();
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
            afterPic.Location = new Point(641, 41);
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
            beforePic.Location = new Point(47, 41);
            beforePic.Margin = new Padding(4, 3, 4, 3);
            beforePic.Name = "beforePic";
            beforePic.Size = new Size(588, 561);
            beforePic.TabIndex = 4;
            beforePic.TabStop = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(68, 195, 52);
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnAdd.IconColor = Color.Black;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.Location = new Point(1091, 661);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 85);
            btnAdd.TabIndex = 14;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(68, 195, 52);
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.Black;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.Location = new Point(819, 661);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 85);
            btnSave.TabIndex = 13;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.FromArgb(68, 195, 52);
            btnDel.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDel.IconColor = Color.Black;
            btnDel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDel.Location = new Point(955, 661);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(130, 85);
            btnDel.TabIndex = 12;
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
            // 
            // radioGerme
            // 
            radioGerme.AutoSize = true;
            radioGerme.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            radioGerme.ForeColor = SystemColors.ButtonHighlight;
            radioGerme.Location = new Point(47, 640);
            radioGerme.Name = "radioGerme";
            radioGerme.Size = new Size(123, 42);
            radioGerme.TabIndex = 24;
            radioGerme.TabStop = true;
            radioGerme.Text = "Germe";
            radioGerme.UseVisualStyleBackColor = true;
            radioGerme.CheckedChanged += radioGerme_CheckedChanged;
            // 
            // radioGenisletme
            // 
            radioGenisletme.AutoSize = true;
            radioGenisletme.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            radioGenisletme.ForeColor = SystemColors.ButtonHighlight;
            radioGenisletme.Location = new Point(47, 703);
            radioGenisletme.Name = "radioGenisletme";
            radioGenisletme.Size = new Size(180, 42);
            radioGenisletme.TabIndex = 25;
            radioGenisletme.TabStop = true;
            radioGenisletme.Text = "Genişletme";
            radioGenisletme.UseVisualStyleBackColor = true;
            radioGenisletme.CheckedChanged += radioGenisletme_CheckedChanged;
            // 
            // Histogram
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1278, 786);
            Controls.Add(radioGenisletme);
            Controls.Add(radioGerme);
            Controls.Add(btnAdd);
            Controls.Add(btnSave);
            Controls.Add(btnDel);
            Controls.Add(afterPic);
            Controls.Add(beforePic);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Histogram";
            Text = "Histogram";
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
        private RadioButton radioGerme;
        private RadioButton radioGenisletme;
    }
}