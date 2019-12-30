using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision___Crime_Investigation_System__22_7_2019_
{
    public partial class Formmain : Form
    {
        public Formmain()
        {
            InitializeComponent();
        }

        private void pictureBoxlogout_Click(object sender, EventArgs e)
        {
            Formlogin fl = new Formlogin();
            fl.Show();
            this.Hide();
        }

        private void pictureBoxminimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxcomplaint_Click(object sender, EventArgs e)
        {
            pictureBoxcomplaint.BackColor = Color.DarkRed;
            pictureBoxfirsystem.BackColor = Color.Black;
            pictureBoxcrimeinquiry.BackColor = Color.Black;
            pictureBoxlockupdetails.BackColor = Color.Black;
            pictureBoxconfiscateditems.BackColor = Color.Black;

            userControlcomplaint1.Show();
            userControlcriminalenquiry1.Hide();
            userControlFIRsystem1.Hide();
            userControllockupdetails1.Hide();
            userControlconfiscateditems1.Hide();
        }

        private void pictureBoxfirsystem_Click(object sender, EventArgs e)
        {
            pictureBoxcomplaint.BackColor = Color.Black;
            pictureBoxfirsystem.BackColor = Color.DarkRed;
            pictureBoxcrimeinquiry.BackColor = Color.Black;
            pictureBoxlockupdetails.BackColor = Color.Black;
            pictureBoxconfiscateditems.BackColor = Color.Black;

            userControlcomplaint1.Hide();
            userControlcriminalenquiry1.Hide();
            userControlFIRsystem1.Show();
            userControllockupdetails1.Hide();
            userControlconfiscateditems1.Hide();
        }

        private void pictureBoxcrimeinquiry_Click(object sender, EventArgs e)
        {
            pictureBoxcomplaint.BackColor = Color.Black;
            pictureBoxfirsystem.BackColor = Color.Black;
            pictureBoxcrimeinquiry.BackColor = Color.DarkRed;
            pictureBoxlockupdetails.BackColor = Color.Black;
            pictureBoxconfiscateditems.BackColor = Color.Black;

            userControlcomplaint1.Hide();
            userControlcriminalenquiry1.Show();
            userControlFIRsystem1.Hide();
            userControllockupdetails1.Hide();
            userControlconfiscateditems1.Hide();
        }

        private void pictureBoxlockupdetails_Click(object sender, EventArgs e)
        {
            pictureBoxcomplaint.BackColor = Color.Black;
            pictureBoxfirsystem.BackColor = Color.Black;
            pictureBoxcrimeinquiry.BackColor = Color.Black;
            pictureBoxlockupdetails.BackColor = Color.DarkRed;
            pictureBoxconfiscateditems.BackColor = Color.Black;
            
            userControlcomplaint1.Hide();
            userControlcriminalenquiry1.Hide();
            userControlFIRsystem1.Hide();
            userControllockupdetails1.Show();
            userControlconfiscateditems1.Hide();
        }

        private void pictureBoxconfiscateditems_Click(object sender, EventArgs e)
        {
            userControlcomplaint1.Hide();
            userControlcriminalenquiry1.Hide();
            userControlFIRsystem1.Hide();
            userControllockupdetails1.Hide();
            userControlconfiscateditems1.Show();
            
            pictureBoxcomplaint.BackColor = Color.Black;
            pictureBoxfirsystem.BackColor = Color.Black;
            pictureBoxcrimeinquiry.BackColor = Color.Black;
            pictureBoxlockupdetails.BackColor = Color.Black;
            pictureBoxconfiscateditems.BackColor = Color.DarkRed;
        }

        private void Formmain_Load(object sender, EventArgs e)
        {
            userControlcomplaint1.Hide();
            userControlcriminalenquiry1.Hide();
            userControlFIRsystem1.Hide();
            userControllockupdetails1.Hide();
            userControlconfiscateditems1.Hide();
        }

        private void userControllockupdetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
