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
using System.IO;

namespace Vision___Crime_Investigation_System__22_7_2019_
{
    public partial class UserControlcriminalenquiry : UserControl
    {
        public static string suspectname;

        string filename;

        public UserControlcriminalenquiry()
        {
            InitializeComponent();
        }

        private void pictureBoxinsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionclass.ConnectionString);
            if (textBoxenquiryreportno.Text == "" || textBoxsuspectname.Text == "" || textBoxsuspectage.Text == "" || maskedTextBoxcnicno.Text == "" || textBoxaddress.Text == "" || maskedTextBoxphoneno.Text == "" || textBoxcrimetype.Text == "" || textBoxcrimedetails.Text == "" || comboBoxarrestedby.Text == "" || comboBoxlockedin.Text == "" || dateTimePickerdateofarrest.Text == "" || comboBoxcurrentstatus.Text == "" || textBoxfrguarantor.Text == "")
            {
                MessageBox.Show("Please fill the required fields");
            }
            else
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("insert into Criminal_Enquiry values ('" + textBoxenquiryreportno.Text + "','" + textBoxsuspectname.Text + "','" + textBoxsuspectage.Text + "','" + maskedTextBoxcnicno.Text + "','" + textBoxaddress.Text + "','" + maskedTextBoxphoneno.Text + "','" + textBoxcrimetype.Text + "','" + textBoxcrimedetails.Text + "','" + comboBoxarrestedby.Text + "','" + comboBoxlockedin.Text + "','" + dateTimePickerdateofarrest.Value.Date + "','" + comboBoxcurrentstatus.Text + "','" + textBoxfrguarantor.Text + "', @img) ", con);

