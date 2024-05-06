using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Oran : Form
    {
        private Bitmap defaultImage;

        public Oran()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            string imagePath = Path.Combine(parentDirectory, "Images", "girl.jpg");

            defaultImage = new Bitmap(imagePath);
            beforePic.Image = defaultImage;

            beforePic.SizeMode = PictureBoxSizeMode.StretchImage;

            beforePic.MouseUp += beforePic_MouseUp;
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

        private Bitmap ZoomImage(Bitmap originalImage, int zoomFactor)
        {
            // Yakınlaştırma/uzaklaştırma faktörüne göre yeni boyutları hesapla
            int newWidth = originalImage.Width + zoomFactor;
            int newHeight = originalImage.Height + zoomFactor;

            // Yeni boyutlara göre bir Bitmap oluştur
            Bitmap zoomedImage = new Bitmap(newWidth, newHeight);

            // Yakınlaştırma/uzaklaştırma işlemini gerçekleştir
            using (Graphics g = Graphics.FromImage(zoomedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, new Rectangle(0, 0, newWidth, newHeight));
            }

            // Yakınlaştırılmış/uzaklaştırılmış resmi döndür
            return zoomedImage;
        }

        private void yakınlastırmaUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (beforePic.Image != null)
            {
                // Yakınlaştırma faktörünü al
                int zoomFactor = (int)yakınlastırmaUpDown.Value;

                // Yakınlaştırma işlemi
                Bitmap originalImage = beforePic.Image as Bitmap;
                Bitmap zoomedImage = ZoomImage(originalImage, zoomFactor);

                // Yakınlaştırılmış resmi göster
                afterPic.Image = zoomedImage;
            }
        }

        private void uzaklastırmaUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (beforePic.Image != null)
            {
                // Uzaklaştırma faktörünü al
                int zoomFactor = -(int)uzaklastırmaUpDown.Value;

                // Uzaklaştırma işlemi
                Bitmap originalImage = beforePic.Image as Bitmap;
                Bitmap zoomedImage = ZoomImage(originalImage, zoomFactor);

                // Uzaklaştırılmış resmi göster
                afterPic.Image = zoomedImage;
            }
        }


    }
}
