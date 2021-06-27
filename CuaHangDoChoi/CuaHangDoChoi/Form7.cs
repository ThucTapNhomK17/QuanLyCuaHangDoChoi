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
    public partial class Form7 : Form
    {

        DataSet ds;

        SqlDataAdapter dap;

        private void LoadDuLieu(string sql)
        {
            ds = new DataSet();
            dap = new SqlDataAdapter(sql, connection);
            dap.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
        }
        public Form7()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-G3E7L6G\SQLEXPRESS;Initial Catalog=CuaHangDoChoi;Integrated Security=True");
        private void Form7_Load(object sender, EventArgs e)
        {
            connection.Open();
            HienThi();
            HienThi1();
            HienThi2();
        }

        public void HienThi()
        {
            string sql = "select msp.idMua , kh.idKhachHang , kh.ten as ten_kh , sp.idSanPham , sp.ten as ten_sp , msp.soLuong , msp.thanhTien from MuaSanPham msp , KhachHang kh , SanPham sp where msp.idKhachHang = kh.idKhachHang and msp.idSanPham = sp.idSanPham";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(dr);
            dataGridView3.DataSource = data;
        }

        public void HienThi1()
        {
            string sql = "select * from KhachHang";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(dr);
            dataGridView1.DataSource = data;
        }

        public void HienThi2()
        {
            string sql = "select * from SanPham";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(dr);
            dataGridView2.DataSource = data;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Them_Click(object sender, EventArgs e)
        {
            string insert = "insert into MuaSanPham(idMua, idKhachHang,idSanPham,soLuong) values(@idMua, @idKhachHang,@idSanPham,@soLuong)";
            SqlCommand cmd = new SqlCommand(insert, connection);
            cmd.Parameters.AddWithValue("idMua", textBox6.Text);
            cmd.Parameters.AddWithValue("idKhachHang", textBox1.Text);
            cmd.Parameters.AddWithValue("idSanPham", textBox2.Text);
            cmd.Parameters.AddWithValue("soLuong", textBox3.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string delete = "delete from MuaSanPham where idMua = @idMua";
            SqlCommand cmd = new SqlCommand(delete, connection);
            cmd.Parameters.AddWithValue("idMua", textBox6.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select kh.idKhachHang , kh.ten as ten_kh , sp.idSanPham , sp.ten as ten_sp , msp.soLuong , msp.thanhTien from MuaSanPham msp , KhachHang kh , SanPham sp where msp.idKhachHang = kh.idKhachHang and msp.idSanPham = sp.idSanPham";
            string dk = "";
            if (textBox5.Text.Trim() != "")
            {
                dk += " kh.ten like'%" + textBox5.Text + "%'";
            }
            if (textBox7.Text.Trim() != "")
            {
                if (dk != "")
                {
                    dk += " and sp.ten  like'%" + textBox7.Text + "%'";
                }
                if (dk == "")
                {
                    dk += " sp.ten  like'%" + textBox7.Text + "%'";
                }
            }
            if (dk != "")
            {
                sql += " and " + dk;
            }
            LoadDuLieu(sql);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string update = "update MuaSanPham set thanhTien = (select(sp.giaTien * msp.soLuong) from SanPham sp , MuaSanPham msp, KhachHang kh where sp.idSanPham = msp.idSanPham and kh.idKhachHang = msp.idKhachHang and msp.idMua = @idMua)";
            SqlCommand cmd = new SqlCommand(update, connection);
            cmd.Parameters.AddWithValue("idMua", textBox6.Text);

            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form5 = new Form6();
            form5.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = dataGridView1.CurrentRow.Index;
                textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            }
            catch { }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = dataGridView2.CurrentRow.Index;
                textBox2.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();
            }
            catch { }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = dataGridView3.CurrentRow.Index;
                textBox6.Text = dataGridView3.Rows[i].Cells[0].Value.ToString();
                textBox1.Text = dataGridView3.Rows[i].Cells[1].Value.ToString();
                textBox2.Text = dataGridView3.Rows[i].Cells[3].Value.ToString();
                textBox3.Text = dataGridView3.Rows[i].Cells[5].Value.ToString();
                textBox4.Text = dataGridView3.Rows[i].Cells[6].Value.ToString();
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 form10 = new Form10();
            form10.Show();
        }
    }
}
