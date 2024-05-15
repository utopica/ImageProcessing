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
            if (direction == "horizontal")
            {
                return ApplyHorizontalSobelFilter(image, threshold);
            }
            else if (direction == "vertical")
            {
                return ApplyVerticalSobelFilter(image, threshold);
            }
            else if (direction == "both")
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

            for (int x = 1; x < image.Width - 1; x++)
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    // Sobel operatörleri
                    int pixelValue = (GetPixelValue(image, x - 1, y - 1) * -1) +
                                     (GetPixelValue(image, x - 1, y) * -2) +
                                     (GetPixelValue(image, x - 1, y + 1) * -1) +
                                     (GetPixelValue(image, x + 1, y - 1)) +
                                     (GetPixelValue(image, x + 1, y) * 2) +
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

        private Bitmap ApplyVerticalSobelFilter(Bitmap image, int threshold)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int x = 1; x < image.Width - 1; x++)
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    // Sobel operatörleri
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
                    int pixelValue = (int)Math.Sqrt(Math.Pow(horizontalResult.GetPixel(x, y).R, 2) + Math.Pow(verticalResult.GetPixel(x, y).R, 2));

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
            // Eşik değeri alınır
            int threshold;
            if (!int.TryParse(textBox1esik.Text, out threshold))
            {
                MessageBox.Show("Geçerli bir eşik değeri giriniz.");
                return;
            }

            // Hangi radyo düğmesinin seçildiğini kontrol edin ve Sobel filtresini uygulayın
            if (radioButton1horizontal.Checked)
            {
                // Horizontal Sobel filtresini uygulayın
                afterPic.Image = ApplySobelFilter(defaultImage, "horizontal", threshold);
            }
            else if (radioButton2vertical.Checked)
            {
                // Vertical Sobel filtresini uygulayın
                afterPic.Image = ApplySobelFilter(defaultImage, "vertical", threshold);
            }
            else if (radioButton3both.Checked)
            {
                // Both Sobel filtresini uygulayın
                afterPic.Image = ApplySobelFilter(defaultImage, "both", threshold);
            }
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

        private void btnDel_Click(object sender, EventArgs e)
        {

            // "Delete" butonuna basıldığında burada resmi temizleyebilirsiniz
            afterPic.Image = null;
            beforePic.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // "Save" butonuna basıldığında burada resmi kaydedebilirsiniz
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                afterPic.Image.Save(saveFileDialog1.FileName);
            }

        }
    }
}
