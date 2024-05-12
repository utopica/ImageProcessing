using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class histogram : Form
    {
        private Bitmap defaultImage;
        private Bitmap beforePicImage; // Bu değişken, orijinal görüntünün kopyasını tutacak.
        private string selectedChannel = "Gray"; // Varsayılan olarak Gri (Gray) kanalı seçili
        private string selectedOperationComboBox;

        public histogram(Bitmap mainFormImage)
        {
            InitializeComponent();

            // ComboBox'a seçenekler ekleyelim
            comboBox1.Items.Add("Histogram Germe");
            comboBox1.Items.Add("Histogram Genişletme");

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ComboBox'tan seçilen işlemi al
            string selectedOperation = comboBox1.SelectedItem.ToString();

            // Seçilen işlemi ve kanalı saklayalım
            selectedOperationComboBox = selectedOperation;

            // Eğer bir işlem seçilmediyse işlemi başlatmadan önce bir uyarı gösterelim
            if (selectedOperation == null)
            {
                MessageBox.Show("Lütfen bir işlem seçin.");
                return;
            }
        }

        private Bitmap HistogramStretching(Bitmap image, string channel)
        {
            Bitmap processedImage = new Bitmap(image.Width, image.Height);
            double minGray = 255;
            double maxGray = 0;

            // Min ve max gri ton değerlerini bul
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color originalColor = image.GetPixel(i, j);
                    int grayValue = (int)(originalColor.R * 0.299 + originalColor.G * 0.587 + originalColor.B * 0.114);
                    minGray = Math.Min(minGray, grayValue);
                    maxGray = Math.Max(maxGray, grayValue);
                }
            }

            // Kontrast germe işlemini uygula
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color originalColor = image.GetPixel(i, j);
                    Color processedColor;

                    switch (channel)
                    {
                        case "Gray":
                            int grayValue = (int)(originalColor.R * 0.299 + originalColor.G * 0.587 + originalColor.B * 0.114);
                            int stretchedValue = (int)(((grayValue - minGray) / (maxGray - minGray)) * 255);
                            stretchedValue = Math.Max(0, Math.Min(255, stretchedValue)); // Sınırları kontrol et
                            processedColor = Color.FromArgb(stretchedValue, stretchedValue, stretchedValue);
                            break;
                        default:
                            int channelValue = (int)(originalColor.R * 0.299 + originalColor.G * 0.587 + originalColor.B * 0.114);
                            int stretchedChannelValue = (int)(((channelValue - minGray) / (maxGray - minGray)) * 255);
                            stretchedChannelValue = Math.Max(0, Math.Min(255, stretchedChannelValue)); // Sınırları kontrol et
                            switch (channel)
                            {
                                case "Red":
                                    processedColor = Color.FromArgb(stretchedChannelValue, originalColor.G, originalColor.B);
                                    break;
                                case "Green":
                                    processedColor = Color.FromArgb(originalColor.R, stretchedChannelValue, originalColor.B);
                                    break;
                                case "Blue":
                                    processedColor = Color.FromArgb(originalColor.R, originalColor.G, stretchedChannelValue);
                                    break;
                                default:
                                    processedColor = originalColor;
                                    break;
                            }
                            break;
                    }

                    processedImage.SetPixel(i, j, processedColor);
                }
            }

            return processedImage;
        }


        private Bitmap HistogramExpansion(Bitmap image, string channel)
        {
            Bitmap processedImage = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color originalColor = image.GetPixel(i, j);
                    Color processedColor = Color.Black; // Başlangıçta siyah renk

                    switch (channel)
                    {
                        case "Gray":
                            int grayValue = (int)(originalColor.R * 0.299 + originalColor.G * 0.587 + originalColor.B * 0.114);
                            processedColor = Color.FromArgb(grayValue, grayValue, grayValue);
                            break;
                        case "Red":
                            processedColor = Color.FromArgb(originalColor.R, processedColor.G, processedColor.B);
                            break;
                        case "Green":
                            processedColor = Color.FromArgb(processedColor.R, originalColor.G, processedColor.B);
                            break;
                        case "Blue":
                            processedColor = Color.FromArgb(processedColor.R, processedColor.G, originalColor.B);
                            break;
                        default:
                            processedColor = originalColor;
                            break;
                    }

                    processedImage.SetPixel(i, j, processedColor);
                }
            }

            return processedImage;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            // Renk kanalı seçilmediyse varsayılan olarak Gri (Gray) kanalını kullan
            if (selectedChannel == null)
            {
                MessageBox.Show("Lütfen bir renk kanalı seçin.");
                return;
            }

            // ComboBox'tan seçilen işlemi al
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Önce bir işlem seçin.");
                return;
            }

            // Seçilen işlemi ve kanalı saklayalım
            string selectedOperation = comboBox1.SelectedItem.ToString();
            string selectedImageProcessingChannel = selectedChannel;

            // Sonucu göstermek için UpdateImageProcessing metodunu çağıralım
            UpdateImageProcessing(selectedOperation, selectedImageProcessingChannel);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            // Orijinal resmi sadece beforePic'te göster
            beforePic.Image = new Bitmap(beforePicImage);
            afterPic.Image = null; // afterPic'teki işlenmiş görüntüyü temizle
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            // "Delete" butonuna basıldığında burada resmi temizleyebilirsiniz
            afterPic.Image = null;
            beforePic.Image = null;

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

        private void radioButton1gray_CheckedChanged(object sender, EventArgs e)
        {
            selectedChannel = "Gray";
        }

        private void radioButton2blue_CheckedChanged(object sender, EventArgs e)
        {
            selectedChannel = "Blue";
        }

        private void radioButton1red_CheckedChanged(object sender, EventArgs e)
        {
            selectedChannel = "Red";
        }

        private void radioButton1green_CheckedChanged(object sender, EventArgs e)
        {
            selectedChannel = "Green";
        }

        private void UpdateImageProcessing(string selectedOperation, string selectedChannel)
        {
            Bitmap processedImage = null;

            // Seçilen işleme göre görüntüyü işleyin
            switch (selectedOperation)
            {
                case "Histogram Germe":
                    processedImage = HistogramStretching(beforePicImage, selectedChannel);
                    break;
                case "Histogram Genişletme":
                    processedImage = HistogramExpansion(beforePicImage, selectedChannel);
                    break;
                default:
                    MessageBox.Show("Geçersiz işlem seçimi.");
                    break;
            }

            // İşlenmiş görüntüyü afterPic'te göster
            if (processedImage != null)
            {
                afterPic.Image = processedImage;
            }
        }

    }
}