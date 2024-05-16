using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Blurring : Form
    {
        private Bitmap defaultImage;

        public Blurring(Bitmap mainFormImage)
        {
            InitializeComponent();
            defaultImage = mainFormImage;
            this.StartPosition = FormStartPosition.CenterScreen;

            beforePic.Image = defaultImage;
            afterPic.SizeMode = PictureBoxSizeMode.Zoom;
            beforePic.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void beforePic_Click(object sender, EventArgs e)
        {

        }

        private void afterPic_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int blurSize;
            if (int.TryParse(textBox1.Text, out blurSize))
            {
                try
                {
                    FiltreUygulama(blurSize);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir sayı girin.");
            }
        }
     

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveImage();
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


        private void btnDel_Click(object sender, EventArgs e)
        {

            beforePic.Image = null;
            afterPic.Image = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LoadImage();
            afterPic.Image = null;
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void FiltreUygulama(int blurSize)
        {
            Bitmap imageToProcess = beforePic.Image != null ? new Bitmap(beforePic.Image) : defaultImage;

            // Buraya blurring işlemi uygulama kodunu ekleyin
            Bitmap blurredImage = ApplyBlur(imageToProcess, blurSize);

            // Sonuç görüntüsünü göster
            afterPic.Image = blurredImage;
        }

        // Görüntüye blurring uygulayan fonksiyon
        private Bitmap ApplyBlur(Bitmap image, int kernelSize)
        {
            Bitmap blurredImage = new Bitmap(image.Width, image.Height);

            // Kernel boyutunu kontrol et
            if (kernelSize % 2 == 0)
                throw new ArgumentException("Kernel boyutu tek olmalıdır.");

            int radius = kernelSize / 2;

            // Her piksel için blurring uygula
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    // Pikselin etrafındaki diğer pikselleri topla
                    int totalR = 0, totalG = 0, totalB = 0;
                    int count = 0;

                    for (int offsetY = -radius; offsetY <= radius; offsetY++)
                    {
                        for (int offsetX = -radius; offsetX <= radius; offsetX++)
                        {
                            int newX = x + offsetX;
                            int newY = y + offsetY;

                            // Kenar pikselleri kontrol et
                            if (newX >= 0 && newX < image.Width && newY >= 0 && newY < image.Height)
                            {
                                Color pixel = image.GetPixel(newX, newY);
                                totalR += pixel.R;
                                totalG += pixel.G;
                                totalB += pixel.B;
                                count++;
                            }
                        }
                    }

                    // Ortalama rengi hesapla
                    int avgR = totalR / count;
                    int avgG = totalG / count;
                    int avgB = totalB / count;

                    // Blurred image'e atama yap
                    blurredImage.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                }
            }

            return blurredImage;
        }
        
    }
}
