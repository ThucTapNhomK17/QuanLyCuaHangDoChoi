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
    public partial class Form4 : Form
    {
        DataSet ds;

        SqlDataAdapter dap;

        private void LoadDuLieu(string sql)
        {
            ds = new DataSet();
            dap = new SqlDataAdapter(sql, connection);
            dap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-B8E9EA0\SQLEXPRESS01;Initial Catalog=CuaHangDoChoi;Integrated Security=True");
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void HienThi()
        {
            string sql = "select idNhanVien , ten , gioiTinh , chucVu , soDT , queQuan from NhanVien";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(dr);
            dataGridView1.DataSource = data;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string update = "UPDATE NhanVien SET ten = @ten,gioiTinh = @gioiTinh, chucVu = @chucVu, soDT = @soDT,queQuan = @queQuan WHERE idNhanVien = @idNhanVien";
            SqlCommand cmd = new SqlCommand(update, connection);
            cmd.Parameters.AddWithValue("idNhanVien", textBox1.Text);
            cmd.Parameters.AddWithValue("ten", textBox2.Text);
            cmd.Parameters.AddWithValue("gioiTinh", textBox5.Text);
            cmd.Parameters.AddWithValue("chucVu", textBox3.Text);
            cmd.Parameters.AddWithValue("soDT", textBox4.Text);
            cmd.Parameters.AddWithValue("queQuan", textBox6.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            connection.Open();
            HienThi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insert = "insert into NhanVien(idNhanVien , ten , gioiTinh , chucVu , soDT , queQuan) values(@idNhanVien,@ten,@gioiTinh , @chucVu , @soDT,@queQuan)";
            SqlCommand cmd = new SqlCommand(insert, connection);
            cmd.Parameters.AddWithValue("idNhanVien", textBox1.Text);
            cmd.Parameters.AddWithValue("ten", textBox2.Text);
            cmd.Parameters.AddWithValue("gioiTinh", textBox5.Text);
            cmd.Parameters.AddWithValue("chucVu", textBox3.Text);
            cmd.Parameters.AddWithValue("soDT", textBox4.Text);
            cmd.Parameters.AddWithValue("queQuan", textBox6.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string delete = "delete from NhanVien where idNhanVien = @idNhanVien";
            SqlCommand cmd = new SqlCommand(delete, connection);
            cmd.Parameters.AddWithValue("idNhanVien", textBox1.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string search = "select idNhanVien , ten , gioiTinh , chucVu , soDT , queQuan from NhanVien where soDT = @soDT";
            SqlCommand cmd = new SqlCommand(search, connection);
            cmd.Parameters.AddWithValue("soDT", textBox8.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(dr);
            dataGridView1.DataSource = data;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "select idNhanVien , ten , gioiTinh , chucVu , soDT , queQuan from NhanVien";
            string dk = "";
            if (textBox9.Text.Trim() != "")
            {
                dk += "ten like'%" + textBox9.Text + "%'";
            }
            if (textBox8.Text.Trim() != "")
            {
                if (dk != "")
                {
                    dk += " and soDT ="  + textBox8.Text + "";
                }
                if (dk == "")
                {
                    dk += " soDT =" + textBox8.Text + "";
                }
            }
            if (textBox10.Text.Trim() != "")
            {
                if (dk != "")
                {
                    dk += " and gioiTinh like'%" + textBox10.Text + "%'";
                }
                if (dk == "")
                {
                    dk += " gioiTinh like '%" + textBox10.Text + "%'";
                }
            }
            if (textBox11.Text.Trim() != "")
            {
                if (dk != "")
                {
                    dk += " and queQuan like'%" + textBox11.Text + "%'";
                }
                if (dk == "")
                {
                    dk += " queQuan like '%" + textBox11.Text + "%'";
                }
            }
            if (dk != "")
            {
                sql += " where " + dk;
            }
            LoadDuLieu(sql);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form5 = new Form6();
            form5.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = dataGridView1.CurrentRow.Index;
                textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                textBox5.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            }
            catch { }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form10 form10 = new Form10();
            form10.Show();
        }
    }
}
