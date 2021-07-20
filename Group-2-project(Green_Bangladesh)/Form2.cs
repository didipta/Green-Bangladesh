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

namespace Group_2_project_Green_Bangladesh_
{
    public partial class Form2 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dip"].ConnectionString;
        public static string name;
        public static string Address;
        public static string Phonen;
        public static string Email;
        public static string Userid;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

  
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            textBox7.Text = "";
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            textBox8.Text = "";
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "First Name";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Last Name";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Current Address";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {

            if (textBox4.Text == "")
            {
                textBox4.Text = "Phone Number";
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {

            if (textBox5.Text == "")
            {
                textBox5.Text = "Email Address";
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "User ID";
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "password";
             
            }
            
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "Confirm password";
            }

            if (textBox8.Text == textBox7.Text)
            {
                pictureBox5.Image = Properties.Resources.right__2_;
                //pictureBox5.Visible = true;
            }

            else
            {
                pictureBox5.Image = Properties.Resources.error;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((textBox1.Text== "First Name" || textBox2.Text== "Last Name" || textBox3.Text == "Current Address" || textBox4.Text == "Phone Number"
                || textBox5.Text == "Email Address" || textBox6.Text == "User ID" || textBox7.Text == "password" || textBox8.Text != textBox7.Text))
            {
                
                    label2.ForeColor = System.Drawing.Color.Red;
                    label2.Text = "invalied!! please provide all right information!! Thank you...";
                    label2.Visible = true;

               
            }
            
            else
            {
                
               // name = textBox1.Text + " " + textBox2.Text;
                //Address = textBox3.Text;
               // Phonen = textBox4.Text;
                //Email = textBox5.Text;
                // Userid = textBox6.Text;

                SqlConnection sq = new SqlConnection(cs);
                string query = "insert into login_tb_gb_p values(@firstname,@lastname,@currentaddress,@phonumber,@email,@userid,@pass,@confirmpass)";
                SqlCommand smd = new SqlCommand(query, sq);
                smd.Parameters.AddWithValue("@firstname", textBox1.Text);
                smd.Parameters.AddWithValue("@lastname", textBox2.Text);
                smd.Parameters.AddWithValue("@currentaddress", textBox3.Text);
                smd.Parameters.AddWithValue("@phonumber", textBox4.Text);
                smd.Parameters.AddWithValue("@email", textBox5.Text);
                smd.Parameters.AddWithValue("@userid", textBox6.Text);
                smd.Parameters.AddWithValue("@pass", textBox7.Text);
                smd.Parameters.AddWithValue("@confirmpass", textBox8.Text);
               
                sq.Open();
                int a = smd.ExecuteNonQuery();
                if (a>0)
                {
                    label2.ForeColor = System.Drawing.Color.Green;
                    label2.Text = "registration successful....Thank you";
                    label2.Visible = true;
                    

                }

                else
                {

                    label2.ForeColor = System.Drawing.Color.Red;
                    label2.Text = "invalied!! please provide all right information!! Thank you...";
                    label2.Visible = true;
                }
                sq.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
