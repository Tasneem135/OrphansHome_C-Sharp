using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace orphans
{
    public partial class Form6 : Form
    {
        string o = ConfigurationManager.ConnectionStrings["atmt"].ConnectionString;
        public Form6()

        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(o);
            string query = "insert into add_client values (@firstname,@lastname,@mbl,@email,@gender,@age,@dis,@address,@client)";
            SqlCommand b = new SqlCommand(query, a);
            b.Parameters.AddWithValue("@firstname", textBox1.Text);
            b.Parameters.AddWithValue("@lastname", textBox2.Text);
            b.Parameters.AddWithValue("@mbl", textBox3.Text);
            b.Parameters.AddWithValue("@email", textBox4.Text);
            b.Parameters.AddWithValue("@gender", comboBox1.SelectedItem);
            b.Parameters.AddWithValue("@age", numericUpDown1.Value);
            b.Parameters.AddWithValue("@dis", comboBox2.SelectedItem);
            b.Parameters.AddWithValue("@address", textBox6.Text);
            b.Parameters.AddWithValue("@client", comboBox3.SelectedItem);



            a.Open();
            int c = b.ExecuteNonQuery();
            if (c > 0)
            {
                MessageBox.Show("CLIENT_ADDED");
                reset();

            }
            else
            {
                MessageBox.Show("NOT ADDED");
            }

        }

        void reset()
        {
            textBox1.Clear(); 
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            numericUpDown1.Value = 0;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form20 f = new Form20();
            f.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Visible = false;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightSteelBlue;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.MidnightBlue;
            button2.ForeColor = Color.White;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSteelBlue;
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSlateGray;
            button1.ForeColor = Color.White;
        }
    }
}
