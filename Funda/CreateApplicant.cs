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
    public partial class CreateApplicant : Form
    {
        string connectionString = @"Data Source=DESKTOP-276FMBL;Initial Catalog=#fundMe;Integrated Security=True";

        public CreateApplicant()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateApplicant_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(mtxID, "13 digit identity number that is found on above the bar code on your ID book/card");
            toolTip2.SetToolTip(mtxfName, "Your first legal name as printed on your ID book/card");
            toolTip3.SetToolTip(mtxlName, "Your last legal name as printed on your ID book/card");
            toolTip4.SetToolTip(mtxCell, "The 10 digit telephone number where you can be contacted");
            toolTip5.SetToolTip(mtxEmail, "Your student or personal email address");
            toolTip6.SetToolTip(mtxAddress1, "The physical address where you currently reside");
            toolTip7.SetToolTip(mtxPostalCode, "The postal code of the physical address where you currently reside");
            toolTip8.SetToolTip(tbCity, "The city where you live");
            toolTip9.SetToolTip(cbUni, "University you have been accepted at");
            toolTip10.SetToolTip(mtxDegree, "Degree you have been selected for");
            toolTip11.SetToolTip(mtxStudentNo, "The unique number provided to you by your university");
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                bool blnValidInput = true;

                sqlCon.Open();
                //Accessing the stored procedure created in SQL Server
                SqlCommand sqlCmd = new SqlCommand("CreateApplicant3", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                //Getting data values from the form
                blnValidInput = ValidateInput(blnValidInput);
                if (blnValidInput)
                {
                    sqlCmd.Parameters.AddWithValue("@applicant_IDNo", mtxID.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@applicant_firstName", mtxfName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@applicant_lastName", mtxlName.Text.Trim());
                    //Branching logic depending on whether the person is "logged in" as an admin or an applicant
                    if (Program.User == "admin")
                    {
                        sqlCmd.Parameters.AddWithValue("@admin_ID", 1);
                    }
                    else {
                        sqlCmd.Parameters.AddWithValue("@admin_ID", DBNull.Value);
                    }
                    //
                    sqlCmd.Parameters.AddWithValue("@applicant_dob", getDate(mtxID.Text.Trim().Substring(0, 6)));
                    sqlCmd.Parameters.AddWithValue("@applicant_cell", mtxCell.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@applicant_email", mtxEmail.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@applicant_addressLine1", mtxAddress1.Text.Trim());
                    if (mtxAddress2.Text.Trim() != "")
                    {
                        sqlCmd.Parameters.AddWithValue("@applicant_addressLine2", mtxAddress2.Text.Trim());
                    }
                    else {
                        sqlCmd.Parameters.AddWithValue("@applicant_addressLine2", DBNull.Value);
                    }
                    sqlCmd.Parameters.AddWithValue("@applicant_postalCode", mtxPostalCode.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@applicant_university", cbUni.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@applicant_degree", mtxDegree.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@applicant_studentNo", mtxStudentNo.Text.Trim());
                    //This value is defaulted to red, that is why it is hard coded
                    sqlCmd.Parameters.AddWithValue("@applicant_status", "Red");
                    //Defaults to the current date time
                    sqlCmd.Parameters.AddWithValue("@applicant_creationDate", DateTime.Now);
                    sqlCmd.Parameters.AddWithValue("@applicant_city", tbCity.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    //Confirmation message
                    MessageBox.Show("Applicant Successfully Created", "Confirmation");
                }
                sqlCon.Close();

                CreateApplicant NewForm = new CreateApplicant();
                NewForm.Show();

                this.Dispose(false);

                ViewApplicant va = new ViewApplicant();
                va.Show();

                //va.btnView_Click(sender, e);
            }
        }

        private bool ValidateInput(bool blnValidInput) {
            //address line 2 not included because not compulsory
            if (mtxID.Text == "" || mtxfName.Text == "" || mtxlName.Text == "" || mtxCell.Text == ""
                || mtxEmail.Text == "" || mtxAddress1.Text == "" || mtxPostalCode.Text == "" || cbUni.Text == ""
                || mtxDegree.Text == "" || mtxStudentNo.Text == "" || tbCity.Text=="")
            {
                MessageBox.Show("Please fill in all fields", "Error");
                blnValidInput = false;
            }
            //validate ID length
            if (mtxID.Text.Length != 13)
            {
                MessageBox.Show("Please enter a valid ID number", "Error");
                blnValidInput = false;
            }
            //validate cell length
            if (mtxCell.Text.Length != 14)
            {
                MessageBox.Show("Please enter a valid cell number", "Error");
                blnValidInput = false;
            }
            //validate postal code length
            if (mtxPostalCode.Text.Length != 4)
            {
                MessageBox.Show("Please enter a valid postal code", "Error");
                blnValidInput = false;
            }
            //validate that email address contains @
            if (mtxEmail.Text.Contains("@") == false)
            {
                MessageBox.Show("Please enter a valid email address", "Error");
                blnValidInput = false;
            }
            
            return blnValidInput;
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

        private string getDate(string dob) {
            string year, month, day, yearNow;
            yearNow = DateTime.Now.Year.ToString().Substring(2, 2);
            year = dob.Substring(0, 2);
            if (Convert.ToInt32(yearNow) < Convert.ToInt32(year))
            {
                year = "19" + year;
            }
            else
            {
                year = "20" + year;
            }
            month = dob.Substring(2, 2);
            day = dob.Substring(4, 2);
            dob = day + "/" + month + "/" + year;
            return dob;
        }

    }
}
