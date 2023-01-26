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

namespace Food_project
{
   
    public partial class income : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\bill\database\foodproject.mdf;Integrated Security=True;Connect Timeout=30");
        public income()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtid.Text = row.Cells["id"].Value.ToString();
        }

       public void display()
        {
            try
            {
                con.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("select * from salesreport", con);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                double sum1 = 0;
                for(int i=0; i <dataGridView1.Rows.Count; ++i)
                {
                    sum1 += Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);

                }
                lbltotal.Text = sum1.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void income_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin a1 = new admin();
            a1.Show();
            this.Hide();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtid.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete from salesreport where id = '" + txtid.Text + "'", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("deleted");
                    con.Close();
                    txtid.Text = String.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                display();
                
            }
            else
            {
                MessageBox.Show("Please click ID that you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtid.Text = String.Empty;
            }
            
        }

        private void btndeleteall_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to Delete all", "Information", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("truncate table salesreport ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Done");
                    con.Close();
                    lbltotal.Text = String.Empty;
                    txtid.Text = String.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                display();
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
