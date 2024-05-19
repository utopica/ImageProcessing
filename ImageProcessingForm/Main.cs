using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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
        private Dondurme dondurmeForm = null;
        private Kirpma kirpmaForm = null;
        private Aritmetik aritmetikForm = null;
        private Oran oranForm = null;
        private Esikleme esiklemeForm = null;
        private Histogram histogramForm = null;
        private Gurultu_Filtreleme gurultuForm = null;
        private Morfolojik morfolojikForm = null;
        private Sobel sobelForm = null;
        private RenkUzayı renkUzayıForm = null;
        private Konvolusyon konvolusyonForm = null;
        private Blurring blurringForm = null;

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

           

        }

        private void ResimYukle()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tüm Dosyalar|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                beforePic.Image = null;
                beforePic.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

        


        private void GriDonusum()
        {
            if (beforePic.Image != null)
            {
                Bitmap grayImage = new Bitmap(beforePic.Image.Width, beforePic.Image.Height);

                for (int y = 0; y < beforePic.Image.Height; y++)
                {
                    for (int x = 0; x < beforePic.Image.Width; x++)
                    {
                        Color originalColor = ((Bitmap)beforePic.Image).GetPixel(x, y);
                        int grayValue = (originalColor.R + originalColor.G + originalColor.B) / 3;
                        Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue); //r=g=b olunca gri ton oluyor
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
            if (dondurmeForm == null || dondurmeForm.IsDisposed)
            {
                dondurmeForm = new Dondurme();
                dondurmeForm.FormClosed += DondurmaForm_FormClosed;
            }

            dondurmeForm.Show();

            this.Hide();

        }
        

        private void DondurmaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            dondurmeForm = null;
            this.Show();
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
            if (oranForm == null)
            {
                oranForm = new Oran();
                oranForm.FormClosed += OranForm_FormClosed; // Form kapandığında null yapmak için olaya abone ol
            }

            oranForm.Show();

            this.Hide();
        }

        private void OranForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            oranForm = null; 
            this.Show(); 
        }

        private void RenkUzayiDonusumleri()
        { 
            if (renkUzayıForm == null)
            {
                renkUzayıForm = new RenkUzayı();
                renkUzayıForm.FormClosed += RenkUzayıForm_FormClosed;
            }


            renkUzayıForm.Show();


            this.Hide();
        }

        private void RenkUzayıForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            renkUzayıForm = null; 
            this.Show(); 
        }

        private void HistogramGenisletme()
        {
            if (histogramForm == null)
            {
                histogramForm = new Histogram(defaultImage); 
                histogramForm.FormClosed += HistogramForm_FormClosed;
            }

            histogramForm.Show();
            this.Hide();
        }

        private void HistogramForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            histogramForm = null;
            this.Show();
        }


        private void AritmetikIslemler()
        {

            if (aritmetikForm == null)
            {
                aritmetikForm = new Aritmetik(defaultImage);
                aritmetikForm.FormClosed += AritmetikIslemlerForm_FormClosed;
            }

            aritmetikForm.Show();

            this.Hide();

        }
        private void AritmetikIslemlerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            aritmetikForm = null;
            this.Show();
        }

        private void ParlaklikArtirma()
        {
            if (parlaklikForm == null)
            {
                parlaklikForm = new Parlaklik();
                parlaklikForm.FormClosed += ParlaklikForm_FormClosed; 
            }

            parlaklikForm.Show();

            this.Hide();


        }

        private void ParlaklikForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parlaklikForm = null; 
            this.Show(); 
        }

        private void KonvolusyonIslemi()
        {
            if (konvolusyonForm == null)
            {
                konvolusyonForm = new Konvolusyon(defaultImage);
                konvolusyonForm.FormClosed += KonvolusyonForm_FormClosed;
            }

            konvolusyonForm.Show();
            this.Hide();

        }
        private void KonvolusyonForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            konvolusyonForm = null; 
            this.Show(); 
        }

        private void EsiklemeIslemleri()
        {
            if (esiklemeForm == null)
            {
                esiklemeForm = new Esikleme();
                esiklemeForm.FormClosed += EsiklemeForm_FormClosed;
            }


            esiklemeForm.Show();


            this.Hide();
        }

        private void EsiklemeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            esiklemeForm = null; 
            this.Show(); 
        }


        private void KenarBulma()
        {
            if (sobelForm == null)
            {
                sobelForm = new Sobel(defaultImage); 
                sobelForm.FormClosed += SobelForm_FormClosed;
            }

            sobelForm.Show();
            this.Hide();
        }

        private void SobelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sobelForm = null;
            this.Show();
        }

        private void GurultuEklemeTemizleme()
        {
            if (gurultuForm == null)
            {
                gurultuForm = new Gurultu_Filtreleme(defaultImage);
                gurultuForm.FormClosed += GurultuForm_FormClosed;
            }
            gurultuForm.Show();
            this.Hide();
        }
        private void GurultuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            gurultuForm = null;
            this.Show();
        }

        private void FiltreUygulama()
        {
            if (blurringForm == null)
            {
                blurringForm = new Blurring(defaultImage);
                blurringForm.FormClosed += blurringForm_FormClosed;
            }
            blurringForm.Show();
            this.Hide();
        }

        private void blurringForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            blurringForm = null;
            this.Show();
        }


        private void MorfolojikIslemler()
        {
            if (morfolojikForm == null)
            {
                morfolojikForm = new Morfolojik();
                morfolojikForm.FormClosed += MorfolojikForm_FormClosed;
            }
            morfolojikForm.Show();
            this.Hide();
        }

        private void MorfolojikForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            morfolojikForm = null;
            this.Show();
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

        private void btnStart_Click(object sender, EventArgs e)
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
    }

}

