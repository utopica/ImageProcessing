using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Esikleme : Form
    {
        private Bitmap defaultImage;
        private Bitmap processedImage;
        private int threshold = 128; // Varsayılan eşik değeri
        private int blockSize = 3; // Varsayılan blok boyutu

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

            comboBox1.Items.Add("MEAN");
            comboBox1.Items.Add("MEDIAN");
            comboBox1.Items.Add("GAUSS");
        }



        private void ResimYukle()
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOperation = comboBox1.SelectedItem.ToString();
            switch (selectedOperation)
            {
                case "MEAN":
                    Mean();
                    break;
                case "MEDIAN":
                    Median();
                    break;
                case "GAUSS":
                    Gauss();
                    break;
            }
        }

        private void Mean()
        {
            if (beforePic.Image != null)
            {
                processedImage = new Bitmap(beforePic.Image);

                // Her pikselin değerini eşik değeri ile karşılaştır ve sonucu hesapla
                for (int i = 0; i < processedImage.Width; i++)
                {
                    for (int j = 0; j < processedImage.Height; j++)
                    {
                        Color pixelColor = processedImage.GetPixel(i, j);
                        int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        processedImage.SetPixel(i, j, grayValue < threshold ? Color.Black : Color.White);
                    }
                }

                afterPic.Image = processedImage;
            }
        }

        private void Median()
        {
            if (beforePic.Image != null)
            {
                Bitmap inputImage = new Bitmap(beforePic.Image);
                processedImage = new Bitmap(inputImage.Width, inputImage.Height);

                // Her piksel için blok boyutu içindeki piksel değerlerini bir listeye topla
                for (int x = 0; x < inputImage.Width; x++)
                {
                    for (int y = 0; y < inputImage.Height; y++)
                    {
                        List<int> pixelValues = new List<int>();

                        // Blok boyutu içindeki piksel değerlerini listeye ekle
                        for (int i = x - blockSize / 2; i <= x + blockSize / 2; i++)
                        {
                            for (int j = y - blockSize / 2; j <= y + blockSize / 2; j++)
                            {
                                if (i >= 0 && i < inputImage.Width && j >= 0 && j < inputImage.Height)
                                {
                                    Color pixelColor = inputImage.GetPixel(i, j);
                                    int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                                    pixelValues.Add(grayValue);
                                }
                            }
                        }

                        // Piksel değerlerini sırala ve ortadaki değeri al
                        pixelValues.Sort();
                        int medianValue = pixelValues[pixelValues.Count / 2];
                        processedImage.SetPixel(x, y, medianValue < threshold ? Color.Black : Color.White);
                    }
                }

                afterPic.Image = processedImage;
            }
        }

        private void Gauss()
        {
            if (beforePic.Image != null)
            {
                Bitmap inputImage = new Bitmap(beforePic.Image);
                processedImage = new Bitmap(inputImage.Width, inputImage.Height);

                // Her piksel için Gauss filtresi uygula
                for (int x = 0; x < inputImage.Width; x++)
                {
                    for (int y = 0; y < inputImage.Height; y++)
                    {
                        double sum = 0;
                        double weightSum = 0;

                        // Blok boyutu içindeki piksel değerlerini ve Gauss ağırlıklarını hesapla
                        for (int i = x - blockSize / 2; i <= x + blockSize / 2; i++)
                        {
                            for (int j = y - blockSize / 2; j <= y + blockSize / 2; j++)
                            {
                                if (i >= 0 && i < inputImage.Width && j >= 0 && j < inputImage.Height)
                                {
                                    Color pixelColor = inputImage.GetPixel(i, j);
                                    int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                                    double weight = Math.Exp(-(Math.Pow(i - x, 2) + Math.Pow(j - y, 2)) / (2 * Math.Pow(blockSize / 2, 2)));
                                    sum += grayValue * weight;
                                    weightSum += weight;
                                }
                            }
                        }

                        // Ağırlıklı ortalama piksel değerini al
                        int gaussValue = (int)(sum / weightSum);
                        processedImage.SetPixel(x, y, gaussValue < threshold ? Color.Black : Color.White);
                    }
                }

                afterPic.Image = processedImage;
            }
        }

        private void txtBlokBoyutu_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBlokBoyutu.Text, out blockSize))
            {
                MessageBox.Show("Lütfen geçerli bir blok boyutu girin.");
            }
        }

        private void txtSabitDeger_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSabitDeger.Text, out threshold))
            {
                MessageBox.Show("Lütfen geçerli bir eşik değeri girin.");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedOperation = comboBox1.SelectedItem.ToString();
                switch (selectedOperation)
                {
                    case "MEAN":
                        Mean();
                        break;
                    case "MEDIAN":
                        Median();
                        break;
                    case "GAUSS":
                        Gauss();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir işlem seçin.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
