using System;
using System.Linq;
using System.Windows.Forms;

namespace Project2_EFDbFirstProduct
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        UdemyEFDbFirstProductEntities context = new UdemyEFDbFirstProductEntities();
        void GetAllCategories()
        {
            var categories = context.Categories.ToList();
            dataGridView1.DataSource = categories;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Kategori";
            dataGridView1.Columns[2].Visible = false;

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txt)
                    txt.Clear();
            }
            txtCategory.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtCategory.Focus();
            GetAllCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Categories category = new Categories();
            category.CategoryName = txtCategory.Text;
            context.Categories.Add(category);
            context.SaveChanges();
            MessageBox.Show("Kategori Kaydı Başarılı","SONUÇ",MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllCategories();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(txtId.Text);
            var category = context.Categories.Find(categoryId);
            context.Categories.Remove(category);
            context.SaveChanges();
            MessageBox.Show("Kategori Kaydı Başarı ile Silindi", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllCategories();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtCategory.Text = row.Cells[1].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(txtId.Text);
            var category = context.Categories.Find(categoryId);
            category.CategoryName = txtCategory.Text;
            context.SaveChanges();
            MessageBox.Show("Kategori Kaydı Başarı ile Güncellendi","SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllCategories();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
