using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Konvolusyon : Form
    {
        private Bitmap defaultImage;
        public Konvolusyon(Bitmap mainFormImage)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            defaultImage = mainFormImage;
            beforePic.Image = defaultImage;
            afterPic.Image = null;
            afterPic.SizeMode = PictureBoxSizeMode.Zoom;
            beforePic.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (defaultImage != null)
            {
                Bitmap filteredImage = ApplyGaussianFilter(defaultImage, 20);
                afterPic.Image = filteredImage;
            }
            else
            {
                MessageBox.Show("Please add an image first.");
            }
        }


        private Bitmap ApplyGaussianFilter(Bitmap image, double sigma)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            double[,] kernel = GenerateGaussianKernel(sigma);

            int kernelWidth = kernel.GetLength(1);
            int kernelHeight = kernel.GetLength(0);
            int kernelOffset = kernelWidth / 2;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    double newValueR = 0;
                    double newValueG = 0;
                    double newValueB = 0;

                    for (int i = 0; i < kernelHeight; i++)
                    {
                        for (int j = 0; j < kernelWidth; j++)
                        {
                            int pixelX = Math.Min(Math.Max(x + j - kernelOffset, 0), image.Width - 1);
                            int pixelY = Math.Min(Math.Max(y + i - kernelOffset, 0), image.Height - 1);
                            Color pixel = image.GetPixel(pixelX, pixelY);
                            double coefficient = kernel[i, j];
                            newValueR += pixel.R * coefficient; // Kırmızı kanal
                            newValueG += pixel.G * coefficient; // Yeşil kanal
                            newValueB += pixel.B * coefficient; // Mavi kanal
                        }
                    }

                    int intValueR = Math.Min(Math.Max((int)newValueR, 0), 255);
                    int intValueG = Math.Min(Math.Max((int)newValueG, 0), 255);
                    int intValueB = Math.Min(Math.Max((int)newValueB, 0), 255);
                    Color newColor = Color.FromArgb(intValueR, intValueG, intValueB);
                    result.SetPixel(x, y, newColor);
                }
            }
            return result;
        }

        private double[,] GenerateGaussianKernel(double sigma)
        {
            int size = 5; // Kernel size, 5x5 (daha büyük bir kernel boyutu)
            double[,] kernel = new double[size, size];
            double coefficient = 1 / (2 * Math.PI * sigma * sigma);
            double sum = 0;

            int kernelOffset = size / 2;

            for (int i = -kernelOffset; i <= kernelOffset; i++)
            {
                for (int j = -kernelOffset; j <= kernelOffset; j++)
                {
                    double exponent = -(i * i + j * j) / (2 * sigma * sigma);
                    kernel[i + kernelOffset, j + kernelOffset] = coefficient * Math.Exp(exponent);
                    sum += kernel[i + kernelOffset, j + kernelOffset];
                }
            }

            // Normalize the kernel
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    kernel[i, j] /= sum;
                }
            }

            return kernel;
        }




        private void beforePic_Click(object sender, EventArgs e)
        {

        }

        private void afterPic_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Kullanıcı tarafından seçilen resmi yükle
                string imagePath = openFileDialog.FileName;
                Bitmap selectedImage = new Bitmap(imagePath);

                // Seçilen resmi beforePic'te göster
                beforePic.Image = selectedImage;

                // Yeni resmi orijinal resim olarak ayarla
                defaultImage = new Bitmap(selectedImage);

                // İşlenmiş görüntüyü temizleyin
                afterPic.Image = null;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // "Save" butonuna basıldığında burada resmi kaydedebilirsiniz
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                afterPic.Image.Save(saveFileDialog1.FileName);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // "Delete" butonuna basıldığında burada resmi temizleyebilirsiniz
            afterPic.Image = null;
            beforePic.Image = null;
        }
    }
}
