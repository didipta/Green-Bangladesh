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
    public partial class Form20: Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dip2"].ConnectionString;
        public Form20()
        {
            
            InitializeComponent();
            BindGridView();
        }

        private void Form17_Load(object sender, EventArgs e)
        {

        }

        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from order_list_tb";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;


            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f1 = new Form5();
            f1.Show();
        }
    }
}
