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
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;




namespace WindowsFormsApp4
{
    

    public partial class invoice_form : Form
    {





        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project;integrated Security=true;");
        SqlCommand cmd;

        string streamType;

        private System.IO.Stream streamToPrint;


        string Item_Name1;
         string size1;
         string Company1;
        string category1;
        string Price1;
        

        public string DC_No;
        public string Invoice_No;
        public string Client;
        public string Total_Price;
        public string date_box;
        


        public invoice_form()
        {
            InitializeComponent();
            DCs();
            panel2.Hide();
            dataGridView1.RowTemplate.Height = 20;
            this.WindowState = FormWindowState.Maximized;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            refresh();

        }
        void refresh()
        {
            
            dataGridView1.Rows.Clear();
            conn.Open();
            string Query = "Select * from T_Invoice ";
            cmd = new SqlCommand(Query, conn);
            var reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                x++;
                var Name = reader["Name"];
                var Size = reader["Size"];
                var Company = reader["Company"];
                var Quantity = reader["Quantity"];
                var discount = reader["Discount"];
                var Price = reader["Price"];
                var Client = reader["Client"].ToString();
                var Invoice_No = reader["Invoice_No"].ToString();
                var category = reader["category"];

                textBox1.Text = Invoice_No;
                textBox2.Text = Client;
                double total= Convert.ToInt64(Quantity.ToString()) * Convert.ToInt64(Price.ToString()); 
                dataGridView1.Rows.Add(x, Name, Size,category, Company, Quantity, discount, Price,total.ToString());


            }
            conn.Close();

            int sum = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
               
