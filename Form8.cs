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
   
    public partial class Form8 : Form
    {
        string o = ConfigurationManager.ConnectionStrings["atmt"].ConnectionString;
        public Form8()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            showdonation();
        }


        void showdonation()
        {
            SqlConnection a = new SqlConnection(o);
            string query = "select * from donate ";
            SqlDataAdapter d = new SqlDataAdapter(query, a);
            DataTable e = new DataTable();
            d.Fill(e);
            dataGridView1.DataSource = e;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
