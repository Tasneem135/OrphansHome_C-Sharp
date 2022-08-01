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
using System.IO;

namespace orphans

{
    public partial class Form11 : Form
    {
        string o = ConfigurationManager.ConnectionStrings["atmt"].ConnectionString;
        public Form11()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(o);
            string query = "insert into orphans values (@serial,@name,@gender,@date,@age,@roomno,@floor,@status,@picture)";
            SqlCommand b = new SqlCommand(query, a);
            b.Parameters.AddWithValue("@serial", textBox1.Text);
            b.Parameters.AddWithValue("@name", textBox2.Text);
            b.Parameters.AddWithValue("@gender", comboBox1.SelectedItem);
            b.Parameters.AddWithValue("@date", textBox3.Text);
            b.Parameters.AddWithValue("@age",numericUpDown1.Value );
            b.Parameters.AddWithValue("@roomno", textBox5.Text);
            b.Parameters.AddWithValue("@floor", comboBox3.SelectedItem);
            b.Parameters.AddWithValue("@status", comboBox2.SelectedItem);
            b.Parameters.AddWithValue("@picture", SavePhoto());
            a.Open();
            int c = b.ExecuteNonQuery();
            if (c > 0)
            {
                MessageBox.Show("NEW ORPHAN ADDEDED");
                reset();

            }
            else
            {
                MessageBox.Show("NOT ADDEDED");
            }

            //a.Close();

        }
        private byte[] SavePhoto()
        {
            MemoryStream m = new MemoryStream();
            pictureBox1.Image.Save(m, pictureBox1.Image.RawFormat);
            return m.GetBuffer();
        }

        void reset()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = 0;
            textBox3.Clear();
            numericUpDown1.Value = 0;
            textBox5.Clear();
            comboBox3.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            pictureBox1.Image = Properties.Resources.images__5_;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Title = "Select Image";
            o.Filter = "Image File (All files) *.* | *.*";

            if (o.ShowDialog() == DialogResult.OK) 
            {
                pictureBox1.Image = new Bitmap(o.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Form13 f = new Form13();
            f.Show();
            this.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10();
            f.Show();
            this.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {

        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.OrangeRed;
            button5.ForeColor = Color.Black;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Coral;
            button5.ForeColor = Color.White;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.OrangeRed;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Chocolate;
            button2.ForeColor = Color.White;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.OrangeRed;
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSalmon;
            button1.ForeColor = Color.White;
        }
    }
}
