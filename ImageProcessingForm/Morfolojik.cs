using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Morfolojik : Form
    {
        private Bitmap originalImage;
        private Bitmap binaryImage;
        private Bitmap afterImage; // Son işlem sonrası oluşan resmi saklamak için değişken

        public Morfolojik()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string imagePath = Path.Combine(parentDirectory, "Images", "girl.jpg");

            originalImage = new Bitmap(imagePath);
            binaryImage = Binary(originalImage); 
            DisplayImageBefore(originalImage); 
            DisplayImageBinary(binaryImage); 

            comboBox1.Items.Add("Genişleme - Dilation");
            comboBox1.Items.Add("Aşınma - Erosion");
            comboBox1.Items.Add("Açma - Opening");
            comboBox1.Items.Add("Kapama - Closing");

          
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOperation = comboBox1.SelectedItem.ToString();
            Bitmap processedImage = null;

            switch (selectedOperation)
            {
                case "Genişleme - Dilation":
                    processedImage = Dilation(binaryImage);
                    break;
                case "Aşınma - Erosion":
                    processedImage = Erosion(binaryImage);
                    break;
                case "Açma - Opening":
                    processedImage = Opening(binaryImage);
                    break;
                case "Kapama - Closing":
                    processedImage = Closing(binaryImage);
                    break;
                default:
                    MessageBox.Show("Geçersiz işlem seçimi.");
                    break;
            }

            if (processedImage != null)
            {
                afterImage = processedImage; // Son işlem sonrası oluşan resmi sakla
                DisplayImage(afterImage); // İşlenmiş resmi göster
            }
        }

        private Bitmap Dilation(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color maxColor = Color.Black;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int newX = x + i;
                            int newY = y + j;

                            if (newX >= 0 && newX < image.Width && newY >= 0 && newY < image.Height)
                            {
                                Color currentColor = image.GetPixel(newX, newY);

                                if (currentColor.R > maxColor.R)
                                    maxColor = currentColor;
                            }
                        }
                    }

                    result.SetPixel(x, y, maxColor);
                }
            }

            return result;
        }

        private Bitmap Erosion(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color minColor = Color.White;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int newX = x + i;
                            int newY = y + j;

                            if (newX >= 0 && newX < image.Width && newY >= 0 && newY < image.Height)
                            {
                                Color currentColor = image.GetPixel(newX, newY);

                                if (currentColor.R < minColor.R)
                                    minColor = currentColor;
                            }
                        }
                    }

                    result.SetPixel(x, y, minColor);
                }
            }

            return result;
        }

        private Bitmap Opening(Bitmap image)
        {
            // Opening işlemi, önce Erosion sonra Dilation işlemi uygulamaktadır.
            Bitmap erodedImage = Erosion(image);
            Bitmap openedImage = Dilation(erodedImage);
            return openedImage;
        }

        private Bitmap Closing(Bitmap image)
        {
            // Closing işlemi, önce Dilation sonra Erosion işlemi uygulamaktadır.
            Bitmap dilatedImage = Dilation(image);
            Bitmap closedImage = Erosion(dilatedImage);
            return closedImage;
        }

        private void beforePic_Click(object sender, EventArgs e)
        {
            DownloadImage();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DownloadImage();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            beforePic.Image = null;
            afterPic.Image = null;
            binaryPic.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void DisplayImageBefore(Bitmap image)
        {
            beforePic.Image = image;
            beforePic.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void DisplayImageBinary(Bitmap image)
        {
            binaryPic.Image = image;
            binaryPic.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void DisplayImage(Bitmap image)
        {
            afterPic.Image = image;
            afterPic.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private Bitmap Binary(Bitmap originalImage)
        {
            Bitmap binaryImage = new Bitmap(originalImage.Width, originalImage.Height);

            // Her bir pikselin renk değerlerinin ortalamasını alarak gri tonlamaya dönüştürme
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);
                    int grayValue = (originalColor.R + originalColor.G + originalColor.B) / 3;
                    Color binaryColor = grayValue > 128 ? Color.White : Color.Black;
                    binaryImage.SetPixel(x, y, binaryColor);
                }
            }

            return binaryImage;
        }

        private void DownloadImage()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tüm Dosyalar|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                beforePic.Image = null;
                afterPic.Image = null;
                binaryPic.Image = null;

                originalImage = new Bitmap(openFileDialog1.FileName);
                binaryImage = Binary(originalImage); // Yeni resme binary işlemi uygula
                DisplayImageBefore(originalImage); // İşlem yapılmış resmi beforePic'te göster
                DisplayImageBinary(binaryImage); // Binary işlemi yapılmış resmi binaryPic'te göster
            }
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
    }
}
