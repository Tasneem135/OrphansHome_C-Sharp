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
    public partial class Form16 : Form
    {
        string o = ConfigurationManager.ConnectionStrings["atmt"].ConnectionString;
        public Form16()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            showAppointmentClient();
            showorphansdetails();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) 
        {
            if (textBox3.Text != "" && textBox4.Text != "")
            {

                SqlConnection a = new SqlConnection(o);
                string query = "insert into client_request values (@cname,@cmbl,@adate,@atime,@oserial,@oname,@ogender,@age,@picture)";
                SqlCommand b = new SqlCommand(query, a);
                b.Parameters.AddWithValue("@cname", textBox3.Text);
                b.Parameters.AddWithValue("@cmbl", textBox4.Text);
                b.Parameters.AddWithValue("@adate", textBox1.Text);
                b.Parameters.AddWithValue("@atime", textBox2.Text);
                b.Parameters.AddWithValue("@oserial", textBox9.Text);
                b.Parameters.AddWithValue("@oname", textBox6.Text);
                b.Parameters.AddWithValue("@ogender", textBox7.Text);
                b.Parameters.AddWithValue("@age", textBox8.Text);
                b.Parameters.AddWithValue("@picture", SavePhoto());

                a.Open();
                int c = b.ExecuteNonQuery();
                if (c > 0)
                {
                    MessageBox.Show("REQUEST ACCEPTED");
                    showstatusupdate();
                    showorphansdetails();
                    update();
                    ResetControl();

                }
                else
                {
                    MessageBox.Show("NOT ACCEPTED");
                }
            }
            else
            {
                MessageBox.Show("Enter Your Username and Mobile No", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private byte[] SavePhoto()
        {
            MemoryStream m = new MemoryStream();
            pictureBox1.Image.Save(m, pictureBox1.Image.RawFormat);
            return m.GetBuffer();
        }
        void showAppointmentClient()   
        {
            SqlConnection a = new SqlConnection(o);
            string query = "select Appointment_No,Appointment_Date,Appointment_Time,Statuss from appointment where Statuss=' ' " ;
            SqlDataAdapter d = new SqlDataAdapter(query, a);
            DataTable e = new DataTable();
            d.Fill(e);
            dataGridView1.DataSource = e;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            //textBox1.Text =  (dataGridView1.SelectedRows[0].Cells[1].Value);//.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

        }

        void showorphansdetails()
        {
            SqlConnection a = new SqlConnection(o);
            string query = "select   Serial_no,Name,Gender,Age,_Status_ ,Picture from orphans where _status_='Waiting'";
            SqlDataAdapter d = new SqlDataAdapter(query, a);
            DataTable e = new DataTable();
            d.Fill(e);
            dataGridView2.DataSource = e;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            DataGridViewImageColumn i = new DataGridViewImageColumn();
            i = (DataGridViewImageColumn)dataGridView2.Columns[5];
            i.ImageLayout = DataGridViewImageCellLayout.Stretch;


            dataGridView2.RowTemplate.Height = 50;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[4].Visible = false;


        }

         void showstatusupdate() 
         {
            SqlConnection a = new SqlConnection(o);
            string query = "update orphans set _status_=@status where serial_no=@serial";
            SqlCommand b = new SqlCommand(query, a);
            b.Parameters.AddWithValue("@serial", textBox9.Text);
            b.Parameters.AddWithValue("@status", "Requesting");


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

      

       private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            //textBox1.Text =  (dataGridView1.SelectedRows[0].Cells[1].Value);//.ToString();
            textBox9.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            textBox6.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            textBox7.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            textBox8.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            textBox10.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView2.SelectedRows[0].Cells[5].Value);
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }



        void update() 
        {
            SqlConnection a = new SqlConnection(o);
            string query = "update appointment set statuss=@status where appointment_no=@no";
            SqlCommand b = new SqlCommand(query, a);
            b.Parameters.AddWithValue("@no", numericUpDown1.Value);
            //b.Parameters.AddWithValue("@date", textBox1.Text);
            //b.Parameters.AddWithValue("@time", textBox2.Text);
            b.Parameters.AddWithValue("@status", "Confrimed");

            a.Open();
            int f = b.ExecuteNonQuery();
            if (f >= 0)
            {
                //MessageBox.Show(" TIME DELETED ");
                showAppointmentClient();

            }
            else
            {
                //MessageBox.Show("NOT NOT DELETED");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Visible = false;
        }

      
         void ResetControl()
        {
            textBox3.Clear();
            textBox4.Clear();
            numericUpDown1.Value = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox10.Clear();
            pictureBox1.Image = Properties.Resources.images__5_;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form14 f = new Form14();
            f.Show();
            this.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider1.SetError(this.textBox3, "Enter Your NAME ");
            }
            else
            {
                errorProvider1.Clear();
            }

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider2.SetError(this.textBox4, "Enter Your MOBILE_NO ");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Crimson;
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Salmon;
            button1.ForeColor = Color.White;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.Crimson;
            button5.ForeColor = Color.Black;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.LightPink;
            button5.ForeColor = Color.White;
        }
    }
}
