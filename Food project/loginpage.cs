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
using System.Threading;

namespace Food_project
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\bill\database\foodproject.mdf;Integrated Security=True;Connect Timeout=30");
        public Login()
        {

            InitializeComponent();
            

        }

        

        private void Login_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

      

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtpass.Text) && !String.IsNullOrEmpty(txtuser.Text) && comboBox1.SelectedIndex != -1)
            {
               

                if (comboBox1.SelectedItem == "ADMIN")
                {
                    SqlCommand cmd = new SqlCommand("select * from admin where username='" + txtuser.Text + "' and password='" + txtpass.Text + "'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    String utype = comboBox1.SelectedItem.ToString();

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            MessageBox.Show("you are login as : ADMIN");
                            if (comboBox1.SelectedItem == "ADMIN")
                            {
                                admin a1 = new admin();
                                a1.Show();
                                this.Hide();
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Please type correct Username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("select username,password from employee where username='" + txtuser.Text + "' and password='" + txtpass.Text + "'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    String utype = comboBox1.SelectedItem.ToString();

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            MessageBox.Show("you are login as : EMPLOYEE");
                            if (comboBox1.SelectedItem == "EMPLOYEE")
                            {
                                Bill e1 = new Bill();
                                e1.Show();
                                this.Hide();
                            }




                        }

                    }
                    else
                    {
                        MessageBox.Show("Please type correct Username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }


            }
            else
            {
                if (String.IsNullOrEmpty(txtpass.Text) && String.IsNullOrEmpty(txtuser.Text) && comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill the all three field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (String.IsNullOrEmpty(txtpass.Text) && String.IsNullOrEmpty(txtuser.Text))
                {
                    MessageBox.Show("Please fill the Username and Password field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (String.IsNullOrEmpty(txtpass.Text) && comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill the Password and Usertype field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (String.IsNullOrEmpty(txtuser.Text) && comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please choose the Usertype and Username field ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (String.IsNullOrEmpty(txtuser.Text))
                {
                    MessageBox.Show("Please fill the Username field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (String.IsNullOrEmpty(txtpass.Text))
                {
                    MessageBox.Show("Please fill the Password field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Please fill the Usertype field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
