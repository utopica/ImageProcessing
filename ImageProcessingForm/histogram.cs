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

            // Sadece resim dosyalarını filtrele
            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tüm Dosyalar|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                beforePic.Image = null;
                afterPic.Image = null;
                // Seçilen resmi PictureBox kontrolüne yükle
                beforePic.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void radioGerme_CheckedChanged(object sender, EventArgs e)
        {
            if (beforePic.Image != null)
            {
                Bitmap originalImage = new Bitmap(beforePic.Image);

                // Histogram germe işlevini uygula
                Bitmap stretchedImage = StretchHistogram(originalImage);

                // Gerilmiş görüntüyü göster
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

                // Histogram genişletme işlevini uygula
                Bitmap expandedImage = ExpandHistogram(originalImage);

                // Genişletilmiş görüntüyü göster
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

                    // Histogram germe işlemleri burada gerçekleştirilir

                    int r = pixelColor.R * 2; // Örnek bir germe işlemi (örnektir, ihtiyacınıza göre değiştirin)
                    int g = pixelColor.G * 2;
                    int b = pixelColor.B * 2;

                    r = Math.Min(r, 255); // Renk değerlerini 0-255 aralığında tutar
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

                    // Histogram genişletme işlemleri burada gerçekleştirilir

                    int r = pixelColor.R / 2; // Örnek bir genişletme işlemi (örnektir, ihtiyacınıza göre değiştirin)
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
