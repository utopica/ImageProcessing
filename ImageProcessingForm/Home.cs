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
        private Main mainForm = null;
        public Home()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            if (mainForm == null)
            {
                mainForm = new Main();
                mainForm.FormClosed += MainForm_FormClosed; 
            }

            mainForm.Show();

            
            this.Hide();

            
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm = null; 
            this.Show(); 
        }
       
    }
}
