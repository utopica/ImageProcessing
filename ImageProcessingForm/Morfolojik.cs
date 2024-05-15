using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Morfolojik : Form
    {
        private Bitmap originalImage;
        public Morfolojik(Bitmap mainmainFormImage)
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
            switch (selectedOperation)
            {
                case "Genişleme - Dilation":
                    Dilation();
                    break;
                case "Aşınma - Erosion":
                    Erosion();
                    break;
                case "Açma - Opening":
                    Opening();
                    break;
                case "Kapama - Closing":
                    Closing();
                    break;
                
                default:
                    MessageBox.Show("Geçersiz işlem seçimi.");
                    break;
            }
        }

        private void Closing()
        {
            throw new NotImplementedException();
        }

        private void Opening()
        {
            throw new NotImplementedException();
        }

        private void Erosion()
        {
            throw new NotImplementedException();
        }

        private void Dilation()
        {
            throw new NotImplementedException();
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
