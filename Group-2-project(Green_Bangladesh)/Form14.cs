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
    public partial class Form14 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dip1"].ConnectionString;
        string cs1 = ConfigurationManager.ConnectionStrings["dip"].ConnectionString;
        string cs2 = ConfigurationManager.ConnectionStrings["dip2"].ConnectionString;

        public static string name;
        public static string name1;
        public static string name2;
        public static string name3;
        public static string name4;
        public static string name5;
        public static string name6;
        public static string name7;
        public static string name8;
        public static int qn;
        public static string oid;
        int Discount, tk, ttk;
      
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
             


            SqlConnection sq = new SqlConnection(cs);
            string query = "Select * from PRODUCT_LIST_GB_P where name = '" + (Form11.name).ToString() + "'";
            SqlDataAdapter sqm = new SqlDataAdapter(query, sq);
            DataTable dt = new DataTable();
            sqm.Fill(dt);

            string x = dt.Rows[0]["price"].ToString();
            int x1 = int.Parse(x);
            
            string y = dt.Rows[0]["DISCOUNT"].ToString();
            int y1= int.Parse(y);
            


            

            Discount = (x1 * y1) / 100;
            tk = (x1 - Discount);
           
           
            pictureBox1.Image= GetPhoto((byte[])(dt.Rows[0]["picture"]));
            label1.Text = dt.Rows[0]["name"].ToString();
            
            label2.Text = dt.Rows[0]["price"].ToString() + " TK";
            label3.Text = "Price: "+tk.ToString()+" TK";
            label4.Text = "-" + y + "%";
             
            



            SqlConnection sq1 = new SqlConnection(cs1);
            string query1 = "Select * from login_tb_gb_p where userid = '" + (Form1.id).ToString() + "'";
            SqlDataAdapter sqm1 = new SqlDataAdapter(query1, sq1);
            DataTable dt1 = new DataTable();
            sqm1.Fill(dt1);
            label13.Text = dt1.Rows[0]["CURRENTADDRESS"].ToString();
            name3= dt1.Rows[0]["CURRENTADDRESS"].ToString();
            name4= dt1.Rows[0]["firstname"].ToString() + " " + dt1.Rows[0]["lastname"].ToString();
            name5= dt1.Rows[0]["USERID"].ToString();
            name6= dt1.Rows[0]["PHONUMBER"].ToString();
            name7= dt1.Rows[0]["EMAIL"].ToString();
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f1 = new Form3();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            qn = int.Parse(textBox1.Text);
            ttk = (tk * qn);
            name = ttk + " Tk";
            name1 = (ttk + 45).ToString() + " Tk";
            
            
            name2 = Form11.name;
            Form15 f1 = new Form15();
            f1.Show();


            
        

            
            


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you...\n", " Successfully Add ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
