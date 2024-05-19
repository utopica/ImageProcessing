using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.IO;

using System.IO; 

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Dondurme : Form
    {
        private Bitmap defaultImage;

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

    
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (beforePic.Image != null)
            {
                int angle;
                if (int.TryParse(txtAngle.Text, out angle))
                {
                    Bitmap rotatedImage = RotateImageWithNearestNeighbor((Bitmap)beforePic.Image, angle);
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


        private Bitmap RotateImageWithNearestNeighbor(Bitmap image, int angle)
        {
            double radianAngle = angle * Math.PI / 180.0;
            int width = image.Width;
            int height = image.Height;
            Bitmap rotatedImage = new Bitmap(width, height);

            int centerX = width / 2;
            int centerY = height / 2;

            for (int x = 0; x < width; x++)
            {//orijinal görüntünün merkez koordinatlarını hesaplıyoruz.İç içe döngülerde, her bir pikselin yeni konumunu hesaplamak için nearest uyguluyoruz.


                for (int y = 0; y < height; y++)
                {
                    int newX = (int)(((double)(x - centerX)) * Math.Cos(radianAngle) - ((double)(y - centerY)) * Math.Sin(radianAngle)) + centerX;
                    int newY = (int)(((double)(x - centerX)) * Math.Sin(radianAngle) + ((double)(y - centerY)) * Math.Cos(radianAngle)) + centerY;

                    if (newX >= 0 && newX < width && newY >= 0 && newY < height)
                    {
                        Color nearestColor = image.GetPixel(newX, newY);
                        rotatedImage.SetPixel(x, y, nearestColor);
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
                string imagePath = openFileDialog.FileName;
                Bitmap selectedImage = new Bitmap(imagePath);
                beforePic.Image = selectedImage;
                defaultImage = new Bitmap(selectedImage);
                afterPic.Image = null;
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
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


    }
}