                    sum = sum + Convert.ToInt32(dataGridView1.Rows[i].Cells["Price"].Value);
               
              

            }
            textBox3.Text = sum.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string Query = "Truncate Table T_Invoice";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            trunc();
            load();
            zero();
            Quotation();
            refresh();

           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Invoices_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ProjectDataSet27.ID' table. You can move, or remove it, as needed.
            this.iDTableAdapter.Fill(this.ProjectDataSet27.ID);
            // TODO: This line of code loads data into the 'ProjectDataSet26.categories' table. You can move, or remove it, as needed.
          
            

        }
        void DCs()
        {

            conn.Open();
            string Query1 = "Truncate table ID";
            cmd = new SqlCommand(Query1, conn);
            cmd.ExecuteNonQuery();
            conn.Close();


            conn.Open();
            string Query = "Insert into ID(ID) Select  distinct DC_No From DC ";
            cmd = new SqlCommand(Query, conn);

            cmd.ExecuteNonQuery();
            conn.Close();


            conn.Open();
            string Query2 = "Update ID set ID.Date=DC.Date from ID Inner Join  DC on ID.ID = DC.DC_No ";
            cmd = new SqlCommand(Query2, conn);

            cmd.ExecuteNonQuery();
            conn.Close();

        }
        void load()
        {
            conn.Open();
            string Query1 = "Insert into T_Invoice(Invoice_No,Name,Size,Company,Quantity,Date,Client,category,Q_No) select DC_No,Name,Size,Company,Quantity,Date,Client,category,Q_No from DC where DC_No = '" + comboBox1.Text + "'";
            cmd = new SqlCommand(Query1, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void button8_Click(object sender, EventArgs e)
        {

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
             

           
               
                    Price_Change.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                


                conn.Close();
                panel2.Show();
            }
            if(e.ColumnIndex==10)
            {
                conn.Open();
                string Query = "delete T_Invoice where Name='" + Item_Name1 + "' and Size= '" + size1 + "' and Company ='" + Company1 + "' and Category='" + category1 + "'";
                cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                refresh();

            }

        }




        private void button1_Click(object sender, EventArgs e)
        {

            conn.Open();
            int check= Convert.ToInt32(textBox1.Text);
            string Query_check="Select*from Invoice where Invoice_No="+check+"";
            cmd = new SqlCommand(Query_check, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               
              

                    MessageBox.Show("Invoice Already Exist if you Wish to Edit it Modify the Delivery Challan with its Dc_No ");
                conn.Close();
                    return;
                
            }
            conn.Close();

            if (MessageBox.Show("Do you want to save the Invoices ",
                               "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {





                conn.Open();
                DateTime dt = dateTimePicker1.Value;
                dt.ToString();
                string Query = "UPDATE  T_Invoice set Invoice_No='"+textBox1.Text+"',DC_No='" + comboBox1.Text + "',Client='" + textBox2.Text + "', Date='"+dateTimePicker1.Value+"' where Invoice_No=1";
                cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                String Query1 = "Insert into Invoice(Name, Size,Company, Quantity, Client, Date, Invoice_No,Discount,Price,category) select Name, Size,Company, Quantity, Client, Date, Invoice_No,Discount,Price,category from T_Invoice";
                cmd = new SqlCommand(Query1, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Invoice Saved");
                conn.Close();



                conn.Open();
                string update = "UPDATE  inventory SET inventory.Quantity = inventory.Quantity - T_Invoice.Quantity FROM inventory INNER JOIN T_Invoice ON  inventory.Name = T_Invoice.Name and inventory.Size = T_Invoice.Size and inventory.Company=T_Invoice.company and inventory.category=T_Invoice.category";
                cmd = new SqlCommand(update, conn);
                cmd.ExecuteNonQuery();
                conn.Close();



                conn.Close();



                conn.Open();
                int x = 0;
                string Query4 = "Insert into ledgers_1(DC_No,Invoice_No,Client,Price,Date,Debit) values('" + comboBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value + "','" + x + "')";
                cmd = new SqlCommand(Query4, conn);
                cmd.ExecuteNonQuery();
                conn.Close();


            }
            else
            {
                // Do nothing
            }




        }
       
        

      public void trunc()
      {
            conn.Open();
            string Query = "Truncate table T_Invoice";          // delete the table T_invioce
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

      }
        public  void zero()
        {
            conn.Open();
            string Query2 = "Update T_Invoice set T_Invoice.Discount='0',T_Invoice.Price=inventory.Price from T_Invoice inner join inventory on T_Invoice.Name=inventory.Name and T_Invoice.Size=inventory.Size and T_Invoice.Company=inventory.Company and T_invoice.category=inventory.category";
            cmd = new SqlCommand(Query2, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            int x = 100;
            string Query3="Update T_Invoice set Invoice_No=Invoice_No" +
                "+'"+x+"'";
            cmd = new SqlCommand(Query3, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for(int i=0;i<dataGridView1.RowCount;i++)
            {
                sum = sum + Convert.ToInt32(dataGridView1.Rows[i].Cells["Price"].Value);
            }
            textBox3.Text = sum.ToString();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            conn.Open();
            string Query = "Update T_Invoice set Discount='" + textBox4.Text + "' where Name='" + Item_Name1 + "' and Size='" + size1 + "' and Company='" + Company1 + "' and category='"+category1+"'";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            percent();
            refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox4.Text = null;
            conn.Open();
            string Query = "Update T_Invoice set Discount ='0'  where T_Invoice.Name='" + Item_Name1 + "' and T_Invoice.Size='" + size1 + "' and T_Invoice.Company='" + Company1 + "' and T_Invoice.category='" + category1 + "'";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            string Query1 = "Update T_Invoice  set T_Invoice.Price=inventory.Price from T_Invoice inner join inventory on T_Invoice.Name=inventory.Name and T_Invoice.Size=inventory.Size and T_Invoice.Company=inventory.Company and T_Invoice.category=inventory.category and T_Invoice.Name='" + Item_Name1 + "' and T_Invoice.Size='" + size1 + "' and T_Invoice.Company='" + Company1 + "' and T_Invoice.category='" + category1 + "' ";
            cmd = new SqlCommand(Query1, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Updated");
            refresh();
        
        }
        public void percent()
        {

            int x = 100;
            conn.Open();

            string Query = "Update T_Invoice set T_Invoice.Price=T_Invoice.Price-((T_Invoice.Discount/" + x+ ")*T_Invoice.Price) where  T_Invoice.Name='" + Item_Name1 + "' and T_Invoice.Size='" + size1 + "' and T_Invoice.Company='" + Company1 + "' and T_Invoice.category='"+category1+"' " ;
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();


        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string style = "stylesheet";

            string filePath = @"C:\Files\Invoice.html";
            string html = @"<!DOCTYPE html> <html lang='en'> <head> <title>document</title> <meta charset='utf - 8'> <meta name='viewport' content='width = device - width, initial - scale = 1'> <link rel=" + style + " href='https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css'> <script src='https://cdn.jsdelivr.net/npm/jquery@3.6.0/dist/jquery.slim.min.js'></script> <script src='https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js'></script> <script src='https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js'></script>";
            html = html + "<style> *{ margin: 0; padding: 0; } body{ background-color: #D6DBDF; } .container-fluid{ height: 10vh; width: 100%; } footer{ margin-top: 130px; height: 60vh; /* border: 2px solid red; */ } .fright{ display: flex; align-items: center; justify-content: center; width: 25%; /* border: 2px solid black; */ display: inline-block; /* padding-top: 50px; */ text-align: center; } .fright{ /* margin-top: 100px; */ padding-right: 80px; } .fright ul li{ list-style-type: none; } .fleft{ /* border: 2px solid black; */ display: inline-block; width: 70%; /* margin-top: 150px; */ } .fleft p{ text-align: justify; width:70% ; } .container-fluid  .left{ display: flex; align-items: center; width: 15%; float: left; display: inline; } body { margin: 0; font-size: 1rem; font-weight: 400; line-height: 0.5; color: #212529; text-align: left; background-color: #fff; } table td { padding: -1.25rem; vertical-align: top; border-top: 1px solid #dee2e6; } .container-fluid .left h1{ color: black; font-size: 63px; font-weight: 100; margin-top:5px; } .container-fluid .right{ display: flex; align-items: center; width: 10%; float: right; display: inline; } .right h2{ margin-top: -50px; margin-left: 580px; color: Black; } .right p{ color: Black; margin-left: 500px; margin-top: 10px; } .right ul{ margin-top: 10px; margin-left:500px ; } .right ul li{ color: Black; display: inline; margin-right: 20px; } .main-left{ padding-top: 10px; width: 55%; display: inline; float: left; } .main-right{ padding-top: 10px; width: 20%; display: inline; float: right; text-align: center; } .invoice-to{ text-decoration: underline #D4AC0D; text-underline-offset: 5px; }";
            html = html + "#grnd{ background-color: #D4AC0D; color: Black; font-weight: 600; border-radius: 7px; } </style> </head> <body> <div class='container - fluid bg - dark'> <div class='left'> <h1>INVOICE</h1> </div> <div class='right'> <h2>A & H TRADING</h2> <p>H#4 Block 14 B-1 College Road TownShip,Lahore,Pakistan</p> <ul> <li>Tel:+92 4235115171</li> <li>Cell:+92 3214023272</li> <li> +92 3069111888 </li> </ul> </div> </div> <div class='container'> <div class='main - left'> <h5 class='Delivery Challan-to'>DATE</h5> <p>'" + dateTimePicker1.Text + "'</p> <h5 class='Delivery Challan-to'>DC NO:</h5> <p>" + comboBox1.Text + "</p> <h5 class='Delivery Challan-to'>Invoice_No:</h5> <p>" + textBox1.Text + "</p> </div> <div class='main - right'> <h5 class='Delivery Challan-to'>Invoice To:" + textBox2.Text + "</h5>   </div> <div class='container'> <table class='table table-striped '> <thead> <tr> <th>No</th> <th>Particulars</th> <th>Size</th> <th>Material</th> <th>Brand</th> <th>Discount</th> <th>Rate</th> <th>Quantity</th>  <th>Total</th> </tr>   </div>   </thead> <tbody> ";

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
                string RPrice = dataGridView1.Rows[i].Cells[7].Value.ToString();
                string RDiscount = dataGridView1.Rows[i].Cells[6].Value.ToString();
                string RTotal = dataGridView1.Rows[i].Cells[8].Value.ToString();

                html = html + " <tr style='line_height:0.5' > <td> " + RNo + "</td> <td>" + Rparticulars + "</td> <td>" + Rsize + "</td>  <td>" + Rmaterial + "</td> <td>" + Rbrand + "</td>   <td>" + RDiscount + "</td> <td>" + RPrice + "</td> <td>" + Rquantity + "</td>  <td>" + RTotal + "</td> </tr>";
            }
            html = html + "<tr style='Background-color:gray='> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td> <td></td>  <td id='grnd' ;>GRAND TOTAL:</td> <td id='grnd'>" + textBox3.Text + "</td> </tr> </tbody> </table> </div> </ul> </div>  <br<br<br><br><br> <div class='container - fluid footer'> <div class='fleft'> <h3>NOTE:</h3> <p>'" + Description.Text+"'</p> </div> <div class='fright'> <ul>  <li>SIGNATURE</li> </ul> </div> </div>";




            TextWriter txt = new StreamWriter(filePath);
            txt.Write(html);
            txt.Close();


            if (MessageBox.Show("Delivery Challan saved Successfully\n Do you Wish to exit? ",
                                "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                conn.Open();
                string Query = "Truncate Table T_Invoice";
                cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                this.Close();

            }

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            conn.Open();
            string Query = "Update T_Invoice set Price='" + Price_Change.Text + "' where Name='" + Item_Name1 + "' and Size='" + size1 + "' and Company='" + Company1 + "' and category='" + category1 + "'";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            refresh();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }







        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt
    (
        IntPtr hdcDest, // handle to destination DC
        int nXDest, // x-coord of destination upper-left corner
        int nYDest, // y-coord of destination upper-left corner
        int nWidth, // width of destination rectangle
        int nHeight, // height of destination rectangle
        IntPtr hdcSrc, // handle to source DC
        int nXSrc, // x-coordinate of source upper-left corner
        int nYSrc, // y-coordinate of source upper-left corner
        System.Int32 dwRop // raster operation code
    );
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Image image = System.Drawing.Image.FromStream(this.streamToPrint);

            int x = e.MarginBounds.X;
            int y = e.MarginBounds.Y;

            int width = image.Width;
            int height = image.Height;
            if ((width / e.MarginBounds.Width) > (height / e.MarginBounds.Height))
            {
                width = e.MarginBounds.Width;
                height = image.Height * e.MarginBounds.Width / image.Width;
            }
            else
            {
                height = e.MarginBounds.Height;
                width = image.Width * e.MarginBounds.Height / image.Height;
            }
            System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(x, y, width, height);
            e.Graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel);
        }
        public void StartPrint(Stream streamToPrint, string streamType)
        {

          
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void Description_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
                conn.Open();
                string Query = "Update T_Invoice Set Discount='" + textBox5.Text + "'";
                cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            conn.Open();
            int x = 100;
            string discount = "Update T_Invoice set T_Invoice.Price=T_Invoice.Price-((T_Invoice.Discount/" + x + ")*T_Invoice.Price)";
            cmd = new SqlCommand(discount, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            percent();
            refresh();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        void Quotation()
        {
            refresh();
            conn.Open();
            string Query = "Update T_Invoice  set  T_Invoice.Price=Quotations.Price ,T_Invoice.Discount=Quotations.Discount from T_Invoice inner join Quotations on T_Invoice.Name=Quotations.Name and T_Invoice.Size=Quotations.Size and T_Invoice.Company=Quotations.Company and T_Invoice.category=Quotations.category and T_Invoice.Q_No=Quotations.Q_No";
            cmd = new SqlCommand(Query,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            refresh();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            textBox5.Text = "0";
            conn.Open();
            string Query = "Update T_Invoice set Discount ='0'";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            string Query1 = "Update T_Invoice  set T_Invoice.Price=inventory.Price from T_Invoice inner join inventory on T_Invoice.Name=inventory.Name and T_Invoice.Size=inventory.Size and T_Invoice.Company=inventory.Company and T_Invoice.category=inventory.category ";
            cmd = new SqlCommand(Query1, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Updated");
            refresh();
        }
    }

    
}
