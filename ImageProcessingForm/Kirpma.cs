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
    public partial class Kirpma : Form
    {
        private Bitmap originalImage;
        private Bitmap croppedImage;
        public Kirpma()
        {
            InitializeComponent();

            string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            string imagePath = Path.Combine(parentDirectory, "Images", "girl.jpg");

            originalImage = new Bitmap(imagePath);

            DisplayImage(originalImage);



        }
        private void DisplayImage(Bitmap image)
        {
            beforePic.Image = image;

            beforePic.SizeMode = PictureBoxSizeMode.Zoom;

            if (beforePic.Image != null)
            {
                lblWidth.Text = beforePic.Image.Width.ToString();
                lblHeight.Text = beforePic.Image.Height.ToString();
            }
            else
            {
                lblWidth.Text = "0";
                lblHeight.Text = "0";
            }



        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResimYukle();
            afterPic.Image = null;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            beforePic.Image = null;
            afterPic.Image = null;
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
                    saveDialog.Title = "Save Image";
                    saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    saveDialog.RestoreDirectory = true;

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = saveDialog.FileName;
                        afterPic.Image.Save(savePath, ImageFormat.Jpeg);
                        MessageBox.Show("Image saved successfully to: " + savePath);
                    }
                }
            }
            else
            {
                MessageBox.Show("There is no image to save.");
            }
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

        private void txtWidthStart_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtWidthEnd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHeightStart_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHeightEnd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            int startX = int.Parse(txtWidthStart.Text);
            int startY = int.Parse(txtHeightStart.Text);
            int endX = int.Parse(txtWidthEnd.Text);
            int endY = int.Parse(txtHeightEnd.Text);

            CropImage(startX, startY, endX, endY);
        }

        private void CropImage(int startX, int startY, int endX, int endY)
        {
            // Başlangıç ve bitiş değerlerini kontrol edin
            if (startX < 0 || startY < 0 || endX >= beforePic.Image.Width || endY >= beforePic.Image.Height)
            {
                MessageBox.Show("Invalid crop parameters.");
                return;
            }

            // Yeni kırpılmış resmi oluşturun
            int width = endX - startX + 1;
            int height = endY - startY + 1;
            croppedImage = new Bitmap(width, height);

            // Yeni resmi oluşturulan aralıkta kırpın
            for (int y = startY; y <= endY; y++)
            {
                for (int x = startX; x <= endX; x++)
                {
                    Color pixelColor = ((Bitmap)beforePic.Image).GetPixel(x, y);
                    croppedImage.SetPixel(x - startX, y - startY, pixelColor);
                }
            }

            // Kırpılmış resmi afterPic PictureBox'ına yükleyin
            afterPic.Image = croppedImage;
        }
    }
}
