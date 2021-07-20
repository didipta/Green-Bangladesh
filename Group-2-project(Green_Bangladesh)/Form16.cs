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
    public partial class Form16 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dip2"].ConnectionString;
        string cs2 = ConfigurationManager.ConnectionStrings["dip5"].ConnectionString;
        public Form16()
        {
            InitializeComponent();
            BindGridView();
            BindGridView2();
        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }
        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select productname,orderid,quantity,price from order_list_tb   where userid = '" + (Form1.id).ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;


            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
          
        }
        public void BindGridView2()
        {
            SqlConnection con = new SqlConnection(cs2);
            string query = "select productname,orderid,pdprice,confirm from receive_list_tb  where userid = '" + (Form1.id).ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView2.DataSource = data;


            //AUTOSIZE
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f1 = new Form3();
            f1.Show();
        }
    }
}
