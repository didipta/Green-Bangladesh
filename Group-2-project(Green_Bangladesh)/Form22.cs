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
    public partial class Form22 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dip2"].ConnectionString;
        string cs2 = ConfigurationManager.ConnectionStrings["dip3"].ConnectionString;
        string cs3 = ConfigurationManager.ConnectionStrings["dip4"].ConnectionString;
        public static string orderid;
        public static string boyid;
        public static string USERID;
        public static string USERNAME;
        public static string ADDRESSS;
        public static string PDNAME;
        public static string PRRICE;
        public static string BOYNAME;
        public static string PHONNO;
        public Form22()
        {
            InitializeComponent();
            BindGridView();
        }

        private void Form22_Load(object sender, EventArgs e)
        {

        }
        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select userid,USERNAME,productname,addresss,orderid,PRICE,PHONE from order_list_tb";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           /* USERID = data.Rows[0]["userid"].ToString();
           USERNAME = data.Rows[0]["USERNAME"].ToString();
           PHONNO = data.Rows[0]["PHONE"].ToString();
           ADDRESSS = data.Rows[0]["addresss"].ToString();
           PRRICE = data.Rows[0]["PRICE"].ToString();
           orderid = data.Rows[0]["orderid"].ToString();
           PDNAME = data.Rows[0]["productname"].ToString();*/



            SqlConnection con1 = new SqlConnection(cs2);
            string query1 = "select userid,name,email,PHONENUMBER from  EMPLOYEE_RES_TB where employee_type='Delivery Boy'";
            SqlDataAdapter sda1 = new SqlDataAdapter(query1, con1);
            DataTable data1 = new DataTable();
            sda1.Fill(data1);
            dataGridView2.DataSource = data1;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           /* boyid = data1.Rows[0]["userid"].ToString();
            BOYNAME = data1.Rows[0]["userid"].ToString();*/
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            label1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            orderid = label1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select userid,USERNAME,productname,addresss,orderid,PRICE,PHONE from order_list_tb where orderid = '" + orderid.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            //dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            USERID = data.Rows[0]["userid"].ToString();
            USERNAME = data.Rows[0]["USERNAME"].ToString();
            PHONNO = data.Rows[0]["PHONE"].ToString();
            ADDRESSS = data.Rows[0]["addresss"].ToString();
            PRRICE = data.Rows[0]["PRICE"].ToString();
            
            PDNAME = data.Rows[0]["productname"].ToString();



            SqlConnection con1 = new SqlConnection(cs2);
            string query1 = "select userid,name,email,PHONENUMBER from  EMPLOYEE_RES_TB where  userid= '" + boyid.ToString() + "'";
            SqlDataAdapter sda1 = new SqlDataAdapter(query1, con1);
            DataTable data1 = new DataTable();
            sda1.Fill(data1);
            //dataGridView2.DataSource = data1;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            BOYNAME = data1.Rows[0]["name"].ToString();


            SqlConnection sq = new SqlConnection(cs3);
            string query2 = "insert into EDelivery_list_tb values(@USERID,@USERNAME,@ADDRESSS,@PRODUCTNAME,@ORDERID,@USERPHONENUMBER,@PDPRICE,@DBNAME,@DBUSERID)";
            SqlCommand smd = new SqlCommand(query2, sq);
            smd.Parameters.AddWithValue("@USERID", USERID);
            smd.Parameters.AddWithValue("@USERNAME", USERNAME);
            smd.Parameters.AddWithValue("@ADDRESSS", ADDRESSS);
            smd.Parameters.AddWithValue("@PRODUCTNAME", PDNAME);
            smd.Parameters.AddWithValue("@ORDERID", orderid);
            smd.Parameters.AddWithValue("@USERPHONENUMBER", PHONNO);
            smd.Parameters.AddWithValue("@PDPRICE", PRRICE);
            smd.Parameters.AddWithValue("@DBNAME", BOYNAME);
            smd.Parameters.AddWithValue("@DBUSERID", boyid);
            sq.Open();
            smd.ExecuteNonQuery();

            MessageBox.Show("Thank you...", " Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            label2.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            boyid = label2.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f1 = new Form6();
            f1.Show();
        }
    }
}
