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
    public partial class Form9 : Form
    {
        string o = ConfigurationManager.ConnectionStrings["atmt"].ConnectionString;
        public Form9()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            showAppointmentAdmin();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(o);
            string query = "insert into appointment values (@no,@day,@time,@status)";
            SqlCommand b = new SqlCommand(query, a);
            b.Parameters.AddWithValue("@no" , numericUpDown1.Value);
            b.Parameters.AddWithValue("@day", textBox1.Text);
            b.Parameters.AddWithValue("@time", textBox2.Text);
            b.Parameters.AddWithValue("@status", " ");
            a.Open();
            int f = b.ExecuteNonQuery();
            if (f >= 0)
            {
                MessageBox.Show("NEW TIME ADDEDED ");
                showAppointmentAdmin();
                ResetControl();

            }
            else
            {
                MessageBox.Show("NOT ADDEDED");
            }

        }
        void showAppointmentAdmin()
        {
            SqlConnection a = new SqlConnection(o);
            string query = "select * from appointment ";
            SqlDataAdapter d = new SqlDataAdapter(query, a);
            DataTable e = new DataTable();
            d.Fill(e);
            dataGridView1.DataSource = e;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            //textBox1.Text =  (dataGridView1.SelectedRows[0].Cells[1].Value);//.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void ResetControl()
        {
            numericUpDown1.Value = 0;
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(o);
            string query = "update appointment set appointment_no=@no,appointment_date=@day,appointment_time=@time where appointment_no=@no ";
            SqlCommand b = new SqlCommand(query, a);
            b.Parameters.AddWithValue("@no", numericUpDown1.Value);
            b.Parameters.AddWithValue("@day", textBox1.Text);
            b.Parameters.AddWithValue("@time", textBox2.Text);
            

            a.Open();
            int  f = b.ExecuteNonQuery();
            if (f > 0)
            {
                MessageBox.Show(" TIME UPDATED ");
                showAppointmentAdmin();
                ResetControl();

            }
            else
            {
                MessageBox.Show("NOT UPDATED");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(o);
            string query = "delete from  appointment where appointment_no=@no ";
            SqlCommand b = new SqlCommand(query, a);
            int no = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            //textBox1.Text =  (dataGridView1.SelectedRows[0].Cells[1].Value);//.ToString();
            string date = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string time = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            b.Parameters.AddWithValue("@no", no);
            //b.Parameters.AddWithValue("@day", textBox1.Text);
            //b.Parameters.AddWithValue("@time", textBox2.Text);
            a.Open();
            int f = b.ExecuteNonQuery();
            if (f >= 0)
            {
                MessageBox.Show(" TIME DELETED ");
                showAppointmentAdmin();
                //ResetControl();

            }
            else
            {
                MessageBox.Show("NOT NOT DELETED");
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
            this.Visible = false;
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

       


       

        private void button2_MouseHover_1(object sender, EventArgs e)
        {

            button2.BackColor = Color.LightSteelBlue;
            button2.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.SteelBlue;
            button1.ForeColor = Color.White;
        }

        private void button2_MouseLeave_1(object sender, EventArgs e)
        {

            button2.BackColor = Color.SteelBlue;
            button2.ForeColor = Color.White;
        }

        private void button5_MouseHover_1(object sender, EventArgs e)
        {
            button5.BackColor = Color.LightSteelBlue;
            button5.ForeColor = Color.Black;
        }

        private void button5_MouseLeave_1(object sender, EventArgs e)
        {
            button5.BackColor = Color.LightSlateGray;
            button5.ForeColor = Color.White;
        }

        private void button1_MouseHover_1(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSteelBlue;
            button1.ForeColor = Color.Black;
        }
    }
}
