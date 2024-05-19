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
                // Kullanıcıdan sigma değerini alma
                if (double.TryParse(textBox2.Text, out double sigma) && int.TryParse(textBox1.Text, out int kernelSize))
                {
                    if (kernelSize % 2 == 0)
                    {
                        MessageBox.Show("Kernel boyutu tek sayı olmalıdır.");
                        return;
                    }

                    Bitmap filteredImage = ApplyGaussianFilter(defaultImage, sigma, kernelSize);
                    afterPic.Image = filteredImage;
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir sigma ve kernel boyutu değeri girin.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce bir resim ekleyin.");
            }
        }


        private Bitmap ApplyGaussianFilter(Bitmap image, double sigma=1.0, int kernelSize=3)
        {   // dışardan da sigma ve kernelsize alabilir ama girilmezse varsayılan olarak tanımlanmıştır
            Bitmap result = new Bitmap(image.Width, image.Height);//defaultImagenin yükseklik genişlik değerleri
            double[,] kernel = GenerateGaussianKernel(sigma, kernelSize);
            //kernel oluşturma fonksiyonu

            int kernelWidth = kernel.GetLength(1); // kernelin sütun sayısı
            int kernelHeight = kernel.GetLength(0); // kernelin satır sayısı
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
                            //math.max X koordinatının 0'dan küçük olmamasını sağlar. Yani, görüntünün sol kenarının dışına çıkmasını engeller
                            //math.min görüntünün sağ kenarının dışına çıkmasını engeller
                            int pixelY = Math.Min(Math.Max(y + i - kernelOffset, 0), image.Height - 1);
                            //math.max Y koordinatının 0'dan küçük olmamasını sağlar. Yani, görüntünün üst kenarının dışına çıkmasını engeller
                            Color pixel = image.GetPixel(pixelX, pixelY);//belirtilen koodinatlardaki pixelin rengini color nesnesi olarak alıyor
                            double coefficient = kernel[i, j]; //kernelin belirtilen koordinatlarındaki katsayısı coefficiente eşitliyor
                            newValueR += pixel.R * coefficient; 
                            newValueG += pixel.G * coefficient;
                            newValueB += pixel.B * coefficient;
                        }
                    }
                    /*rgb nin new value ları ilk önce sıfırdan düşükse 0 a eşitliyor
                     daha sonra 255 ten büyükse 255 e eşitliyor katsayıyla çarpılmış piksellerle
                     yeni bir color nesnesi oluşturuyor result.setpixel kısmında belirtilen 
                     koordinatlara yeni renk değerlerini yerleştiriyor
                     */
                    int intValueR = Math.Min(Math.Max((int)newValueR, 0), 255);
                    int intValueG = Math.Min(Math.Max((int)newValueG, 0), 255);
                    int intValueB = Math.Min(Math.Max((int)newValueB, 0), 255);
                    Color newColor = Color.FromArgb(intValueR, intValueG, intValueB);
                    result.SetPixel(x, y, newColor);
                }
            }
            return result;
        }


        private double[,] GenerateGaussianKernel(double sigma, int size)
        {
            double[,] kernel = new double[size, size];
            double coefficient = 1 / (2 * Math.PI * sigma * sigma); // normallik katsayısını formülle bulma
            double sum = 0;

            int kernelOffset = size / 2; 

            for (int i = -kernelOffset; i <= kernelOffset; i++)
            {
                for (int j = -kernelOffset; j <= kernelOffset; j++)//kernelin içini geziyor
                {
                    double exponent = -(i * i + j * j) / (2 * sigma * sigma); // kernelin bulunduğu konuma göre  formülün üstel kısmını yapıyor
                    kernel[i + kernelOffset, j + kernelOffset] = coefficient * Math.Exp(exponent);// üstel kısmı yapıyor
                    //cofficient ile üstel kısmı çarpıp kernelin belirli pikseline yerleştiriyor
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
