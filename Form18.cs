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
    public partial class Form18 : Form
    {
        string o = ConfigurationManager.ConnectionStrings["atmt"].ConnectionString;

        public Image Image { get; private set; }

        public Form18()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            showoradoptedphansdetails();
        }
        void showoradoptedphansdetails()
        {
            SqlConnection a = new SqlConnection(o);
            string query = "select * from adopted_orphans  ";
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
            Form12 f = new Form12();
            f.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(o);
            string query = "delete from adopted_orphans where serial_no=@serial";
            SqlCommand b = new SqlCommand(query, a);
            int  serial = Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string gender= dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            string age = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            string father = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            string mother = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            int mob= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
            string date =dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[8].Value);

            b.Parameters.AddWithValue("@serial", serial);




            a.Open();
            int c = b.ExecuteNonQuery();
            if (c > 0)
            {
                MessageBox.Show("DELETED SUCCESSFULLY");
                showoradoptedphansdetails();
            }
            else
            {
                MessageBox.Show("NOT DELETED");
            }



        }
        Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }


        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
           Text = dataGridView1.SelectedRows[1].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.OrangeRed;
            button1.ForeColor = Color.Black;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Coral;
            button4.ForeColor = Color.White;
        }
    }
}
