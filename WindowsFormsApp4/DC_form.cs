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
using System.IO;
namespace WindowsFormsApp4
{
    public partial class DC_form : Form
    {
        public String name;
        public String size;
        public String quantity;
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Project;integrated Security=true;");
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project;integrated Security=true;");

        SqlCommand cmd;

        string Name_text ;
        string Size_text  ;
        string Company_text;
        string Quantity_text;
        string Category_Text;
        public DC_form()
        {

            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            panel3.Hide();
            panel4.Hide();
            dataGridView1.RowTemplate.Height = 20;
            Get_DC_No();
            refresh();
            getQ_No();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
            panel3.Show();
            panel4.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }







        private void button1_Click_1(object sender, EventArgs e)
        {
           

            if (MessageBox.Show("Do you want to save the DC ?",
                                "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {





                conn.Open();
                DateTime dt = dateTimePicker1.Value;
                int day = dateTimePicker1.Value.Day;
                int month = dateTimePicker1.Value.Month;
                int year = dateTimePicker1.Value.Year;
                string Query = "UPDATE  TDC set IC_No='" + textBox1.Text + "',Client='" + textBox2.Text + "', Date='" + dateTimePicker1.Value + "'";
                cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                string check = "Select DC_No from DC where DC_No='" + textBox1.Text + "' ";
                cmd=new SqlCommand(check, conn);
                var reader=cmd.ExecuteReader();
                while(reader.Read())
                {
                    var DC_No = reader["DC_No"].ToString();
                    if(DC_No!=null)
                    {
                        conn.Close();
                            con.Open();
                        int y = Int32.Parse(textBox1.Text);
                        int x = 100 + y;
                        string del = "Delete from DC where DC_No='" + textBox1.Text + "'; Delete from invoice where Invoice_No='"+x+"'; Delete from ledgers_1 where DC_No='"+textBox1.Text+"' and Invoice_No='"+x+"' ";
                         cmd= new SqlCommand(del, con);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        conn.Open();
                        String Query1 = "Insert into DC(Name, Size,Company, Quantity, Client, Date, DC_No,category,Q_No) select Name, Size,Company, Quantity, Client, Date, IC_No,category,Q_No from TDC";
                        cmd = new SqlCommand(Query1, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Delivery Challan\nUpdated");

                        return ;

                    }

                }
                conn.Close();
                conn.Open();
                string Query2 = "Insert into DC(Name, Size,Company, Quantity, Client, Date, DC_No,category,Q_No) select Name, Size,Company, Quantity, Client, Date, IC_No,category,Q_No from TDC";
                cmd = new SqlCommand(Query2, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Delivery Challan\nSaved");







            }
            else
            {
                // Do nothing
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string Query = "Truncate Table TDC";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            this.Close();
        }
        public void refresh()
        {
            
            dataGridView1.Rows.Clear();
            conn.Open();
            string Query = "Select * from TDC  ";

            cmd = new SqlCommand(Query, conn);
            var reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                x++;
                var Item_Name = reader["Name"];
                var Size = reader["Size"];
                var Quantity = reader["Quantity"];
                var Company = reader["Company"];
                var category = reader["category"];
                dataGridView1.Rows.Add(x, Item_Name, Size,category, Company, Quantity);
            }
            conn.Close();

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void DC_form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ProjectDataSet29.Quote_No' table. You can move, or remove it, as needed.
            this.quote_NoTableAdapter.Fill(this.ProjectDataSet29.Quote_No);
            // TODO: This line of code loads data into the 'ProjectDataSet27.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter1.Fill(this.ProjectDataSet27.Client);
            // TODO: This line of code loads data into the 'ProjectDataSet27.categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.ProjectDataSet27.categories);
            // TODO: This line of code loads data into the 'ProjectDataSet26.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.ProjectDataSet26.Client);
            // TODO: This line of code loads data into the 'ProjectDataSet26.company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.ProjectDataSet26.company);
       
            // TODO: This line of code loads data into the 'ProjectDataSet26.sizes' table. You can move, or remove it, as needed.
            this.sizesTableAdapter.Fill(this.ProjectDataSet26.sizes);
            // TODO: This line of code loads data into the 'ProjectDataSet26.Name' table. You can move, or remove it, as needed.
            this.nameTableAdapter.Fill(this.ProjectDataSet26.Name);


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int inv_total = 0;
            bool flag = false;
            int Q_total = 0;
            conn.Open();
            string Q_Check = "Select * from Quotations where Name='" + comboBox1.Text + "' and Size='" + comboBox2.Text + "' and Category='" + Cat_Box.Text + "' and Company='" + comboBox3.Text + "'";
            cmd = new SqlCommand(Q_Check, conn);
            var Qreader = cmd.ExecuteReader();

            Form8 form8 = new Form8();
            while (Qreader.Read())
            {


                var Quote_No = Qreader["Q_No"];
                var Quote_Client = Qreader["Client"];
                var Quote_Quantity = Qreader["Quantity"];
                var Quote_Date = Qreader["Date"];

                if (Quote_Client != null)
                {

                    flag = true;
                    Q_total = Convert.ToInt32(Quote_Quantity.ToString()) + Q_total;

                    form8.dataGridView1.Rows.Add(Quote_No, Quote_Client, Quote_Quantity, Quote_Date);


                }
                else
                {

                    break;
                }


            }

            if (flag == true)
            {
                conn.Close();

                conn.Open();
                string search = "Select * from inventory where Name='" + comboBox3.Text + "' and Size='" + comboBox1.Text + "' and Category='" + Cat_Box.Text + "' and Company='" + comboBox2.Text + "'";
                cmd = new SqlCommand(search, conn);
                var S_reader = cmd.ExecuteReader();
                while (S_reader.Read())
                {
                    var S_Quantity = S_reader["Quantity"];
                    inv_total = Convert.ToInt32(S_Quantity.ToString());

                }
                conn.Close();

                int x = inv_total - Q_total;
                form8.textBox1.Text = x.ToString();
                form8.textBox2.Text = Q_total.ToString();

                form8.Show();


            }
            else
            {
                conn.Close();

            }

            conn.Open();
                string check = "Select * from inventory where Name='" + comboBox1.Text + "' and Size= '" + comboBox2.Text + "'and Company='" + comboBox3.Text + "'   and category= '" + Cat_Box.Text + "' ;Select* from Quotations where Name='" + comboBox1.Text + "' and Size= '" + comboBox2.Text + "' and Company='" + comboBox3.Text + "' and category='" + Cat_Box.Text + "' ";
                cmd = new SqlCommand(check, conn);
                var reader = cmd.ExecuteReader();

            
                while (reader.Read())
                {
                    var Item = reader["Name"];
                    var Size = reader["Size"];
                    var company = reader["Company"];
                    var category = reader["category"];

                    if (Item != null && Size != null && company != null && category!=null)
                    {
                    DateTime dt = DateTime.Now;
                    dt.ToString();
                        conn.Close();
                        conn.Open();
                        string Quer = "Insert into TDC(Name,Size,Quantity,IC_No,Client,date,Company,category) values('" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox3.Text + "','1','1','"+dt+"','" + comboBox3.Text + "','"+Cat_Box.Text+"')";
                        cmd = new SqlCommand(Quer, conn);
                        cmd.ExecuteNonQuery();
                        textBox3.Text = null;
                        comboBox1.Text = null;
                        textBox3.Text = null;
                        comboBox2.Text = null;

                        conn.Close();
                        refresh();
                        return;


                    }
                }
            conn.Close();

                refresh();
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
             Name_text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
             Size_text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
             Company_text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
             Quantity_text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            Category_Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();




            if (e.ColumnIndex == 6)
            {
                panel3.Show();
                panel4.Show();
                comboBox4.Text = Name_text;
                comboBox5.Text = Size_text;
                comboBox6.Text = Company_text;
                textBox4.Text = Quantity_text;
                


            }
            if (e.ColumnIndex == 7)
            {
                if (MessageBox.Show("Are You Sure ? ",
                              "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    string Query = "Delete from TDC where Name='" + Name_text + "' and Size='" + Size_text + "' and Company='" + Company_text + "'";
                    cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    //do nothing
                }
                refresh();
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            M_Invoice form = new M_Invoice();
            form.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
      

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

            conn.Open();
            string Query = "Update TDC set Name='" + comboBox4.Text + "',Size='" + comboBox5.Text + "',Company='" + comboBox6.Text + "',Quantity='" + textBox4.Text + "' , category='" + ECat_Box.Text + "' where Name='" + Name_text + "' and Size='" + Size_text + "' and Company='" + Company_text + "' and Quantity='" + Quantity_text + "' and  category='" + Category_Text+ "' ";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            refresh();

        }
        private void Get_DC_No()
        {

            bool flag = false;
            for (int i=1000;i<=999999999;i++)
            {
                conn.Open();
                string Query = "Select DC_No from DC ";
                cmd = new SqlCommand(Query, conn);
                var reader=cmd.ExecuteReader();
                while(reader.Read())
                {
                    var DC_No = reader["DC_No"];
                    string x = i.ToString();
                    if (x ==DC_No.ToString())
                    {
                        flag = false;
                        break;
                    }
                    else
                    {
                        flag = true;
                    }

                }
                if(flag==true)
                {
                    textBox1.Text = i.ToString();
                    conn.Close();

                    return;

                }
                conn.Close();
              


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string style = "stylesheet";

            string filePath = @"C:\Files\DC.html";
            string html = @"<!DOCTYPE html> <html lang='en'> <head> <title>document</title> <meta charset='utf - 8'> <meta name='viewport' content='width = device - width, initial - scale = 1'> <link rel="+style+" href='https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css'> <script src='https://cdn.jsdelivr.net/npm/jquery@3.6.0/dist/jquery.slim.min.js'></script> <script src='https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js'></script> <script src='https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js'></script>";
            html = html + "<style> *{ margin: 0; padding: 0; } body{ background-color: #D6DBDF; } .container-fluid{ height: 10vh; width: 100%; }footer{ margin-top: 130px; height: 60vh; /* border: 2px solid red; */ } .fright{ display: flex; align-items: center; justify-content: center; width: 25%; /* border: 2px solid black; */ display: inline-block; /* padding-top: 50px; */ text-align: center; } .fright{ /* margin-top: 100px; */ padding-right: 80px; } .fright ul li{ list-style-type: none; } .fleft{ /* border: 2px solid black; */ display: inline-block; width: 70%; /* margin-top: 150px; */ } .fleft p{ text-align: justify; width:70% ; } .container-fluid .left{ display: flex; align-items: center; width: 15%; float: left; display: inline; } body { margin: 0; font-size: 1rem; font-weight: 400; line-height: 0.5; color: #212529; text-align: left; background-color: #fff; } .container-fluid .left h1{ color: black; font-size: 63px; font-weight: 100; margin-top:5px; } .container-fluid .right{ display: flex; align-items: center; width: 10%; float: right; display: inline; } .right h2{ margin-top: -50px; margin-left: 580px; color: Black; } .right p{ color: Black; margin-left: 500px; margin-top: 10px; } .right ul{ margin-top: 10px; margin-left:500px ; } .right ul li{ color: Black; display: inline; margin-right: 20px; } .main-left{ padding-top: 10px; width: 55%; display: inline; float: left; } .main-right{ padding-top: 10px; width: 20%; display: inline; float: right; text-align: center; } .invoice-to{ text-decoration: underline #D4AC0D; text-underline-offset: 5px; }";
            html=html+ "#grnd{ background-color: #D4AC0D; color: Black; font-weight: 600; border-radius: 7px; } </style> </head> <body> <div class='container - fluid bg - dark'> <div class='left'> <h1>Delivery Challan</h1> </div> <div class='right'> <h2>A & H TRADING</h2> <p>H#4 Block 14 B-1 College Road TownShip,Lahore,Pakistan</p> <ul> <li>Tel:+92 4235115171</li> <li>Cell:+92 3214023272</li> <li> +92 3069111888 </li> </ul> </div> </div> <div class='container'> <div class='main - left'>  <h5 class='Delivery Challan-to'>DC NO:</h5> <p>'"+textBox1.Text+"'</p> <h5 class='Delivery Challan-to'>DATE</h5> <p>'"+dateTimePicker1.Text+"'</p> </div> <div class='main - right'> <h5 class='Delivery Challan-to'>Delivery Challan to:'"+textBox2.Text+"'</h5>  </div> </div> <div class='container'> <table class='table table-striped '> <thead> <tr> <th>No</th> <th>Particulars</th> <th>Size</th> <th>Material</th> <th>Brand</th> <th>Quantity</th> </tr> </thead> <tbody> ";

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if(i==dataGridView1.RowCount-1)
                {
                    html = html + " </ul> </div> </body> </html>";
                    break;
                }
                string RNo = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string Rparticulars = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string Rsize = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string Rmaterial = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string Rbrand = dataGridView1.Rows[i].Cells[4].Value.ToString();
                string Rquantity = dataGridView1.Rows[i].Cells[5].Value.ToString();
                html = html + " <tr style='height:1px' > <td> " + RNo + "</td> <td>" + Rparticulars + "</td> <td>" + Rsize + "</td>  <td>" + Rmaterial + "</td> <td>" + Rbrand + "</td> <td>" + Rquantity + "</td> </tr>";
            }

            html = html + " </tbody> </table> </div> <br<br<br><br><br> <div class='container - fluid footer'> <div class='fleft'> <h3>NOTE:</h3> <p>'" + Description.Text + "'</p> </div> <div class='fright'> <ul>  <li>SIGNATURE</li> </ul> </div> </div>";


            TextWriter txt = new StreamWriter(filePath);
            txt.Write(html);
            txt.Close();


            if (MessageBox.Show("Delivery Challan saved Successfully\n Do you Wish to exit? ",
                                "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                conn.Open();
                string Query = "Truncate Table TDC";
                cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                this.Close();

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Description_TextChanged(object sender, EventArgs e)
        {

        }
        void getQ_No()
        {
            conn.Open();
            string Query = " truncate table Quote_No ;Insert into Quote_No select distinct Q_No from Quotations";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            string Query = " truncate table TDC;Insert into TDC(No,Name,Size,Company,Category,Quantity,Client,Q_No) select No,Name,Size,Company,Category,Quantity,Client,Q_No from Quotations where Q_No='"+ comboBox7.Text+"'";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            string Client = "Select Client from Quotations where Q_No='"+comboBox7.Text+"'";
            cmd=new SqlCommand(Client, conn);
            var reader = cmd.ExecuteReader();
            while(reader.Read())
                {
                var client = reader["Client"];
                textBox2.Text = client.ToString();
               
                }
            conn.Close();
            refresh();
        }
    }
}