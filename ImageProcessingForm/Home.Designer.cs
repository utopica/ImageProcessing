namespace ImageProcessingForm
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            ıconButton1 = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            SuspendLayout();
            // 
            // ıconButton1
            // 
            ıconButton1.BackColor = Color.FromArgb(68, 195, 52);
            ıconButton1.IconChar = FontAwesome.Sharp.IconChar.Play;
            ıconButton1.IconColor = Color.Black;
            ıconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconButton1.IconSize = 72;
            ıconButton1.ImageAlign = ContentAlignment.BottomCenter;
            ıconButton1.Location = new Point(563, 347);
            ıconButton1.Name = "ıconButton1";
            ıconButton1.Size = new Size(178, 85);
            ıconButton1.TabIndex = 0;
            ıconButton1.UseVisualStyleBackColor = false;
            ıconButton1.Click += ıconButton1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(430, 173);
            label1.Name = "label1";
            label1.Size = new Size(447, 60);
            label1.TabIndex = 1;
            label1.Text = "IMAGE PROCESSING";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1278, 786);
            Controls.Add(label1);
            Controls.Add(ıconButton1);
            Name = "Home";
            Text = "Home";
            Load += Home_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton ıconButton1;
        private Label label1;
    }
}