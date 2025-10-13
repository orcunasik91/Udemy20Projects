using System;
using System.Windows.Forms;

namespace Project1_AdonetCustomer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnCityForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 cityForm = new Form1();
            cityForm.Owner = this;
            cityForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
