using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Aritmetik : Form
    {
        private Bitmap defaultImage;
        private Bitmap resim1;
        private Bitmap resim2;

        public Aritmetik(Bitmap mainFormImage)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            btnAdd.Click += btnAdd_Click;
            btnDel.Click += btnDel_Click;
            

            // Belirli bir resmi defaultImage'a yükleme
            defaultImage = mainFormImage;

            // PictureBox'ların boyutlandırılması
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;

            // Varsayılan resmin gösterimi
            pictureBox1.Image = defaultImage;
            pictureBox2.Image = defaultImage;
        }

        private Bitmap Toplama(Bitmap resim1, Bitmap resim2)
        {
            Bitmap sonuc = new Bitmap(resim1.Width, resim1.Height);

            for (int x = 0; x < resim1.Width; x++)
            {
                for (int y = 0; y < resim1.Height; y++)
                {
                    Color piksel1 = resim1.GetPixel(x, y);
                    Color piksel2 = resim2.GetPixel(x, y);

                    int yeniRed = Math.Min(255, piksel1.R + piksel2.R);
                    int yeniGreen = Math.Min(255, piksel1.G + piksel2.G);
                    int yeniBlue = Math.Min(255, piksel1.B + piksel2.B);

                    sonuc.SetPixel(x, y, Color.FromArgb(yeniRed, yeniGreen, yeniBlue));
                }
            }

            return sonuc;
        }

        private Bitmap Carpma(Bitmap resim1, Bitmap resim2)
        {
            Bitmap sonuc = new Bitmap(resim1.Width, resim1.Height);

            for (int x = 0; x < resim1.Width; x++)
            {
                for (int y = 0; y < resim1.Height; y++)
                {
                    Color piksel1 = resim1.GetPixel(x, y);
                    Color piksel2 = resim2.GetPixel(x, y);

                    int yeniRed = (int)(((double)piksel1.R / 255) * piksel2.R);
                    int yeniGreen = (int)(((double)piksel1.G / 255) * piksel2.G);
                    int yeniBlue = (int)(((double)piksel1.B / 255) * piksel2.B);

                    sonuc.SetPixel(x, y, Color.FromArgb(yeniRed, yeniGreen, yeniBlue));
                }
            }

            return sonuc;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap yuklenenResim = new Bitmap(openFileDialog.FileName);

                // İlk olarak resim1'e yüklenir
                if (resim1 == null)
                {
                    resim1 = yuklenenResim;
                    pictureBox1.Image = resim1;
                }
                // İkinci olarak resim2'ye yüklenir
                else
                {
                    resim2 = yuklenenResim;
                    pictureBox2.Image = resim2;

                    // Resim 1 ve Resim 2 boyutları eşitlenir
                    if (resim1.Size != resim2.Size)
                    {
                        resim2 = new Bitmap(resim2, resim1.Size);
                        pictureBox2.Image = resim2;
                    }
                }
            }
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            Bitmap image1 = resim1 ?? defaultImage;
            Bitmap image2 = resim2 ?? defaultImage;

            pictureBox3.Image = Toplama(image1, image2);
        }

        private void BtnMultiply_Click(object sender, EventArgs e)
        {
            Bitmap image1 = resim1 ?? defaultImage;
            Bitmap image2 = resim2 ?? defaultImage;

            pictureBox3.Image = Carpma(image1, image2);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // Resim1 ve Resim2'nin içeriği temizlenir
            resim1 = null;
            resim2 = null;

            // Picture box'lardaki resimler temizlenir
            pictureBox1.Image = defaultImage;
            pictureBox2.Image = defaultImage;

            // pictureBox3'teki resim de temizlenir
            pictureBox3.Image = null;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|BMP Image|*.bmp";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Resmi kaydetme
                    pictureBox3.Image.Save(filePath);

                    MessageBox.Show("Resim başarıyla kaydedildi.");
                }
            }
            else
            {
                MessageBox.Show("Kaydedilecek resim bulunamadı.");
            }
        }
    }
}
