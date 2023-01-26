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
    public partial class fooditem : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\bill\database\foodproject.mdf;Integrated Security=True;Connect Timeout=30");
        public fooditem()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtid.Text = String.Empty;
            txtname.Text = String.Empty;
            txtmprice.Text = String.Empty;
            txtlprice.Text = string.Empty;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if ( !String.IsNullOrEmpty(txtname.Text) && !String.IsNullOrEmpty(txtmprice.Text) && !String.IsNullOrEmpty(txtmprice.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into Food values('" + txtname.Text + "','" + txtmprice.Text + "','" + txtlprice.Text + "')", con);
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
                displaydata();
            }
            else
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtid.Text) && !String.IsNullOrEmpty(txtname.Text) && !String.IsNullOrEmpty(txtmprice.Text) && !String.IsNullOrEmpty(txtmprice.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update Food set name='" + txtname.Text + "',mprice='" + txtmprice.Text + "',lprice='" + txtlprice.Text + "' where FoodId ='" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    con.Close();
                    displaydata();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select the item you want to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtid.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete from Food where FoodId = '" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("deleted");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                displaydata();

            }
            else
            {
                MessageBox.Show("Please select the item you want to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void displaydata()
        {
            try
            {
                con.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("select * from Food", con);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fooditem_Load(object sender, EventArgs e)
        {
            displaydata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtid.Text = row.Cells["FoodId"].Value.ToString();
                txtname.Text = row.Cells["name"].Value.ToString();
                txtmprice.Text = row.Cells["mprice"].Value.ToString();
                txtlprice.Text = row.Cells["lprice"].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin a1 = new admin();
            a1.Show();
            this.Hide();
        }

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
