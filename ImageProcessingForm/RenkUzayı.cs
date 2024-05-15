using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class RenkUzayı : Form
    {
        private Bitmap defaultImage;
        public RenkUzayı()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            string imagePath = Path.Combine(parentDirectory, "Images", "girl.jpg");

            defaultImage = new Bitmap(imagePath);
            beforePic.Image = defaultImage;
            beforePic.SizeMode = PictureBoxSizeMode.StretchImage;

            beforePic.MouseUp += beforePic_MouseUp;

            comboBox1.Items.Add("NTSC");
            comboBox1.Items.Add("HSV");
            comboBox1.Items.Add("LAB");
            comboBox1.Items.Add("YbCr");
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void beforePic_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DownloadImage();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSpace = comboBox1.SelectedItem.ToString();

            Bitmap convertedImage = null;

            switch (selectedSpace)
            {
                case "NTSC":
                    convertedImage = ConverToNTSC(defaultImage);
                    break;
                case "HSV":
                    convertedImage = ConvertToHSV(defaultImage);
                    break;
                case "LAB":
                    convertedImage = ConvertToLAB(defaultImage);
                    break;
                case "YbCr":
                    convertedImage = ConvertToYbCr(defaultImage);
                    break;
                default:
                    MessageBox.Show("Geçersiz renk uzayı seçimi.");
                    break;
            }

            if (convertedImage != null)
            {
                afterPic.Image = convertedImage;
                afterPic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private Bitmap ConverToNTSC(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);

                    int r = pixelColor.R;
                    int g = pixelColor.G;
                    int b = pixelColor.B;

                    // NTSC formülleri
                    int Y = (int)(0.299 * r + 0.587 * g + 0.114 * b);
                    int I = (int)(0.596 * r - 0.275 * g - 0.321 * b);
                    int Q = (int)(0.212 * r - 0.528 * g + 0.311 * b);

                    // Sınırları kontrol et
                    Y = Math.Min(255, Math.Max(0, Y));
                    I = Math.Min(255, Math.Max(0, I));
                    Q = Math.Min(255, Math.Max(0, Q));

                    // Yeni renk oluştur ve NTSC resmine ekle
                    Color ntscColor = Color.FromArgb(Y, I, Q);
                    result.SetPixel(x, y, ntscColor);
                }
            }

            return result;
        }



        private Bitmap ConvertToHSV(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);

                    float r = pixelColor.R / 255.0f;
                    float g = pixelColor.G / 255.0f;
                    float b = pixelColor.B / 255.0f;

                    float cmax = Math.Max(r, Math.Max(g, b));
                    float cmin = Math.Min(r, Math.Min(g, b));
                    float delta = cmax - cmin;

                    float h = 0;
                    if (delta != 0)
                    {
                        if (cmax == r)
                            h = 60 * (((g - b) / delta) % 6);
                        else if (cmax == g)
                            h = 60 * (((b - r) / delta) + 2);
                        else
                            h = 60 * (((r - g) / delta) + 4);
                    }

                    float s = cmax == 0 ? 0 : delta / cmax;
                    float v = cmax;

                    h = (h < 0) ? 360 + h : h;

                    int hh = (int)(h / 2);
                    int ss = (int)(s * 255);
                    int vv = (int)(v * 255);

                    Color hsvColor = Color.FromArgb(hh, ss, vv);
                    result.SetPixel(x, y, hsvColor);
                }
            }

            return result;
        }

        private Bitmap ConvertToLAB(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);

                    double r = pixelColor.R / 255.0;
                    double g = pixelColor.G / 255.0;
                    double b = pixelColor.B / 255.0;

                    double[] xyz = new double[3];
                    xyz[0] = 0.412453 * r + 0.357580 * g + 0.180423 * b;
                    xyz[1] = 0.212671 * r + 0.715160 * g + 0.072169 * b;
                    xyz[2] = 0.019334 * r + 0.119193 * g + 0.950227 * b;

                    xyz[0] = (xyz[0] > 0.008856) ? Math.Pow(xyz[0], (1.0 / 3)) : (7.787 * xyz[0]) + (16.0 / 116);
                    xyz[1] = (xyz[1] > 0.008856) ? Math.Pow(xyz[1], (1.0 / 3)) : (7.787 * xyz[1]) + (16.0 / 116);
                    xyz[2] = (xyz[2] > 0.008856) ? Math.Pow(xyz[2], (1.0 / 3)) : (7.787 * xyz[2]) + (16.0 / 116);

                    double l = (116 * xyz[1]) - 16;
                    double a = 500 * (xyz[0] - xyz[1]);
                    double bb = 200 * (xyz[1] - xyz[2]);

                    int ll = (int)((116 * xyz[1]) - 16);
                    int aa = (int)(500 * (xyz[0] - xyz[1]) + 128);
                    int bbb = (int)(200 * (xyz[1] - xyz[2]) + 128);

                    ll = Math.Min(255, Math.Max(0, ll));
                    aa = Math.Min(255, Math.Max(0, aa));
                    bbb = Math.Min(255, Math.Max(0, bbb));

                    Color labColor = Color.FromArgb(ll, aa, bbb);
                    result.SetPixel(x, y, labColor);
                }
            }

            return result;
        }
        private Bitmap ConvertToYbCr(Bitmap image)
        {
            if (image != null)
            {
                Bitmap ycbcrImage = new Bitmap(image.Width, image.Height);

                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        Color originalColor = image.GetPixel(x, y);

                        // RGB değerlerini al
                        int R = originalColor.R;
                        int G = originalColor.G;
                        int B = originalColor.B;

                        // YbCr dönüşüm formülleri
                        int Y = (int)(0.299 * R + 0.587 * G + 0.114 * B);
                        int Cb = (int)(128 - 0.168736 * R - 0.331264 * G + 0.5 * B);
                        int Cr = (int)(128 + 0.5 * R - 0.418688 * G - 0.081312 * B);

                        // Sınırları kontrol et
                        Y = Math.Min(255, Math.Max(0, Y));
                        Cb = Math.Min(255, Math.Max(0, Cb));
                        Cr = Math.Min(255, Math.Max(0, Cr));

                        // Yeni renk oluştur ve YbCr resmine ekle
                        Color ycbcrColor = Color.FromArgb(Y, Cb, Cr);
                        ycbcrImage.SetPixel(x, y, ycbcrColor);
                    }
                }

                return ycbcrImage;
            }
            else
            {
                MessageBox.Show("There is no image to process.");
                return null;
            }
        }





        private void DownloadImage()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tüm Dosyalar|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                beforePic.Image = null;
                afterPic.Image = null;

                defaultImage = new Bitmap(openFileDialog1.FileName);
                beforePic.Image = defaultImage;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DownloadImage();
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
