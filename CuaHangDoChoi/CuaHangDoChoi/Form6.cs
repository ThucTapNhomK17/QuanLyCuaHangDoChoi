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
    public partial class Form6 : Form
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

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-G3E7L6G\SQLEXPRESS;Initial Catalog=CuaHangDoChoi;Integrated Security=True");
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            connection.Open();
            HienThi();
        }

        public void HienThi()
        {
            string sql = "select * from SanPham";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(dr);
            dataGridView1.DataSource = data;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string delete = "delete from SanPham where idSanPham = @idSanPham";
            SqlCommand cmd = new SqlCommand(delete, connection);
            cmd.Parameters.AddWithValue("idSanPham", textBox1.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insert = "insert into SanPham values(@idSanPham,@ten,@giaTien)";
            SqlCommand cmd = new SqlCommand(insert, connection);
            cmd.Parameters.AddWithValue("idSanPham", textBox1.Text);
            cmd.Parameters.AddWithValue("ten", textBox2.Text);
            cmd.Parameters.AddWithValue("giaTien", textBox3.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sql = "select * from SanPham";
            string dk = "";
            if (textBox5.Text.Trim() != "")
            {
                dk += "ten like'%" + textBox5.Text + "%'";
            }
            if (textBox6.Text.Trim() != "")
            {
                if (textBox7.Text.Trim() != "")
                {
                    if (dk != "")
                    {
                        dk += " and giaTien >= " + textBox6.Text + "";
                    }
                    if (dk == "")
                    {
                        dk += " giaTien >= " + textBox6.Text + "";
                    }
                }
                if (textBox7.Text.Trim() == "")
                {
                    if (dk != "")
                    {
                        dk += " and giaTien >= " + textBox6.Text + " order by giaTien";
                    }
                    if (dk == "")
                    {
                        dk += " giaTien >= " + textBox6.Text + " order by giaTien";
                    }
                }
            }
            if (textBox7.Text.Trim() != "")
            {
                if (dk != "")
                {
                    dk += " and giaTien <= " + textBox7.Text + " order by giaTien";
                }
                if (dk == "")
                {
                    dk += " giaTien <= " + textBox7.Text + " order by giaTien";
                }
            }
            if (dk != "")
            {
                sql += " where " + dk;
            }
            LoadDuLieu(sql);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string search = "select * from SanPham where ten like '%" + textBox5.Text + "%'";
            SqlCommand cmd = new SqlCommand(search, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(dr);
            dataGridView1.DataSource = data;
        }

        private void button11_Click(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2= new Form2();
            form2.Show();
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
                textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string update = "UPDATE SanPham SET ten = @ten,giaTien = @giaTien WHERE idSanPham = @idSanPham";
            SqlCommand cmd = new SqlCommand(update, connection);
            cmd.Parameters.AddWithValue("idSanPham", textBox1.Text);
            cmd.Parameters.AddWithValue("ten", textBox2.Text);
            cmd.Parameters.AddWithValue("giaTien", textBox3.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form10 form10 = new Form10();
            form10.Show();
        }
    }
}
