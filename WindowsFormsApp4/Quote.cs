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
    public partial class Quotation : Form
    {
        public string Quote_Name;
        public string Quote_Size;
        public string Quote_Company;
        public string Quote_Category;

        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project;integrated Security=true;");
        SqlCommand cmd;
        public Quotation()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            DateTime dt = DateTime.Now;
            conn.Open();
            string Query = "Insert into Quotations(Name,Size,Company,Quantity,Client,Date,category) values('" + Quote_Name + "','" + Quote_Size + "','" + Quote_Company + "','"+textBox1.Text+"','"+textBox2.Text+"','"+dt+"','"+Quote_Category+"')";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Quotation Save");
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void Quotation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ProjectDataSet26.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.ProjectDataSet26.Client);
          

        }
    }
}
