using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision___Crime_Investigation_System__22_7_2019_
{
    public partial class Formlogin : Form
    {
        public static string admin;

        public Formlogin()
        {
            InitializeComponent();
        }

        private void panelloginform_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxminimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {       
            if(textBoxuserid.Text == "" || textBoxpassword.Text == "")
            {
                MessageBox.Show("Please fill the required fields");
            }

            Formmain fm = new Formmain();

            if(textBoxuserid.Text == "101" && textBoxpassword.Text == "12345")
            {
                fm.Show();
                this.Hide();
            }
            else if (textBoxuserid.Text == "102" && textBoxpassword.Text == "12345")
            {
                fm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        }

        private void textBoxuserid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("User ID cannot contain letters in it");
            }
        }

        private void textBoxpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Password cannot contain numbers in it");
            }
        }

        private void pictureBoxshowpassword_Click(object sender, EventArgs e)
        {
            if (textBoxpassword.UseSystemPasswordChar == true)
            {
                textBoxpassword.UseSystemPasswordChar = false;
            }
            else if (textBoxpassword.UseSystemPasswordChar == false)
            {
                textBoxpassword.UseSystemPasswordChar = true;
            }
        }
    }
}
