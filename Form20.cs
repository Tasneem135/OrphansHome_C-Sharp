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
    public partial class Form20 : Form
    {
        string o = ConfigurationManager.ConnectionStrings["atmt"].ConnectionString;
        public Form20()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            showclientinfo();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(o);
            string query = "update  add_client set  first_name=@firstname,last_name=@lastname,mobile_no=@mbl,email=@email,gender=@gender,age=@age,district=@dis,address_=@address,client_catagory=@client where mobile_no=@mbl";
            SqlCommand b = new SqlCommand(query, a);
            b.Parameters.AddWithValue("@firstname", textBox1.Text);
            b.Parameters.AddWithValue("@lastname", textBox2.Text);
            b.Parameters.AddWithValue("@mbl", textBox3.Text);
            b.Parameters.AddWithValue("@email", textBox4.Text);
            b.Parameters.AddWithValue("@gender", comboBox3.SelectedItem);
            b.Parameters.AddWithValue("@age", numericUpDown1.Value);
            b.Parameters.AddWithValue("@dis", comboBox1.SelectedItem);
            b.Parameters.AddWithValue("@address", textBox7.Text);
            b.Parameters.AddWithValue("@client", comboBox2.SelectedItem);



            a.Open();
            int c = b.ExecuteNonQuery();
            if (c > 0)
            {
                MessageBox.Show("CLIENt UPDATED");
                showclientinfo();
                reset();

            }
            else
            {
                MessageBox.Show("NOT UPDATED");
            }
        }
        void showclientinfo()   
        {
            SqlConnection a = new SqlConnection(o);
            string query = "select * from add_client ";
            SqlDataAdapter d = new SqlDataAdapter(query, a);
            DataTable e = new DataTable();
            d.Fill(e);
            dataGridView1.DataSource = e;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value);
            comboBox1.Text= dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            f.Show();
            this.Visible = false;
        }
        void reset()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox7.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            numericUpDown1.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(o);
            string query = "delete from add_client where mobile_no=@mbl";
            SqlCommand b = new SqlCommand(query, a);
            string fname = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string lname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //int mob = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            int mob = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            string email = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            string grnder = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            int age = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value);
            string dis = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            string add = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            string client = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            b.Parameters.AddWithValue("@mbl", mob);



            a.Open();
            int c = b.ExecuteNonQuery();
            if (c > 0)
            {
                MessageBox.Show("CLIENt DELETED SUCCESSFULLY");
                showclientinfo();
                reset();

            }
            else
            {
                MessageBox.Show("NOT DELETED");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

            Form5 f = new Form5();
            f.Show();
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form1 f = new Form1();
            f.Show();
            this.Visible = false;
        }

        private void Form20_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSteelBlue;
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.SteelBlue;
            button1.ForeColor = Color.White;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightSteelBlue;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightSlateGray;
            button2.ForeColor = Color.White;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.LightSteelBlue;
            button4.ForeColor = Color.Black;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.SteelBlue;
            button4.ForeColor = Color.White;
        }
    }
}
