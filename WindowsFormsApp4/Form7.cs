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
    public partial class Form7 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog = Project;Integrated Security=true;");
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog = Project;Integrated Security=true;");

        SqlCommand cmd; public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            conn.Open();
            string check = "Select* from inventory where Name='" + textBox1.Text + "' and Size= '"+comboBox1.Text+"'and Company='"+comboBox2.Text+"'";
            cmd = new SqlCommand(check, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var Item = reader["Name"];
                var Size = reader["Size"];
                var company = reader["Company"];
                if (Item != null && Size != null && company!=null)
                {
                    conn.Close();
                    conn.Open();
                    string Quer = "Insert into TDC(Name,Size,Quantity,IC_No,Client,date,Company) values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','1','1','0111-11-11','"+comboBox2.Text+"')";
                    cmd = new SqlCommand(Quer, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Saved");
                    textBox1.Text = null;
                    comboBox1.Text = null;
                    textBox3.Text = null;
                    comboBox2.Text = null;

                    conn.Close();
                    Refresh();
                    return ;


                }
            }
            conn.Close();
            MessageBox.Show("Item donot Exit kindly Check the Name and Size of the Item");
            this.Close();
            return;







          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        void  refresh()
        { 
            DC_form dc = new DC_form();

           
                dc.dataGridView1.Rows.Clear();
                conn.Open();
                string Query = "Select * from TDC  ";
                cmd = new SqlCommand(Query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var No = reader["No"];
                    var Item_Name = reader["Name"];
                    var Size = reader["Size"];
                    var Quantity = reader["Quantity"];
                var Company = reader["Company"];  
                    dc.dataGridView1.Rows.Add(No, Item_Name, Size,Company, Quantity);
                }
                conn.Close();

            
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sizes.sizes' table. You can move, or remove it, as needed.
            this.sizesTableAdapter.Fill(this.sizes.sizes);
            // TODO: This line of code loads data into the 'ProjectDataSet1.company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.ProjectDataSet1.company);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
