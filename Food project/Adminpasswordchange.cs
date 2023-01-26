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
    public partial class Adminpasswordchange : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\bill\database\foodproject.mdf;Integrated Security=True;Connect Timeout=30");
        public Adminpasswordchange()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            admin a1 = new admin();
            a1.Show();
            this.Hide();

            
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtpass.Text) && !String.IsNullOrEmpty(txtuser.Text))
            {
               
                try
                {
                    SqlCommand cmd = new SqlCommand("update admin set username='" + txtuser.Text + "',password='" + txtpass.Text + "'", con);
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
            }
            else
            {
                if (String.IsNullOrEmpty(txtpass.Text) && String.IsNullOrEmpty(txtuser.Text))
                {
                    MessageBox.Show("Please fill the all field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 
                else if (String.IsNullOrEmpty(txtuser.Text))
                {
                    MessageBox.Show("Please fill the Username field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Please fill the Password field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            txtpass.Text = String.Empty;
            txtuser.Text = String.Empty;
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void Adminpasswordchange_Load(object sender, EventArgs e)
        {

        }
    }
}

