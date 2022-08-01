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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form12 f = new Form12();
            f.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form13 f = new Form13();
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
            Form17 f = new Form17();
            f.Show();
            this.Visible = false;
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkOrange;
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Orange;
            button1.ForeColor = Color.Black;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkOrange;
            button2.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Orange;
            button2.ForeColor = Color.Black;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Orange;
            button3.ForeColor = Color.Black;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.DarkOrange;
            button3.ForeColor = Color.White;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.Red;
            button4.ForeColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.DarkRed;
            button4.ForeColor = Color.Black;
        }
    }
}
