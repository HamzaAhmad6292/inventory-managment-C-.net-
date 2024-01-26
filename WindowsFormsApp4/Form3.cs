using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public partial class Form3 : Form
    {
        SqlConnection conn=new SqlConnection(@"Data Source=.;Initial Catalog = Project;Integrated Security=true;");
        SqlCommand cmd;
        SqlCommand command;
        
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string check = "Select * from inventory where Name = '" + textBox1.Text + "' and Size='" + comboBox1.Text + "'and Company='"+comboBox2.Text+"'";

            cmd = new SqlCommand(check, conn);
            var read = cmd.ExecuteReader();
            while (read.Read())
            {
                var item = read["Name"];
                var size = read["Size"];
                var company = read["Company"];
                if (item != null)
                {
                    if (size != null)
                    {
                        if (company != null)
                        {
                            MessageBox.Show("Item Already Saved");
                            textBox1.Text = null;
                            textBox2.Text = null;
                            textBox3.Text = null;
                            comboBox1.Text = null;
                            comboBox2.Text = null;

                            conn.Close();
                            read.Close();
                            this.Close();
                            return;
                        }

                    }
                }
            }
            read.Close();
            conn.Close();


            conn.Open();
            
            string Query = "Insert into inventory(Name,Price,Quantity,Size,Company) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text+"','"+comboBox1.Text+"','"+comboBox2.Text+"')";
            
            command =new SqlCommand(Query, conn);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Item Saved");
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            comboBox1.Text = null;
            comboBox2.Text = null;
            conn.Close();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
        public void check()
        {
            conn.Open();
            string check = "Select * from inventory where Name = '" + textBox1.Text + "' and Size='"+comboBox1.Text+"',Company='"+comboBox2.Text+"'";

            cmd = new SqlCommand(check, conn);
            var read = cmd.ExecuteReader();
            while (read.Read())
            {
                var item = read["Name"];
                var size = read["Size"];
                var company = read["Company"];
                if (item != null)
                {
                    if (size != null)
                    {
                        MessageBox.Show("Item Already Saved");
                        textBox1.Text = null;
                        textBox2.Text = null;
                        textBox3.Text = null;
                        comboBox1.Text = null;
                        comboBox2.Text=null;

                        conn.Close();
                        read.Close();
                        this.Close();
                        return;
                       
                    }
                }
            }
            conn.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ProjectDataSet1.company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.ProjectDataSet1.company);
            // TODO: This line of code loads data into the 'sizes.sizes' table. You can move, or remove it, as needed.
            this.sizesTableAdapter.Fill(this.sizes.sizes);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
