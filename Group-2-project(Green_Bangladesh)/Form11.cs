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
    public partial class Form11 : Form
    {
        public static string name;
        string cs = ConfigurationManager.ConnectionStrings["dip1"].ConnectionString;

        public Form11()
        {
            InitializeComponent();
            BindGridView();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {



            dataGridView1.Columns[0].Width = 300;

            /*int x = Form8.discount;
            int y = Form8.price;
            float tk, Discount;

            Discount = (y * x) / 100;
            tk = (y - Discount);
            pictureBox1.Image= GetPhoto((byte[])(dt.Rows[0]["picture"]));

            label1.Text = Form8.name;
            label1.Visible = true;


            label5.Text = "TK-" + Convert.ToString(tk);
            label5.Visible = true;

            label3.Text = Convert.ToString(Form8.discount)+"%";
            label3.Visible = true;

            label2.Text = "TK-"+ Convert.ToString(Form8.price);
            label2.Visible = true;*/



        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void BindGridView()
        {
            SqlConnection sq = new SqlConnection(cs);
            string query = "Select name , picture from PRODUCT_LIST_GB_P ";
            SqlDataAdapter sqm = new SqlDataAdapter(query, sq);
            DataTable dt = new DataTable();
            sqm.Fill(dt);


            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[1];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
           
            dataGridView1.RowTemplate.Height = 150;
           
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            name = textBox1.Text;
            name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();


            this.Hide();
            Form14 f1 = new Form14();
            f1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f1 = new Form3();
            f1.Show();
        }
    }
}
