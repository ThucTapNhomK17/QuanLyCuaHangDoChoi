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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-B8E9EA0\SQLEXPRESS01;Initial Catalog=CuaHangDoChoi;Integrated Security=True");
            try
            {
                connection.Open();
                string username = textBox1.Text;
                string password = textBox2.Text;
                string sql = "select * from users where username = '" + username + "' and password = '" + password + "';";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader data = cmd.ExecuteReader();
                if(data.Read() == true)
                {
                    this.Hide();
                    Form2 form2 = new Form2();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Dang nhap that bai");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Loi ket noi.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
