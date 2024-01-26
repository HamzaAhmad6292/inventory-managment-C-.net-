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
    public partial class Form6 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project;integrated Security=true;");
        SqlCommand cmd;
        public Form6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string Query = "Insert into user1(UserName,Password) values('" + textBox1.Text + "','"+textBox2.Text+"')";
                cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                this.Close();
            }

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
