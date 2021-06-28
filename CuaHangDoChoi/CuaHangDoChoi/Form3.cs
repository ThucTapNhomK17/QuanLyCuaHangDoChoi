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
        DataSet ds;

        SqlDataAdapter dap;

        private void LoadDuLieu(string sql)
        {
            ds = new DataSet();
            dap = new SqlDataAdapter(sql, connection);
            dap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
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
            cmd.Parameters.AddWithValue("idKhachHang", textBox1.Text);
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
            string sql = "select * from KhachHang";
            string dk="";
            if (textBox6.Text.Trim() != "")
            {
                dk += "soDT = '" + textBox6.Text + "'";
            }
            if (textBox7.Text.Trim() != "")
            {
                if (dk != "")
                {
                    dk += " and ten like'%" + textBox7.Text + "%'";
                }
                if(dk == "")
                {
                    dk += " ten like '%" + textBox7.Text + "%'";
                }
            }
            if (textBox8.Text.Trim() != "")
            {
                if (dk != "")
                {
                    dk += " and diaChi like'%" + textBox8.Text + "%'";
                }
                if (dk == "")
                {
                    dk += " diaChi like '%" + textBox8.Text + "%'";
                }
            }
            if (dk != "")
            {
                sql += " where " + dk;
            }
            LoadDuLieu(sql);
        }



        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

          
          private void button6_Click(object sender, EventArgs e)
        {
                string search = "select * from KhachHang where ten like '%"+textBox7.Text+"%'";
                SqlCommand cmd = new SqlCommand(search, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(dr);
                dataGridView1.DataSource = data;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

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

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
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
                textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            }
            catch { }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form10 form10 = new Form10();
            form10.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
