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
    public partial class UpdateDonor : Form
    {
        string donorfName;
        public UpdateDonor()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        dsFunda dsApp = new dsFunda();
        dsFundaTableAdapters.DonorTableAdapter ta = new Funda.dsFundaTableAdapters.DonorTableAdapter();
        dsFunda.DonorRow DonorRow;

        public void setDonorFName(string donFname)
        {
            donorfName = donFname;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool vldInput = true;
            vldInput = validateInput(vldInput);

            if (vldInput)
            {
                //Update
                DonorRow.donor_firstName= tbxFirstName.Text;
                DonorRow.donor_lastName = tbxLastName.Text;
                if (radOrg.Checked == true)
                {
                    DonorRow.donor_orgType = "Organisation";
                }
                else
                {
                    DonorRow.donor_orgType = "Individual";
                }
                DonorRow.donor_maxAmount = Convert.ToDecimal(tbMaxAmount.Text);
                DonorRow.donor_organisation = mtxOrgName.Text;
                DonorRow.donor_addressLine1 = tbxAddress1.Text;
                DonorRow.donor_addressLine2 = tbxAddress2.Text;
                DonorRow.donor_postalCode = tbxPostCode.Text;
                DonorRow.donor_city = tbxCity.Text;
                //Confirmation
                MessageBox.Show("Donor data succesfully created!");
            }
            CreateDonor NewForm = new CreateDonor();
            NewForm.Show();
            this.Dispose(false);
        }

        private void ViewDonor() {
            tbxFirstName.Text = DonorRow.donor_firstName.Trim();
            tbxLastName.Text = DonorRow.donor_lastName.Trim();
            if (DonorRow.donor_orgType.Trim() == "Organisation")
            {
                radOrg.Checked = true;
            }
            else
            {
                radIndi.Checked = true;
            }
            tbMaxAmount.Text = DonorRow.donor_maxAmount.ToString();
            mtxOrgName.Text = DonorRow.donor_organisation.Trim();
            tbxAddress1.Text = DonorRow.donor_addressLine1.Trim();
            tbxAddress2.Text = DonorRow.donor_addressLine2.Trim();
            tbxPostCode.Text = DonorRow.donor_postalCode.Trim();
            tbxCity.Text = DonorRow.donor_city.Trim();
        }

        private bool validateInput(bool vldInput)
        {
            //checks that fields aren't empty
            if (tbxFirstName.Text == "" || tbxLastName.Text == "" || tbMaxAmount.Text == ""
                || tbxPhoneNo.Text == "" || tbxEmail.Text == "" || tbxAddress1.Text == "" || tbxPostCode.Text == ""
                || tbxCity.Text == "" || (radIndi.Checked == false && radOrg.Checked == false))
            {
                vldInput = false;
                MessageBox.Show("Please fill in mandatory fields", "Error");
            }
            //validate cell length
            if (tbxPhoneNo.Text.Length != 10)
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
            if (Convert.ToDouble(tbMaxAmount.Text) < 100)
            {
                MessageBox.Show("Please enter a donation amount more than R100", "Error");
                vldInput = false;
            }
            //validates org name if organisation chosen
            if (radOrg.Checked == true && mtxOrgName.Text == "")
            {
                MessageBox.Show("Please enter a valid organisation name", "Error");
                vldInput = false;
            }

            return vldInput;
        }

        private void tbxPhoneNo_TextChanged(object sender, EventArgs e)
        {
            //SelectDonor a = new SelectDonor;
            //ta.Fill(dsApp.Donor);
            //DonorRow = dsApp.Donor.FindBydonor_email()
            //ViewDonor();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminLandingPage ap = new AdminLandingPage();
            ap.Show();
            this.Hide();
        }

        private void tbxFirstName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void tbxFirstName_TextChanged(object sender, EventArgs e)
        {
            if (tbxFirstName.Text != "")
            {
                SelectDonor a = new SelectDonor();
                ta.Fill(dsApp.Donor);
                DonorRow = dsApp.Donor.FindBydonor_ID(Program.DonIndex);
                ViewDonor();
            }
        }
    }
}
