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
    
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-B8E9EA0\SQLEXPRESS01;Initial Catalog=CuaHangDoChoi;Integrated Security=True");
        private void Form3_Load(object sender, EventArgs e)
        {
   
            connection.Open();
            HienThi();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void HienThi()
        {
            string sql = "select * from KhachHang";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(dr);
            dataGridView1.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insert = "insert into KhachHang values(@idKhachHang,@ten,@soDT,@diaChi)";
            SqlCommand cmd = new SqlCommand(insert, connection);
            cmd.Parameters.AddWithValue("idKhachHang", textBox1.Text);
            cmd.Parameters.AddWithValue("ten", textBox2.Text);
            cmd.Parameters.AddWithValue("soDT", textBox3.Text);
            cmd.Parameters.AddWithValue("diaChi", textBox4.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string update = "UPDATE KhachHang SET ten = @ten,soDT = @soDT,diaChi = @diaChi WHERE idKhachHang = @idKhachHang";
            SqlCommand cmd = new SqlCommand(update, connection);
            cmd.Parameters.AddWithValue("ten", textBox2.Text);
            cmd.Parameters.AddWithValue("soDT", textBox3.Text);
            cmd.Parameters.AddWithValue("diaChi", textBox4.Text);
            cmd.Parameters.AddWithValue("idKhachHang", textBox1.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string delete = "delete from KhachHang where idKhachHang = @idKhachHang";
            SqlCommand cmd = new SqlCommand(delete, connection);
            cmd.Parameters.AddWithValue("idKhachHang", textBox5.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string search = "select * from KhachHang where soDT = @soDT";
            SqlCommand cmd = new SqlCommand(search, connection);
            cmd.Parameters.AddWithValue("idKhachHang", textBox1.Text);
            cmd.Parameters.AddWithValue("ten", textBox2.Text);
            cmd.Parameters.AddWithValue("soDT", textBox6.Text);
            cmd.Parameters.AddWithValue("diaChi", textBox4.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(dr);
            dataGridView1.DataSource = data;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string search = "select * from KhachHang where ten like '%@ten%'";
            SqlCommand cmd = new SqlCommand(search, connection);
            cmd.Parameters.AddWithValue("idKhachHang", textBox1.Text);
            cmd.Parameters.AddWithValue("ten", textBox7.Text);
            cmd.Parameters.AddWithValue("soDT", textBox3.Text);
            cmd.Parameters.AddWithValue("diaChi", textBox4.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(dr);
            dataGridView1.DataSource = data;
        }
    }
}
