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
      
        private void btnStart_Click(object sender, EventArgs e)
        {
            int blurSize;

            if (int.TryParse(textBox1.Text, out blurSize))
            {
                try
                {
                    FiltreUygulama(blurSize);
                }
                catch (ArgumentException ex) 
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
                    saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); 
                    saveDialog.RestoreDirectory = true; 

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = saveDialog.FileName;
                        afterPic.Image.Save(savePath, ImageFormat.Jpeg);
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

            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tüm Dosyalar|*.*"; 
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                beforePic.Image = null; 
                afterPic.Image = null;

                beforePic.Image = new Bitmap(openFileDialog1.FileName);
            }
        }
       
        private void FiltreUygulama(int blurSize)
        {
            if (blurSize % 2 == 0)
            {
                throw new ArgumentException("Radius tek sayı olmalıdır.");
            }
            Bitmap imageToProcess = beforePic.Image != null ? new Bitmap(beforePic.Image) : defaultImage; 

            Bitmap blurredImage = ApplyBlur(imageToProcess, blurSize); 

            afterPic.Image = blurredImage; 
        }
        //Radius (yarıçap) değerine göre disk şeklinde bir bulanıklaştırma filtresi uygular
        private Bitmap ApplyBlur(Bitmap image, int radius)
        {
            Bitmap blurredImage = new Bitmap(image.Width, image.Height); 
         
            double[,] diskFilter = CreateDiskFilter(radius);  

           
            int filterWidth = diskFilter.GetLength(0);      
            int filterHeight = diskFilter.GetLength(1);
            int filterOffset = filterWidth / 2;               //filtrenin merkezine olan uzaklığını belirler

            for (int y = 0; y < image.Height; y++)     
            {
                for (int x = 0; x < image.Width; x++)
                {
                    double totalR = 0, totalG = 0, totalB = 0; 
                    double totalWeight = 0;

                    for (int filterY = 0; filterY < filterHeight; filterY++)   
                    {
                        for (int filterX = 0; filterX < filterWidth; filterX++)    
                        {
                            // Filtrenin resim üzerindeki konumları hesaplanır
                            int imageX = x + filterX - filterOffset;  
                            int imageY = y + filterY - filterOffset;   

                            //filtrenin resmin dışına taşmaması için sınırlar kontrol edilir
                            if (imageX >= 0 && imageX < image.Width && imageY >= 0 && imageY < image.Height)  
                            {
                                Color pixel = image.GetPixel(imageX, imageY);  
                                double weight = diskFilter[filterX, filterY];      

                                totalR += pixel.R * weight; 
                                totalG += pixel.G * weight;
                                totalB += pixel.B * weight;
                                totalWeight += weight;
                            }
                        }
                    }

                    int avgR = (int)(totalR / totalWeight);     
                    int avgG = (int)(totalG / totalWeight);
                    int avgB = (int)(totalB / totalWeight);

                    blurredImage.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));  
                }
            }

            return blurredImage;
        }

        //Belirtilen radius değerine göre disk şeklinde bir filtre oluşturur ve bu filtrenin ağırlıklarını normalleştiri
        private double[,] CreateDiskFilter(int radius)
        {
            int size = radius * 2 + 1; 
            double[,] filter = new double[size, size]; 
            double radiusSquared = radius * radius;

            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    if (x * x + y * y <= radiusSquared)    //filtrenin disk şeklinde olup olmadığını kontrol eder, belirli bir noktanın filtrenin içinde olup olmadığını belirler
                    {
                        filter[x + radius, y + radius] = 1;   //içindeyse değer atanır değilse 0 olarak kalır
                    }
                }
            }

            double sum = 0;
            for (int y = 0; y < size; y++)   
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
                    filter[x, y] /= sum; 
                }
            }

            return filter;
        }
    }
}
