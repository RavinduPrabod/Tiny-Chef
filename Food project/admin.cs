using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_project
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
           
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to close the program", "Information", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnadmin_Click(object sender, EventArgs e)
        {
            panelleft.Height = btnadmin.Height;
            panelleft.Top = btnadmin.Top;
            Adminpasswordchange p1 = new Adminpasswordchange();
            p1.Show();
            this.Hide();
            

        }

        private void btnemployee_Click(object sender, EventArgs e)
        {
            panelleft.Height = btnemployee.Height;
            panelleft.Top = btnemployee.Top;
            Employeedetails e1 = new Employeedetails();
            e1.Show();
            this.Hide();
           

        }

        private void btnfood_Click(object sender, EventArgs e)
        {
            panelleft.Top = btnfood.Top;
            panelleft.Height = btnfood.Height;
            fooditem f1 = new fooditem();
            f1.Show();
            this.Hide();
        }

        private void btnincome_Click(object sender, EventArgs e)
        {
            panelleft.Top = btnincome.Top;
            panelleft.Height = btnincome.Height;
            income i1 = new income();
            i1.Show();
            this.Hide();
        }

        private void panelleft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void admin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
