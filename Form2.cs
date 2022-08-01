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
    public partial class Form2 : Form
    {
        string o = ConfigurationManager.ConnectionStrings["atmt"].ConnectionString;
        public Form2()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection a = new SqlConnection(o);
                string query = "select * from admin_login where username=@name and pass=@password";
                SqlCommand d = new SqlCommand(query, a);
                d.Parameters.AddWithValue("@name", textBox1.Text);
                d.Parameters.AddWithValue("@password", textBox2.Text);
                a.Open();

                SqlDataReader re = d.ExecuteReader();
                if (re.HasRows == true)
                {
                    MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form5 f = new Form5();
                    f.Show();
                    this.Visible = false;
                }

                else
                {
                    MessageBox.Show("Log in failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                a.Close();


            }
            else
            {
                MessageBox.Show("Enter Your Username and Password", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter Your Username First");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Enter Your Password ");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Navy;
            button2.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightSteelBlue;
            button2.ForeColor = Color.Black;
        }
    }
}
