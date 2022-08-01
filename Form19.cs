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


namespace orphans
{
    public partial class Form19 : Form
    {
        string o = ConfigurationManager.ConnectionStrings["atmt"].ConnectionString;
        public Form19()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                SqlConnection a = new SqlConnection(o);
                string query = "insert into client_login values (@firstname,@lastname,@email,@user,@pass)";
                SqlCommand b = new SqlCommand(query, a);
                b.Parameters.AddWithValue("@firstname", textBox1.Text);
                b.Parameters.AddWithValue("@lastname", textBox2.Text);
                b.Parameters.AddWithValue("@email", textBox3.Text);
                b.Parameters.AddWithValue("@user", textBox4.Text);
                b.Parameters.AddWithValue("@pass", textBox5.Text);


                a.Open();
                int c = b.ExecuteNonQuery();
                if (c > 0)
                {
                    MessageBox.Show("REGISTRATE SUCCESSFULLY");
                    Form4 f = new Form4();
                    f.Show();
                    this.Visible = false;

                }
                else
                {
                    MessageBox.Show("NOT REGISTRATE");
                }
            }
            else
            {
                MessageBox.Show("Enter Your EMAIL AND USER NAME", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }
        void reset()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void Form19_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            this.Visible = false;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.DeepPink;
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Tomato;
            button1.ForeColor = Color.White;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.DeepPink;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.BurlyWood;
            button2.ForeColor = Color.White;
        }
    }
}
