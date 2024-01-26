using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class PrintForm : Form
    {
        public PrintForm()
        {
            InitializeComponent();
            dataGridView1.RowTemplate.Height = 20;
            this.WindowState = FormWindowState.Normal;




        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_MouseHover(object sender, EventArgs e)
        {

        }


        private void print(Panel pnl)
        {
            try
            {
                PrinterSettings ps = new PrinterSettings();
                panel1 = pnl;
                GetPrintArea(pnl);
                printPreviewDialog1.Document = printDocument1;
                printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                printPreviewDialog1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Close the form and try again \n Just the form not the Application");
            }
        }

        private Bitmap memorying;

        private void GetPrintArea(Panel pnl)
        {
            memorying = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memorying, new Rectangle(0, 0, pnl.Width, pnl.Height));

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = Bounds;
            e.Graphics.DrawImage(memorying, (pagearea.Width) - (this.panel1.Width), this.panel1.Location.Y );


        }

        private void PrintBox_Click(object sender, EventArgs e)
        {
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            invoice_form form = new invoice_form();
            DC_Box.Text = form.DC_No;
            Invoice_Box.Text = form.Invoice_No;
            Date_Box.Text = form.date_box;
            Client_Box.Text = form.Client;
            Price_Box.Text = form.Total_Price;

            for (int i = 0; i < form.dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < form.dataGridView1.ColumnCount - 2; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = form.dataGridView1.Rows[i].Cells[j].Value;
                }
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintForm form = new PrintForm();
            print(panel1);

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
