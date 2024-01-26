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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Project;integrated Security=true;");
        SqlCommand cmd;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }



       private void button1_Click(object sender, EventArgs e)
       {
            con.Open();
            string text = textBox1.Text;
            string password = textBox2.Text;

            string Query = "Select * From user1 where Username = '"+text+"' and Password='"+password+"' ";
            cmd = new SqlCommand(Query,con);
            var reader = cmd.ExecuteReader();
          

            while (reader.Read())
            {

                var name = reader["UserName"];
                var pass = reader["Password"];

                if (name!= null && pass != null)
                {

                    new Form1().Show();
                    this.Hide();
                    return;
                }

                



            }
            MessageBox.Show("Incorrect");
            
            con.Close();
       }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
