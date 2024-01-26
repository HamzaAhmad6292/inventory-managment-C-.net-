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
    public partial class ledgers_form : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project;Integrated Security=true");
        SqlCommand cmd;

        public string DC;
        public string Invoice;
        public ledgers_form()
        {







            InitializeComponent();
            ledgers.RowTemplate.Height = 17;
            panel2.Hide();
            comboBox2.Text = "Main";
            comboBox1.Text = "Total";
            refresh_ledgers();
            ledgers.RowTemplate.Height = 17;
            
            
            TClients();
            balance();
        }

        private void ledgers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DC = ledgers.CurrentRow.Cells[1].Value.ToString();
            Invoice = ledgers.CurrentRow.Cells[2].Value.ToString();
            string voucher_No = ledgers.CurrentRow.Cells[3].Value.ToString();
            if (e.ColumnIndex==10)
            {
               
                    panel2.Show();
                    panel6.Hide();
                    textBox1.Text = ledgers.CurrentRow.Cells[1].Value.ToString();
                    textBox2.Text = ledgers.CurrentRow.Cells[2].Value.ToString();
                    textBox3.Text = ledgers.CurrentRow.Cells[4].Value.ToString();
                    textBox4.Text = ledgers.CurrentRow.Cells[5].Value.ToString();
                    textBox5.Text = ledgers.CurrentRow.Cells[6].Value.ToString();
                    textBox6.Text = ledgers.CurrentRow.Cells[7].Value.ToString();

                    dateTimePicker1.Text = ledgers.CurrentRow.Cells[9].Value.ToString();
               
                        
            }
            if(e.ColumnIndex==11)
            {
                if (MessageBox.Show("Are You Sure you Want to delete This ledger ? IT CANNOT BE UNDO ! ",
                             "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    string Query = "Delete  ledgers_1 where DC_No='" + DC + "' and Invoice_No='" + Invoice + "' and Voucher_No='"+voucher_No+"'";
                    cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    // Do Nothing
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel6.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            conn.Open();
            string Query1 = "Truncate table Temp";
            cmd = new SqlCommand(Query1, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            this.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                conn.Open();
                string Query = "Update ledgers_1 set DC_No='" + textBox1.Text + "',Invoice_No='" + textBox2.Text + "',Client='" + textBox3.Text + "',Price='" + textBox4.Text + "',Debit='" + textBox5.Text + "' where DC_No='" + DC + "' and Invoice_No='" + Invoice + "'";
                cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                refresh_ledgers();
                refresh_ledgers();

            balance();
          
             

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void refresh_ledgers()
        {

        
            ledgers.Rows.Clear();
            truncate();
            if (comboBox2.Text == "Main")
            {
                last_Date();

                ledgers.Columns[1].Visible = false;
                ledgers.Columns[2].Visible = false;
                ledgers.Columns[3].Visible = false;
                ledgers.Columns[5].Visible = false;
                ledgers.Columns[6].Visible = false;
                ledgers.Columns[9].Visible = false;
                ledgers.Columns[10].Visible = false;
                ledgers.Columns[11].Visible = false;


                ledgers.Columns[4].Width = 300;
                ledgers.Columns[7].Width = 300;
                ledgers.Columns[8].Width = 300;

                return;

            }
            else
            {
                No_last_Date();

                ledgers.Columns[1].Visible = true;
                ledgers.Columns[2].Visible = true;
                ledgers.Columns[3].Visible = true;
                ledgers.Columns[5].Visible = true;
                ledgers.Columns[6].Visible = true;
                ledgers.Columns[9].Visible = true;
                ledgers.Columns[10].Visible=true;
                ledgers.Columns[11].Visible = true;

                ledgers.Columns[4].Width = 100;
                ledgers.Columns[7].Width = 100;
                ledgers.Columns[8].Width = 100;
                return;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ledgers_form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ProjectDataSet26.Temp' table. You can move, or remove it, as needed.
            this.tempTableAdapter.Fill(this.ProjectDataSet26.Temp);
            // TODO: This line of code loads data into the 'ProjectDataSet6.Temp' table. You can move, or remove it, as needed.

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel6.Show();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //conn.Open();
            //DateTime time = dateTimePicker2.Value;
            //string Query1 = "Insert into ledgers_1( DC_No,Invoice_No,Client,Price,Debit,Date) values('" + textBox8.Text + "' , '" + textBox9.Text + "','" + textBox10.Text + "','"+ textBox11.Text +"','" + textBox12.Text + "','" +time+ "')";
            //cmd = new SqlCommand(Query1, conn);
            //cmd.ExecuteNonQuery();
            //conn.Close();
            //refresh_ledgers();
            //TClients();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel4.Hide();
        }
     
        private void button7_Click(object sender, EventArgs e)
        {
            refresh_ledgers();
            balance();
        }
        void TClients()
        {
            conn.Open();
            string Query1 = "Insert into Temp(Client) values('Main')";
            cmd = new SqlCommand(Query1, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            string Query = "Insert into Temp(Client) Select Distinct Client from ledgers_1";
            cmd=new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

           
        }
        void truncate()
        {
          
        }
        void last_Date()
        {
            string Query;
            if (comboBox1.Text == "Total")
            {
                Query = "select Client,Sum(Price) as Price ,Sum(Debit) as Debit from ledgers_1 group by Client";

            }
            else if (comboBox1.Text == "Day")
            {


                Query = "select Client,Sum(Price) as Price ,Sum(Debit) as Debit from ledgers_1 WHERE Date >= DATEADD(Day,-1, GETDATE()) group by Client ";

            }

            else if (comboBox1.Text == "Week")
            {
                Query = "select Client,Sum(Price) as Price ,Sum(Debit) as Debit from ledgers_1 WHERE Date >= DATEADD(Week,-1, GETDATE()) group by Client ";
            }

            else if (comboBox1.Text == "Month")
            {

                Query = "select Client,Sum(Price) as Price ,Sum(Debit) as Debit from ledgers_1  WHERE Date >= DATEADD(Month,-1, GETDATE()) group by Client ";

            }

            else if (comboBox1.Text == "Year")
            {

                Query = "select Client,Sum(Price) as Price ,Sum(Debit) as Debit from ledgers_1 WHERE Date >= DATEADD(Year,-1, GETDATE()) group by Client ";

            }

            else
            {


                DateTime dt = DateTime.Now;
                Query = "select Client,Sum(Price) as Price ,Sum(Debit) as Debit from ledgers_1 WHERE Date between '" + dateTimePicker3.Value + "' and '" + dt + "' group by Client ";

            }
            cmd = new SqlCommand(Query, conn);
            conn.Open();
            var reader = cmd.ExecuteReader();
            int x = 0;
            double Balance = 0;
            double Total = 0;
            while (reader.Read())
            {
                x++;
                var Client = reader["Client"];
                var Credit = reader["Price"];
                var Debit = reader["Debit"];
                
                
                

                int Credit1 = Convert.ToInt32(Credit);
                int Debit1 = Convert.ToInt32(Debit);

               Total = Total + (Credit1 - Debit1);
                Balance = Credit1 - Debit1;

                DateTime dt = DateTime.Now;
                ledgers.Rows.Add(x, 0, 0,0, Client, Credit, Debit, Balance,Total, dt);





            }
            conn.Close();

            color();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

       public  void No_last_Date()
        {
            string Query;
            if (comboBox1.Text == "Total")
            {
                Query = "select * from ledgers_1 where Client = '"+comboBox2.Text+"' order  by Date ";

            }
            else if (comboBox1.Text == "Day")
            {

                DateTime dt = DateTime.Now;
                Query = "select* from ledgers_1 where  Date >= DATEADD(Day,-1, GETDATE())  and Client = '" + comboBox2.Text + "' order by Date ";

            }

            else if (comboBox1.Text == "Week")
            {
                Query = "select* from ledgers_1 where  Date >= DATEADD(Week,-1, GETDATE())  and Client = '" + comboBox2.Text + "' order by Date ";
            }

            else if (comboBox1.Text == "Month")
            {

                Query = "select * from ledgers_1 WHERE Date >= DATEADD(Month,-1, GETDATE())  and Client = '" + comboBox2.Text + "' order by Date";

            }

            else if (comboBox1.Text == "Year")
            {

                Query = "select * from ledgers_1  WHERE Date >= DATEADD(Year,-1, GETDATE()) and Client = '" + comboBox2.Text + "'  order by Date";
            }

            else 
            {


                DateTime dt = DateTime.Now;
                Query = "select * from ledgers_1  WHERE  Client = '" + comboBox2.Text + "' and  Date between '" + dateTimePicker3.Value + "' and '" + dt + "'  order by Date  ";

            }
            conn.Open();
            cmd = new SqlCommand(Query, conn);
            var reader = cmd.ExecuteReader();
            int x = 0;
            double Balance = 0;
            double Total = 0;

            while (reader.Read())
            {
                x++;


                var DC_No = reader["DC_No"];
                var Invoice_No = reader["Invoice_No"];
                var Voucher_No = reader["Voucher_No"];
                var Client = reader["Client"];
                var Credit = reader["Price"];
                var Debit = reader["Debit"];
                var Date = reader["Date"];


                     int Credit1= Convert.ToInt32(Credit);
                int Debit1 = Convert.ToInt32(Debit);

                Total = Total + (Credit1 - Debit1);
                Balance=(Credit1 - Debit1);   

                ledgers.Rows.Add(x,DC_No,Invoice_No,Voucher_No, Client, Credit, Debit,Balance,Total,Date);
            }
            conn.Close();

            color();




        }
        void color()
        {
            for (int i = 0; i < ledgers.Rows.Count; i++)
            {

                int b = Convert.ToInt32(ledgers.Rows[i].Cells[7].Value);
                if (b > 0)
                {
                    ledgers.Rows[i].Cells[7].Style.ForeColor = Color.Green;
                }
                else if(b==0)
                {
                    ledgers.Rows[i].Cells[7].Style.ForeColor = Color.Blue;
                }
                else
                {
                    ledgers.Rows[i].Cells[7].Style.ForeColor = Color.Red;
                }
            }
        }
        void balance()
        {

            double B = 0;
            for (int i = 0; i < ledgers.RowCount; i++)
            {
                if (i == ledgers.RowCount - 1)
                {
                    break;
                }
                B = Convert.ToInt32(ledgers.Rows[i].Cells["Total"].Value);

            }

            label9.Text = B.ToString();
            if (B == 0)
            {
                label9.ForeColor = Color.Blue;
            }
            if (B < 0)
            {
                label9.ForeColor = Color.Red;
            }
            if (B > 0)
            {
                label9.ForeColor = Color.LightGreen;
            }



        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            string Query = "Insert into ledgers_1(No,Voucher_No,Debit,Date,client,DC_No,Invoice_No,Price) values(0,'" + textBox7.Text + "','" + textBox8.Text + "','"+dateTimePicker1.Value.ToString()+"','"+comboBox2.Text+"',0,0,0) ";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            refresh_ledgers();
            balance();

        }
    }
}
