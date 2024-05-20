using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Histogram : Form
    {
        private Bitmap defaultImage;

        public Histogram(Bitmap mainFormImage)
        {
            InitializeComponent();

            defaultImage = mainFormImage;
            this.StartPosition = FormStartPosition.CenterScreen;

            beforePic.Image = defaultImage;
            afterPic.SizeMode = PictureBoxSizeMode.Zoom;
            beforePic.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LoadImage();
            afterPic.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            beforePic.Image = null;
            afterPic.Image = null;
        }

        private void SaveImage()
        {
            if (afterPic.Image != null)
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "JPEG Image|*.jpg";
                    saveDialog.Title = "Kaydet";
                    saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    saveDialog.RestoreDirectory = true;

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = saveDialog.FileName;
                        afterPic.Image.Save(savePath, ImageFormat.Jpeg);
                        MessageBox.Show("Resim şuraya kaydedildi :  " + savePath);
                    }
                }
            }
            else
            {
                MessageBox.Show("Kaydedilecek resim bulunmamaktadır.");
            }
        }

        private void LoadImage()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tüm Dosyalar|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                beforePic.Image = null;
                afterPic.Image = null;

                beforePic.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void radioGerme_CheckedChanged(object sender, EventArgs e)
        {
            if (beforePic.Image != null)
            {
                Bitmap originalImage = new Bitmap(beforePic.Image);

                Bitmap stretchedImage = StretchHistogram(originalImage);

                afterPic.Image = stretchedImage;
            }
            else
            {
                MessageBox.Show("Lütfen önce bir resim ekleyin.");
            }
        }

        private void radioGenisletme_CheckedChanged(object sender, EventArgs e)
        {
            if (beforePic.Image != null)
            {
                Bitmap originalImage = new Bitmap(beforePic.Image);

                Bitmap expandedImage = ExpandHistogram(originalImage);

                afterPic.Image = expandedImage;
            }
            else
            {
                MessageBox.Show("Lütfen önce bir resim ekleyin.");
            }
        }

        private Bitmap StretchHistogram(Bitmap originalImage)
        {
            Bitmap stretchedImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);

                    int r = pixelColor.R * 2; 
                    int g = pixelColor.G * 2;
                    int b = pixelColor.B * 2;

                    r = Math.Min(r, 255); 
                    g = Math.Min(g, 255);
                    b = Math.Min(b, 255);

                    Color newPixelColor = Color.FromArgb(r, g, b);
                    stretchedImage.SetPixel(x, y, newPixelColor);
                }
            }

            return stretchedImage;
        }

        private Bitmap ExpandHistogram(Bitmap originalImage)
        {
            Bitmap expandedImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);

                    int r = pixelColor.R / 2; 
                    int g = pixelColor.G / 2;
                    int b = pixelColor.B / 2;

                    Color newPixelColor = Color.FromArgb(r, g, b);
                    expandedImage.SetPixel(x, y, newPixelColor);
                }
            }

            return expandedImage;
        }
    }
}
