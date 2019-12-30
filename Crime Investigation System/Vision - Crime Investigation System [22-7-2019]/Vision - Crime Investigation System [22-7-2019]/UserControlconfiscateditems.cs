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
    public partial class UserControlconfiscateditems : UserControl
    {
        public UserControlconfiscateditems()
        {
            InitializeComponent();
        }

        private void pictureBoxinsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionclass.ConnectionString);
            if (textBoxitemno.Text == "" || textBoxitemname.Text == "" || maskedTextBoxitemserialno.Text == "" || textBoxpropertyowner.Text == "" || textBoxlocation.Text == "" || comboBoxreceivedby.Text == "")
            {
                MessageBox.Show("Please fill the required fields");
            }
            else
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("insert into Confiscated_Items values ('" + textBoxitemno.Text + "','" + textBoxitemname.Text + "','" + maskedTextBoxitemserialno.Text + "','" + dateTimePickerconfiscationdate.Value.Date + "','" + textBoxpropertyowner.Text + "','" + textBoxlocation.Text + "','" + comboBoxreceivedby.Text + "')", con);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Confiscated Item Added Successfully");

                    textBoxitemno.Clear();
                    textBoxitemname.Clear();
                    maskedTextBoxitemserialno.Clear();
                    textBoxpropertyowner.Clear();
                    textBoxlocation.Clear();
                    comboBoxreceivedby.ResetText();


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
            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Confiscated_Items WHERE Item_No='" + textBoxitemno.Text + "'", con);
            try
            {
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    if (textBoxitemno.Text == "" || textBoxitemname.Text == "" || maskedTextBoxitemserialno.Text == "" || textBoxpropertyowner.Text == "" || textBoxlocation.Text == "" || comboBoxreceivedby.Text == "")
                    {
                        MessageBox.Show("Please fill the required fields");
                    }
                    else
                    {
                        try
                        {
                            SqlCommand cmd1 = new SqlCommand("UPDATE Confiscated_Items SET Item_Name=('" + textBoxitemname.Text + "'), Item_Serial_No=('" + maskedTextBoxitemserialno.Text + "'), Confiscation_Date=('" + dateTimePickerconfiscationdate.Value.Date + "'), Property_Owner=('" + textBoxpropertyowner.Text + "'), Location=('" + textBoxlocation.Text + "'), Received_By=('" + comboBoxreceivedby.Text + "') where Item_No=('" + textBoxitemno.Text + "')", con);
                            cmd1.ExecuteNonQuery();
                            MessageBox.Show("Confiscated Item updated successfully");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {

                    MessageBox.Show("Item# not matched");
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
            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Confiscated_Items WHERE Item_No = '" + textBoxitemno.Text + "'", con);
            try
            {
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {


                    try
                    {

                        SqlCommand cmd1 = new SqlCommand("DELETE FROM Confiscated_Items WHERE Item_No=('" + textBoxitemno.Text + "')", con);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Confiscated Item Deleted");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                    MessageBox.Show("Item# not matched");
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

        private void textBoxs_r_itemno_TextChanged(object sender, EventArgs e)
        {
            if (textBoxs_r_itemno.Text == "")
            {
                textBoxs_r_itemname.Text = "";
                textBoxs_r_itemserialno.Text = "";
                textBoxs_r_confiscationdate.Text = "";
                textBoxs_r_propertyowner.Text = "";
                textBoxs_r_location.Text = "";
                textBoxs_r_receivedby.Text = "";
            }

            string conx = connectionclass.ConnectionString;
            SqlConnection con1 = new SqlConnection(conx);
            try
            {
                con1.Open();
                string selectquery = "select * from Confiscated_Items where Item_No=('" + textBoxs_r_itemno.Text + "')";

                SqlCommand cmd = new SqlCommand(selectquery, con1);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string rn = dr.GetString(1);
                    textBoxs_r_itemname.Text = rn;
                    string rn1 = dr.GetString(2);
                    textBoxs_r_itemserialno.Text = rn1;
                    string rn2 = Convert.ToString(dr.GetDateTime(3));
                    textBoxs_r_confiscationdate.Text = rn2;
                    string rn3 = dr.GetString(4);
                    textBoxs_r_propertyowner.Text = rn3;
                    string rn4 = dr.GetString(5);
                    textBoxs_r_location.Text = rn4;
                    string rn5 = dr.GetString(6);
                    textBoxs_r_receivedby.Text = rn5;
              
 
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
        }

        private void textBoxitemno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Item# cannot contain letters in it");
            }
        }

        private void textBoxitemname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
                MessageBox.Show("It cannot contain numbers in it");
            }
        }

        private void maskedTextBoxitemserialno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Item Serial# cannot contain letters in it");
            }
        }

        private void textBoxpropertyowner_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
                MessageBox.Show("It cannot contain numbers in it");
            }
        }

        private void textBoxlocation_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void comboBoxreceivedby_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
                MessageBox.Show("It cannot contain numbers in it");
            }
        }

        private void textBoxs_r_itemno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Item# cannot contain letters in it");
            }
        }

        private void textBoxitemno_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxitemname_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserControlconfiscateditems_Load(object sender, EventArgs e)
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
                    comboBoxreceivedby.Items.Add(rn);

                }
                dr.Close();


                string selectquery1 = "select * from Confiscated_Items";

                SqlCommand cmd1 = new SqlCommand(selectquery1, con);

                SqlDataReader dr1 = cmd1.ExecuteReader();

                while (dr1.Read())
                {

                    int rn2 = dr1.GetInt32(0);
                    int h = rn2 + 1;
                    textBoxitemno.Text = h.ToString();

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
    }
}
