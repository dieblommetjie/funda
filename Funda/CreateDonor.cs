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

namespace Funda
{
    public partial class CreateDonor : Form
    {
        string connectionString = @"Data Source=DESKTOP-276FMBL;Initial Catalog=#fundMe;Integrated Security=True";

        public CreateDonor()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
            
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool vldInput = true;
            vldInput = validateInput(vldInput);
            if (vldInput)
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("CreateDonor2", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@admin_ID", 1);
                    sqlCmd.Parameters.AddWithValue("@donor_firstName", tbxFirstName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@donor_lastName", tbxLastName.Text.Trim());
                    string orgType;
                    if (radOrg.Checked)
                        orgType = radOrg.Text;
                    else
                        orgType = radIndi.Text;
                    sqlCmd.Parameters.AddWithValue("@donor_orgType", orgType);
                    sqlCmd.Parameters.AddWithValue("@donor_phone", tbxPhoneNo.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@donor_email", tbxEmail.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@donor_addressLine1", tbxAddress1.Text.Trim());
                    if (tbxAddress2.Text != "")
                    {
                        sqlCmd.Parameters.AddWithValue("@donor_addressLine2", tbxAddress2.Text.Trim());
                    }
                    else
                    {
                        sqlCmd.Parameters.AddWithValue("@donor_addressLine2", DBNull.Value);
                    }
                    sqlCmd.Parameters.AddWithValue("@donor_postalCode", tbxPostCode.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@donor_city", tbxCity.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@donor_maxAmount", Convert.ToDouble(tbMaxAmount.Text));
                    sqlCmd.Parameters.AddWithValue("@donor_fundBalance", Convert.ToDouble(tbMaxAmount.Text));
                    if (mtxOrgName.Text != "")
                    {
                        sqlCmd.Parameters.AddWithValue("@donor_organisation", mtxOrgName.Text.Trim());
                    }
                    else
                    {
                        sqlCmd.Parameters.AddWithValue("@donor_organisation", DBNull.Value);
                    }
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("New Donor succesfully created!"); ;
                }
            }
        }

        private bool validateInput(bool vldInput)
        {
            //checks that fields aren't empty
            if (tbxFirstName.Text == "" || tbxLastName.Text == "" || tbMaxAmount.Text ==""
                || tbxPhoneNo.Text == "" || tbxEmail.Text == "" || tbxAddress1.Text == "" || tbxPostCode.Text == ""
                || tbxCity.Text == "" || (radIndi.Checked == false && radOrg.Checked == false))
            {
                vldInput = false;
                MessageBox.Show("Please fill in mandatory fields", "Error");
            }
            //validate cell length, in () - format
            if (tbxPhoneNo.Text.Length != 14)
            {
                MessageBox.Show("Please enter a valid cell number", "Error");
                vldInput = false;
            }
            //checks that postCode is formatted correctly
            if (tbxPostCode.Text.Length != 4)
            {
                vldInput = false;
                MessageBox.Show("Please enter a valid post code", "Error");
            }
            //validate that email address contains @
            if (tbxEmail.Text.Contains("@") == false)
            {
                MessageBox.Show("Please enter a valid email address", "Error");
                vldInput = false;
            }
            //validate donation amount
            if (tbMaxAmount.Text != "")
            {
                if (Convert.ToDouble(tbMaxAmount.Text) < 100)
                {
                    MessageBox.Show("Please enter a donation amount more than R100", "Error");
                    vldInput = false;
                }
            }
            //validates org name if organisation chosen
            if(radOrg.Checked == true && mtxOrgName.Text == "")
            {
                MessageBox.Show("Please enter a valid organisation name", "Error");
                vldInput = false;
            }

            return vldInput;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CreateDonor NewForm = new CreateDonor();
            NewForm.Show();
            this.Dispose(false);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminLandingPage ap = new AdminLandingPage();
            ap.Show();
            this.Hide();
        }

        private void CreateDonor_Load(object sender, EventArgs e)
        {
            toolTip5.SetToolTip(gbOrgType, "Is the donor an organisation/company or an individual?");
            toolTip1.SetToolTip(tbxFirstName, "Your first legal name as printed on your ID book/card");
            toolTip2.SetToolTip(tbxLastName, "Your last legal name as printed on your ID book/card");
            toolTip3.SetToolTip(tbxPhoneNo, "The 10 digit telephone number where you can be contacted");
            toolTip4.SetToolTip(tbxEmail, "Your email address where you can be contacted");
            toolTip6.SetToolTip(tbMaxAmount, "Maximum amount that the donor is willing to donate towards applications");
            toolTip7.SetToolTip(mtxOrgName, "If an organisation, what is the registered name of the organisation?");
            toolTip10.SetToolTip(tbxCity, "The city where you live or the organisation is based");
            toolTip8.SetToolTip(tbxAddress1, "The address where the individual or organisation can be found");
            toolTip9.SetToolTip(tbxPostCode, "The 4 digit postal code for the area you are based in");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }    

        private void radIndi_CheckedChanged(object sender, EventArgs e)
        {
                if (radIndi.Checked)
                {
                    mtxOrgName.Enabled = false;
                }
                else
                {
                    mtxOrgName.Enabled = true;
                }
        }
    }
}
