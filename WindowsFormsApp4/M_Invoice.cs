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
    public partial class M_Invoice : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project;integrated Security=true;");
        SqlCommand cmd;
        public M_Invoice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "Truncate table TDC";
            cmd=new SqlCommand(sql,conn);
            cmd.ExecuteNonQuery();
            conn.Close();



            DC_form form = new DC_form();
            conn.Open();
            string Query = "Insert into TDC(DC_No,Name,Size,category,Company,Quantity) Select DC_No,Name,Size,category,Company,Quantity from DC where DC_No='"+textBox1.Text+"'";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            form.textBox1.Text = textBox1.Text;
            form.refresh();
            conn.Close();
            this.Close();
        }

        private void M_Invoice_Load(object sender, EventArgs e)
        {

        }
    }
}
