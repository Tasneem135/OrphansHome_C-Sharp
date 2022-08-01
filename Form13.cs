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
    public partial class Form13 : Form
    {
        string o = ConfigurationManager.ConnectionStrings["atmt"].ConnectionString;

        public Image Image { get; private set; }

        public Form13()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            showorphans();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(o);
            string query = "delete from orphans where serial_no=@serial";
            SqlCommand b = new SqlCommand(query, a);
            int serial = Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string gender = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            string date = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            string age = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            int room = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            string floor = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            string status = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[8].Value);
            b.Parameters.AddWithValue("@serial", serial);

            a.Open();
            int c = b.ExecuteNonQuery();
            if (c > 0)
            {
                MessageBox.Show("ORPHANS DELETED SUCCESSFULLY");
                showorphans();
                //reset();

            }
            else
            {
                MessageBox.Show("NOT DELETTED");
            }

            //a.Close(); 


        }
       

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value);
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[8].Value);

        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        


        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Title = "Select Image";
            o.Filter = "Image File (All files) *.* | *.*";

            if (o.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(o.FileName);
            }
        }
        void showorphans()
        {
            SqlConnection a = new SqlConnection(o);
            string query = "select * from orphans";
            SqlDataAdapter d = new SqlDataAdapter(query, a);
            DataTable e = new DataTable();
            d.Fill(e);
            dataGridView1.DataSource = e;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            DataGridViewImageColumn i = new DataGridViewImageColumn();
            i = (DataGridViewImageColumn)dataGridView1.Columns[8];
            i.ImageLayout = DataGridViewImageCellLayout.Stretch;


            dataGridView1.RowTemplate.Height = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(o);
            string query = "update orphans set serial_no=@serial,name=@name,gender=@gender,entry_date=@date,age=@age,room_no=@roomno,floor_no=@floor,_status_=@status,picture=@picture where serial_no=@serial";
            SqlCommand b = new SqlCommand(query, a);
            b.Parameters.AddWithValue("@serial", textBox1.Text);
            b.Parameters.AddWithValue("@name", textBox2.Text);
            b.Parameters.AddWithValue("@gender", comboBox1.SelectedItem);
            b.Parameters.AddWithValue("@date", textBox3.Text);
            b.Parameters.AddWithValue("@age", numericUpDown1.Value);
            b.Parameters.AddWithValue("@roomno", textBox4.Text);
            b.Parameters.AddWithValue("@floor", comboBox2.SelectedItem);
            b.Parameters.AddWithValue("@status", comboBox3.SelectedItem);
            b.Parameters.AddWithValue("@picture", SavePhoto());
            a.Open();
            int c = b.ExecuteNonQuery();
            if (c > 0)
            {
                MessageBox.Show(" ORPHAN iNFORMATION UPDATED");
                showorphans();
                reset();

            }
            else
            {
                MessageBox.Show("NOT UPDATED");
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
            textBox3.Clear();
            textBox4.Clear();
            numericUpDown1.Value = 0;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            pictureBox1.Image = Properties.Resources.images__5_;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
            Form11 f = new Form11();
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

        private void Form13_Load(object sender, EventArgs e)
        {

        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.BackColor = Color.OrangeRed;
            button6.ForeColor = Color.Black;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.LightSalmon;
            button6.ForeColor = Color.White;
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

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.OrangeRed;
            button5.ForeColor = Color.Black;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Chocolate;
            button5.ForeColor = Color.White;
        }
    }
}
