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
    public partial class Form9 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dip1"].ConnectionString;
        public Form9()
        {
            InitializeComponent();
            BindGridView();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
           
           /* int row = 0;
            dataGridView1.Rows.Add();
            row = dataGridView1.Rows.Count - 2;
            float total,discount,payment;
            total = (Form8.price) * (Form8.quantity);
            Form8.totale = "" + total;
            discount = (total * (Form8.discount)) / 100;
            payment = total - discount;
            Form8.payment = "" + payment;
            dataGridView1["Id", row].Value = Form8.id;
            dataGridView1["Name", row].Value = Form8.name;
            dataGridView1["Quantity", row].Value = Form8.quantity;
            dataGridView1["Price", row].Value = Form8.price;
            dataGridView1["Total", row].Value = Form8.totale;
            dataGridView1["Discount", row].Value = Form8.discount;
            dataGridView1["Payment", row].Value = Form8.payment;
           */
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form6 f1 = new Form6();
            f1.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from PRODUCT_LIST_GB_P";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            ///Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[7];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 f1 = new Form12();
            f1.Show();
        }
    }
}
