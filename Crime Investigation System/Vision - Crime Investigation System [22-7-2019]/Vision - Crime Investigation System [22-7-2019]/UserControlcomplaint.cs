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
    public partial class UserControlcomplaint : UserControl
    {
        public UserControlcomplaint()
        {
            InitializeComponent();
        }

        private void UserControlfirsystem_Load(object sender, EventArgs e)
        {
            string conx = connectionclass.ConnectionString;
            SqlConnection con = new SqlConnection(conx);
            try
            {


                con.Open();
                string selectquery = "select Officer_Name from Officer_Login";

                SqlCommand cmd = new SqlCommand(selectquery, con);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string rn = dr.GetString(0);
                    comboBoxondutyofficer.Items.Add(rn);

                }
                dr.Close();


                string selectquery1 = "select * from Complaint";

                SqlCommand cmd1 = new SqlCommand(selectquery1, con);

                SqlDataReader dr1 = cmd1.ExecuteReader();

                while (dr1.Read())
                {

                    int rn2 = dr1.GetInt32(0);
                    int h = rn2 + 1;
                    textBoxcomplaintno.Text = h.ToString();

                }
                dr1.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);

            }
            finally
            {
                con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxinsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionclass.ConnectionString);
            if (textBoxcomplaintno.Text == "" || textBoxcomplainantname.Text == "" || maskedTextBoxcnicno.Text == "" || comboBoxondutyofficer.Text == "" || textBoxcomplaineename.Text == "" || textBoxcomplainantstatement.Text == "" || dateTimePickerfilingdate.Text == "")
            {
                MessageBox.Show("Please fill the required fields");
            }
            else
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("insert into Complaint values ('" + textBoxcomplaintno.Text + "','" + textBoxcomplainantname.Text + "','" + maskedTextBoxcnicno.Text + "','" + comboBoxondutyofficer.Text + "','" + textBoxcomplaineename.Text + "','" + textBoxcomplainantstatement.Text + "','" + dateTimePickerfilingdate.Value.Date + "')", con);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Complaint Filed Successfully");

                    textBoxcomplaintno.Clear();
                    textBoxcomplainantname.Clear();
                    maskedTextBoxcnicno.Clear();
                    comboBoxondutyofficer.ResetText();
                    textBoxcomplaineename.Clear();
                    textBoxcomplainantstatement.Clear();

                    string selectquery1 = "select * from Complaint";

                    SqlCommand cmd1 = new SqlCommand(selectquery1, con);

                    SqlDataReader dr1 = cmd1.ExecuteReader();

                    while (dr1.Read())
                    {

                        int rn1 = dr1.GetInt32(0);
                        int h = rn1 + 1;
                        textBoxcomplaintno.Text = h.ToString();

                    }
                    dr1.Close();

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

        private void pictureBoxupdate_Click(object sender, EventArgs e)
        {
            string conx = connectionclass.ConnectionString;
            SqlConnection con = new SqlConnection(conx);
            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Complaint WHERE Complaint_No='" + textBoxcomplaintno.Text + "'", con);
            try
            {
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    if (textBoxcomplaintno.Text == "" || textBoxcomplainantname.Text == "" || maskedTextBoxcnicno.Text == "" || comboBoxondutyofficer.Text == "" || textBoxcomplaineename.Text == "" || textBoxcomplainantstatement.Text == "" || dateTimePickerfilingdate.Text == "")
                    {
                        MessageBox.Show("Please fill the required fields");
                    }
                    else
                    {
                        try
                        {
                            SqlCommand cmd1 = new SqlCommand("UPDATE Complaint SET Complainant_Name=('" + textBoxcomplainantname.Text + "'),Complainant_CNIC=('" + maskedTextBoxcnicno.Text + "'), On_duty_Officer=('" + comboBoxondutyofficer.Text + "'), Complainee_Name=('" + textBoxcomplaineename.Text + "'), Complainant_Statement=('" + textBoxcomplainantstatement.Text + "'), Filing_Date=('" + dateTimePickerfilingdate.Value.Date + "') where Complaint_No=('" + textBoxcomplaintno.Text + "')", con);
                            cmd1.ExecuteNonQuery();
                            MessageBox.Show("Complaint updated successfully");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {

                    MessageBox.Show("Complaint# not matched");
                }
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

        private void pictureBoxdelete_Click(object sender, EventArgs e)
        {
            string conx = connectionclass.ConnectionString;
            SqlConnection con = new SqlConnection(conx);
            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Complaint WHERE Complaint_No = '" + textBoxcomplaintno.Text + "'", con);
            try
            {
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {


                    try
                    {

                        SqlCommand cmd1 = new SqlCommand("DELETE FROM Complaint WHERE Complaint_No=('" + textBoxcomplaintno.Text + "')", con);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Complaint Deleted");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                    MessageBox.Show("Complaint# not matched");
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

        private void pictureBoxview_Click(object sender, EventArgs e)
        {
            string conx = connectionclass.ConnectionString;
            SqlConnection con = new SqlConnection(conx);
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Complaint", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridViewcomplaint.DataSource = dt;
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

        private void textBoxcomplaintno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Complaint# cannot contain letters in it");
            }
        }

        private void textBoxcomplainantname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
                MessageBox.Show("Complainant's name cannot contain numbers in it");
            }
        }

        private void maskedTextBoxcnicno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("CNIC# cannot contain letters in it");
            }
        }

        private void comboBoxondutyofficer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
                MessageBox.Show("On duty Officer's name cannot contain numbers in it");
            }
        }

        private void textBoxcomplaineename_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
                MessageBox.Show("Complain cannot contain numbers in it");
            }
        }

        private void textBoxcomplaintno_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxondutyofficer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxondutyofficer_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
