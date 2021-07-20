using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_2_project_Green_Bangladesh_
{
    public partial class Form3 : Form
    {
        public static string pname;
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search.....";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
          
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {
            linkLabel1.LinkColor = System.Drawing.Color.Blue;
            linkLabel1.BackColor = System.Drawing.Color.White;
        }

        private void linkLabel1_MouseLeave(object sender, EventArgs e)
        {
            linkLabel1.LinkColor = System.Drawing.Color.White;
            linkLabel1.BackColor = System.Drawing.Color.DarkGreen;
        }

        private void linkLabel2_MouseHover(object sender, EventArgs e)
        {
            linkLabel2.LinkColor = System.Drawing.Color.Blue;
            linkLabel2.BackColor = System.Drawing.Color.White;
        }

        private void linkLabel2_MouseLeave(object sender, EventArgs e)
        {
            linkLabel2.LinkColor = System.Drawing.Color.White;
            linkLabel2.BackColor = System.Drawing.Color.DarkGreen;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form11 f1 = new Form11();
            f1.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void linkLabel3_MouseHover(object sender, EventArgs e)
        {
            linkLabel3.LinkColor = System.Drawing.Color.Blue;
            linkLabel3.BackColor = System.Drawing.Color.White;
        }

        private void linkLabel3_MouseLeave(object sender, EventArgs e)
        {
            linkLabel3.LinkColor = System.Drawing.Color.White;
            linkLabel3.BackColor = System.Drawing.Color.DarkGreen;
        }

        private void linkLabel4_MouseHover(object sender, EventArgs e)
        {
            linkLabel4.LinkColor = System.Drawing.Color.Blue;
            linkLabel4.BackColor = System.Drawing.Color.White;
        }

        private void linkLabel4_MouseLeave(object sender, EventArgs e)
        {
            linkLabel4.LinkColor = System.Drawing.Color.White;
            linkLabel4.BackColor = System.Drawing.Color.DarkGreen;
        }

        private void linkLabel5_MouseHover(object sender, EventArgs e)
        {
            linkLabel5.LinkColor = System.Drawing.Color.Blue;
            linkLabel5.BackColor = System.Drawing.Color.White;

           
        }

        private void linkLabel5_MouseLeave(object sender, EventArgs e)
        {
            linkLabel5.LinkColor = System.Drawing.Color.White;
            linkLabel5.BackColor = System.Drawing.Color.DarkGreen;
            
        }

        private void linkLabel6_MouseHover(object sender, EventArgs e)
        {
            linkLabel6.LinkColor = System.Drawing.Color.Blue;
            linkLabel6.BackColor = System.Drawing.Color.White;
        }

        private void linkLabel6_MouseLeave(object sender, EventArgs e)
        {
            linkLabel6.LinkColor = System.Drawing.Color.White;
            linkLabel6.BackColor = System.Drawing.Color.DarkGreen;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox3.ImageLocation = Form18.imag;
            label16.Text = Form18.text;
           
            label2.Text = Form18.name;
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ForeColor= System.Drawing.Color.White; 
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Complaint Box";
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form16 f4 = new Form16();
            f4.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form18 f4 = new Form18();
            f4.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pname = textBox1.Text;
            this.Hide();
            Form29 f1 = new Form29();
            Form11 f2 = new Form11();
            f1.Show();
        }
    }
}
