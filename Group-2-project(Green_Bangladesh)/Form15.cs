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
    public partial class Form15 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dip2"].ConnectionString;

        string oid;
        int x;
        static int i = 590283;
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            SqlConnection sq = new SqlConnection(cs);
            string query = "Select * from order_list_tb where userid = '" + (Form1.id).ToString() + "'";
            SqlDataAdapter sqm = new SqlDataAdapter(query, sq);
            DataTable dt = new DataTable();
            sqm.Fill(dt);
            x = dt.Rows.Count;

            label4.Text = Form14.name2;
            label3.Text = "80238474" + (x * i);
            label6.Text = Form14.name;
            label9.Text = Form14.name1;
            label11.Text = Form14.name3;
            

            i = i + 234;











        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sq = new SqlConnection(cs);
            string query = "insert into order_list_tb values(@userid,@username,@productname,@QUANTITY,@price,@addresss,@orderid,@email,@phone)";
            SqlCommand smd = new SqlCommand(query, sq);
            smd.Parameters.AddWithValue("@userid", Form14.name5);
            smd.Parameters.AddWithValue("@username", Form14.name4);
            smd.Parameters.AddWithValue("@productname", Form14.name2);
            smd.Parameters.AddWithValue("@QUANTITY", Form14.qn);
            smd.Parameters.AddWithValue("@addresss", Form14.name3);
            smd.Parameters.AddWithValue("@price", Form14.name);
            smd.Parameters.AddWithValue("@orderid", label3.Text);
            smd.Parameters.AddWithValue("@email", Form14.name7);
            smd.Parameters.AddWithValue("@phone", Form14.name6);
            sq.Open();
            smd.ExecuteNonQuery();

            if (comboBox1.Text == "Bkask")
            {
                Form27 f1 = new Form27();
                f1.Show();
            }
            else if (comboBox1.Text == "Card")
            {
                Form28 f1 = new Form28();
                f1.Show();
            }

            else
            {
                MessageBox.Show("Thank you...\n 4-11 day delivery", " Successfully order receive", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
    }
}
