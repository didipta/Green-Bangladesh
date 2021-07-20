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
    public partial class Form12 : Form
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
        public static float total;
        public Form12()
        {
            InitializeComponent();
            BindGridView();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            totale = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            payment = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[7].Value);
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
            id = textBox1.Text;
            name = textBox2.Text;
            quantity = int.Parse(textBox3.Text);
            price = int.Parse(textBox4.Text);
            discount = int.Parse(textBox6.Text);



            float total, Discount, Payment;
            total = price * quantity;
            textBox5.Text = "" + total;
            totale = textBox5.Text;
            Discount = (total * discount) / 100;
            Payment = total - Discount;
            textBox7.Text = "" + Payment;
            payment = textBox7.Text;

            SqlConnection con = new SqlConnection(cs);
            string query = "update PRODUCT_LIST_GB_P set id=@id,name=@name,quantity=@uantity,price=@price,total=@total,discount=@discount,payment=@payment,picture=@img where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@uantity", textBox3.Text);
            cmd.Parameters.AddWithValue("@price", textBox4.Text);
            cmd.Parameters.AddWithValue("@total", totale);
            cmd.Parameters.AddWithValue("@discount", textBox6.Text);
            cmd.Parameters.AddWithValue("@payment", payment);
            cmd.Parameters.AddWithValue("@img", SavePhoto());
            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {
                label11.ForeColor = System.Drawing.Color.Green;
                label11.Text = "Data Updated Successfully !....Thank you";
                label11.Visible = true;
                BindGridView();
                ResetContro();
            }
            else
            {
            

                label11.ForeColor = System.Drawing.Color.Red;
                label11.Text = "invalied!! Data not Updated !!!!";
                label11.Visible = true;
            }

        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {

        }

      
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image File (All files) *.* | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f1 = new Form6();
            f1.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from PRODUCT_LIST_GB_P where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a >= 0)
            {

                label11.ForeColor = System.Drawing.Color.Green;
                label11.Text = "Data Deleted Successfully!!!....Thank you";
                label11.Visible = true;
                
                BindGridView();
                ResetContro();
            }
            else
            {
                label11.ForeColor = System.Drawing.Color.Red;
                label11.Text = "invalied!! Data not Deleted !!!!!";
                label11.Visible = true;
                
            }
        }
        void ResetContro()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            
            pictureBox1.Image = Properties.Resources._4fc20722_5368_e911_80d5_b82a72db46f21_680x680pr;
        }
    }
}
