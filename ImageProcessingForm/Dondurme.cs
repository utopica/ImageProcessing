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
    public partial class Dondurme : Form
    {
        private Bitmap defaultImage;
        
        //private Bitmap originalImage;
        public Dondurme()
        {
            InitializeComponent();

            
            this.StartPosition = FormStartPosition.CenterScreen;

            string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            string imagePath = Path.Combine(parentDirectory, "Images", "girl.jpg");

            defaultImage = new Bitmap(imagePath);
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
            if (beforePic.Image != null)
            {
                // Döndürme açısını al
                int angle;
                if (int.TryParse(txtAngle.Text, out angle))
                {
                    // Resmi döndür
                    Bitmap rotatedImage = RotateImage((Bitmap)beforePic.Image, angle);

                    // PictureBox'ta döndürülmüş resmi göster
                    afterPic.Image = rotatedImage;
                }
                else
                {
                    MessageBox.Show("Geçersiz açı değeri.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir resim yükleyin.");
            }
        }


        private Bitmap RotateImage(Bitmap image, int angle)
        {
            // Radyan cinsinden açıyı hesapla
            double radianAngle = angle * Math.PI / 180.0;

            // Resmin boyutlarını al
            int width = image.Width;
            int height = image.Height;

            // Yeni bir boş resim oluştur
            Bitmap rotatedImage = new Bitmap(width, height);

            // Döndürülmüş resmi oluştur
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Yeni koordinatları hesapla
                    int newX = (int)(Math.Cos(radianAngle) * (x - width / 2) - Math.Sin(radianAngle) * (y - height / 2) + width / 2);
                    int newY = (int)(Math.Sin(radianAngle) * (x - width / 2) + Math.Cos(radianAngle) * (y - height / 2) + height / 2);

                    // Kenar kontrolü yap
                    if (newX >= 0 && newX < width && newY >= 0 && newY < height)
                    {
                        rotatedImage.SetPixel(x, y, image.GetPixel(newX, newY));
                    }
                }
            }

            return rotatedImage;
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
            afterPic.Image = null;
            beforePic.Image = null;

        }

        private void txtAngle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
