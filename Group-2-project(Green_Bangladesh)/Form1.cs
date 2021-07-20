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
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dip"].ConnectionString;
        string cs1 = ConfigurationManager.ConnectionStrings["dip3"].ConnectionString;
        public static string id;
        public static string name4;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text ="";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text ="";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text =="")
            {
                textBox1.Text = "User Id";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                
                textBox2.Text = "Password";
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form2 F2 = new Form2();
            F2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id = textBox1.Text;
            if (id.Substring(0, 3) == "111")
            {
                SqlConnection sq = new SqlConnection(cs);
                string query = "select * from login_tb_gb_p where userid=@user and pass=@pass";
                SqlCommand sqm = new SqlCommand(query, sq);
                sqm.Parameters.AddWithValue("@user", textBox1.Text);
                sqm.Parameters.AddWithValue("@pass", textBox2.Text);
                sq.Open();
                SqlDataReader sr = sqm.ExecuteReader();


                
                if (sr.HasRows == true)
                {


                    this.Hide();
                    Form3 f3 = new Form3();
                    f3.Show();
                }
                else
                {
                    label3.ForeColor = System.Drawing.Color.Red;
                    label3.Text = "invalied password!! please enter right password";
                    label3.Visible = true;
                }
                sq.Close();

                
                
            }
            else if(id=="200-1234" && textBox2.Text == "12345")
            {
                this.Hide();
                Form5 f5 = new Form5();
                f5.Show();
            }
            else if (id.Substring(0, 3) == "100")
            {
                SqlConnection sq = new SqlConnection(cs1);
                string query = "select * from EMPLOYEE_RES_TB where userid=@user and pass=@pass";
                SqlCommand sqm = new SqlCommand(query, sq);
                sqm.Parameters.AddWithValue("@user", textBox1.Text);
                sqm.Parameters.AddWithValue("@pass", textBox2.Text);
                sq.Open();
                SqlDataReader sr = sqm.ExecuteReader();
                if (sr.HasRows == true)
                {


                    this.Hide();
                    Form6 f3 = new Form6();
                    f3.Show();
                }
                else
                {
                    label3.ForeColor = System.Drawing.Color.Red;
                    label3.Text = "invalied password!! please enter right password";
                    label3.Visible = true;
                }
                sq.Close();

            }
            else if (id.Substring(0, 3) == "110")
            {
                SqlConnection sq = new SqlConnection(cs1);
                string query = "select * from EMPLOYEE_RES_TB where userid=@user and pass=@pass";
                SqlCommand sqm = new SqlCommand(query, sq);
                sqm.Parameters.AddWithValue("@user", textBox1.Text);
                sqm.Parameters.AddWithValue("@pass", textBox2.Text);
                sq.Open();
                SqlDataReader sr = sqm.ExecuteReader();



                if (sr.HasRows == true)
                {


                    this.Hide();
                    Form7 f3 = new Form7();
                    f3.Show();
                }
                else
                {
                    label3.ForeColor = System.Drawing.Color.Red;
                    label3.Text = "invalied password!! please enter right password";
                    label3.Visible = true;
                }
                sq.Close();
            }
            else
            {
                label3.ForeColor = System.Drawing.Color.Red;
                label3.Text = "invalied password!! please enter right password";
                label3.Visible = true;
            }
            
        }
    }
}
