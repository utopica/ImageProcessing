using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Blurring : Form
    {
        private Bitmap defaultImage;

        public Blurring(Bitmap mainFormImage)
        {
            InitializeComponent();
            defaultImage = mainFormImage;
            this.StartPosition = FormStartPosition.CenterScreen;

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
            int blurSize;

            if (int.TryParse(textBox1.Text, out blurSize)) // metni tamsayıya dönüştürüp blurSize'a atar
            {
                try
                {
                    FiltreUygulama(blurSize);
                }
                catch (ArgumentException ex) // kernel size çift sayı ise hata fırlatır
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir sayı girin.");
            }
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
                    saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); // varsayılan olarak resimler klasörünü seçer
                    saveDialog.RestoreDirectory = true; // kullanıcının önceki kaydetme konumunu hatırlar

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = saveDialog.FileName; // dosya yolunu alır
                        afterPic.Image.Save(savePath, ImageFormat.Jpeg); // resmi belirtilen yola kaydeder
                        MessageBox.Show("Resim şuraya kaydedildi: " + savePath);
                    }
                }
            }
            else
            {
                MessageBox.Show("Kaydedilecek resim bulunmamaktadır.");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            beforePic.Image = null;
            afterPic.Image = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LoadImage();
            afterPic.Image = null;
        }
        private void LoadImage()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tüm Dosyalar|*.*"; // yalnızca resim dosyalarını seçebilmeyi sağlar
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                beforePic.Image = null; // mevcut resimleri kaldırır
                afterPic.Image = null;

                beforePic.Image = new Bitmap(openFileDialog1.FileName); // seçilen dosyayı pictureboxa yükler
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void FiltreUygulama(int blurSize)
        {
            Bitmap imageToProcess = beforePic.Image != null ? new Bitmap(beforePic.Image) : defaultImage; // beforePic'te resim varsa onu yoksa varsayılan resmi uygular

            Bitmap blurredImage = ApplyBlur(imageToProcess, blurSize); // blurringi uygular ve sonucu değişkene atar

            afterPic.Image = blurredImage; // yeni resmi afterPic'te gösterir
        }

        private Bitmap ApplyBlur(Bitmap image, int radius)
        {
            Bitmap blurredImage = new Bitmap(image.Width, image.Height);   // sonuç görüntüsü için yeni bitmap oluşturur
         
            double[,] diskFilter = CreateDiskFilter(radius);  // Disk filtresini oluşturur

           
            int filterWidth = diskFilter.GetLength(0);          //filtrenin boyutlarnı alır(2 boyutlu matris old)
            int filterHeight = diskFilter.GetLength(1);
            int filterOffset = filterWidth / 2;                //merkez pikselin koordinatını belirler

            for (int y = 0; y < image.Height; y++)       //tüm pikselleri dolaşır
            {
                for (int x = 0; x < image.Width; x++)
                {
                    double totalR = 0, totalG = 0, totalB = 0;      //değişkeler tanımlandı
                    double totalWeight = 0;

                    for (int filterY = 0; filterY < filterHeight; filterY++)    //filtrenin y koordinatlarını dolaşır
                    {
                        for (int filterX = 0; filterX < filterWidth; filterX++)    //filtrenin x koordinatlarını dolaşır
                        {
                            int imageX = x + filterX - filterOffset;    //x=merkezi pikselin x koordinatı ,filterX=filtrenin x eksenindeki pozisyonu ikisini toplayıp filtrenin görüntüdeki yatay yerleşimi hesaplanır 
                            int imageY = y + filterY - filterOffset;     //filtrenin y koordinatını hesaplar

                            if (imageX >= 0 && imageX < image.Width && imageY >= 0 && imageY < image.Height)  //hesaplanan koordinatlarının görüntü sınırları içinde olup olmadığını kontrol eder
                            {
                                Color pixel = image.GetPixel(imageX, imageY);  //piksellerin renk değerlerini alır
                                double weight = diskFilter[filterX, filterY];      //filtredeki ağırlık değerini alır

                                totalR += pixel.R * weight;  //renk bileşenlerini ağırlıkla çarpar ve toplamlarını alır
                                totalG += pixel.G * weight;
                                totalB += pixel.B * weight;
                                totalWeight += weight;
                            }
                        }
                    }

                    int avgR = (int)(totalR / totalWeight);      //kırmızı renk bileşenini hesaplar
                    int avgG = (int)(totalG / totalWeight);
                    int avgB = (int)(totalB / totalWeight);

                    blurredImage.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));  //hesaplanan değerler ile yeni pikseli ayarlar
                }
            }

            return blurredImage;
        }

        private double[,] CreateDiskFilter(int radius)
        {
            int size = radius * 2 + 1;  //matrisin boyutunu belirler
            double[,] filter = new double[size, size];   //filtre matrisini oluşturur
            double radiusSquared = radius * radius;

            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    if (x * x + y * y <= radiusSquared)  //filtrenin disk şeklinde olmasını sağlar
                    {
                        filter[x + radius, y + radius] = 1;
                    }
                }
            }

            // Normalize filter  f,ltrenin doğru şekilde çalışmasını sağlar
            double sum = 0;
            for (int y = 0; y < size; y++)   //filtrenin her elemanını dolaşır ve değerleri toplar
            {
                for (int x = 0; x < size; x++)
                {
                    sum += filter[x, y];
                }
            }
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    filter[x, y] /= sum;  //her elemanı toplam değere böler
                }
            }

            return filter;
        }
    }
}
