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
    public partial class Gurultu_Filtreleme : Form
    {
        private Bitmap defaultImage;


        public Gurultu_Filtreleme(Bitmap mainFormImage)
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

        private void ıconButton2salt_Click(object sender, EventArgs e)
        {
            Bitmap imageToProcess = beforePic.Image != null ? (Bitmap)beforePic.Image : defaultImage;   //seçilen görüntü varsa onu yoksa varsayılan görüntüyü alır

            if (imageToProcess != null)
            {
                Bitmap saltImage = AddSaltNoise(imageToProcess);
                afterPic.Image = saltImage;
            }
            else
            {
                MessageBox.Show("İşlem yapılacak fotoğraf yok.");
            }
        }
        private Bitmap AddSaltNoise(Bitmap image)
        {
            Random rand = new Random();   //rastgele sayı üretir, rastgele pikselleri seçmek için
            Bitmap saltImage = (Bitmap)image.Clone();
            int noisePercentage = 5;             // Tuz gürültüsünün yüzde oranı

            int noise = (image.Width * image.Height * noisePercentage) / 100;      // Gürültü miktarı hesaplanır

            for (int i = 0; i < noise; i++)         // Rasgele pikselleri seçip beyaz renk (255, 255, 255) yapar
            {
                int x = rand.Next(0, image.Width);
                int y = rand.Next(0, image.Height);
                saltImage.SetPixel(x, y, Color.White);
            }

            return saltImage;
        }

        private void ıconButton1pepper_Click(object sender, EventArgs e)
        {
            Bitmap imageToProcess = beforePic.Image != null ? (Bitmap)beforePic.Image : defaultImage;

            if (imageToProcess != null)
            {
                Bitmap pepperImage = AddPepperNoise(imageToProcess);
                afterPic.Image = pepperImage;
            }
            else
            {
                MessageBox.Show("İşlem yapılacak fotoğraf yok.");
            }
        }
        private Bitmap AddPepperNoise(Bitmap image)
        {
            Random rand = new Random();
            Bitmap pepperImage = (Bitmap)image.Clone();
            int noisePercentage = 5;       // Biber gürültüsünün yüzde oranı

           
            int noise = (image.Width * image.Height * noisePercentage) / 100;    // Gürültü miktarı hesaplanır

            
            for (int i = 0; i < noise; i++)               // Rasgele pikselleri seçip siyah renk (0, 0, 0) yapar
            {
                int x = rand.Next(0, image.Width);
                int y = rand.Next(0, image.Height);
                pepperImage.SetPixel(x, y, Color.Black);
            }

            return pepperImage;
        }

        private void radioButton1mean_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1mean.Checked)
            {
                Bitmap imageToProcess = beforePic.Image != null ? (Bitmap)beforePic.Image : defaultImage;

                if (imageToProcess != null)
                {
                    Bitmap filteredImage = ApplyMeanFilter(imageToProcess);
                    afterPic.Image = filteredImage;
                }
                else
                {
                    MessageBox.Show("İşlem yapılacak fotoğraf yok.");
                }
            }
        }

        private Bitmap ApplyMeanFilter(Bitmap image)         
        {
            Bitmap filteredImage = new Bitmap(image.Width, image.Height);

            for (int y = 1; y < image.Height - 1; y++)             //tüm pikselleri dolaşır
            {
                for (int x = 1; x < image.Width - 1; x++)
                {
                    int totalR = 0, totalG = 0, totalB = 0;

                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            Color pixelColor = image.GetPixel(x + i, y + j);     //piksel rengi alınır

                            //RGB bileşenleri toplanır
                            totalR += pixelColor.R;
                            totalG += pixelColor.G;
                            totalB += pixelColor.B;
                        }
                    }
                    //ortalama değerler hesaplanır, 3x3 matris olduğundan 9'a bölünüyor
                    int avgR = totalR / 9;
                    int avgG = totalG / 9;
                    int avgB = totalB / 9;

                    Color newColor = Color.FromArgb(avgR, avgG, avgB);   //görüntüye uygulanır
                    filteredImage.SetPixel(x, y, newColor);
                }
            }

            return filteredImage;
        }

        private void radioButton1median_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1median.Checked)
            {
                Bitmap imageToProcess = beforePic.Image != null ? (Bitmap)beforePic.Image : defaultImage;

                if (imageToProcess != null)
                {
                    Bitmap filteredImage = ApplyMedianFilter(imageToProcess);
                    afterPic.Image = filteredImage;
                }
                else
                {
                    MessageBox.Show("İşlem yapılacak fotoğraf yok.");
                }
            }
        }

        private Bitmap ApplyMedianFilter(Bitmap image)
        {
            Bitmap filteredImage = new Bitmap(image.Width, image.Height);

            for (int y = 1; y < image.Height - 1; y++)            //tüm pikselleir dolaşır
            {
                for (int x = 1; x < image.Width - 1; x++)
                {
                    List<int> redValues = new List<int>();              //RGB değerleri için listeler oluşturuldu
                    List<int> greenValues = new List<int>();
                    List<int> blueValues = new List<int>();

                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            Color pixelColor = image.GetPixel(x + i, y + j);         //piksel rengini alır
                            redValues.Add(pixelColor.R);            //bileşenler listelere eklenir
                            greenValues.Add(pixelColor.G);
                            blueValues.Add(pixelColor.B);
                        }
                    }

                    redValues.Sort();             //listelerdeki değerler sıralanır
                    greenValues.Sort();
                    blueValues.Sort();

                    int medianR = redValues[4];            //ortanca değerler hesaplanır , 3x3 lük matris olduğunda 4.indis alınır
                    int medianG = greenValues[4];
                    int medianB = blueValues[4];

                    Color newColor = Color.FromArgb(medianR, medianG, medianB);        //yeni renk oluşturulup görüntüye uygulanır
                    filteredImage.SetPixel(x, y, newColor);
                }
            }

            return filteredImage;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Bitmap imageToProcess = beforePic.Image != null ? (Bitmap)beforePic.Image : defaultImage;

            if (imageToProcess != null)
            {
                if (radioButton1mean.Checked)
                {
                    Bitmap meanImage = ApplyMeanFilter(imageToProcess);
                    afterPic.Image = meanImage;
                }
                else if (radioButton1median.Checked)
                {
                    Bitmap medianImage = ApplyMedianFilter(imageToProcess);
                    afterPic.Image = medianImage;
                }
                else
                {
                    MessageBox.Show("Lütfen bir filtre seçin.");
                }
            }
            else
            {
                MessageBox.Show("İşlem yapılacak fotoğraf yok.");
            }
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            afterPic.Image = null;
            beforePic.Image = null;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                afterPic.Image.Save(saveFileDialog1.FileName);
            }

        }

        private void ıconButton1saltpepper_Click(object sender, EventArgs e)
        {
            Bitmap imageToProcess = beforePic.Image != null ? (Bitmap)beforePic.Image : defaultImage;

            if (imageToProcess != null)
            {
                Bitmap saltImage = AddSaltNoise(imageToProcess);
                Bitmap saltPepperImage = AddPepperNoise(saltImage);       // Salt gürültüsü eklenmiş görüntüye biber gürültüsü ekler
                afterPic.Image = saltPepperImage;
            }
            else
            {
                MessageBox.Show("İşlem yapılacak fotoğraf yok.");
            }
        }
    }
}
