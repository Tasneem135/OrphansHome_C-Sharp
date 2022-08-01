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
    public partial class Form17 : Form
    {
        string o = ConfigurationManager.ConnectionStrings["atmt"].ConnectionString;

        public Image Image { get; private set; }

        public Form17()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            showorphansdetails();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        void showorphansdetails()
        {
            SqlConnection a = new SqlConnection(o);
           string query = "select * from client_request";
            SqlDataAdapter d = new SqlDataAdapter(query, a);
            DataTable e = new DataTable();
            d.Fill(e);
            dataGridView1.DataSource = e;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            DataGridViewImageColumn i = new DataGridViewImageColumn();
            i = (DataGridViewImageColumn)dataGridView1.Columns[8];
            i.ImageLayout = DataGridViewImageCellLayout.Stretch;


            dataGridView1.RowTemplate.Height = 50;

            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10();
            f.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(o);
            string query = "delete from client_request where orphans_serial_no=@serial";
            SqlCommand b = new SqlCommand(query, a);
           
           
            string cname = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int cmob = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            string date = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            string time = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            int serial = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            string oname = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            string gender = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            string age = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[8].Value);

            b.Parameters.AddWithValue("@serial", serial);




            a.Open();
            int c = b.ExecuteNonQuery();
            if (c > 0)
            {
                MessageBox.Show("DELETED SUCCESSFULLY");
                showorphansdetails();
            }
            else
            {
                MessageBox.Show("NOT DELETED");
            }
            Image GetPhoto(byte[] photo)
            {
                MemoryStream ms = new MemoryStream(photo);
                return Image.FromStream(ms);
            }

        }

        private void Form17_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.OrangeRed;
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Coral;
            button1.ForeColor = Color.White;
        }
    }
}
