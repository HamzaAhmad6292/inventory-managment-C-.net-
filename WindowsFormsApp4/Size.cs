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

    public partial class Size : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project;integrated Security=true;");
        SqlCommand cmd;
        public Size()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conn.Open();
                string Query = "Insert into sizes(Size) values('" + textBox1.Text + "')";
                cmd=new SqlCommand(Query,conn);
                cmd.ExecuteNonQuery();
                this.Close();
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Size_Load(object sender, EventArgs e)
        {

        }
    }
}
