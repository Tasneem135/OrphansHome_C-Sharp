using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace orphans
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form20 f = new Form20();
            f.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.Show();
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Visible = false;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Blue;
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.SteelBlue;
            button1.ForeColor = Color.Black;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {

            button2.BackColor = Color.Blue;
            button2.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.SteelBlue;
            button2.ForeColor = Color.Black;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {

            button3.BackColor = Color.Blue;
            button3.ForeColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.SteelBlue;
            button3.ForeColor = Color.Black;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {

            button4.BackColor = Color.Blue;
            button4.ForeColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.SteelBlue;
            button4.ForeColor = Color.Black;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.Red;
            button5.ForeColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.DarkRed;
            button5.ForeColor = Color.Black;
        }
    }
}
