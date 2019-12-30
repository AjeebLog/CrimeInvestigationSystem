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
    public partial class UserControlFIRsystem : UserControl
    {
        public UserControlFIRsystem()
        {
            InitializeComponent();
        }

        private void pictureBoxinsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionclass.ConnectionString);
            if (textBoxFIRno.Text == "" || textBoxvictimname.Text == "" || maskedTextBoxcnicno.Text == "" || comboBoxondutyofficer.Text == "" || textBoxaccusedname.Text == "" || textBoxvictimstatement.Text == "" || dateTimePickerlodgingdate.Text == "")
            {
                MessageBox.Show("Please fill the required fields");
            }
            else
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("insert into FIR_System values ('" + textBoxFIRno.Text + "','" + textBoxvictimname.Text + "','" + maskedTextBoxcnicno.Text + "','" + comboBoxondutyofficer.Text + "','" + textBoxaccusedname.Text + "','" + textBoxvictimstatement.Text + "','" + dateTimePickerlodgingdate.Value.Date + "')", con);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("F.I.R Lodged Successfully");

                    textBoxFIRno.Clear();
                    textBoxvictimname.Clear();
                    maskedTextBoxcnicno.Clear();
                    comboBoxondutyofficer.ResetText();
                    textBoxaccusedname.Clear();
                    textBoxvictimstatement.Clear();

                    string selectquery1 = "select * from FIR_System";

                    SqlCommand cmd1 = new SqlCommand(selectquery1, con);

                    SqlDataReader dr1 = cmd1.ExecuteReader();

                    while (dr1.Read())
                    {

                        int rn1 = dr1.GetInt32(0);
                        int h = rn1 + 1;
                        textBoxFIRno.Text = h.ToString();

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
            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM FIR_System WHERE FIR_No='" + textBoxFIRno.Text + "'", con);
            try
            {
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    if (textBoxFIRno.Text == "" || textBoxvictimname.Text == "" || maskedTextBoxcnicno.Text == "" || comboBoxondutyofficer.Text == "" || textBoxaccusedname.Text == "" || textBoxvictimstatement.Text == "" || dateTimePickerlodgingdate.Text == "")
                    {
                        MessageBox.Show("Please fill the required fields");
                    }
                    else
                    {
                        try
                        {
                            SqlCommand cmd1 = new SqlCommand("UPDATE FIR_System SET Victim_Name=('" + textBoxvictimname.Text + "'),Victim_CNIC=('" + maskedTextBoxcnicno.Text + "'), On_duty_Officer=('" + comboBoxondutyofficer.Text + "'), Accused_Name=('" + textBoxaccusedname.Text + "'), Victim_Statement=('" + textBoxvictimstatement.Text + "'), Filing_Date=('" + dateTimePickerlodgingdate.Value.Date + "') where FIR_No=('" + textBoxFIRno.Text + "')", con);
                            cmd1.ExecuteNonQuery();
                            MessageBox.Show("F.I.R updated successfully");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {

                    MessageBox.Show("FIR# not matched");
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
            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM FIR_System WHERE FIR_No = '" + textBoxFIRno.Text + "'", con);
            try
            {
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {


                    try
                    {

                        SqlCommand cmd1 = new SqlCommand("DELETE FROM FIR_System WHERE FIR_No=('" + textBoxFIRno.Text + "')", con);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("F.I.R Deleted");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                    MessageBox.Show("FIR# not matched");
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
                SqlDataAdapter sda = new SqlDataAdapter("select * from FIR_System", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridViewFIRsystem.DataSource = dt;
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

        private void UserControlFIRsystem_Load(object sender, EventArgs e)
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


                string selectquery1 = "select * from FIR_System";

                SqlCommand cmd1 = new SqlCommand(selectquery1, con);

                SqlDataReader dr1 = cmd1.ExecuteReader();

                while (dr1.Read())
                {

                    int rn2 = dr1.GetInt32(0);
                    int h = rn2 + 1;
                    textBoxFIRno.Text = h.ToString();

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

        private void textBoxFIRno_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFIRno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("FIR# cannot contain letters in it");
            }
        }

        private void textBoxvictimname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
                MessageBox.Show("Victim's name cannot contain numbers in it");
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

        private void textBoxaccusedname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
                MessageBox.Show("Accused's name cannot contain numbers in it");
            }
        }

        private void textBoxvictimname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