                    FileStream fs = new FileStream(openFileDialogimageinsert.FileName, FileMode.Open, FileAccess.Read);
                    byte[] image = new byte[fs.Length];
                    fs.Read(image, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    SqlParameter sql = new SqlParameter("@img", SqlDbType.VarBinary, image.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, image);
                    cmd.Parameters.Add(sql);
                    cmd.ExecuteNonQuery();
              
                    con.Close();
                    MessageBox.Show("Enquiry Report Added Successfully");

                    textBoxenquiryreportno.Clear();
                    textBoxsuspectname.Clear();
                    textBoxsuspectage.Clear();
                    maskedTextBoxcnicno.Clear();
                    textBoxaddress.Clear();
                    maskedTextBoxphoneno.Clear();
                    textBoxcrimetype.Clear();
                    textBoxcrimedetails.Clear();
                    comboBoxarrestedby.ResetText();
                    comboBoxlockedin.ResetText();
                    comboBoxcurrentstatus.ResetText();
                    textBoxfrguarantor.Clear();
                    pictureBoxsuspectimage.BackColor = Color.Black;

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
            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Criminal_Enquiry WHERE Enquiry_Report_No='" + textBoxenquiryreportno.Text + "'", con);
            try
            {
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    if (textBoxenquiryreportno.Text == "" || textBoxsuspectname.Text == "" || textBoxsuspectage.Text == "" || maskedTextBoxcnicno.Text == "" || textBoxaddress.Text == "" || maskedTextBoxphoneno.Text == "" || textBoxcrimetype.Text == "" || textBoxcrimedetails.Text == "" || comboBoxarrestedby.Text == "" || comboBoxlockedin.Text == "" || dateTimePickerdateofarrest.Text == "" || comboBoxcurrentstatus.Text == "" || textBoxfrguarantor.Text == "")
                    {
                        MessageBox.Show("Please fill the required fields");
                    }
                    else
                    {
                        try
                        {
                            SqlCommand cmd1 = new SqlCommand("UPDATE Criminal_Enquiry SET Suspect_Name=('" + textBoxsuspectname.Text + "'), Suspect_Age=('" + textBoxsuspectage.Text + "'),Suspect_CNIC=('" + maskedTextBoxcnicno.Text + "'), Suspect_Address=('" + textBoxaddress.Text + "'), Phone_Number=('" + maskedTextBoxphoneno.Text + "'), Crime_Type=('" + textBoxcrimetype.Text + "'), Crime_Details=('" + textBoxcrimedetails.Text + "'), Arrested_By=('" + comboBoxarrestedby.Text + "'), Locked_In=('" + comboBoxlockedin.Text + "'), Date_of_Arrest=('" + dateTimePickerdateofarrest.Value.Date + "'), Current_Status=('" + comboBoxcurrentstatus.Text + "'), FR_Guarantor=('" + textBoxfrguarantor.Text + "') where Enquiry_Report_No=('" + textBoxenquiryreportno.Text + "')", con);
                            cmd1.ExecuteNonQuery();
                            MessageBox.Show("Enquiry Report updated successfully");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {

                    MessageBox.Show("Enquiry Report# not matched");
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

        private void UserControlcriminalenquiry_Load(object sender, EventArgs e)
        {
            panelrecordmaintenance.Show();
            panelsearchrecord.Hide();

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
                    comboBoxarrestedby.Items.Add(rn);

                }
                dr.Close();


                string selectquery1 = "select * from Criminal_Enquiry";

                SqlCommand cmd1 = new SqlCommand(selectquery1, con);

                SqlDataReader dr1 = cmd1.ExecuteReader();

                while (dr1.Read())
                {

                    int rn2 = dr1.GetInt32(0);
                    int h = rn2 + 1;
                    textBoxenquiryreportno.Text = h.ToString();

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panelrecordmaintenance.Show();
            panelsearchrecord.Hide();
        }

        private void pictureBoxsearchpanel_Click(object sender, EventArgs e)
        {
            panelrecordmaintenance.Hide();
            panelsearchrecord.Show();
        }

        private void pictureBoxinsert_Click_1(object sender, EventArgs e)
        {

        }

        private void textBoxs_r_enquiryreportno_TextChanged(object sender, EventArgs e)
        {
            if (textBoxs_r_enquiryreportno.Text == "")
            {
                textBoxs_r_suspectname.Text = "";
                textBoxs_r_suspectage.Text = "";
                textBoxs_r_cnicno.Text = "";
                textBoxs_r_address.Text = "";
                textBoxs_r_phonenumber.Text = "";
                textBoxs_r_crimetype.Text = "";
                textBoxs_r_crimedetails.Text = "";
                textBoxs_r_arrestedby.Text = "";
                textBoxs_r_lockedin.Text = "";
                textBoxs_r_dateofarrest.Text = "";
                textBoxs_r_currentstatus.Text = "";
                textBoxs_r_frguarantor.Text = "";
            }

            string conx = connectionclass.ConnectionString;
            SqlConnection con1 = new SqlConnection(conx);
            try
            {
                con1.Open();
                string selectquery = "select * from Criminal_Enquiry where Enquiry_Report_No=('" + textBoxs_r_enquiryreportno.Text + "')";

                SqlCommand cmd = new SqlCommand(selectquery, con1);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string rn = dr.GetString(1);
                    textBoxs_r_suspectname.Text = rn;
                    int rn1 = dr.GetInt32(2);
                    textBoxs_r_suspectage.Text = rn1.ToString();
                    string rn2 = dr.GetString(3);
                    textBoxs_r_cnicno.Text = rn2;
                    string rn3 = dr.GetString(4);
                    textBoxs_r_address.Text = rn3;
                    string rn4 = dr.GetString(5);
                    textBoxs_r_phonenumber.Text = rn4;
                    string rn5 = dr.GetString(6);
                    textBoxs_r_crimetype.Text = rn5;
                    string rn6 = dr.GetString(7);
                    textBoxs_r_crimedetails.Text = rn6;
                    string rn7 = dr.GetString(8);
                    textBoxs_r_arrestedby.Text = rn7;
                    string rn8 = dr.GetString(9);
                    textBoxs_r_lockedin.Text = rn8;
                    string rn9 = Convert.ToString(dr.GetDateTime(10));
                    textBoxs_r_dateofarrest.Text = rn9;
                    string rn10 = dr.GetString(11);
                    textBoxs_r_currentstatus.Text = rn10;
                    string rn11 = dr.GetString(12);
                    textBoxs_r_frguarantor.Text = rn11;
                }
                dr.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);

            }
            finally
            {
                con1.Close();
            }

            string conx1 = connectionclass.ConnectionString;
            SqlConnection con2 = new SqlConnection(conx);
            SqlCommand cmd1;
            try
            {
                con2.Open();

                cmd1 = new SqlCommand("select Suspect_Image from Criminal_Enquiry where Enquiry_Report_No ='"+textBoxs_r_enquiryreportno.Text+"'", con2);

                SqlDataAdapter da = new SqlDataAdapter(cmd1);

                DataSet ds = new DataSet();

                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["Suspect_Image"]);

                   pictureBoxs_r_suspectimage.Image = new Bitmap(ms);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con2.Close();
            }
        }

        private void pictureBoxdelete_Click(object sender, EventArgs e)
        {
            string conx = connectionclass.ConnectionString;
            SqlConnection con = new SqlConnection(conx);
            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Criminal_Enquiry WHERE Enquiry_Report_No = '" + textBoxs_r_enquiryreportno.Text + "'", con);
            try
            {
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {


                    try
                    {

                        SqlCommand cmd1 = new SqlCommand("DELETE FROM Criminal_Enquiry WHERE Enquiry_Report_No=('" + textBoxs_r_enquiryreportno.Text + "')", con);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Enquiry Report Deleted");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                    MessageBox.Show("Enquiry Report# not matched");
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

        private void pictureBoxbrowse_Click(object sender, EventArgs e)
        {
            openFileDialogimageinsert.ShowDialog();
            filename = openFileDialogimageinsert.FileName;
            pictureBoxsuspectimage.Image = Image.FromFile(openFileDialogimageinsert.FileName);
            pictureBoxsuspectimage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBoxupload_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            if (File.Exists(openFileDialogimageinsert.FileName))
            {
                try
                {
                    string conx = connectionclass.ConnectionString;
                    SqlConnection con = new SqlConnection(conx);
                    con.Open();
                    cmd = new SqlCommand("insert into Criminal_Enquiry values (@Suspect_Image)", con);
                    FileStream fs = new FileStream(openFileDialogimageinsert.FileName, FileMode.Open, FileAccess.Read);
                    byte[] image = new byte[fs.Length];
                    fs.Read(image, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    SqlParameter sql = new SqlParameter("@Suspect_Image", SqlDbType.VarBinary, image.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, image);
                    cmd.Parameters.Add(sql);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Suspect's Image Added Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select Image");
            }
        }

        private void textBoxenquiryreportno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Enquiry Report# cannot contain letters in it");
            }
        }

        private void textBoxsuspectname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
                MessageBox.Show("Suspect's name cannot contain numbers in it");
            }
        }

        private void textBoxsuspectage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Suspect's age cannot contain letters in it");
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

        private void maskedTextBoxphoneno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Phone number cannot contain letters in it");
            }
        }

        private void textBoxcrimetype_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
                MessageBox.Show("Crime type cannot contain numbers in it");
            }
        }

        private void comboBoxarrestedby_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
                MessageBox.Show("It cannot contain numbers in it");
            }
        }

        private void comboBoxcurrentstatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
                MessageBox.Show("It cannot contain numbers in it");
            }
        }

        private void textBoxfrguarantor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
                MessageBox.Show("It cannot contain numbers in it");
            }
        }

        private void textBoxs_r_enquiryreportno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("It cannot contain letters in it");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
