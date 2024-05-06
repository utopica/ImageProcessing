namespace ImageProcessingForm
{
    partial class Oran
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
            yakınlastırmaoranı = new Label();
            Uzaklastırma = new Label();
            btnSave = new FontAwesome.Sharp.IconButton();
            btnDel = new FontAwesome.Sharp.IconButton();
            btnAdd = new FontAwesome.Sharp.IconButton();
            yakınlastırmaUpDown = new NumericUpDown();
            uzaklastırmaUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)beforePic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)afterPic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)yakınlastırmaUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uzaklastırmaUpDown).BeginInit();
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
            beforePic.Location = new Point(12, 12);
            beforePic.Margin = new Padding(4, 3, 4, 3);
            beforePic.Name = "beforePic";
            beforePic.Size = new Size(588, 561);
            beforePic.TabIndex = 3;
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
            afterPic.Location = new Point(608, 12);
            afterPic.Margin = new Padding(4, 3, 4, 3);
            afterPic.Name = "afterPic";
            afterPic.Size = new Size(588, 561);
            afterPic.TabIndex = 4;
            afterPic.TabStop = false;
            // 
            // yakınlastırmaoranı
            // 
            yakınlastırmaoranı.AutoSize = true;
            yakınlastırmaoranı.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            yakınlastırmaoranı.ForeColor = SystemColors.ButtonFace;
            yakınlastırmaoranı.Location = new Point(115, 600);
            yakınlastırmaoranı.Name = "yakınlastırmaoranı";
            yakınlastırmaoranı.Size = new Size(202, 28);
            yakınlastırmaoranı.TabIndex = 6;
            yakınlastırmaoranı.Text = "Yakınlaştırma Oranı:";
            // 
            // Uzaklastırma
            // 
            Uzaklastırma.AutoSize = true;
            Uzaklastırma.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Uzaklastırma.ForeColor = SystemColors.ButtonHighlight;
            Uzaklastırma.Location = new Point(115, 663);
            Uzaklastırma.Name = "Uzaklastırma";
            Uzaklastırma.Size = new Size(198, 28);
            Uzaklastırma.TabIndex = 8;
            Uzaklastırma.Text = "Uzaklastırma Oranı:";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(68, 195, 52);
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.Black;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.Location = new Point(641, 600);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(173, 78);
            btnSave.TabIndex = 11;
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.FromArgb(68, 195, 52);
            btnDel.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnDel.IconColor = Color.Black;
            btnDel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDel.Location = new Point(820, 600);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(173, 78);
            btnDel.TabIndex = 12;
            btnDel.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(68, 195, 52);
            btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnAdd.IconColor = Color.Black;
            btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAdd.Location = new Point(999, 600);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(173, 78);
            btnAdd.TabIndex = 13;
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // yakınlastırmaUpDown
            // 
            yakınlastırmaUpDown.BackColor = SystemColors.InactiveCaptionText;
            yakınlastırmaUpDown.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            yakınlastırmaUpDown.ForeColor = SystemColors.InactiveBorder;
            yakınlastırmaUpDown.Location = new Point(323, 605);
            yakınlastırmaUpDown.Name = "yakınlastırmaUpDown";
            yakınlastırmaUpDown.Size = new Size(150, 30);
            yakınlastırmaUpDown.TabIndex = 14;
            yakınlastırmaUpDown.ValueChanged += yakınlastırmaUpDown_ValueChanged;
            // 
            // uzaklastırmaUpDown
            // 
            uzaklastırmaUpDown.BackColor = SystemColors.InactiveCaptionText;
            uzaklastırmaUpDown.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            uzaklastırmaUpDown.ForeColor = SystemColors.Window;
            uzaklastırmaUpDown.Location = new Point(323, 664);
            uzaklastırmaUpDown.Name = "uzaklastırmaUpDown";
            uzaklastırmaUpDown.Size = new Size(150, 30);
            uzaklastırmaUpDown.TabIndex = 15;
            uzaklastırmaUpDown.ValueChanged += uzaklastırmaUpDown_ValueChanged;
            // 
            // Oran
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1207, 738);
            Controls.Add(uzaklastırmaUpDown);
            Controls.Add(yakınlastırmaUpDown);
            Controls.Add(btnAdd);
            Controls.Add(btnDel);
            Controls.Add(btnSave);
            Controls.Add(Uzaklastırma);
            Controls.Add(yakınlastırmaoranı);
            Controls.Add(afterPic);
            Controls.Add(beforePic);
            Name = "Oran";
            Text = "Oran";
            ((System.ComponentModel.ISupportInitialize)beforePic).EndInit();
            ((System.ComponentModel.ISupportInitialize)afterPic).EndInit();
            ((System.ComponentModel.ISupportInitialize)yakınlastırmaUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)uzaklastırmaUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox beforePic;
        private FontAwesome.Sharp.IconPictureBox afterPic;
        private Label yakınlastırmaoranı;
        private Label Uzaklastırma;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnDel;
        private FontAwesome.Sharp.IconButton btnAdd;
        private NumericUpDown yakınlastırmaUpDown;
        private NumericUpDown uzaklastırmaUpDown;
    }
}