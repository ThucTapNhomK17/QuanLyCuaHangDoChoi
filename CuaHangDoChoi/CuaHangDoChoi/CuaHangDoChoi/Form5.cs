using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CuaHangDoChoi
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-B8E9EA0\SQLEXPRESS01;Initial Catalog=CuaHangDoChoi;Integrated Security=True");
        public void HienThi()
        {
            string sql = "select * from SanPham";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(dr);
            dataGridView1.DataSource = data;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            connection.Open();
            HienThi();
        }
    }
}
