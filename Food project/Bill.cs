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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Reflection;

namespace Food_project
{
    public partial class Bill : Form
    {
        double total = 0;
        double amt = 0;
        double qty = 0;
        double price1;
        double final;
        double diamt = 0;
        double discount = 0;
        double cashp = 0;
        double balance = 0;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\bill\database\foodproject.mdf;Integrated Security=True;Connect Timeout=30");
        public Bill()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to  the program", "Information", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("truncate table costdetail ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    
                    con.Close();
                    txtfinal.Text = String.Empty;
                    txtbalance.Text = String.Empty;
                    txtcash.Text = String.Empty;
                    txtdiscount.Text = String.Empty;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Application.Exit();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtid.Text) && !String.IsNullOrEmpty(txtname.Text) && !String.IsNullOrEmpty(txtprice.Text))
            {
             if (!String.IsNullOrEmpty(txtqty.Text))
             {
            price1 = Convert.ToDouble(txtprice.Text);
            qty = Convert.ToDouble(txtqty.Text);
            total  = price1 * qty;
            txttotal.Text = total.ToString();
            final = final + total;
            if (radioButton1.Checked == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into costdetail values('" + txtid.Text + "','" + txtname.Text + "','Medium','" + txtprice.Text + "','" + txtqty.Text + "','" + txttotal.Text + "')", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("added");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into costdetail values('" + txtid.Text + "','" + txtname.Text + "',' Large ','" + txtprice.Text + "','" + txtqty.Text + "','" + txttotal.Text + "')", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("added");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            costdisplay();
                }
                else
                {
                    MessageBox.Show("Please fill the QTY field before  add", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please fill the select item you want to add", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        public void costdisplay()
        {

            try
            {
                con.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("select costid, name, type, price, qty, total from costdetail", con);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtid.Text = String.Empty;
            txtname.Text = String.Empty;
            txtprice.Text = String.Empty;
      
            txtqty.Text = String.Empty;
            txttotal.Text = String.Empty;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtid.Text))
            {


                if (radioButton1.Checked == true)
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(@"select * from Food where FoodId ='" + txtid.Text + "'", con);
                        SqlDataReader rdr = cmd.ExecuteReader();
                        bool temp = false;
                        while (rdr.Read())
                        {
                            txtname.Text = rdr.GetValue(1).ToString();
                            txtprice.Text = rdr.GetValue(2).ToString();

                            temp = true;

                        }
                        if (temp == false)
                        {
                            MessageBox.Show("not found");
                        }
                        con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(@"select * from Food where FoodId ='" + txtid.Text + "'", con);
                        SqlDataReader rdr = cmd.ExecuteReader();
                        bool temp = false;
                        while (rdr.Read())
                        {
                            txtname.Text = rdr.GetValue(1).ToString();
                            txtprice.Text = rdr.GetValue(3).ToString();

                            temp = true;

                        }
                        if (temp == false)
                        {
                            MessageBox.Show("not found");
                        }
                        con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill the Foodid field before  add", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Bill_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
                
                try
                {
                    SqlCommand cmd = new SqlCommand("truncate table costdetail ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Done");
                    con.Close();
                    txtfinal.Text = String.Empty;
                    txtbalance.Text = String.Empty;
                txtcash.Text = String.Empty;
                txtdiscount.Text = String.Empty;


            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                costdisplay();

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (!String.IsNullOrEmpty(txtid.Text))
            {
                total = Convert.ToDouble(txttotal.Text);

                try
                {
                    SqlCommand cmd = new SqlCommand("delete from costdetail where costid = '" + txtid.Text + "'", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("deleted");
                    con.Close();
                    final = final - total;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please click the purshased items you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            costdisplay();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtid.Text = row.Cells["costid"].Value.ToString();
                txtname.Text = row.Cells["name"].Value.ToString();
                txtprice.Text = row.Cells["price"].Value.ToString();
               txtqty.Text = row.Cells["qty"].Value.ToString();
                txttotal.Text = row.Cells["total"].Value.ToString();

            }
        }

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtdiscount.Text))
            {

               
                    discount = Convert.ToDouble(txtdiscount.Text);
                    diamt = final * (discount / 100);
                    amt = final - diamt;
                    txtfinal.Text = amt.ToString();
                
            }
            else
            {
                MessageBox.Show("Please enter the discount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }

        private void button6_Click(object sender, EventArgs e)
        {

            double b = Convert.ToDouble(txtfinal.Text);
            if (!String.IsNullOrEmpty(txtfinal.Text)&& txtfinal.Text !="0")
                {
                    if (!String.IsNullOrEmpty(txtcash.Text))
                    {
                        cashp = Convert.ToDouble(txtcash.Text);
                        if (b <= cashp)
                        {
                            balance = cashp - b;
                            txtbalance.Text = balance.ToString();

                            DialogResult dialog = MessageBox.Show("Do you really want to finish the bill", "Information", MessageBoxButtons.YesNo);
                            if (dialog == DialogResult.Yes)
                            {

                                String timec = DateTime.Now.ToLongTimeString();
                                String datec = DateTime.Now.ToLongDateString();
                                try
                                {
                                    SqlCommand cmd = new SqlCommand("insert into salesreport values('" + txtfinal.Text + "','" + timec + "','" + datec + "')", con);
                                    con.Open();
                                    cmd.CommandType = CommandType.Text;
                                    cmd.ExecuteNonQuery();
                                    final = 0;

                                    con.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                            }

                        }
                        else
                        {
                            MessageBox.Show("paid amount is not enough", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill the cash paid field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Please Calculate the bill", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
            
               
            


        

        private void txtcash_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtfinal.Text) && !String.IsNullOrEmpty(txtdiscount.Text) && !String.IsNullOrEmpty(txtdiscount.Text) && !String.IsNullOrEmpty(txtcash.Text) && !String.IsNullOrEmpty(txtbalance.Text))
            {
                Document d = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(d, new FileStream("C:/bill/ bill.pdf", FileMode.Create));
                d.Open();

                PdfPTable table1 = new PdfPTable(dataGridView1.Columns.Count);

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    table1.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int k = 0; k < dataGridView1.Columns.Count; k++)
                    {
                        if (dataGridView1[k, i].Value != null)
                        {
                            table1.AddCell(new Phrase(dataGridView1[k, i].Value.ToString()));
                        }

                    }
                }


                table1.SpacingBefore = 18f;

                String timec = DateTime.Now.ToLongTimeString();
                String datec = DateTime.Now.ToLongDateString();

                Paragraph pg = new Paragraph("...TINYCHEF....", FontFactory.GetFont("Century Gothic"));
                pg.Font.Size = 35;
                pg.Alignment = Element.ALIGN_CENTER;
                d.Add(pg);
                Paragraph pg5 = new Paragraph("NO.55, ST.JOSAPH RD, KURUNEGALA", FontFactory.GetFont("Century Gothic"));
                pg5.Font.Size = 20;
                pg5.Alignment = Element.ALIGN_CENTER;
                d.Add(pg5);
                Paragraph pg51 = new Paragraph("TELEPHONE NO: 0755346789 , FAX:067653565", FontFactory.GetFont("Century Gothic"));
                pg51.Font.Size = 20;
                pg51.Alignment = Element.ALIGN_CENTER;
                d.Add(pg51);

                Paragraph pIg = new Paragraph("", FontFactory.GetFont("Century Gothic"));
                pIg.Font.Size = 20;
                pIg.Alignment = Element.ALIGN_LEFT;
                d.Add(pIg);

                PdfPTable table2 = new PdfPTable(2);
                table2.DefaultCell.Border = 0;

                table2.TotalWidth = 200f;
                table2.HorizontalAlignment = Element.ALIGN_RIGHT;
                table2.LockedWidth = true;
                table2.AddCell("TIME:");
                table2.AddCell(timec);

                table2.AddCell("DATE:");
                table2.AddCell(datec);

                table2.SpacingBefore = 12.5f;

                d.Add(table2);





                d.Add(table1);

                PdfPTable table3 = new PdfPTable(2);
                table3.DefaultCell.Border = 0;
                table3.TotalWidth = 200f;
                table3.HorizontalAlignment = Element.ALIGN_RIGHT;
                table3.LockedWidth = true;
                table3.AddCell("Final Amount:");
                table3.AddCell(txtfinal.Text);
                table3.AddCell("Discount:");
                table3.AddCell(txtdiscount.Text);
                table3.AddCell("Cash Paid:");
                table3.AddCell(txtcash.Text);
                table3.AddCell("Balance:");
                table3.AddCell(txtbalance.Text);
                table3.SpacingBefore = 18f;

                d.Add(table3);
                Paragraph pg1 = new Paragraph("THANK YOU COME BACK", FontFactory.GetFont("Century Gothic"));
                pg1.Font.Size = 18;
                pg1.Alignment = Element.ALIGN_CENTER;
               
                d.Add(pg1);
                Paragraph pg6 = new Paragraph("Enjoy your Tiny meal with Tinychef!", FontFactory.GetFont("Century Gothic"));
                pg6.Font.Size = 18;
                pg6.Alignment = Element.ALIGN_CENTER;
              
                d.Add(pg6);
                Paragraph pg23 = new Paragraph("Open at 7.30 A.M, Close at 8.50 P.M", FontFactory.GetFont("Century Gothic"));
                pg23.Font.Size = 18;
                pg23.Alignment = Element.ALIGN_CENTER;
               
                d.Add(pg23);

                d.Close();
                System.Diagnostics.Process.Start("C:\\bill\\ bill.pdf");
            }
            else
            {
                MessageBox.Show("Please Final the bill", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

              
        }

        private void button9_Click(object sender, EventArgs e)
        {
            itemdisplay a1 = new itemdisplay();
            a1.Show();
            
        }
    }
}
