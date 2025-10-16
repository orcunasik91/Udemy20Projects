using System;
using System.Windows.Forms;

namespace Project2_EFDbFirstProduct
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnCategoriForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 categoryForm = new Form1();
            categoryForm.Owner = this;
            categoryForm.Show();
        }

        private void btnProductForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 productForm = new Form2();
            productForm.Owner = this;
            productForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
