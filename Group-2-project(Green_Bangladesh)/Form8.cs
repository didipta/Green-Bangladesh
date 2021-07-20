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
    public partial class Form8 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dip1"].ConnectionString;
        public static string id;
        public static string name;
        public static int quantity;
        public static int price;
        public static string totale;
        public static int discount;
        public static string payment;
        public static String imag = "";
        public Form8()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            id = textBox1.Text;
            name = textBox3.Text;
            quantity = int.Parse(textBox4.Text);
            price = int.Parse(textBox5.Text);
            discount = int.Parse(textBox7.Text);
            


            float total, Discount, Payment;
            total = price*quantity;
            textBox6.Text = "" + total;
            totale = textBox6.Text;
            Discount = (total *discount) / 100;
            Payment = total - Discount;
            textBox8.Text = "" + Payment;
            payment = textBox8.Text;

            SqlConnection con = new SqlConnection(cs);
            string query = "insert into PRODUCT_LIST_GB_P values(@id,@name,@uantity,@price,@total,@discount,@payment,@img)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox3.Text);
            cmd.Parameters.AddWithValue("@uantity", textBox4.Text);
            cmd.Parameters.AddWithValue("@price", textBox5.Text);
            cmd.Parameters.AddWithValue("@total", total);
            cmd.Parameters.AddWithValue("@discount", textBox7.Text);
            cmd.Parameters.AddWithValue("@payment", payment);
            cmd.Parameters.AddWithValue("@img", SavePhoto());
            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {
                label11.ForeColor = System.Drawing.Color.Green;
                label11.Text = "Inserted successful....Thank you";
                label11.Visible = true;
            }
            else
            {
                label11.ForeColor = System.Drawing.Color.Red;
                label11.Text = "invalied!! please provide all right information!! Thank you...";
                label11.Visible = true;
            }

        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }
        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form6 f1 = new Form6();
            f1.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form9 f2 = new Form9();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image File (All files) *.* | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
