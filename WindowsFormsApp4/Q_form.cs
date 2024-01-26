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

    public partial class Q_form : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project;integrated Security=true;");

        SqlCommand cmd;
        string Item_Name1;
        string size1;
        string Company1;
        string category1;
        string Price1;


        public string Q_No;
        public string Invoice_No;
        public string Client;
        public string Total_Price;
        public string date_box;
        public Q_form()
        {

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            dataGridView1.RowTemplate.Height = 20;
            panel3.Hide();
            panel4.Hide();
            Get_DC_No();
            trunc();
            refresh();


        }

        private void Q_form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ProjectDataSet27.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.ProjectDataSet27.Client);
            // TODO: This line of code loads data into the 'ProjectDataSet27.company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.ProjectDataSet27.company);
            // TODO: This line of code loads data into the 'ProjectDataSet27.categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.ProjectDataSet27.categories);
            // TODO: This line of code loads data into the 'ProjectDataSet27.sizes' table. You can move, or remove it, as needed.
            this.sizesTableAdapter.Fill(this.ProjectDataSet27.sizes);
            // TODO: This line of code loads data into the 'ProjectDataSet27.Name' table. You can move, or remove it, as needed.
            this.nameTableAdapter.Fill(this.ProjectDataSet27.Name);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int inv_total=0;
            bool flag = false;
            int Q_Q = 0;
            int Q_total = 0;
            conn.Open();
            string Q_Check = "Select * from Quotations where Name='" + comboBox3.Text + "' and Size='" + comboBox1.Text + "' and Category='" + Cat_Box.Text + "' and Company='" + comboBox2.Text + "'";
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

                    flag= true;
                     Q_total = Convert.ToInt32(Quote_Quantity.ToString()) + Q_total;

                    form8.dataGridView1.Rows.Add(Quote_No,Quote_Client, Quote_Quantity, Quote_Date);
                   

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
                var S_reader=cmd.ExecuteReader();
                while(S_reader.Read())
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
            string check = "Select* from inventory where Name='" + comboBox3.Text + "' and Size= '" + comboBox1.Text + "'and Company='" + comboBox2.Text + "' and category='" + Cat_Box.Text + "'";
            cmd = new SqlCommand(check, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var Item = reader["Name"];
                var Size = reader["Size"];
                var company = reader["Company"];
                var category = reader["category"];
                if (Item != null && Size != null && company != null && category != null)
                {
                    DateTime dt = DateTime.Now;
                    conn.Close();
                    conn.Open();
                    string Quer = "Insert into T_Quote(Name,Size,Quantity,Q_No,Client,date,Company,category) values('" + comboBox3.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','1','1','" + dt + "','" + comboBox2.Text + "','" + Cat_Box.Text + "')";
                    cmd = new SqlCommand(Quer, conn);
                    cmd.ExecuteNonQuery();
                    comboBox3.Text = null;
                    comboBox1.Text = null;
                    textBox3.Text = null;
                    comboBox2.Text = null;
                    Cat_Box.Text = null;
                    

                    conn.Close();



                    conn.Open();
                    string Query = "UPDATE  T_Quote SET T_Quote.Price=inventory.Price FROM inventory INNER JOIN T_Quote ON  inventory.Name = T_Quote.Name and inventory.Size = T_Quote.Size and inventory.Company=T_Quote.company and inventory.category=T_Quote.category";
                    cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    refresh();
                    return;


                }
            }
            conn.Close();
            MessageBox.Show("Item donot Exit kindly Check ");
            return;
        }
        void refresh()
        {

            dataGridView1.Rows.Clear();
            conn.Open();
            string Query = "Select * from T_Quote ";
            cmd = new SqlCommand(Query, conn);
            var reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                x++;
                var Name1 = reader["Name"];
                var Size1 = reader["Size"];
                var Company = reader["Company"];
                var Quantity = reader["Quantity"];
                var discount = reader["Discount"];
                var Price = reader["Price"];
                var Client = reader["Client"].ToString();
                var Q_No = reader["Q_No"].ToString();
                var category = reader["category"];

             
                double total = Convert.ToInt64(Quantity.ToString()) * Convert.ToInt64(Price.ToString());
                dataGridView1.Rows.Add(x, Name1, Size1, category, Company, Quantity, discount, Price,total.ToString());


            }
            conn.Close();

            int sum = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {


                sum = sum + Convert.ToInt32(dataGridView1.Rows[i].Cells["Price"].Value);

            }
            textBox7.Text = sum.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string truncate = "truncate table T_Quote";
            cmd = new SqlCommand(truncate, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Item_Name1 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            size1 = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            category1 = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Company1 = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Price1 = dataGridView1.CurrentRow.Cells[8].Value.ToString();

            if (e.ColumnIndex == 9)
            {


                if (e.ColumnIndex == 9)
                {




                    Price_Change.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();



                    conn.Close();
                    panel4.Show();
                }
            }
            if(e.ColumnIndex == 10)
            {
                conn.Open();
                string Query1 = "Delete T_Quote where Name='" + Item_Name1 + "' and Size='" + size1 + "' and Category='" + category1 + "' and Company='" + Company1 + "'";
                cmd = new SqlCommand(Query1, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                refresh();
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            conn.Open();
            string Query = "Update T_Quote set Price='" + Price_Change.Text + "' where Name='" + Item_Name1 + "' and Size='" + size1 + "' and Company='" + Company1 + "' and category='" + category1 + "'";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox5.Text = null;
            conn.Open();
            string Query = "Update T_Invoice set Discount ='0'  where T_Invoice.Name='" + Item_Name1 + "' and T_Invoice.Size='" + size1 + "' and T_Invoice.Company='" + Company1 + "' and T_Invoice.category='" + category1 + "'";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            string Query1 = "Update T_Invoice  set T_Quote.Price=inventory.Price from T_Quote inner join inventory on T_Quote.Name=inventory.Name and T_Quote.Size=inventory.Size and T_Quote.Company=inventory.Company and T_Quote.category=inventory.category and T_Quote.Name='" + Item_Name1 + "' and T_Quote.Size='" + size1 + "' and T_Quote.Company='" + Company1 + "' and T_Quote.category='" + category1 + "' ";
            cmd = new SqlCommand(Query1, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Updated");
            refresh();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            conn.Open();
            string Query = "Update T_Quote Set Discount='" + textBox6.Text + "'";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            int x = 100;
            string discount = "Update T_Quote set Price=Price-((Discount/" + x + ")* Price)";
            cmd = new SqlCommand(discount, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            percent();
            refresh();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel4.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            conn.Open();
            string Query = "Update T_Quote set Discount='" + textBox5.Text + "' where Name='" + Item_Name1 + "' and Size='" + size1 + "' and Company='" + Company1 + "' and category='" + category1 + "'";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            percent();
            refresh();
        }

        void percent()
        {
            int x = 100;
            conn.Open();
            string Query = "Update T_Quote set Price=Price-((Discount/'" + x + "')*Price)  where T_Quote.Name='" + Item_Name1 + "' and T_Quote.Size='" + size1 + "' and T_Quote.Company='" + Company1 + "' and T_Quote.category='" + category1 + "' ";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        private void Get_DC_No()
        {

            bool flag = false;
            for (int i = 1000; i <= 999999999; i++)
            {
                conn.Open();
                string Query = "Select Q_No from Quotations ";
                cmd = new SqlCommand(Query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var Q_No = reader["Q_No"];
                   
                    string x = i.ToString();
                    if (x == Q_No.ToString())
                    {
                        flag = false;
                        break;
                    }
                    else
                    {
                        flag = true;
                    }

                }
                if (flag == true)
                {
                    textBox1.Text = i.ToString();
                    conn.Close();

                    return;

                }
                conn.Close();



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the Quotation ?",
                              "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {





                conn.Open();
                DateTime dt = dateTimePicker1.Value;
                int day = dateTimePicker1.Value.Day;
                int month = dateTimePicker1.Value.Month;
                int year = dateTimePicker1.Value.Year;
                string Query = "UPDATE  T_Quote set Q_No='" + textBox1.Text + "',Client='" + textBox2.Text + "', Date='" + dateTimePicker1.Value + "'";
                cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                string check = "Select Q_No from Quotations where Q_No='" + textBox1.Text + "' ";
                cmd = new SqlCommand(check, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var Q_No = reader["Q_No"].ToString();
                    if (Q_No != null)
                    {
                        conn.Close();
                        conn.Open();
                        int y = Int32.Parse(textBox1.Text);
                        int x = 100 + y;
                        string del = "Delete from Quotations where Q_No='" + textBox1.Text + "'";
                        cmd = new SqlCommand(del, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        conn.Open();
                        String Query1 = "Insert into Quotations(Name, Size,Company, Quantity, Client, Date, Q_No,category,Price,Discount) select Name, Size,Company, Quantity, Client, Date, Q_No,category,Price,Discount from T_Quote";
                        cmd = new SqlCommand(Query1, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Quotation\nUpdated");

                        return;

                    }

                }
                conn.Close();
                conn.Open();
                string Query2 = "Insert into Quotations(Name, Size,Company, Quantity, Client, Date, Q_No,category,Price,Discount) select Name, Size,Company, Quantity, Client, Date, Q_No,category,Price,Discount from T_Quote";
                cmd = new SqlCommand(Query2, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Quotation\nSaved");







            }
            else
            {
                // Do nothing
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            conn.Open();
            string Query = "Insert into T_Quote(Name,Size,Category,Company,Quantity,Price,Discount,Q_No,Client,Date)  select Name,Size,Category,Company,Quantity,Price,Discount,Q_No,Client,Date from Quotations  where Q_No='"+comboBox4.Text+"'" ;
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();


            conn.Open();
            string Load = "Select * from T_Quote";
            cmd = new SqlCommand(Load, conn);
            var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                var Q_No = reader["Q_No"].ToString();
                textBox1.Text = Q_No;
                var Client = reader["Client"].ToString();
                textBox2.Text=Client;
            }
            conn.Close();
        
            percent();
            refresh();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            conn.Open();
            string Query = "Delete Quotations where Q_No='" + textBox1.Text + "' and Client='" + textBox2.Text + "'";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();


            conn.Open();
            string truncate = "truncate table T_Quote";
            cmd = new SqlCommand(truncate, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            refresh();
            MessageBox.Show("Quotations deleted");
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string style = "stylesheet";

            string filePath = @"C:\Files\Quotation.html";
            string html = @"<!DOCTYPE html> <html lang='en'> <head> <title>document</title> <meta charset='utf - 8'> <meta name='viewport' content='width = device - width, initial - scale = 1'> <link rel=" + style + " href='https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css'> <script src='https://cdn.jsdelivr.net/npm/jquery@3.6.0/dist/jquery.slim.min.js'></script> <script src='https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js'></script> <script src='https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js'></script>";
            html = html + "<style> *{ margin: 0; padding: 0; } body{ background-color: #D6DBDF; } .container-fluid{ height: 10vh; width: 100%; } .container-fluid .left{ display: flex; align-items: center; width: 15%; float: left; display: inline; }  body { margin: 0; font-size: 1rem; font-weight: 400; line-height: 0.5; color: #212529; text-align: left; background-color: #fff; }  table td { padding: -1.25rem; vertical-align: top; border-top: 1px solid #dee2e6; } .container-fluid .left h1{ color: black; font-size: 63px; font-weight: 100; margin-top:5px; } .container-fluid .right{ display: flex; align-items: center; width: 10%; float: right; display: inline; } .right h2{ margin-top: -50px; margin-left: 580px; color: Black; } .right p{ color: Black; margin-left: 500px; margin-top: 10px; } .right ul{ margin-top: 10px; margin-left:500px ; } .right ul li{ color: Black; display: inline; margin-right: 20px; } .main-left{ padding-top: 10px; width: 55%; display: inline; float: left; } .main-right{ padding-top: 10px; width: 20%; display: inline; float: right; text-align: center; } .invoice-to{ text-decoration: underline #D4AC0D; text-underline-offset: 5px; }";
            html = html + "#grnd{ background-color: #D4AC0D; color: Black; font-weight: 600; border-radius: 7px; } </style> </head> <body> <div class='container - fluid bg - dark'> <div class='left'> <h1>QUOTATION</h1> </div> <div class='right'> <h2>A & H TRADING</h2> <p>H#4 Block 14 B-1 College Road TownShip,Lahore,Pakistan</p> <ul> <li>Tel:+92 4235115171</li> <li>Cell:+92 3214023272</li> <li> +92 3069111888 </li> </ul> </div> </div> <div class='container'> <div class='main - left'> <h5 class='Delivery Challan-to'>DATE</h5> <p>'" + dateTimePicker1.Text + "'</p> <h5 class='Delivery Challan-to'>Quotation NO:</h5> <p>" + textBox1.Text + "</p>  </div> <div class='main - right'> <h5 class='Delivery Challan-to'>Quotation To:" + textBox2.Text + "</h5>   </div> <div class='container'> <table class='table table-striped '> <thead> <tr> <th>No</th> <th>Particulars</th> <th>Size</th> <th>Material</th> <th>Brand</th> <th>Dscount</th> <th>Rate</th> <th>Quantity</th> <th>Total</th> </tr> </thead> <tbody> ";

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (i == dataGridView1.RowCount - 1)
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
                string RTotal = dataGridView1.Rows[i].Cells[8].Value.ToString();
                string RDiscount = dataGridView1.Rows[i].Cells[6].Value.ToString();
                string RPrice = dataGridView1.Rows[i].Cells[7].Value.ToString();



                html = html + " <tr style='line_height:0.5' > <td> " + RNo + "</td> <td>" + Rparticulars + "</td> <td>" + Rsize + "</td>  <td>" + Rmaterial + "</td> <td>" + Rbrand + "</td> <td>" + RDiscount + "</td><td>" + RPrice + "</td> <td>" + Rquantity + "</td> <td>" + RTotal + "</td> </tr>";
            }
            html = html + "<tr style='Background-color:gray='> <td></td> <td></td> <td></td> <td></td><td></td><td></td> <td></td> <td id='grnd' ;>GRAND TOTAL:</td> <td id='grnd'>" + textBox7.Text + "</td> </tr> ";
            //html = html + " </tbody> </table> </div> <br<br<br><br><br> <div class='container - fluid footer'> <div class='fleft'> <h3>NOTE:</h3> <p>'" + Description.Text + "'</p> </div> <div class='fright'> <ul>  <li>SIGNATURE</li> </ul> </div> </div>";





            TextWriter txt = new StreamWriter(filePath);
            txt.Write(html);
            txt.Close();


            if (MessageBox.Show("Quotation saved Successfully\n Do you Wish to exit? ",
                                "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                conn.Open();
                string Query = "Truncate Table T_Quote";
                cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                this.Close();

            }
        }
        void trunc()
        {
            conn.Open();
            string Query = "Truncate table T_Quote";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox6.Text = "0";
            conn.Open();
            string Query = "Update T_Quote set Discount ='0'";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            string Query1 = "Update T_Quote  set T_Quote.Price=inventory.Price from T_Quote inner join inventory on T_Quote.Name=inventory.Name and T_Quote.Size=inventory.Size and T_Quote.Company=inventory.Company and T_Quote.category=inventory.category ";
            cmd = new SqlCommand(Query1, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Updated");
            refresh();
        }
    }
}
