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
    public partial class CreateApplication : Form
    {
        //string status;
        //string applicant;
        string connectionString = @"Data Source=DESKTOP-276FMBL;Initial Catalog=#fundMe;Integrated Security=True";

        public CreateApplication()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            //Validate form
            bool blnValidInput = true;
            blnValidInput = ValidateInput(blnValidInput);

            if (blnValidInput)
            {
                //Validate applicant exists
                bool confirmation = true;
                confirmation = VerifyExistence(confirmation);

                //Verify green status
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Applicant where applicant_IDno='" + mtxApplicantID.Text + "'", sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    Object o = dtbl.Rows[0]["applicant_status"];
                    string status = Convert.ToString(o).Trim();
                    if (dtbl.Rows.Count == 0)
                    {
                        MessageBox.Show("Applicant does not exist", "Error");
                    }
                    else if (status == "Green")
                    {
                        //Create Application

                        using (SqlConnection sqlCon2 = new SqlConnection(connectionString))
                        {
                            sqlCon2.Open();
                            SqlCommand sqlCmd = new SqlCommand("CreateApplication2", sqlCon2);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddWithValue("@applicant_IDno", mtxApplicantID.Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@admin_id", 1);
                            sqlCmd.Parameters.AddWithValue("@application_fundType", cbxFundType.Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@application_requiredAmount", Convert.ToDouble(tbAmount.Text));
                            sqlCmd.Parameters.AddWithValue("@application_date", System.DateTime.Now);
                            sqlCmd.Parameters.AddWithValue("@application_status", "Unfunded");
                            sqlCmd.Parameters.AddWithValue("@application_fundedAmount", 0);
                            sqlCmd.ExecuteNonQuery();
                            //confirmation of creation
                            MessageBox.Show("Creation of application is successfull", "Confirmation");
                        }
                        sqlCon.Close();
                    }else
                        {
                            MessageBox.Show("The application cannot be created because the applicant still has red status. Please submit your documents and try again.", "Error");
                        }
                }
                CreateApplication NewForm = new CreateApplication();
                NewForm.Show();
                this.Dispose(false);
            }
        }

        private bool ValidateInput(bool blnValidInput) {
            //check not empty
            if ((mtxApplicantID.Text == "") || (cbxFundType.Text == "") || Convert.ToDouble(tbAmount.Text)<1000 )
            {
                blnValidInput = false;
                MessageBox.Show("Please fill each field", "Error");
            }
            //validate amount
            if (Convert.ToDouble(tbAmount.Text) < 100)
            {
                blnValidInput = false;
                MessageBox.Show("Please enter a minimum amount of R100", "Error");
            }
            //validate ID length
            if (mtxApplicantID.Text.Length != 13)
            {
                MessageBox.Show("Please enter a valid ID number", "Error");
                blnValidInput = false;
            }
            return blnValidInput;
        }

        private bool VerifyExistence(bool exist)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                //Search APPLICANT table for the applicant ID - to check if it exists
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Applicant where applicant_IDno ='" + mtxApplicantID.Text + "'", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                if (dtbl.Rows.Count == 0)
                {
                    MessageBox.Show("The applicant with ID number " + mtxApplicantID.Text + " does not exist", "Error");
                    exist = false;
                }
                sqlCon.Close();
            }

            return exist;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OpeningPage op = new OpeningPage();
            if (Program.User == "admin")
            {
                AdminLandingPage ap = new AdminLandingPage();
                ap.Show();
                this.Hide();
            }
            else if (Program.User == "appl")
            {
                ApplicantLandingPage ap = new ApplicantLandingPage();
                ap.Show();
                this.Hide();
            }
        }

        private void CreateApplication_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(mtxApplicantID, "13 digit identity number that is found on above the bar code on your ID book/card");
            toolTip2.SetToolTip(cbxFundType, "The category of funding you require");
            toolTip3.SetToolTip(tbAmount, "The amount required to cover your costs in the chosen category. Minimum R100");
        }
    }
}
