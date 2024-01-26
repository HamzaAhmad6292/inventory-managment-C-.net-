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
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace WindowsFormsApp4
{

    public partial class Form1 : Form
    {
        public string text;
        public string size;
        public string Company;
        public string category1;

        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Project;integrated Security=true;");
        SqlCommand cmd;
      
        public Form1()
        {

            
            InitializeComponent();





            Grids();
            inventory.Show();

          inventory.RowTemplate.Height = 20;

            IC.RowTemplate.Height = 20;
            dataGridView1.RowTemplate.Height = 20;
            Invoice.RowTemplate.Height = 20;
            dataGridView2.RowTemplate.Height = 20;
            companies.RowTemplate.Height = 20;
            Size1.RowTemplate.Height = 20;
            IC.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
Invoice.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
           companies.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
           Size1.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;







            refresh();
            this.WindowState = FormWindowState.Maximized;
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();

            comboBox8.Text = "All";



        

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Dream FoodsDataSet27.categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.ProjectDataSet27.categories);
            // TODO: This line of code loads data into the 'Dream FoodsDataSet26.company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.ProjectDataSet26.company);
            // TODO: This line of code loads data into the 'Dream FoodsDataSet26.sizes' table. You can move, or remove it, as needed.
            this.sizesTableAdapter.Fill(this.ProjectDataSet26.sizes);
           


            IC.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
            Invoice.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
            companies.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
            Size1.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh();
        }
        public void refresh()
        {
            refresh_Quote();
            
            inventory.Rows.Clear();
            string Query;
            if (comboBox9.Text == "All" )
            {
                Query = "Select * from inventory where Category like '"+comboBox8.Text+"%' and Name like '"+textBox1.Text+"%' ";
            }
            else 
            {
                Query = "Select * from inventory where Name like '"+textBox1.Text+"%' and  Category like '" + comboBox8.Text + "%' and Size like '"+comboBox9.Text+"%'";

            }
            conn.Open();

            cmd = new SqlCommand(Query, conn);
            var reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                x++;
   
                var name1 = reader["Name"];
                var name2 = reader["Name"];


                var Size1 = reader["Size"];
         


                var Quantity1 = reader["Quantity"];
                var Price1 = reader["Price"];

                var company1 = reader["Company"];
           

                var category = reader["Category"];




                inventory.Rows.Add(x, name1, Size1, company1, Price1, Quantity1,category);



              
            }
            conn.Close();

 


            conn.Open();
            string truc = "Truncate Table CLient ;Truncate table Name";
            cmd = new SqlCommand(truc, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            string Query1 = "Insert into Name(Name) select distinct Name from inventory";
            cmd = new SqlCommand(Query1, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            string Query3 = "Insert into CLient(Client) select distinct Client from IC";
            cmd = new SqlCommand(Query3, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            string Query4 = "Insert into CLient(Client) select distinct Client from DC";
            cmd = new SqlCommand(Query4, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }



         
        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Show();
            panel4.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        private void button3_Click(object sender, EventArgs e)
        {
            DC_form form = new DC_form();
            form.Show();
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Company form = new Company();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            refresh();
            refresh_company();
            refresh_DC();
            refresh_IC();
            refresh_invoice();
            refresh_size();
            refresh_Quote();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Size form = new Size();
            form.Show();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            IC form = new IC();
            form.Show();
        }


    
        public void Grids()
        {


            inventory.Hide();
            Invoice.Hide();
            dataGridView1.Hide();
            IC.Hide();
            Size1.Hide();
            companies.Hide();
            dataGridView2.Hide();



        }




       

        public void refresh_IC()
        {
            IC.Rows.Clear ();
            string Query = "Select * From IC where IC_No like '" + textBox1.Text + "%' order by Date desc" ;
            cmd = new SqlCommand(Query, conn);
            conn.Open();
            var reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())

            {
                x++;
                var ID = reader["IC_No"];
                var Name = reader["Name"];
                var Size = reader["Size"];
                var Company = reader["Company"];
                var Quantity = reader["Quantity"];
                var Client = reader["Client"];
                var Date = reader["Date"];





                IC.Rows.Add(x, ID, Name, Size, Company,Quantity,Client,Date);


            }
            conn.Close();
        }

        public void refresh_DC()
        {
            dataGridView1.Rows.Clear();

            string Query = "Select * from DC where DC_No like'" + textBox1.Text + "%' order by Date desc" ;
            cmd = new SqlCommand(Query, conn);
            conn.Open();
            var reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                x++;
                var ID = reader["DC_No"];
                var Name = reader["Name"];
                var Size = reader["Size"];
                var Company = reader["Company"];
                var Quantity = reader["Quantity"];
                var Client = reader["Client"];
                var Date = reader["Date"];





                dataGridView1.Rows.Add(x, ID, Name, Size, Company, Quantity, Client, Date);


            }
            conn.Close();
        }

        public void refresh_invoice()
        {
            Invoice.Rows.Clear();

            string Query = "Select * From invoice where Invoice_No like '" + textBox1.Text + "%' order by Date desc" ;
            cmd = new SqlCommand(Query, conn);
            conn.Open();
            var reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                x++;
               
                var ID = reader["invoice_No"];
                var Name = reader["Name"];
                var Size = reader["Size"];
                var Company = reader["Company"];
                var Price  = reader["Price"];
                var Quantity = reader["Quantity"];
                var Client = reader["Client"];
                var Date = reader["Date"];



               

                Invoice.Rows.Add(x, ID, Name, Size, Company,Price,Quantity, Client, Date);


            }
            conn.Close();
        }
        public void refresh_size()
        {
            Size1.Rows.Clear();

            string Query = "Select * from sizes";
            cmd = new SqlCommand(Query, conn);
            conn.Open();
            var reader = cmd.ExecuteReader();
            int x = 1;
            while (reader.Read())
            {
               
                var Size = reader["Size"];
                

                Size1.Rows.Add(x,Size);
                x++;

            }
            conn.Close();
        }
        public void refresh_company()
        {
            companies.Rows.Clear();

            string Query = "Select * From company ";
            cmd = new SqlCommand(Query, conn);
            conn.Open();
            var reader = cmd.ExecuteReader();
            int x = 1;
            while (reader.Read())
            {

                var Company = reader["Company"];


                companies.Rows.Add(x, Company);
                x++;


            }
            conn.Close();
        }
        public void refresh_Quote()
        {
            dataGridView2.Rows.Clear();


            conn.Open();
            string Query;
            if (comboBox9.Text == "All" )
            {
                Query = "Select *from Quotations where  Name like '" + textBox1.Text + "%' ";
            }
            
            else
            {
                Query = "Select * From Quotations where Name like '" + textBox1.Text + "%'  and  Size  like '" + comboBox9.Text + "%' ";
            }

            cmd = new SqlCommand(Query, conn);
            var reader=cmd.ExecuteReader();
            int x = 1;
            while(reader.Read())
            {
                var item_Name = reader["Name"];
                var Size = reader["Size"];
                var Q_No = reader["Q_No"];
                var company1 = reader["Company"];
                var Quantity = reader["Quantity"];
                var Client = reader["Client"];
                var Date = reader["Date"];


                dataGridView2.Rows.Add(x,Q_No,item_Name,Size,company1,Quantity,Client,Date);
                x++;
            }
            conn.Close();
        }

        private void companies_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                conn.Open();
                string Query = "Delete  company where Company='" + companies.CurrentRow.Cells[1].Value.ToString() + "'";
                cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                refresh_size();
            }


        }

        private void button11_Click(object sender, EventArgs e)
        {
            invoice_form form = new invoice_form();
            form.Show();
        }
      

            private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
            {

            }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==7)
            {
                if (MessageBox.Show("Are You Sure ?",
                              "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    conn.Open();
                    string Query = "Delete Quotations where Name='" + dataGridView2.CurrentRow.Cells[1].Value.ToString() + "' and Size='" + dataGridView2.CurrentRow.Cells[2].Value.ToString() + "' and Company ='" + dataGridView2.CurrentRow.Cells[3].Value.ToString() + "'";
                    cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    // do nothing
                }
                refresh_Quote();
            }
        }

        private void ledgers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            ledgers_form form = new ledgers_form();
            form.Show();
            form.WindowState = FormWindowState.Maximized;
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void inventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form4 form = new Form4();
            Form5 form5 = new Form5();
            Form9  form9=new Form9();
            Quotation Quote = new Quotation();



            if (e.ColumnIndex == 7)
            {
                panel3.Show();
                panel4.Show();
                
               text = inventory.CurrentRow.Cells[1].Value.ToString();
               size = inventory.CurrentRow.Cells[2].Value.ToString();
               Company = inventory.CurrentRow.Cells[3].Value.ToString();
                category1= inventory.CurrentRow.Cells[6].Value.ToString();
                textBox7.Text = inventory.CurrentRow.Cells[1].Value.ToString();
                textBox6.Text = inventory.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = inventory.CurrentRow.Cells[5].Value.ToString();
                comboBox5.Text = inventory.CurrentRow.Cells[2].Value.ToString();
                comboBox4.Text = inventory.CurrentRow.Cells[3].Value.ToString();
                comboBox6.Text= inventory.CurrentRow.Cells[6].Value.ToString();
            }


            if (e.ColumnIndex == 8)
            {
                try
                {
                    Quote.Show();
                    Quote.Quote_Name = inventory.CurrentRow.Cells[1].Value.ToString();
                    Quote.Quote_Size = inventory.CurrentRow.Cells[2].Value.ToString();
                    Quote.Quote_Company = inventory.CurrentRow.Cells[3].Value.ToString();
                    Quote.Quote_Category = inventory.CurrentRow.Cells[6].Value.ToString();


                }
                catch (Exception) 
                {
                    MessageBox.Show("No Index");
                }
                

            }
            if (e.ColumnIndex == 9)
            {
                if (MessageBox.Show("Are you Sure", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    string Query = "Delete from Quotations where Name='" + Quote.Quote_Name + "' and Company='" + Quote.Quote_Company + "' and Size = '" + Quote.Quote_Size + "'";
                    cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Task Completed");
                    conn.Close();
                    inventory.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    //Chill bro just do nothing 
                }
                
            }
            if(e.ColumnIndex==10)
            {
                if (MessageBox.Show("Are You Sure ?",
                           "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                   
                    text = inventory.CurrentRow.Cells[1].Value.ToString();
                    size = inventory.CurrentRow.Cells[2].Value.ToString();
                    Company = inventory.CurrentRow.Cells[3].Value.ToString();
                    category1 = inventory.CurrentRow.Cells[6].Value.ToString();
                    conn.Open();
                    string Query = "Delete inventory where Name='" + text + "' and size='" + size + "' and Company='" + Company + "' and Category='" + category1 + "'";
                    cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    refresh();
                }
                else
                {
                    // do nothing
                }
                
            }
            if(e.ColumnIndex==11)
            {
                form9.Show();
                conn.Open();
                string Name1=inventory.CurrentRow.Cells[1].Value.ToString();
                string size1 = inventory.CurrentRow.Cells[2].Value.ToString();
                string company1= inventory.CurrentRow.Cells[3].Value.ToString();
                string category1=inventory.CurrentRow.Cells[6].Value.ToString();
                string Query="Select * from invoice where Name='"+Name1+"' and Size='"+size1+"' and Company='"+company1+"' and category='"+category1+"'  ";
                cmd = new SqlCommand(Query, conn);
                var reader=cmd.ExecuteReader();
                int x = 1;
                while(reader.Read())
                {
                   
                    var Item = reader["Name"];
                    var Size = reader["Size"];
                    var Company = reader["Company"];
                    var Client = reader["Client"];
                    var date = reader["Date"];
                    var Invoice_No = reader["Invoice_No"];
                        var Quantity = reader["Quantity"];
                    var category = reader["category"];

                    form9.history.Rows.Add(x,Invoice_No,Item,Size,category,Company,Quantity,Client,date);
                    x++;
                }
                conn.Close();
            }



        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            string check = "Select * from inventory where Name = '" + textBox4.Text + "' and Size='" + comboBox3.Text + "'and Company='" + comboBox2.Text + "' and Category='"+comboBox7.Text+"'";

            cmd = new SqlCommand(check, conn);
            var read = cmd.ExecuteReader();
            while (read.Read())
            {
                var item = read["Name"];
                var size = read["Size"];
                var company = read["Company"];
                var category = read["Category"];
                if (item != null)
                {
                    if (size != null)
                    {
                        if (company != null)
                        {
                            if (category != null)
                            {
                                MessageBox.Show("Item Already Saved");
                                textBox4.Text = null;
                                textBox2.Text = null;
                                textBox3.Text = null;
                                comboBox3.Text = null;
                                comboBox2.Text = null;
                                comboBox7.Text = null;

                                conn.Close();
                                read.Close();
                                this.Close();
                                refresh();
                                return;
                            }
                        }

                    }
                }
            }
            read.Close();
            conn.Close();


            conn.Open();

            string Query = "Insert into inventory(Name,Price,Quantity,Size,Company,Category) values('" + textBox4.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox3.Text + "','" + comboBox2.Text + "','"+comboBox7.Text+"')";

            cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Item Saved");
            textBox4.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            comboBox3.Text = null;
            comboBox2.Text = null;
            comboBox7.Text= null;
            conn.Close();
            refresh();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel4.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            conn.Open();
            string Query1 = "Update inventory Set Name='" + textBox7.Text + "',Price='" + textBox6.Text + "',Quantity='" + textBox5.Text + "',Size='" + comboBox5.Text + "',Company='" + comboBox4.Text + "',Category='"+comboBox6.Text+"' where Name = '" + text + "' and Size='" + size + "' and Company='" + Company + "' and Category='"+category1+"' ";
            cmd = new SqlCommand(Query1, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Item Updated");
            refresh();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            Category form = new Category();
            form.Show();
        }

        void color_check()
        {
            for(int i=0;i<inventory.RowCount;i++)
            {
                for (int j = 0; j < dataGridView2.RowCount; j++)
                {
                    if(inventory.Rows[i].Cells[1].Value==dataGridView2.Rows[j].Cells[1].Value)
                    {
                        inventory.Rows[i].DefaultCellStyle.BackColor=Color.Aqua;
                        break;
                    }
                }
                    
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button2, "Add new Item");

        }

        private void button12_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button12, "Ledgers");

        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button10, "Create New Input Challan");

        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button3,"Create New Delivery Challan");

        }

        private void button11_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button11, "Create New Invoice");

        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button9, "New Size");

        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button5, "New Company");

        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button6, "Add New User");

        }

        private void button16_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button16, "New Category");

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            Grids();
            inventory.Show();
            refresh();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Grids();
            textBox1.Text = null;

            dataGridView2.Show();
            refresh_Quote();
            
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Grids();
            textBox1.Text = null;

            Invoice.Show();
            refresh_invoice();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Grids();
            textBox1.Text = null;

            dataGridView1.Show();
            refresh_DC();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Grids();
            textBox1.Text = null;

            IC.Show();
            refresh_IC();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Grids();
            textBox1.Text = null;

            companies.Show();
            refresh_company();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Grids();
            textBox1.Text = null;

            Size1.Show();
            refresh_size();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "Menu");

        }

        private void button21_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button21, "Inventory");

        }

        private void button19_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button19, "Quotations");

        }

        private void button20_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button20, "Invoices");

        }

        private void button17_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button17, "DCs");

        }

        private void button23_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button23, "ICs");

        }

        private void button18_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button18, "Companies");

        }

        private void button22_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(button22, "Sizes");

        }

        private void Size1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==2)
            {
                conn.Open();
                string Query = "Delete  sizes where Size='" + Size1.CurrentRow.Cells[1].Value.ToString() + "'";
                cmd = new SqlCommand(Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                refresh_size();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            refresh();
            refresh_company();
            refresh_DC();
            refresh_IC();
            refresh_invoice();
            refresh_size();
            refresh_Quote();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Q_form form = new Q_form();
            form.Show();
        }

       
    }

}
