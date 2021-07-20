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
namespace Group_2_project_Green_Bangladesh_
{
    public partial class Form18 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dip"].ConnectionString;
        public static String imag = "";
        public static String text;
        public static String name;
        public Form18()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = System.Drawing.Color.Black;
           
            


        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "What's on your mind?";
                textBox1.ForeColor = System.Drawing.Color.Thistle;
            }
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            SqlConnection sq = new SqlConnection(cs);
            string query1 = "select * from login_tb_gb_p where userid = '" + (Form1.id).ToString() + "'";
            SqlDataAdapter sqm1 = new SqlDataAdapter(query1, sq);
            DataTable dt1 = new DataTable();
            sqm1.Fill(dt1);
            label1.Text = dt1.Rows[0]["firstname"].ToString() + " " + dt1.Rows[0]["lastname"].ToString();
             name= dt1.Rows[0]["firstname"].ToString() + " " + dt1.Rows[0]["lastname"].ToString(); ;



        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg|PNG files|*.png|All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imag = dialog.FileName;
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("uploade");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string c = imag;

            text=textBox1.Text;
            this.Hide();
            Form3 f1 = new Form3();
            f1.Show();



        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f1 = new Form3();
            f1.Show();
        }
    }
}
