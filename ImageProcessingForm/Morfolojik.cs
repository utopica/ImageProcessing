using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Morfolojik : Form
    {
        private Bitmap originalImage;

        public Morfolojik(Bitmap mainFormImage)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string imagePath = Path.Combine(parentDirectory, "Images", "girl.jpg");

            originalImage = new Bitmap(imagePath);
            DisplayImage(originalImage);

            comboBox1.Items.Add("Genişleme - Dilation");
            comboBox1.Items.Add("Aşınma - Erosion");
            comboBox1.Items.Add("Açma - Opening");
            comboBox1.Items.Add("Kapama - Closing");

            // ComboBox'ın SelectedIndexChanged olayını dinleyelim
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOperation = comboBox1.SelectedItem.ToString();
            Bitmap processedImage = null;

            switch (selectedOperation)
            {
                case "Genişleme - Dilation":
                    processedImage = Dilation(originalImage);
                    break;
                case "Aşınma - Erosion":
                    processedImage = Erosion(originalImage);
                    break;
                case "Açma - Opening":
                    processedImage = Opening(originalImage);
                    break;
                case "Kapama - Closing":
                    processedImage = Closing(originalImage);
                    break;
                default:
                    MessageBox.Show("Geçersiz işlem seçimi.");
                    break;
            }

            if (processedImage != null)
                DisplayImage(processedImage);
        }

        private Bitmap Dilation(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color maxColor = Color.Black;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int newX = x + i;
                            int newY = y + j;

                            if (newX >= 0 && newX < image.Width && newY >= 0 && newY < image.Height)
                            {
                                Color currentColor = image.GetPixel(newX, newY);

                                if (currentColor.R > maxColor.R)
                                    maxColor = currentColor;
                            }
                        }
                    }

                    result.SetPixel(x, y, maxColor);
                }
            }

            return result;
        }

        private Bitmap Erosion(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color minColor = Color.White;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int newX = x + i;
                            int newY = y + j;

                            if (newX >= 0 && newX < image.Width && newY >= 0 && newY < image.Height)
                            {
                                Color currentColor = image.GetPixel(newX, newY);

                                if (currentColor.R < minColor.R)
                                    minColor = currentColor;
                            }
                        }
                    }

                    result.SetPixel(x, y, minColor);
                }
            }

            return result;
        }

        private Bitmap Opening(Bitmap image)
        {
            // Opening işlemi, önce Erosion sonra Dilation işlemi uygulamaktadır.
            Bitmap erodedImage = Erosion(image);
            Bitmap openedImage = Dilation(erodedImage);
            return openedImage;
        }

        private Bitmap Closing(Bitmap image)
        {
            // Closing işlemi, önce Dilation sonra Erosion işlemi uygulamaktadır.
            Bitmap dilatedImage = Dilation(image);
            Bitmap closedImage = Erosion(dilatedImage);
            return closedImage;
        }

        private void beforePic_Click(object sender, EventArgs e)
        {
            DownloadImage();
            afterPic.Image = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DownloadImage();
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

        private void DisplayImage(Bitmap image)
        {
            beforePic.Image = image;
            afterPic.SizeMode = PictureBoxSizeMode.Zoom;
            beforePic.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void DownloadImage()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tüm Dosyalar|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                beforePic.Image = null;
                afterPic.Image = null;

                beforePic.Image = new Bitmap(openFileDialog1.FileName);
                DisplayImage((Bitmap)beforePic.Image);
            }
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
