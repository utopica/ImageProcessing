using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Sobel : Form
    {
        private Bitmap defaultImage;
        
 

        public Sobel(Bitmap mainFormImage)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            defaultImage = mainFormImage;
            beforePic.Image = defaultImage;
            afterPic.Image = null;
            afterPic.SizeMode = PictureBoxSizeMode.Zoom;
            beforePic.SizeMode = PictureBoxSizeMode.Zoom;

            

        }
        private Bitmap ApplySobelFilter(Bitmap image, string direction, int threshold)
        {
            if (direction == "horizontal")//Yatay yönde Sobel filtresi uygular.
            {
                return ApplyHorizontalSobelFilter(image, threshold);
            }
            else if (direction == "vertical")// Dikey yönde Sobel filtresi uygular.
            {
                return ApplyVerticalSobelFilter(image, threshold);
            }
            else if (direction == "both")//Hem yatay hem de dikey yönde Sobel filtresi uygular.
            {
                return ApplyBothSobelFilter(image, threshold);
            }
            else
            {
                throw new ArgumentException("Invalid direction");
            }
        }

        private Bitmap ApplyHorizontalSobelFilter(Bitmap image, int threshold)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int x = 1; x < image.Width - 1; x++)//Bu döngü, görüntünün genişliği boyunca piksel işlemeye yarar. x değişkeni sütunları temsil eder ve kenar pikselleri hariç tutulur (1den başlayıp image.Width - 1e kadar gider), çünkü kenar piksellerin komşuları eksiktir ve hesaplama yapılamaz.
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    // Sobel yatay matristeki değerlerle çarpılmış halidir
                    int pixelValue = (GetPixelValue(image, x - 1, y - 1) * -1) +
                                     (GetPixelValue(image, x - 1, y) * -2) +
                                     (GetPixelValue(image, x - 1, y + 1) * -1) +
                                     (GetPixelValue(image, x + 1, y - 1)) +
                                     (GetPixelValue(image, x + 1, y) * 2) +
                                     (GetPixelValue(image, x + 1, y + 1));

                    if (pixelValue < threshold)//Hesaplanan pixelValue, belirtilen eşik değerinden küçükse siyah (0) olarak ayarlanır.Eşik değerinden büyükse beyaz(255) olarak ayarlanır.

                    {
                        pixelValue = 0;
                    }
                    else
                    {
                        pixelValue = 255;
                    }

                    result.SetPixel(x, y, Color.FromArgb(pixelValue, pixelValue, pixelValue));//Piksel değeri gri tonlama (grayscale) formunda ayarlanır
                }
            }

            return result;
        }

        private Bitmap ApplyVerticalSobelFilter(Bitmap image, int threshold)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int x = 1; x < image.Width - 1; x++)//Bu döngü, görüntünün genişliği boyunca piksel işlemeye yarar.
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    // Sobel dikey matrisindeki değerlerle çarpılır.
                    int pixelValue = (GetPixelValue(image, x - 1, y - 1) * -1) +
                                     (GetPixelValue(image, x, y - 1) * -2) +
                                     (GetPixelValue(image, x + 1, y - 1) * -1) +
                                     (GetPixelValue(image, x - 1, y + 1)) +
                                     (GetPixelValue(image, x, y + 1) * 2) +
                                     (GetPixelValue(image, x + 1, y + 1));

                    if (pixelValue < threshold)
                    {
                        pixelValue = 0;
                    }
                    else
                    {
                        pixelValue = 255;
                    }

                    result.SetPixel(x, y, Color.FromArgb(pixelValue, pixelValue, pixelValue));
                }
            }

            return result;
        }
        //birer kerede bir pikseli işleyerek görüntü üzerinde hareket ederler ve her bir noktanın yaklaşık gradient (eğim) büyüklüğünü hesaplarlar.
        private Bitmap ApplyBothSobelFilter(Bitmap image, int threshold)
        {
            // İki yönde de filtre uygulanır ve sonuçlar toplanır
            Bitmap horizontalResult = ApplyHorizontalSobelFilter(image, threshold);
            Bitmap verticalResult = ApplyVerticalSobelFilter(image, threshold);

            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    int Gx = horizontalResult.GetPixel(x, y).R;
                    int Gy = verticalResult.GetPixel(x, y).R;

                    // Gradient büyüklüğünü hesapla
                    int G = (int)Math.Sqrt(Gx * Gx + Gy * Gy);

                    // Eşik değerine göre ikili (binary) görüntü oluştur
                    if (G < threshold)
                    {
                        G = 0;
                    }
                    else
                    {
                        G = 255;
                    }

                    result.SetPixel(x, y, Color.FromArgb(G, G, G));
                }
            }

            return result;
        }

        private int GetPixelValue(Bitmap image, int x, int y)
        {
            if (x < 0 || x >= image.Width || y < 0 || y >= image.Height)
            {
                return 0;
            }
            else
            {
                return image.GetPixel(x, y).R;
            }
        }

        private void textBox1esik_TextChanged(object sender, EventArgs e)
        {

        }

        private void beforePic_Click(object sender, EventArgs e)
        {

        }

        private void afterPic_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3both_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3both.Checked)
            {
                radioButton1horizontal.Checked = false;
                radioButton2vertical.Checked = false;
            }
        }

        private void radioButton1horizontal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1horizontal.Checked)
            {
                radioButton2vertical.Checked = false;
                radioButton3both.Checked = false;
            }

        }

        private void radioButton2vertical_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2vertical.Checked)
            {
                radioButton1horizontal.Checked = false;
                radioButton3both.Checked = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
           
            int threshold;
            if (!int.TryParse(textBox1esik.Text, out threshold))
            {
                MessageBox.Show("Geçerli bir eşik değeri giriniz.");
                return;
            }

           
            if (radioButton1horizontal.Checked)
            {
              
                afterPic.Image = ApplySobelFilter(defaultImage, "horizontal", threshold);
            }
            else if (radioButton2vertical.Checked)
            {
                
                afterPic.Image = ApplySobelFilter(defaultImage, "vertical", threshold);
            }
            else if (radioButton3both.Checked)
            {
                
                afterPic.Image = ApplySobelFilter(defaultImage, "both", threshold);
            }
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                string imagePath = openFileDialog.FileName;
                Bitmap selectedImage = new Bitmap(imagePath);

               
                beforePic.Image = selectedImage;

               
                defaultImage = new Bitmap(selectedImage);

            
                afterPic.Image = null;
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

         
            afterPic.Image = null;
            beforePic.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                afterPic.Image.Save(saveFileDialog1.FileName);
            }

        }
    }
}
