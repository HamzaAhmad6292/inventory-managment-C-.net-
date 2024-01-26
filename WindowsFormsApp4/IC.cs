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
    public partial class IC : Form
    {
        public string item_name;
        public string size;
        public string company;
        public string quantity;
        public string category1;
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project;integrated Security=true;");

        SqlCommand cmd;
        public IC()
        {
            InitializeComponent();
            panel3.Hide();
            dataGridView1.RowTemplate.Height = 20;
            this.WindowState = FormWindowState.Maximized;
            Get_IC_No();
            refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            item_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            size = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            company = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            category1 = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            

            if(e.ColumnIndex==5)
            {
                conn.Open();
                string Query = "Delete  TIC where Name='" + item_name + "' and Size='" + size + "' and Company ='" + company + "' and category='"+category1+"'";
                cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                refresh();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
           string Query = "Truncate Table TIC";
            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the IC ",
                               "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {





                conn.Open();
                DateTime dt = dateTimePicker1.Value;
                int day = dateTimePicker1.Value.Day;
                int month = dateTimePicker1.Value.Month;
                int year = dateTimePicker1.Value.Year;
                string Query = "UPDATE  TIC set IC_No='" + textBox1.Text + "',Client='" + textBox2.Text + "', Date='" + dateTimePicker1.Text + "' where IC_no=1";
                cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                String Query1 = "Insert into IC(Name, Size,Company, Quantity, Client, Date, IC_No,category) select Name, Size,Company, Quantity, Client, Date, IC_No,category from TIC";
                cmd = new SqlCommand(Query1, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Input Challan\nSaved");
                conn.Close();



                conn.Open();
                string update = "UPDATE  inventory SET inventory.Quantity = inventory.Quantity + TIC.Quantity FROM inventory INNER JOIN TIC ON  inventory.Name = TIC.Name and inventory.Size = TIC.Size and inventory.Company=TIC.company and inventory.category=TIC.category";
                cmd = new SqlCommand(update, conn);
                cmd.ExecuteNonQuery();
                conn.Close();



                conn.Close();
            }
            else
            {
                // Do nothing
            }
        }
        public void refresh()
        {
            dataGridView1.Rows.Clear();
            conn.Open();

            string Query = "Select * from TIC  ";

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

        private void button5_Click(object sender, EventArgs e)
        {
            string style = "stylesheet";

            string filePath = @"C:\Files\IC.html";
            string html = @"<!DOCTYPE html> <html lang='en'> <head> <title>document</title> <meta charset='utf - 8'> <meta name='viewport' content='width = device - width, initial - scale = 1'> <link rel=" + style + " href='https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css'> <script src='https://cdn.jsdelivr.net/npm/jquery@3.6.0/dist/jquery.slim.min.js'></script> <script src='https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js'></script> <script src='https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js'></script>";
            html = html + "<style> *{ margin: 0; padding: 0; } body{ background-color: #D6DBDF; } .container-fluid{ height: 10vh; width: 100%; } .container-fluid .left{ display: flex; align-items: center; width: 15%; float: left; display: inline; } body { margin: 0; font-size: 1rem; font-weight: 400; line-height: 0.5; color: #212529; text-align: left; background-color: #fff; } .container-fluid .left h1{ color: black; font-size: 63px; font-weight: 100; margin-top:5px; } .container-fluid .right{ display: flex; align-items: center; width: 10%; float: right; display: inline; } .right h2{ margin-top: -50px; margin-left: 580px; color: Black; } .right p{ color: Black; margin-left: 500px; margin-top: 10px; } .right ul{ margin-top: 10px; margin-left:500px ; } .right ul li{ color: Black; display: inline; margin-right: 20px; } .main-left{ padding-top: 10px; width: 55%; display: inline; float: left; } .main-right{ padding-top: 10px; width: 20%; display: inline; float: right; text-align: center; } .invoice-to{ text-decoration: underline #D4AC0D; text-underline-offset: 5px; }";

            html = html + "#grnd{ background-color: #D4AC0D; color: Black; font-weight: 600; border-radius: 7px; } </style> </head> <body> <div class='container - fluid bg - dark'> <div class='left'> <h1>INPUT CHALLAN</h1> </div> <div class='right'> <h2>A & H TRADING</h2> <p>H#4 Block 14 B-1 College Road TownShip,Lahore,Pakistan</p> <ul> <li>Tel:+92 4235115171</li> <li>Cell:+92 3214023272</li> <li> +92 3069111888 </li> </ul> </div> </div> <div class='container'> <div class='main - left'> <h5 class='Delivery Challan-to'>DATE</h5> <p>" + dateTimePicker1.Text + "</p>  <h5 class='Delivery Challan-to'>IC NO:</h5> <p>" + textBox1.Text + "</p> </div> <div class='main - right'> <h5 class='Delivery Challan-to'>Delivery Challan to:" + textBox2.Text + "</h5>  </div> </div> <div class='container'> <table class='table table-striped '> <thead> <tr> <th>No</th> <th>Particulars</th> <th>Size</th> <th>Material</th> <th>Brand</th> <th>Quantity</th> </tr> </thead> <tbody> ";

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
                html = html + " <tr style='height:1px' > <td> " + RNo + "</td> <td>" + Rparticulars + "</td> <td>" + Rsize + "</td>  <td>" + Rmaterial + "</td> <td>" + Rbrand + "</td> <td>" + Rquantity + "</td> </tr>";
            }




            TextWriter txt = new StreamWriter(filePath);
            txt.Write(html);
            txt.Close();


            if (MessageBox.Show("Input Challan saved Successfully\n Do you Wish to exit? ",
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

        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
            panel3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            conn.Open();
            string check = "Select* from inventory where Name='" + comboBox3.Text + "' and Size= '" + comboBox1.Text + "'and Company='" + comboBox2.Text + "' and category='"+Cat_Box.Text+"'";
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
                    conn.Close();
                    conn.Open();
                    string Quer = "Insert into TIC(Name,Size,Quantity,IC_No,Client,date,Company,category) values('" + comboBox3.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','1','1','"+dt+"','" + comboBox2.Text + "','"+Cat_Box.Text+"')";
                    cmd = new SqlCommand(Quer, conn);
                    cmd.ExecuteNonQuery();
                    comboBox3.Text = null;
                    comboBox1.Text = null;
                    textBox3.Text = null;
                    comboBox2.Text = null;
                    Cat_Box.Text = null;

                    conn.Close();
                    refresh();
                    return;


                }
            }
            conn.Close();
            MessageBox.Show("Item donot Exit kindly Check ");
            return;








        }

        private void IC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ProjectDataSet27.categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.ProjectDataSet27.categories);
            // TODO: This line of code loads data into the 'ProjectDataSet26.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.ProjectDataSet26.Client);
            // TODO: This line of code loads data into the 'ProjectDataSet26.company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.ProjectDataSet26.company);
            // TODO: This line of code loads data into the 'ProjectDataSet26.categories' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'ProjectDataSet26.sizes' table. You can move, or remove it, as needed.
            this.sizesTableAdapter.Fill(this.ProjectDataSet26.sizes);
            // TODO: This line of code loads data into the 'ProjectDataSet26.sysdiagrams' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'ProjectDataSet26.Name' table. You can move, or remove it, as needed.
            this.nameTableAdapter.Fill(this.ProjectDataSet26.Name);
            // TODO: This line of code loads data into the 'ProjectDataSet25.company' table. You can move, or remove it, as needed.
          

        }
        private void Get_IC_No()
        {


            bool flag = false;
            for (int i = 1000; i <= 999999999; i++)
            {
                conn.Open();
                string Query = "Select IC_No from IC ";
                cmd = new SqlCommand(Query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var DC_No = reader["IC_No"];
                    string x = i.ToString();
                    if (x == DC_No.ToString())
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
