using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project1_AdonetCustomer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        #region SqlConnection
        SqlConnection sqlConnection = new SqlConnection("Server=localhost,1434;Database=CoreCustomer;User Id=sa;Password=Password1;TrustServerCertificate=True;");
        #endregion
        void GetAllCustomers()
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Select CustomerId,FirstName,LastName,Balance,IsStatus,City,CityName from Customers Inner join Cities on Cities.CityId = Customers.City", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Adı";
            dataGridView1.Columns[2].HeaderText = "Soyadı";
            dataGridView1.Columns[3].HeaderText = "Bakiye";
            dataGridView1.Columns[4].HeaderText = "Durum";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Şehir";
            sqlConnection.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            txtFirstName.Focus();
            GetAllCustomers();
            #region Şehir Açılır Menü
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Select * from Cities", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cmbCity.ValueMember = "CityId";
            cmbCity.DisplayMember = "CityName";
            cmbCity.DataSource = dt;
            sqlConnection.Close();
            #endregion
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var cityId = Convert.ToInt32(row.Cells[5].Value);
                txtId.Text = row.Cells[0].Value.ToString();
                txtFirstName.Text = row.Cells[1].Value.ToString();
                txtLastName.Text = row.Cells[2].Value.ToString();
                txtBalance.Text = row.Cells[3].Value.ToString();
                cmbCity.SelectedValue = cityId;

                bool isActive = row.Cells[4].Value != DBNull.Value && Convert.ToBoolean(row.Cells[4].Value);
                rdbActive.Checked = isActive;
                rdbPassive.Checked = !isActive;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach(Control control in this.Controls)
            {
                if (control is TextBox txt)
                    txt.Clear();
                else if (control is ComboBox cmb)
                    cmb.SelectedIndex = -1;
            }
            txtFirstName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Insert into Customers (FirstName,LastName,Balance,IsStatus,City) values (@firstName,@lastName,@balance,@isStatus,@city)", sqlConnection);
            cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@balance", Convert.ToDecimal(txtBalance.Text));
            if (rdbActive.Checked)
                cmd.Parameters.AddWithValue("@isStatus", true);
            else
                cmd.Parameters.AddWithValue("@isStatus", false);
            cmd.Parameters.AddWithValue("@city", Convert.ToInt32(cmbCity.SelectedValue.ToString()));
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Müşteri Kaydı Başarılı","SONUÇ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            GetAllCustomers();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int customerId = Convert.ToInt32(txtId.Text);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Delete from Customers where CustomerId = @customerId", sqlConnection);
            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Müşteri Kaydı Başarılı ile Silindi", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllCustomers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int customerId = Convert.ToInt32(txtId.Text);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Update Customers set FirstName = @firstName, LastName = @lastName, Balance = @balance, IsStatus = @isStatus, City = @city where CustomerId = @customerId", sqlConnection);
            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@balance", Convert.ToDecimal(txtBalance.Text));
            if (rdbActive.Checked)
                cmd.Parameters.AddWithValue("@isStatus", true);
            else
                cmd.Parameters.AddWithValue("@isStatus", false);
            cmd.Parameters.AddWithValue("@city", Convert.ToInt32(cmbCity.SelectedValue.ToString()));
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Müşteri Kaydı Başarılı ile Güncellendi", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllCustomers();
        }
    }
}
