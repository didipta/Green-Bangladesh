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
    public partial class Form25: Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dip4"].ConnectionString;
        string cs2 = ConfigurationManager.ConnectionStrings["dip5"].ConnectionString;
        public static string USERID;
        public static string USERIDs;
        public static string USERNAME;
        public static string ADDRESSS;
        public static string PDNAME;
        public static string PRRICE;
        public static string BOYNAME;
        public static string PHONNO;
        public static string orderid;
        public static string DBUSERID;
        public static string DBUSERID1;
        public Form25()
        {
            
            InitializeComponent();
            BindGridView();
            BindGridView2();
        }

        private void Form17_Load(object sender, EventArgs e)
        {

        }

        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from EDelivery_list_tb where DBUSERID = '" + (Form1.id).ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
           /* USERID = data.Rows[0]["userid"].ToString();
            USERNAME = data.Rows[0]["USERNAME"].ToString();
            PHONNO = data.Rows[0]["USERPHONENUMBER"].ToString();
            ADDRESSS = data.Rows[0]["addresss"].ToString();
            PRRICE = data.Rows[0]["PDPRICE"].ToString();
            PDNAME = data.Rows[0]["productname"].ToString();
            orderid = data.Rows[0]["orderid"].ToString();*/


            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f1 = new Form7();
            f1.Show();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            USERID = label2.Text;
            USERNAME = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            PHONNO = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            ADDRESSS = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            PRRICE = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            PDNAME = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            PDNAME = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            label3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            orderid = label3.Text;
            DBUSERID= dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*SqlConnection con = new SqlConnection(cs);
            string query = "select * from EDelivery_list_tb where ORDERID = '" + (label3.Text).ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
           // dataGridView1.DataSource = data;
            USERIDs = data.Rows[0]["userid"].ToString();
            USERNAME = data.Rows[0]["USERNAME"].ToString();
            PHONNO = data.Rows[0]["USERPHONENUMBER"].ToString();
            ADDRESSS = data.Rows[0]["addresss"].ToString();
            PRRICE = data.Rows[0]["PDPRICE"].ToString();
            PDNAME = data.Rows[0]["productname"].ToString();
            orderid = data.Rows[0]["orderid"].ToString();
            DBUSERID = data.Rows[0]["DBUSERID"].ToString();*/



            SqlConnection sq = new SqlConnection(cs2);
            string query2 = "insert into receive_list_tb values(@USERID,@USERNAME,@ADDRESSS,@PRODUCTNAME,@ORDERID,@USERPHONENUMBER,@PDPRICE,@confirm,@DBUSERID)";
            SqlCommand smd = new SqlCommand(query2, sq);
            smd.Parameters.AddWithValue("@USERID", USERID);
            smd.Parameters.AddWithValue("@USERNAME", USERNAME);
            smd.Parameters.AddWithValue("@ADDRESSS", ADDRESSS);
            smd.Parameters.AddWithValue("@PRODUCTNAME", PDNAME);
            smd.Parameters.AddWithValue("@ORDERID", orderid);
            smd.Parameters.AddWithValue("@USERPHONENUMBER", PHONNO);
            smd.Parameters.AddWithValue("@PDPRICE", PRRICE);
            smd.Parameters.AddWithValue("@confirm", comboBox1.Text);
            smd.Parameters.AddWithValue("@DBUSERID", DBUSERID);
            
            sq.Open();
            smd.ExecuteNonQuery();

            BindGridView2();

            /*SqlConnection con1 = new SqlConnection(cs2);
            string query1 = "select * from receive_list_tb where userid = '" + USERID.ToString() + "'";
            SqlDataAdapter sda1 = new SqlDataAdapter(query1, con1);
            DataTable data1 = new DataTable();
            sda1.Fill(data1);
            dataGridView2.DataSource = data1;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;*/
            ResetContro();

        }
        public void BindGridView2()
        {
            SqlConnection con1 = new SqlConnection(cs2);
            string query1 = "select * from receive_list_tb where DBUSERID = '" + (Form1.id).ToString() + "'";
            SqlDataAdapter sda1 = new SqlDataAdapter(query1, con1);
            DataTable data1 = new DataTable();
            sda1.Fill(data1);
            dataGridView2.DataSource = data1;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sq = new SqlConnection(cs2);
            string query2 = "update receive_list_tb set CONFIRM=@confirm where ORDERID=@ORDERID AND DBUSERID=@DBUSERID";
            SqlCommand smd1 = new SqlCommand(query2, sq);
            smd1.Parameters.AddWithValue("@confirm", comboBox1.Text);
            smd1.Parameters.AddWithValue("@ORDERID", label3.Text);
            smd1.Parameters.AddWithValue("@DBUSERID", label2.Text);

            sq.Open();
            smd1.ExecuteNonQuery();

            MessageBox.Show("Thank you...", " Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BindGridView2();
            ResetContro();
        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            comboBox1.Text = dataGridView2.SelectedRows[0].Cells[7].Value.ToString();
            label3.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
            label2.Text = dataGridView2.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        void ResetContro()
        {
            comboBox1.Text= "selected one";
            label3.Text=" ";
            label2.Text=" ";
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
