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
    public partial class Form15 : Form
    {
        string o = ConfigurationManager.ConnectionStrings["atmt"].ConnectionString;
        public Form15()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(o);
            string query = "insert into donate values (@fname,@lname,@mno,@bname,@Obname,@ano,@damo,@date)";
            SqlCommand b = new SqlCommand(query, a);
            b.Parameters.AddWithValue("@fname",textBox1.Text);
            b.Parameters.AddWithValue("@lname",textBox2.Text);
            b.Parameters.AddWithValue("@mno", textBox3.Text);
            b.Parameters.AddWithValue("@bname",comboBox1.SelectedItem);
            b.Parameters.AddWithValue("@Obname", comboBox2.SelectedItem);
            b.Parameters.AddWithValue("@ano",textBox4.Text);
            b.Parameters.AddWithValue("@damo", textBox5.Text);
            b.Parameters.AddWithValue("@date", textBox6.Text);

            a.Open();
            int c = b.ExecuteNonQuery();
            if (c > 0)
            {
                MessageBox.Show("DONATION ACCEPTED");
                reset();


            }
            else
            {
                MessageBox.Show("FILL UP THE FORM");
            }

            //a.Close();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();

        }
        void reset()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form14 f = new Form14();
            f.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Visible = false;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Crimson;
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Salmon;
            button1.ForeColor = Color.White;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Crimson;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightPink;
            button2.ForeColor = Color.White;
        }
    }
}
