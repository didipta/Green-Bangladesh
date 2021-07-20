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
    public partial class Form19 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dip3"].ConnectionString;
        public Form19()
        {
            InitializeComponent();
            BindGridView();
        }

        private void Form19_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "insert into EMPLOYEE_RES_TB values(@userid,@name,@email,@employee_type,@phonenumber,@salary,@password)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userid", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@email", textBox3.Text);
            cmd.Parameters.AddWithValue("@employee_type",comboBox1.Text );
            cmd.Parameters.AddWithValue("@phonenumber", textBox5.Text);
            cmd.Parameters.AddWithValue("@salary", textBox6.Text);
           cmd.Parameters.AddWithValue("@password", textBox7.Text);
           // cmd.Parameters.AddWithValue("@img", SavePhoto());
            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {
                label11.ForeColor = System.Drawing.Color.Green;
                label11.Text = "Inserted successful....Thank you";
                label11.Visible = true;
                BindGridView();
                ResetContro();
            }
            else
            {
                label11.ForeColor = System.Drawing.Color.Red;
                label11.Text = "invalied!! please provide all right information!! Thank you...";
                label11.Visible = true;
                ResetContro();
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from EMPLOYEE_RES_TB";
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update EMPLOYEE_RES_TB set USERID=@userid,NAME=@name,EMAIL=@email,EMPLOYEE_TYPE=@employee_type,PHONENUMBER=@phonenumber,SALARY=@salary,PASS=@password where userid=@userid";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@userid", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@email", textBox3.Text);
            cmd.Parameters.AddWithValue("@employee_type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@phonenumber", textBox5.Text);
            cmd.Parameters.AddWithValue("@salary", textBox6.Text);
            cmd.Parameters.AddWithValue("@password", textBox7.Text);
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
        void ResetContro()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text= "seleted Type";
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

            //pictureBox1.Image = Properties.Resources._4fc20722_5368_e911_80d5_b82a72db46f21_680x680pr;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from EMPLOYEE_RES_TB where userid=@userid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userid", textBox1.Text);
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

        private void button5_Click(object sender, EventArgs e)
        {
            ResetContro();
        }
    }
}
