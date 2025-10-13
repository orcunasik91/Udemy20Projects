using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project1_AdonetCustomer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region SqlConnection
        SqlConnection sqlConnection = new SqlConnection("Server=localhost,1434;Database=CoreCustomer;User Id=sa;Password=Password1;TrustServerCertificate=True;");
        #endregion
        void GetAllCities()
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select * from Cities", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Şehir";
            dataGridView1.Columns[2].HeaderText = "Ülke";
            sqlConnection.Close();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txt)
                    txt.Clear();
            }
            txtCity.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Insert Into Cities (CityName, CityCountry) values (@cityName,@country)", sqlConnection);
            cmd.Parameters.AddWithValue("@cityName",txtCity.Text);
            cmd.Parameters.AddWithValue("@country",txtCountry.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Kayıt işlemi Başarılı","SONUÇ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            GetAllCities();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int cityId = Convert.ToInt32(txtId.Text);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Delete from Cities where CityId = @cityId",sqlConnection);
            cmd.Parameters.AddWithValue("@cityId", cityId);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Kayıt Başarılı ile Silindi", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllCities();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtCity.Text = row.Cells[1].Value.ToString();
                txtCountry.Text = row.Cells[2].Value.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtCity.Focus();
            GetAllCities();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int cityId = Convert.ToInt32(txtId.Text);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Update Cities set CityName = @cityName, CityCountry = @country where CityId = @cityId", sqlConnection);
            cmd.Parameters.AddWithValue("@cityId", cityId);
            cmd.Parameters.AddWithValue("@cityName", txtCity.Text);
            cmd.Parameters.AddWithValue("@country", txtCountry.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Kayıt Başarılı ile Güncellendi", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllCities();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
