using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Main : Form
    {
        private Bitmap defaultImage;
        public Main()
        {
            InitializeComponent();

            defaultImage = new Bitmap("C:\\Data\\Programming\\ImageProcessing\\ImageProcessingForm\\bin\\Debug\\Images\\girl.png"); // Provide the path to your default image file
            beforePic.Image = defaultImage;
            beforePic.SizeMode = PictureBoxSizeMode.StretchImage;
            

            beforePic.MouseDown += beforePic_MouseDown;

            // ComboBox'a seçenekleri ekleyelim
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
            // Seçilen işlemi işleme fonksiyonuna yönlendir
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
                    GoruntuKirma();
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

        // Her bir işlemi işleyecek fonksiyonları tanımlayalım

        private void GriDonusum()
        {
            // Gri dönüşüm işlemi burada gerçekleştirilecek
            MessageBox.Show("Gri Dönüşüm işlemi seçildi.");
        }

        private void BinaryDonusum()
        {
            // Binary dönüşüm işlemi burada gerçekleştirilecek
            MessageBox.Show("Binary Dönüşüm işlemi seçildi.");
        }

        private void GoruntuDonme()
        {
            // Görüntü döndürme işlemi burada gerçekleştirilecek
            MessageBox.Show("Görüntü Döndürme işlemi seçildi.");
        }

        private void GoruntuKirma()
        {
            // Görüntü kırpma işlemi burada gerçekleştirilecek
            MessageBox.Show("Görüntü Kırpma işlemi seçildi.");
        }

        private void GoruntuYaklastirmaUzaklastirma()
        {
            // Görüntü yaklaştırma/uzaklaştırma işlemi burada gerçekleştirilecek
            MessageBox.Show("Görüntü Yaklaştırma/Uzaklaştırma işlemi seçildi.");
        }

        private void RenkUzayiDonusumleri()
        {
            // Renk uzayı dönüşümleri işlemi burada gerçekleştirilecek
            MessageBox.Show("Renk Uzayı Dönüşümleri işlemi seçildi.");
        }

        private void HistogramGenisletme()
        {
            // Histogram genişletme işlemi burada gerçekleştirilecek
            MessageBox.Show("Histogram Genişletme işlemi seçildi.");
        }

        private void AritmetikIslemler()
        {
            // İki resim arasında aritmetik işlemler işlemi burada gerçekleştirilecek
            MessageBox.Show("İki resim arasında aritmetik işlemler işlemi seçildi.");
        }

        private void ParlaklikArtirma()
        {
            // Parlaklık artırma işlemi burada gerçekleştirilecek
            MessageBox.Show("Parlaklık Artırma işlemi seçildi.");
        }

        private void KonvolusyonIslemi()
        {
            // Konvolüsyon işlemi burada gerçekleştirilecek
            MessageBox.Show("Konvolüsyon İşlemi işlemi seçildi.");
        }

        private void EsiklemeIslemleri()
        {
            // Eşikleme işlemleri işlemi burada gerçekleştirilecek
            MessageBox.Show("Eşikleme İşlemleri işlemi seçildi.");
        }

        private void KenarBulma()
        {
            // Kenar bulma işlemi burada gerçekleştirilecek
            MessageBox.Show("Kenar Bulma işlemi seçildi.");
        }

        private void GurultuEklemeTemizleme()
        {
            // Gürültü ekleme/temizleme işlemi burada gerçekleştirilecek
            MessageBox.Show("Gürültü Ekleme/Temizleme işlemi seçildi.");
        }

        private void FiltreUygulama()
        {
            // Filtre uygulama işlemi burada gerçekleştirilecek
            MessageBox.Show("Filtre Uygulama işlemi seçildi.");
        }

        private void MorfolojikIslemler()
        {
            // Morfolojik işlemler işlemi burada gerçekleştirilecek
            MessageBox.Show("Morfolojik İşlemler işlemi seçildi.");
        }

        private void beforePic_MouseDown(object sender, MouseEventArgs e)
        {
            // Kullanıcı PictureBox'a sol tıkladığında ve sol tıklama ile sürükleme yapılmadığında resim yükle
            if (e.Button == MouseButtons.Left )
            {
                ResimYukle();

            }
        }
    }
}
