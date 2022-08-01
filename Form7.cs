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
    public partial class Form7 : Form

    {
        string o = ConfigurationManager.ConnectionStrings["atmt"].ConnectionString;
        public Form7()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            showorphansdetails();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        void showorphansdetails()
        {
            SqlConnection a = new SqlConnection(o);
            string query = "select * from orphans ";
            SqlDataAdapter d = new SqlDataAdapter(query, a);
            DataTable e = new DataTable();
            d.Fill(e);
            dataGridView1.DataSource = e;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            DataGridViewImageColumn i = new DataGridViewImageColumn();
            i = (DataGridViewImageColumn)dataGridView1.Columns[8];
            i.ImageLayout = DataGridViewImageCellLayout.Stretch;


            dataGridView1.RowTemplate.Height = 50;

            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Visible = false;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
