using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Project2_EFDbFirstProduct
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        void ClearToolbox()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txt)
                    txt.Clear();
                else if (control is ComboBox cmb)
                    cmb.SelectedIndex = -1;
            }
            txtProduct.Focus();
        }
        UdemyEFDbFirstProductEntities context = new UdemyEFDbFirstProductEntities();
        void GetAllProducts()
        {
            var products = context.Products
                .Join(context.Categories,
                p=> p.CategoryId,
                c=> c.CategoryId,
                (p,c)=> new
                {
                    p.ProductId,
                    p.ProductName,
                    p.Stock,
                    p.Price,
                    p.CategoryId,
                    c.CategoryName
                }).ToList();
            dataGridView1.DataSource = products;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Ürün";
            dataGridView1.Columns[2].HeaderText = "Stok Miktarı";
            dataGridView1.Columns[3].HeaderText = "Ürün Fiyatı";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Kategori";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearToolbox();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GetAllProducts();
            #region Kategori Açılır Menü
            var categories = context.Categories.ToList();
            cmbCategory.DataSource = categories;
            cmbCategory.ValueMember = "CategoryId";
            cmbCategory.DisplayMember = "CategoryName";
            #endregion
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var categoryId = Convert.ToInt32(row.Cells[4].Value);
                txtId.Text = row.Cells[0].Value.ToString();
                txtProduct.Text = row.Cells[1].Value.ToString();
                txtStock.Text = row.Cells[2].Value.ToString();
                txtPrice.Text = row.Cells[3].Value.ToString();
                cmbCategory.SelectedValue = categoryId;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Products product = new Products();
            product.ProductName = txtProduct.Text;
            product.Stock = int.Parse(txtStock.Text);
            product.Price = decimal.Parse(txtPrice.Text);
            product.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            context.Products.Add(product);
            context.SaveChanges();
            MessageBox.Show("Yeni Ürün Kaydı Başarılı","SONUÇ",MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllProducts();
            ClearToolbox();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(txtId.Text);
            var product = context.Products.Find(productId);
            context.Products.Remove(product);
            context.SaveChanges();
            MessageBox.Show("Ürün Kaydı Başarı ile Silindi", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllProducts();
            ClearToolbox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(txtId.Text);
            var product = context.Products.Find(productId);
            product.ProductName = txtProduct.Text;
            product.Stock = Convert.ToInt32(txtStock.Text);
            product.Price = Convert.ToDecimal(txtPrice.Text);
            product.CategoryId = Convert.ToInt32( cmbCategory.SelectedValue);
            context.SaveChanges();
            MessageBox.Show("Ürün Kaydı Başarı ile Güncellendi", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllProducts();
            ClearToolbox();
        }
    }
}
