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
    public partial class Employeedetails : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\bill\database\foodproject.mdf;Integrated Security=True;Connect Timeout=30");
        public Employeedetails()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin a1 = new admin();
            a1.Show();
            this.Hide();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtid.Text) && !String.IsNullOrEmpty(txtname.Text) && !String.IsNullOrEmpty(txtaddress.Text) && !String.IsNullOrEmpty(txtuser.Text) && !String.IsNullOrEmpty(txtpass.Text) )
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into employee values('" + txtid.Text + "','" + txtname.Text + "','" + txtaddress.Text + "','" + txtuser.Text + "','" + txtpass.Text + "')", con);
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
                
                    MessageBox.Show("Please fill the empty fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            displaydata();

        }
        

        private void Employeedetails_Load(object sender, EventArgs e)
        {
            displaydata();
        }
        public void displaydata()
        {
            try
            {
                con.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("select * from employee", con);
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
             if (!String.IsNullOrEmpty(txtid.Text) && !String.IsNullOrEmpty(txtname.Text) && String.IsNullOrEmpty(txtaddress.Text) && String.IsNullOrEmpty(txtuser.Text) && String.IsNullOrEmpty(txtpass.Text))
            
                {
                try
                {
                    SqlCommand cmd = new SqlCommand("update employee set name='" + txtname.Text + "' where id ='" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                displaydata();
            }
            else if (!String.IsNullOrEmpty(txtid.Text) && String.IsNullOrEmpty(txtname.Text) && !String.IsNullOrEmpty(txtaddress.Text) && String.IsNullOrEmpty(txtuser.Text) && String.IsNullOrEmpty(txtpass.Text))
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("update employee set address='" + txtaddress.Text + "' where id ='" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                displaydata();
            }
            else if (!String.IsNullOrEmpty(txtid.Text) && String.IsNullOrEmpty(txtname.Text) && String.IsNullOrEmpty(txtaddress.Text) && !String.IsNullOrEmpty(txtuser.Text) && String.IsNullOrEmpty(txtpass.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update employee set username='" + txtuser.Text + "' where id ='" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                displaydata();
            }

            else if (!String.IsNullOrEmpty(txtid.Text) && String.IsNullOrEmpty(txtname.Text) && String.IsNullOrEmpty(txtaddress.Text) && String.IsNullOrEmpty(txtuser.Text) && !String.IsNullOrEmpty(txtpass.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update employee set password='" + txtpass.Text + "' where id ='" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                displaydata();
            }
            else if (!String.IsNullOrEmpty(txtid.Text) && !String.IsNullOrEmpty(txtname.Text) && !String.IsNullOrEmpty(txtaddress.Text) && String.IsNullOrEmpty(txtuser.Text) && String.IsNullOrEmpty(txtpass.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update employee set name='" + txtname.Text + "',address='" + txtaddress.Text + "' where id ='" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                displaydata();
            }
            else if (!String.IsNullOrEmpty(txtid.Text) && !String.IsNullOrEmpty(txtname.Text) && String.IsNullOrEmpty(txtaddress.Text) && !String.IsNullOrEmpty(txtuser.Text) && String.IsNullOrEmpty(txtpass.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update employee set name='" + txtname.Text + "', username='" + txtuser.Text + "' where id ='" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                displaydata();
            }

            else if (!String.IsNullOrEmpty(txtid.Text) && !String.IsNullOrEmpty(txtname.Text) && String.IsNullOrEmpty(txtaddress.Text) && String.IsNullOrEmpty(txtuser.Text) && !String.IsNullOrEmpty(txtpass.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update employee set name='" + txtname.Text + "', password='" + txtpass.Text + "' where id ='" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                displaydata();
            }

            else if (!String.IsNullOrEmpty(txtid.Text) && String.IsNullOrEmpty(txtname.Text) && !String.IsNullOrEmpty(txtaddress.Text) && !String.IsNullOrEmpty(txtuser.Text) && String.IsNullOrEmpty(txtpass.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update employee set address='" + txtaddress.Text + "', username='" + txtuser.Text + "' where id ='" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                displaydata();
            }

            else if (!String.IsNullOrEmpty(txtid.Text) && String.IsNullOrEmpty(txtname.Text) && !String.IsNullOrEmpty(txtaddress.Text) && String.IsNullOrEmpty(txtuser.Text) && !String.IsNullOrEmpty(txtpass.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update employee set address='" + txtaddress.Text + "', password='" + txtpass.Text + "' where id ='" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                displaydata();
            }

            else if (!String.IsNullOrEmpty(txtid.Text) && String.IsNullOrEmpty(txtname.Text) && String.IsNullOrEmpty(txtaddress.Text) && !String.IsNullOrEmpty(txtuser.Text) && !String.IsNullOrEmpty(txtpass.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update employee set username='" + txtuser.Text + "', password='" + txtpass.Text + "' where id ='" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                displaydata();
            }


            else if (!String.IsNullOrEmpty(txtid.Text) && !String.IsNullOrEmpty(txtname.Text) && !String.IsNullOrEmpty(txtaddress.Text) && !String.IsNullOrEmpty(txtuser.Text) && String.IsNullOrEmpty(txtpass.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update employee set name='" + txtname.Text + "',address='" + txtaddress.Text + "', username='" + txtuser.Text + "' where id ='" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                displaydata();

            }

            else if (!String.IsNullOrEmpty(txtid.Text) && !String.IsNullOrEmpty(txtname.Text) && !String.IsNullOrEmpty(txtaddress.Text) && String.IsNullOrEmpty(txtuser.Text) && !String.IsNullOrEmpty(txtpass.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update employee set name='" + txtname.Text + "',address='" + txtaddress.Text + "', password='" + txtpass.Text + "' where id ='" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                displaydata();

            }

            else if (!String.IsNullOrEmpty(txtid.Text) && !String.IsNullOrEmpty(txtname.Text) && !String.IsNullOrEmpty(txtpass.Text) && !String.IsNullOrEmpty(txtuser.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update employee set name='" + txtname.Text + "',password='" + txtpass.Text + "', username='" + txtuser.Text + "' where id ='" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                displaydata();

            }

            else if (!String.IsNullOrEmpty(txtid.Text) && !String.IsNullOrEmpty(txtpass.Text) && !String.IsNullOrEmpty(txtaddress.Text) && !String.IsNullOrEmpty(txtuser.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update employee set password='" + txtpass.Text + "',address='" + txtaddress.Text + "', username='" + txtuser.Text + "' where  ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                displaydata();

            }

            else if (!String.IsNullOrEmpty(txtid.Text) && !String.IsNullOrEmpty(txtname.Text) && !String.IsNullOrEmpty(txtaddress.Text) && !String.IsNullOrEmpty(txtuser.Text) && !String.IsNullOrEmpty(txtpass.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update employee set name='" + txtname.Text + "',address='" + txtaddress.Text + "', username='" + txtuser.Text + "',password='" + txtpass.Text + "' where id ='" + txtid.Text + "' ", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updated");
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
                MessageBox.Show("Please fill the empty fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
               
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtid.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete from employee where id ='" + txtid.Text + "' ", con);
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
                MessageBox.Show("Please fill only the NIC NO fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtaddress.Text = String.Empty;
            txtid.Text = String.Empty;
            txtname.Text = String.Empty;
            txtpass.Text = String.Empty;
            txtuser.Text = String.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtid.Text = row.Cells["id"].Value.ToString();
                txtname.Text = row.Cells["name"].Value.ToString();
                txtaddress.Text = row.Cells["address"].Value.ToString();
                txtuser.Text = row.Cells["username"].Value.ToString();
                txtpass.Text = row.Cells["password"].Value.ToString();
            }
        }
    }
}
