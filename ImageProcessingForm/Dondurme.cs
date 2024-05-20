using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace ImageProcessingForm
{
    public partial class Dondurme : Form
    {
        private Bitmap defaultImage;
        //Yeni piksel değeri döndürme matrisi yardımı ile elde edilir
        /* nearest ile çıkış görüntüsündeki her pikselin
        değeri, giriş görüntüsündeki en yakın pikselin değeri alınarak
        belirlenir.
        */
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

            int newWidth = (int)(Math.Abs(width * Math.Cos(radianAngle)) + Math.Abs(height * Math.Sin(radianAngle)));
            int newHeight = (int)(Math.Abs(width * Math.Sin(radianAngle)) + Math.Abs(height * Math.Cos(radianAngle)));


            Bitmap rotatedImage = new Bitmap(newWidth, newHeight);

            int centerX = width / 2;
            int centerY = height / 2;
            int newCenterX = newWidth / 2;
            int newCenterY = newHeight / 2;

            for (int x = 0; x < newWidth; x++)
            {
                for (int y = 0; y < newHeight; y++)
                {
                    int originalX = (int)(((x - newCenterX) * Math.Cos(-radianAngle)) - ((y - newCenterY) * Math.Sin(-radianAngle)) + centerX);
                    int originalY = (int)(((x - newCenterX) * Math.Sin(-radianAngle)) + ((y - newCenterY) * Math.Cos(-radianAngle)) + centerY);

                    if (originalX >= 0 && originalX < width && originalY >= 0 && originalY < height)
                    {
                        Color nearestColor = image.GetPixel(originalX, originalY);
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

