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
    public partial class CreateDonation : Form
    {
        string connectionString = @"Data Source=DESKTOP-276FMBL;Initial Catalog=#fundMe;Integrated Security=True";
        int applicationID, donorID;

        public CreateDonation()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void setApplicationID(int appID) {
            applicationID = appID;
        }

        public void setDonorID(int donID)
        {
            donorID = donID;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminLandingPage ap = new AdminLandingPage();
            ap.Show();
            this.Hide();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //Input Validation on form
            bool blnValidInput = true;
            blnValidInput = ValidateInput(blnValidInput);

            if (blnValidInput) {
                //Verify Existence Applicant
                bool confirmationApp = true;
                bool confirmationDon = true;
                confirmationApp = VerifyExistenceApplicant(confirmationApp);
                //verify existence of donor
                confirmationDon = VerifyExistenceDonor(confirmationDon);

                if (confirmationApp && confirmationDon) {
                    
                    SelectApplication sa = new SelectApplication();
                    //passing applicant filter info to application sellector
                    sa.setID(mtxID.Text);
                    //Passing the donor filter info to the applicant selector to be passed to the donor selector
                    sa.setCell(mtxCell.Text);
                    sa.setEmail(mtxEmail.Text);
                    //Showing form
                    sa.ShowDialog();
                    //validate numbers after selecting
                    bool blnValidSelection = false;
                    blnValidSelection = ValidateSelection(blnValidSelection);
                    
                    //Create the thing
                    
                        using (SqlConnection sqlCon = new SqlConnection(connectionString))
                        {
                            sqlCon.Open();
                            SqlCommand sqlCmd = new SqlCommand("CreateDonation2", sqlCon);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddWithValue("@application_ID", Program.ApplIndex);
                            sqlCmd.Parameters.AddWithValue("@donor_ID", Program.DonIndex);
                            sqlCmd.Parameters.AddWithValue("@admin_ID", 1);
                            sqlCmd.Parameters.AddWithValue("@donation_amount", tbAmount.Text);
                            sqlCmd.Parameters.AddWithValue("@donation_date", System.DateTime.Now);
                            sqlCmd.ExecuteNonQuery();

                            //Getting the Application amount
                            double balanceApp = GetApplicationBalance();
                            double appRequired = GetApplicationRequired();
                            //Update Application
                            double newAmt = balanceApp + Convert.ToDouble(tbAmount.Text);
                            SqlCommand sqlCmd2 = new SqlCommand("UPDATE Application SET application_fundedAmount = " + newAmt + "where application_ID = " + Program.ApplIndex, sqlCon);
                            sqlCmd2.ExecuteNonQuery();
                            balanceApp = GetApplicationBalance();
                            if (balanceApp < appRequired)
                            {
                                SqlCommand sqlCmd4 = new SqlCommand("UPDATE Application SET application_status = 'Partially funded' where application_ID = " + Program.ApplIndex, sqlCon);
                                sqlCmd4.ExecuteNonQuery();
                            }
                            else
                            {
                                SqlCommand sqlCmd4 = new SqlCommand("UPDATE Application SET application_status = 'Funded' where application_ID = " + Program.ApplIndex, sqlCon);
                                sqlCmd4.ExecuteNonQuery();
                            }

                            //getting donor amount 
                            double balanceDon = GetDonorBalance();
                            //Update donor
                            double newAmt2 = balanceDon - Convert.ToDouble(tbAmount.Text);
                            SqlCommand sqlCmd3 = new SqlCommand("UPDATE Donor SET donor_fundBalance = " + newAmt2 + "where donor_ID = " + Program.DonIndex, sqlCon);
                            sqlCmd3.ExecuteNonQuery();

                            MessageBox.Show("Creation of donation is successfull", "Confirmation");
                            sqlCon.Close();

                            CreateDonation NewForm = new CreateDonation();
                            NewForm.Show();
                            this.Dispose(false);
                        }
                    
                }
            }
        }

        private bool VerifyExistenceDonor(bool Donorexist)
        {using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                //Search DONOR table for the donor attributes - to check if it exists
                SqlDataAdapter sqlDa;
                if (mtxCell.Text != "(   )    -" || mtxEmail.Text != "")
                {
                    if (mtxEmail.Text == "")
                    {
                        sqlDa = new SqlDataAdapter("Select * from Donor where donor_phone ='" + mtxCell.Text + "'", sqlCon);
                    }
                    else
                    {
                        sqlDa = new SqlDataAdapter("Select * from Donor where donor_email ='" + mtxEmail.Text + "'", sqlCon);
                    }
                }
                else
                {
                    sqlDa = new SqlDataAdapter("Select * from Donor where donor_phone ='" + mtxCell + "' AND donor_email ='" +mtxEmail+"'", sqlCon);
                }

                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                if (dtbl.Rows.Count == 0)
                {
                    MessageBox.Show("The donor does not exist", "Error");
                    Donorexist = false;
                }
                sqlCon.Close();
            }

            return Donorexist;
        }
        private bool ValidateInput(bool blnValidInput) {
        
            

            if (mtxCell.Text == "" && mtxEmail.Text == "") {
                MessageBox.Show("Please enter a donor email adress and/or a donor phone number", "Error");
                blnValidInput = false;
            }
            if (Convert.ToDouble(tbAmount.Text) < 100 || tbAmount.Text == "")
            {
                MessageBox.Show("Please enter a valid donation amount", "Error");
                blnValidInput = false;
            }
            //validate that email address contains @
            if (mtxEmail.Text.Contains("@") == false && mtxEmail.Text != "")
            {
                MessageBox.Show("Please enter a valid email address", "Error");
                blnValidInput = false;
            }
            //validate ID length
            if (mtxID.Text.Length != 13 || mtxID.Text == "")
            {
                MessageBox.Show("Please enter a valid ID number", "Error");
                blnValidInput = false;
            }


            return blnValidInput;
        }

        private double GetApplicationBalance()
        {
            double balance = 0;

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Application", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                Object o = dtbl.Rows[Program.ApplIndex-1]["application_fundedAmount"];
                balance = Convert.ToDouble(Convert.ToString(o).Trim());
                sqlCon.Close();
            }
            return balance;
        }

        private double GetApplicationRequired()
        {
            double balance = 0;

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Application", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                Object o = dtbl.Rows[Program.ApplIndex - 1]["application_requiredAmount"];
                balance = Convert.ToDouble(Convert.ToString(o).Trim());
                sqlCon.Close();
            }
            return balance;
        }

        private bool ValidateSelection(bool blnValidSelection)
        {
            double balanceDonor = GetDonorBalance();
            double balanceApplication = GetApplicationRequired() - GetApplicationBalance();
            double DonationAmt = Convert.ToDouble(tbAmount.Text);

            if (DonationAmt > balanceDonor)
            {
                MessageBox.Show("The donor does not have sufficient funds to make a donation of" + DonationAmt.ToString("C2"), "Error");
                blnValidSelection = false;
            }
            else if (DonationAmt > balanceApplication)
            {
                MessageBox.Show("The donation is greater than the application funds needed. Donate" + balanceApplication + " instead?", "Error");
                blnValidSelection = false;
                tbAmount.Text = balanceApplication.ToString();
            }

            return blnValidSelection;
        }

        private double GetDonorBalance()
        {
            double balance = 0;

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa2 = new SqlDataAdapter("Select * from Donor", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa2.Fill(dtbl);
                Object o = dtbl.Rows[Program.DonIndex-1]["donor_fundBalance"];
                balance = Convert.ToDouble(Convert.ToString(o).Trim());
                sqlCon.Close();
            }
            return balance;
        }

        private void CreateDonation_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(mtxID, "13 digit identity number that is found on above the bar code on your ID book/card");
            toolTip2.SetToolTip(mtxCell, "The 10 digit telephone number where you can be contacted");
            toolTip3.SetToolTip(mtxEmail, "Your contact email address");
            toolTip4.SetToolTip(tbAmount, "The amount that will be donated towards a single application. Minimum R100");
        }

        private bool VerifyExistenceApplicant(bool AppExist) {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                //Search APPLICATION table for the applicant ID - to check if it exists
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Application where applicant_IDno ='" + mtxID.Text + "'", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                if (dtbl.Rows.Count == 0)
                {
                    MessageBox.Show("The applicant with ID number " + mtxID.Text + " does not exist", "Error");
                    AppExist = false;
                }
                sqlCon.Close();
            }
            return AppExist;
        }
    }
}
