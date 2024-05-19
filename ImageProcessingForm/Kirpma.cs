using System.Drawing.Imaging;

namespace ImageProcessingForm
{
    public partial class Kirpma : Form
    {
        private Bitmap originalImage;
        private Bitmap croppedImage;
        private int prevStartX = 0;
        private int prevStartY = 0;
        private int prevEndX = 0;
        private int prevEndY = 0;
        private int startX = 0;
        private int startY = 0;
        private int endX = 0;
        private int endY = 0;

        public Kirpma()
        {
            InitializeComponent();

            string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            string imagePath = Path.Combine(parentDirectory, "Images", "girl.jpg");

            originalImage = new Bitmap(imagePath);

            DisplayImage(originalImage);

            txtWidthStart.Text = "0";
            txtHeightStart.Text = "0";

           
        }

 
        private void DisplayImage(Bitmap image)
        {
            beforePic.Image = image;

            afterPic.SizeMode = PictureBoxSizeMode.Zoom;
            beforePic.SizeMode = PictureBoxSizeMode.Zoom;

            lblWidth.Text = image.Width.ToString();
            lblHeight.Text = image.Height.ToString();
            txtWidthEnd.Text = image.Width.ToString();
            txtHeightEnd.Text = image.Height.ToString();
            prevEndX = image.Size.Width;
            prevEndY = image.Size.Height;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LoadImage();
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

        private void LoadImage()
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

        private void btnCrop_Click(object sender, EventArgs e)
        {
            prevStartX = startX;
            prevStartY = startY;
            prevEndX = endX;
            prevEndY = endY;

            startX = int.Parse(txtWidthStart.Text);
            startY = int.Parse(txtHeightStart.Text);
            endX = int.Parse(txtWidthEnd.Text);
            endY = int.Parse(txtHeightEnd.Text);

            CropImage(startX, startY, endX, endY);
        }

        private void CropImage(int startX, int startY, int endX, int endY)
        {
            if (startX < 0 || startY < 0 || endX >= beforePic.Image.Width || endY >= beforePic.Image.Height || startX > endX || startY > endY)
            {
                MessageBox.Show("Geçersiz parametre girildi.");
                return;
            }

            int width = endX - startX + 1;
            int height = endY - startY + 1;
            croppedImage = new Bitmap(width, height);

            for (int y = startY; y <= endY; y++)
            {
                for (int x = startX; x <= endX; x++)
                {
                    Color pixelColor = ((Bitmap)beforePic.Image).GetPixel(x, y);
                    croppedImage.SetPixel(x - startX, y - startY, pixelColor);
                }
            }

            afterPic.Image = croppedImage;
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

        private void btnUndo_Click(object sender, EventArgs e)
        {
            startX = prevStartX;
            startY = prevStartY;
            endX = prevEndX;
            endY = prevEndY;

            CropImage(startX, startY, endX, endY);

            txtWidthStart.Text = startX.ToString();
            txtHeightStart.Text = startY.ToString();
            txtWidthEnd.Text = endX.ToString();
            txtHeightEnd.Text = endY.ToString();
        }

        
    }
}
