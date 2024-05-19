using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Esikleme : Form
    {
        private Bitmap defaultImage;
        private Bitmap processedImage;

        public Esikleme()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string imagePath = Path.Combine(parentDirectory, "Images", "girl.jpg");
            defaultImage = new Bitmap(imagePath);
            beforePic.Image = defaultImage;
            beforePic.SizeMode = PictureBoxSizeMode.StretchImage;
            beforePic.MouseUp += beforePic_MouseUp;

           
            afterPic.SizeMode = PictureBoxSizeMode.StretchImage;

            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 255; 
        }

        private void ResimYukle()
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

        private void beforePic_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ResimYukle();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResimYukle();
            afterPic.Image = null;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            beforePic.Image = null;
            afterPic.Image = null;
        }

        private void SaveImage()
        {
            if (processedImage != null)
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
                        processedImage.Save(savePath, ImageFormat.Jpeg);
                        MessageBox.Show("Resim şuraya kaydedildi :  " + savePath);
                    }
                }
            }
            else
            {
                MessageBox.Show("Kaydedilecek resim bulunmamaktadır.");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (beforePic.Image == null)
            {
                MessageBox.Show("Lütfen bir resim yükleyin.");
                return;
            }

            int thresholdValue = Convert.ToInt32(numericUpDown1.Value);
            processedImage = AdaptiveThreshold((Bitmap)beforePic.Image, thresholdValue);
            afterPic.Image = processedImage;
        }
       
        //cv2.ADAPTIVE_THRESH_MEAN_C işlevine daha yakındır. cv2.ADAPTIVE_THRESH_MEAN_C, pikselin eşik değerini, pikselin konumu etrafındaki pencere içindeki piksellerin gri tonlama değerlerinin ortalamasına göre belirler.
        
        // bir görüntünün piksellerini belirli bir eşik değer kullanarak siyah ve beyaz değerlere dömüştürme işlemidir
        // her piksel için yerel bir eşik değer kullanarak çalışır,klasik eşikleme de tek bir global eşik değeri kullanılırken adaptif eşiklemede her pikselin komşularını dikkate alarak farklı eşik değerleri kullanılır
        //
        private Bitmap AdaptiveThreshold(Bitmap image, int thresholdValue)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            int windowSize = 15; // Yerel eşikleme için pencere boyutubu 15 olarak belirledik.
            int halfWindow = windowSize / 2;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    // Yerel pencere sınırlarını belirle
                    int minX = Math.Max(0, x - halfWindow);
                    int maxX = Math.Min(image.Width - 1, x + halfWindow);
                    int minY = Math.Max(0, y - halfWindow);
                    int maxY = Math.Min(image.Height - 1, y + halfWindow);

                    int sum = 0;
                    int count = 0;

                    // Yerel pencere içindeki pikselleri topla
                    for (int i = minX; i <= maxX; i++)
                    {
                        for (int j = minY; j <= maxY; j++)
                        {
                            Color pixelColor = image.GetPixel(i, j);
                            int grayScale = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                            sum += grayScale;
                            count++;
                        }
                    }

                    // Yerel eşik değerini hesapla
                    int localThreshold = sum / count;
                    //Piksel değeri eşik değerden büyükse beyaz,küçükse siyah olarak ayarlanır.
                    // Pikseli ikili değerlere dönüştür
                    Color currentPixelColor = image.GetPixel(x, y);
                    int currentGrayScale = (int)(currentPixelColor.R * 0.3 + currentPixelColor.G * 0.59 + currentPixelColor.B * 0.11);

                    if (currentGrayScale > localThreshold - thresholdValue)
                    {
                        result.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        result.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return result;
        }






    }
}
