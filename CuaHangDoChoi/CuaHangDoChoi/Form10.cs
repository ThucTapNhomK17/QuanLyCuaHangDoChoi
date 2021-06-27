using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace CuaHangDoChoi
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-B8E9EA0\SQLEXPRESS01;Initial Catalog=CuaHangDoChoi;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            string update = "UPDATE NhanVien SET username = @username,password = @password WHERE idNhanVien = @idNhanVien";
            SqlCommand cmd = new SqlCommand(update, connection);
            cmd.Parameters.AddWithValue("username", textBox3.Text);
            cmd.Parameters.AddWithValue("password", textBox4.Text);
            cmd.Parameters.AddWithValue("idNhanVien", textBox1.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            connection.Open();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            HienThi();
        }

        public void HienThi()
        {
            string sql = "select idNhanVien , ten , username , password from NhanVien";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(dr);
            dataGridView1.DataSource = data;
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
