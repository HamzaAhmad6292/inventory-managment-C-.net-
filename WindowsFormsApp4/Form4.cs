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
    public partial class Form4 : Form
    {

        public string text;
        public string size;
        public string Company;
        

        SqlConnection conn =new SqlConnection(@"Data Source=.;Initial Catalog=Project;Integrated Security=true");
        SqlCommand cmd;
        public Form4()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                      
                conn.Open();
                string Query1 = "Update inventory Set Name='" + textBox1.Text+"',Price='" + textBox2.Text + "',Quantity='" + textBox3.Text + "',Size='"+comboBox1.Text+"',Company='"+comboBox2.Text+"' where Name = '"+text+"' and Size='"+size+"' and Company='"+Company+"' ";
                cmd = new SqlCommand(Query1, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Item Updated");
                this.Hide();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Form1 form = new Form1();
                
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ProjectDataSet1.company' table. You can move, or remove it, as needed.
            this.companyTableAdapter1.Fill(this.ProjectDataSet1.company);
            // TODO: This line of code loads data into the 'sizes.company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.sizes.company);
            // TODO: This line of code loads data into the 'sizes.sizes' table. You can move, or remove it, as needed.
            this.sizesTableAdapter.Fill(this.sizes.sizes);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
