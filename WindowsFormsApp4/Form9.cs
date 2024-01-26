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
    public partial class Form9 : Form
    {


        public Form9()
        {
            InitializeComponent();
            history.RowTemplate.Height = 20;
            this.WindowState = FormWindowState.Maximized;
            history.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            history.Rows.Clear();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
