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
   
    public partial class Discounts : Form
    {



        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project;integrated Security=true;");

        SqlCommand cmd;
        public Discounts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           





            MessageBox.Show("Saved");
            this.Hide();
            percent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            conn.Open();
            string Query = "Update TDC set Discount ='0'";
            cmd=new SqlCommand(Query,conn);
            cmd.ExecuteNonQuery ();
            conn.Close();



            MessageBox.Show("Updated");
            this.Close();
        }
        public void percent()
        {
          

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Discounts_Load(object sender, EventArgs e)
        {

        }
    }
}
