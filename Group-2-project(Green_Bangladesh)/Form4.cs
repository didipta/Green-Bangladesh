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
    public partial class Form4 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dip"].ConnectionString;
        
        public Form4()
        {
            InitializeComponent();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            String imag = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg|PNG files|*.png|All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imag = dialog.FileName;
                    pictureBox1.ImageLocation = imag;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("no uploade");
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlConnection sq = new SqlConnection(cs);
            string query = "Select * from login_tb_gb_p where userid = '" +(Form1.id).ToString()+"'";
            SqlDataAdapter sqm = new SqlDataAdapter(query, sq);
            DataTable dt = new DataTable();
            sqm.Fill(dt);
          
            label1.Text = dt.Rows[0]["firstname"].ToString()+" " +dt.Rows[0]["lastname"].ToString();
            label1.Visible = true;

            label3.Text = dt.Rows[0]["userid"].ToString();
            label3.Visible = true;

            label5.Text = dt.Rows[0]["email"].ToString();
            label5.Visible = true;

            label7.Text = dt.Rows[0]["phonumber"].ToString();
            label7.Visible = true;

            label9.Text = dt.Rows[0]["currentaddress"].ToString();
            label9.Visible = true;


        }
        

            private void pictureBox3_Click(object sender, EventArgs e)
            {
                this.Hide();
                Form3 f3 = new Form3();
                f3.Show();
            }

            private void label3_Click(object sender, EventArgs e)
            {

            }

            private void label5_Click(object sender, EventArgs e)
            {

            }

            private void button1_Click(object sender, EventArgs e)
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }

            private void pictureBox1_Click(object sender, EventArgs e)
            {

            }
        }
    }

