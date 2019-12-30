using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Vision___Crime_Investigation_System__22_7_2019_
{
    public partial class UserControllockupdetails : UserControl
    {
        public UserControllockupdetails()
        {
            InitializeComponent();
        }

        private void pictureBoxprison1_Click(object sender, EventArgs e)
        {
            string conx = connectionclass.ConnectionString;
            SqlConnection con = new SqlConnection(conx);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Criminal_Enquiry where Locked_In='Prison1'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridViewlockupdetails.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void pictureBoxprison2_Click(object sender, EventArgs e)
        {
            string conx = connectionclass.ConnectionString;
            SqlConnection con = new SqlConnection(conx);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Criminal_Enquiry where Locked_In='Prison2'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridViewlockupdetails.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void pictureBoxprison3_Click(object sender, EventArgs e)
        {
            string conx = connectionclass.ConnectionString;
            SqlConnection con = new SqlConnection(conx);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Criminal_Enquiry where Locked_In='Prison3'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridViewlockupdetails.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
