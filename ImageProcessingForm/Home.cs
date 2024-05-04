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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            // Ana formu oluştur
            Main mainForm = new Main();

            // Ana formu göster
            mainForm.Show();

            // Şu anki formu gizle
            this.Hide();
        }
    }
}
