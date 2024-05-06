using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Main : Form
    {
        private Bitmap defaultImage;
        private Parlaklik parlaklikForm = null;
        private Kirpma kirpmaForm = null;
        private Oran oranForm=null;
        public Main()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            string imagePath = Path.Combine(parentDirectory, "Images", "girl.jpg");

            defaultImage = new Bitmap(imagePath); 
            beforePic.Image = defaultImage;
            afterPic.Image = defaultImage;
            afterPic.SizeMode = PictureBoxSizeMode.StretchImage;
            beforePic.SizeMode = PictureBoxSizeMode.StretchImage;

            beforePic.MouseUp += beforePic_MouseUp;

            comboBox1.Items.Add("Gri Dönüşüm");
            comboBox1.Items.Add("Binary Dönüşüm");
            comboBox1.Items.Add("Görüntü Döndürme");
            comboBox1.Items.Add("Görüntü Kırpma");
            comboBox1.Items.Add("Görüntü Yaklaştırma/Uzaklaştırma");
            comboBox1.Items.Add("Renk Uzayı Dönüşümleri");
            comboBox1.Items.Add("Giriş görüntüsüne ait histogram ve orjinal görüntü histogramını germe/genişletme");
            comboBox1.Items.Add("İki resim arasında aritmetik işlemler (ekleme, çarpma)");
            comboBox1.Items.Add("Parlaklık artırma");
            comboBox1.Items.Add("Konvolüsyon İşlemi (gauss)");
            comboBox1.Items.Add("Eşikleme işlemleri (Adaptif Eşikleme)");
            comboBox1.Items.Add("Kenar Bulma Algoritmalarının Kullanımı (sobel)");
            comboBox1.Items.Add("Görüntüye Gürültü Ekleme (Salt&Pepper) ve filtrelerin kullanımı (mean, median) ile gürültü temizleme");
            comboBox1.Items.Add("Görüntüye Filtre Uygulanması (Blurring)");
            comboBox1.Items.Add("Morfolojik İşlemler (Genişleme, Aşınma, Açma, Kapama)");

            // ComboBox'ın SelectedIndexChanged olayını dinleyelim
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;


        }

        private void ResimYukle()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Sadece resim dosyalarını filtrele
            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tüm Dosyalar|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                beforePic.Image = null;
                // Seçilen resmi PictureBox kontrolüne yükle
                beforePic.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedOperation = comboBox1.SelectedItem.ToString();
            switch (selectedOperation)
            {
                case "Gri Dönüşüm":
                    GriDonusum();
                    break;
                case "Binary Dönüşüm":
                    BinaryDonusum();
                    break;
                case "Görüntü Döndürme":
                    GoruntuDonme();
                    break;
                case "Görüntü Kırpma":
                    GoruntuKirpma();
                    break;
                case "Görüntü Yaklaştırma/Uzaklaştırma":
                    GoruntuYaklastirmaUzaklastirma();
                    break;
                case "Renk Uzayı Dönüşümleri":
                    RenkUzayiDonusumleri();
                    break;
                case "Giriş görüntüsüne ait histogram ve orjinal görüntü histogramını germe/genişletme":
                    HistogramGenisletme();
                    break;
                case "İki resim arasında aritmetik işlemler (ekleme, çarpma)":
                    AritmetikIslemler();
                    break;
                case "Parlaklık artırma":
                    ParlaklikArtirma();
                    break;
                case "Konvolüsyon İşlemi (gauss)":
                    KonvolusyonIslemi();
                    break;
                case "Eşikleme işlemleri (Adaptif Eşikleme)":
                    EsiklemeIslemleri();
                    break;
                case "Kenar Bulma Algoritmalarının Kullanımı (sobel)":
                    KenarBulma();
                    break;
                case "Görüntüye Gürültü Ekleme (Salt&Pepper) ve filtrelerin kullanımı (mean, median) ile gürültü temizleme":
                    GurultuEklemeTemizleme();
                    break;
                case "Görüntüye Filtre Uygulanması (Blurring)":
                    FiltreUygulama();
                    break;
                case "Morfolojik İşlemler (Genişleme, Aşınma, Açma, Kapama)":
                    MorfolojikIslemler();
                    break;
                default:
                    MessageBox.Show("Geçersiz işlem seçimi.");
                    break;
            }
        }


        private void GriDonusum()
        {
            if (beforePic.Image != null)
            {
                Bitmap grayImage = new Bitmap(beforePic.Image.Width, beforePic.Image.Height);

                // Her bir pikselin renk değerlerinin ortalamasını alarak gri tonlamaya dönüştürme
                for (int y = 0; y < beforePic.Image.Height; y++)
                {
                    for (int x = 0; x < beforePic.Image.Width; x++)
                    {
                        Color originalColor = ((Bitmap)beforePic.Image).GetPixel(x, y);
                        int grayValue = (originalColor.R + originalColor.G + originalColor.B) / 3;
                        Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                        grayImage.SetPixel(x, y, grayColor);
                    }
                }

                afterPic.Image = grayImage;
            }
            else
            {
                MessageBox.Show("İşlem yapılacak fotoğraf yok.");
            }
        }


        private void BinaryDonusum()
        {
            if (beforePic.Image != null)
            {
                Bitmap binaryImage = new Bitmap(beforePic.Image.Width, beforePic.Image.Height);

                // Her bir pikselin renk değerlerinin ortalamasını alarak gri tonlamaya dönüştürme
                for (int y = 0; y < beforePic.Image.Height; y++)
                {
                    for (int x = 0; x < beforePic.Image.Width; x++)
                    {
                        Color originalColor = ((Bitmap)beforePic.Image).GetPixel(x, y);
                        int grayValue = (originalColor.R + originalColor.G + originalColor.B) / 3;
                        Color binaryColor = grayValue > 128 ? Color.White : Color.Black;
                        binaryImage.SetPixel(x, y, binaryColor);
                    }
                }

                afterPic.Image = binaryImage;
            }
            else
            {
                MessageBox.Show("İşlem yapılacak fotoğraf yok.");
            }

        }

        private void GoruntuDonme()
        {

        }

        private void GoruntuKirpma()
        {
            if (kirpmaForm == null)
            {
                kirpmaForm = new Kirpma();
                kirpmaForm.FormClosed += KirpmaForm_FormClosed; 
            }

            kirpmaForm.Show();

            this.Hide();

            
        }

        private void KirpmaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            kirpmaForm = null; 
            this.Show(); 
        }



        private void GoruntuYaklastirmaUzaklastirma()
        {
            // Eğer oran formu daha önce oluşturulmadıysa, oluştur
            if (oranForm == null)
            {
                oranForm = new Oran();
                oranForm.FormClosed += OranForm_FormClosed; // Form kapandığında null yapmak için olaya abone ol
            }

            // Oran formunu göster
            oranForm.Show();

            // Ana formu gizle
            this.Hide();
        }

        private void OranForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            oranForm = null; // Form kapandığında null yap
            this.Show(); // Ana formu göster
        }

        private void RenkUzayiDonusumleri()
        {
            if (beforePic.Image != null)
            {
                Bitmap ycbcrImage = new Bitmap(beforePic.Image.Width, beforePic.Image.Height);

                for (int y = 0; y < beforePic.Image.Height; y++)
                {
                    for (int x = 0; x < beforePic.Image.Width; x++)
                    {
                        Color originalColor = ((Bitmap)beforePic.Image).GetPixel(x, y);

                        // RGB değerlerini al
                        int R = originalColor.R;
                        int G = originalColor.G;
                        int B = originalColor.B;

                        // YCbCr dönüşüm formülleri
                        int Y = (int)(0.299 * R + 0.587 * G + 0.114 * B);
                        int Cb = (int)(128 - 0.168736 * R - 0.331264 * G + 0.5 * B);
                        int Cr = (int)(128 + 0.5 * R - 0.418688 * G - 0.081312 * B);

                        // Yeni renk oluştur ve YCbCr resmine ekle
                        Color ycbcrColor = Color.FromArgb(Y, Cb, Cr);
                        ycbcrImage.SetPixel(x, y, ycbcrColor);
                    }
                }

                afterPic.Image = ycbcrImage;
            }
            else
            {
                MessageBox.Show("There is no image to process.");
            }
        }


        private void HistogramGenisletme()
        {

        }

        private void AritmetikIslemler()
        {

        }

        private void ParlaklikArtirma()
        {
            if (parlaklikForm == null)
            {
                parlaklikForm = new Parlaklik();
                parlaklikForm.FormClosed += ParlaklikForm_FormClosed; // Form kapandığında null yapmak için olaya abone ol
            }

            parlaklikForm.Show();

            // Ana formu gizle
            this.Hide();

            // Formu göster
            
        }

        private void ParlaklikForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parlaklikForm = null; // Form kapandığında null yap
            this.Show(); // Ana formu göster
        }

        private void KonvolusyonIslemi()
        {

        }

        private void EsiklemeIslemleri()
        {

        }

        private void KenarBulma()
        {

        }

        private void GurultuEklemeTemizleme()
        {

        }

        private void FiltreUygulama()
        {
        }

        private void MorfolojikIslemler()
        {

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


    }

}

