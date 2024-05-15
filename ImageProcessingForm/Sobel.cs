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
        private Bitmap beforePicImage;
        private Bitmap originalImage;

        public Sobel(Bitmap mainFormImage)
        {
            InitializeComponent();

            originalImage = mainFormImage;
            this.StartPosition = FormStartPosition.CenterScreen;

            string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            string imagePath = Path.Combine(parentDirectory, "Images", "girl.jpg");

            defaultImage = new Bitmap(imagePath);
            beforePic.Image = defaultImage;
            afterPic.SizeMode = PictureBoxSizeMode.StretchImage;
            beforePic.SizeMode = PictureBoxSizeMode.StretchImage;

            // orijinal görüntüyü bir kopyaya atıyoruz
            beforePicImage = new Bitmap(defaultImage);

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

        }

        private void radioButton1horizontal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2vertical_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnUndo_Click(object sender, EventArgs e)
        {

            // Orijinal resmi sadece beforePic'te göster
            beforePic.Image = new Bitmap(beforePicImage);
            afterPic.Image = originalImage;
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
                beforePicImage = new Bitmap(selectedImage);

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
