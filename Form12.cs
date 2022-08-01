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
    public partial class Form12 : Form
    {
        string o = ConfigurationManager.ConnectionStrings["atmt"].ConnectionString;
        public Form12()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            showorphansdetails();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        void showorphansdetails()
        {
            SqlConnection a = new SqlConnection(o);
            string query = "select Serial_no,Name,Gender,Age,_Status_,Picture from orphans where _Status_ like ('%ing')  ";
            SqlDataAdapter d = new SqlDataAdapter(query, a);
            DataTable e = new DataTable();
            d.Fill(e);
            dataGridView1.DataSource = e;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

     
            DataGridViewImageColumn i = new DataGridViewImageColumn();
            i = (DataGridViewImageColumn)dataGridView1.Columns[5];
            i.ImageLayout = DataGridViewImageCellLayout.Stretch;

       
            dataGridView1.RowTemplate.Height = 50;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(o);
            string query = "insert into adopted_orphans values (@serial,@name,@gender,@age,@father,@mother,@mbl,@date,@picture)";
            SqlCommand b = new SqlCommand(query, a);
            b.Parameters.AddWithValue("@serial", textBox1.Text);
            b.Parameters.AddWithValue("@name", textBox2.Text);
            b.Parameters.AddWithValue("@gender", textBox7.Text);
            b.Parameters.AddWithValue("@age", numericUpDown1.Value);
            b.Parameters.AddWithValue("@father", textBox3.Text);
            b.Parameters.AddWithValue("@mother", textBox4.Text);
            b.Parameters.AddWithValue("@mbl", textBox5.Text);
            b.Parameters.AddWithValue("@date", textBox6.Text);
            b.Parameters.AddWithValue("@picture", SavePhoto());

            a.Open();
            int c = b.ExecuteNonQuery();
            if (c > 0)
            {
                MessageBox.Show("ORPHANS ADOPTED");
                update();
                showorphansdetails();
                reset();

            }
            else
            {
                MessageBox.Show("NOT ADOPTED");
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
            textBox7.Clear();
            numericUpDown1.Value = 0;
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox2.SelectedIndex = 0;
            pictureBox1.Image = Properties.Resources.images__5_;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value);
            comboBox2.Text= dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        void update()
        {
            SqlConnection a = new SqlConnection(o);
            string query = "update orphans set _status_=@status where serial_no=@serial";
            SqlCommand b = new SqlCommand(query, a);
            b.Parameters.AddWithValue("@serial", textBox1.Text);
            b.Parameters.AddWithValue("@status", "Adopted");
           

            a.Open();
            int c = b.ExecuteNonQuery();
            if (c > 0)
            {
               //MessageBox.Show("ADDED");
               // reset();

            }
            else
            {
                //MessageBox.Show("NOT ADDED");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form18 f = new Form18();
            f.Show();
            this.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10();
            f.Show();
            this.Visible = false;
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.OrangeRed;
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Chocolate;
            button1.ForeColor = Color.White;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.OrangeRed;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightSalmon;
            button2.ForeColor = Color.White;
        }
    }
}
