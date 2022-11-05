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
    public partial class UpdateApplicant : Form
    {
        //Data objects
        dsFunda dsApp = new dsFunda();
        dsFundaTableAdapters.ApplicantTableAdapter ta = new Funda.dsFundaTableAdapters.ApplicantTableAdapter();
        dsFunda.ApplicantRow ApplicantRow;

        string connectionString = @"Data Source=DESKTOP-276FMBL;Initial Catalog=#fundMe;Integrated Security=True";

        public UpdateApplicant()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //form validation
            bool blnValidInput = true;
            blnValidInput = ValidateInput(blnValidInput);

            if (blnValidInput)
            {
                //applicant validation
                bool confirmation = true;
                confirmation = blnVerifyExistence(mtxID.Text);

                if (confirmation)
                {
                    //Update
                    ApplicantRow.applicant_firstName  = mtxfName.Text;
                    ApplicantRow.applicant_lastName = mtxlName.Text;
                    if (cbStatus.Checked)
                    {
                        ApplicantRow.applicant_status = "Green";
                    }
                    ApplicantRow.applicant_cell = mtxCell.Text;
                    ApplicantRow.applicant_email = mtxEmail.Text;
                    ApplicantRow.applicant_addressLine1 = mtxAddress1.Text;
                    ApplicantRow.applicant_addressLine2 = mtxAddress2.Text;
                    ApplicantRow.applicant_postalCode = mtxPostalCode.Text;
                    ApplicantRow.applicant_university = cbUni.Text;
                    ApplicantRow.applicant_degree = mtxDegree.Text;
                    ApplicantRow.applicant_studentNo = mtxStudentNo.Text;
                    ta.Update(dsApp.Applicant);

                    MessageBox.Show("Update Successful"); //confirmation message

                    //new clear form
                    UpdateApplicant NewForm = new UpdateApplicant();
                    NewForm.Show();
                    this.Dispose(false);
                }
            }
        }

        private void UpdateApplicant_Load(object sender, EventArgs e)
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
            toolTip12.SetToolTip(cbStatus, "Has the applicants documents been received in order to change their status so applications can be made?");
        }

        private void ViewApplicant() {
            mtxfName.Text = ApplicantRow.applicant_firstName.Trim();
            mtxlName.Text = ApplicantRow.applicant_lastName.Trim();
            if (ApplicantRow.applicant_status.Trim() == "Red")
            {
                cbStatus.Checked = false;
            }
            else
            {
                cbStatus.Checked = true;
                cbStatus.Enabled = false;
            }
            mtxCell.Text = ApplicantRow.applicant_cell.Trim();
            mtxEmail.Text = ApplicantRow.applicant_email.Trim();
            mtxAddress1.Text = ApplicantRow.applicant_addressLine1.Trim();
            mtxAddress2.Text = ApplicantRow.applicant_addressLine2.Trim();
            mtxPostalCode.Text = ApplicantRow.applicant_postalCode.Trim();
            for (int i = 0; i < cbUni.Items.Count; i++) {
                //cbUni.Items
                if (ApplicantRow.applicant_university.Trim() == cbUni.Items[i].ToString()) {
                    cbUni.DropDownStyle = ComboBoxStyle.DropDown;
                    cbUni.SelectedValue = i;
                    //cbUni.DropDownStyle = ComboBoxStyle.DropDownList;
                    MessageBox.Show(cbUni.Items[i].ToString());
                }

            }
            tbCity.Text = ApplicantRow.applicant_city;
            cbUni.Text = ApplicantRow.applicant_university;
            mtxDegree.Text = ApplicantRow.applicant_degree;
            mtxStudentNo.Text = ApplicantRow.applicant_studentNo;
        }

        private bool ValidateInput(bool blnValidInput)
        {
            //address line 2 not included because not compulsory
            if (mtxID.Text == "" || mtxfName.Text == "" || mtxlName.Text == "" || mtxCell.Text == ""
                || mtxEmail.Text == "" || mtxAddress1.Text == "" || mtxPostalCode.Text == "" || cbUni.Text == ""
                || mtxDegree.Text == "" || mtxStudentNo.Text == "" || tbCity.Text == "")
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
            //validate cell length, something in this fromat: (071) 555-6789, would be 14 characters, not 10; but there are 10 numbers
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
            if (mtxEmail.Text.Contains("@") == false && mtxEmail.Text != "")
            {
                MessageBox.Show("Please enter a valid email address", "Error");
                blnValidInput = false;
            }
            
            return blnValidInput;
        }

        private bool blnVerifyExistence(string applicant_ID)
        {
            bool exist = true;

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                //Search APPLICATION table for the applicant ID - to check if it exists
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Applicant where applicant_IDno ='" + mtxID.Text + "'", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                if (dtbl.Rows.Count == 0)
                {
                    MessageBox.Show("The applicant with ID number " + mtxID.Text + " does not exist", "Error");
                    exist = false;
                }
                sqlCon.Close();
            }

            return exist;
        }
        private void UpdateApplicant_Shown(object sender, EventArgs e)
        {

            if (Program.User != "admin")
            {
                cbStatus.Enabled = false;
            }
            else
            {
                cbStatus.Enabled = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

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

        private void mtxID_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void mtxID_TextChanged_1(object sender, EventArgs e)
        {
            if (mtxID.Text.Length == 13 && blnVerifyExistence(mtxID.Text))
            {
                ta.Fill(dsApp.Applicant);
                ApplicantRow = dsApp.Applicant.FindByapplicant_IDno(mtxID.Text);
                ViewApplicant();
            }
        }

        /*//update, depending on what was NOT left blank
                    string sql = "UPDATE Applicant SET ";
                    int count = 0;
                    if (mtxfName.Text != "")
                    {
                        sql += "applicant_firstName = '" + mtxfName.Text + "'";
                        count++;
                        if (count > 0)
                        {
                            sql += ", ";
                        }
                    }
                    if (cbStatus.Checked == true)
                    {
                        sql += "applicant_status = 'Green'";
                        count++;
                        if (count > 0)
                        {
                            sql += ", ";
                        }
                    }
                    if (mtxlName.Text != "")
                    {
                        sql += "applicant_lastName = '" + mtxlName.Text + "'";
                        count++;
                        if (count > 0)
                        {
                            sql += ", ";
                        }
                    }
                    if (mtxCell.Text != "(   )    -")
                    {
                        sql += "applicant_cell = '" + mtxCell.Text + "'";
                        count++;
                        if (count > 0)
                        {
                            sql += ", ";
                        }
                    }
                    if (mtxEmail.Text != "")
                    {
                        sql += "applicant_email = '" + mtxEmail.Text + "'";
                        count++;
                        if (count > 0)
                        {
                            sql += ", ";
                        }
                    }
                    if (mtxAddress1.Text != "")
                    {
                        sql += "applicant_addressLine1 = '" + mtxAddress1.Text + "'";
                        count++;
                        if (count > 0)
                        {
                            sql += ", ";
                        }
                    }
                    if (mtxAddress2.Text != "")
                    {
                        sql += "applicant_addressLine2 = '" + mtxAddress2.Text + "'";
                        count++;
                        if (count > 0)
                        {
                            sql += ", ";
                        }
                    }
                    if (mtxPostalCode.Text != "")
                    {
                        sql += "applicant_postalCode = '" + mtxPostalCode.Text + "'";
                        count++;
                        if (count > 0)
                        {
                            sql += ", ";
                        }
                    }
                    if (cbUni.Text != "")
                    {
                        sql += "applicant_university = '" + cbUni.Text + "'";
                        count++;
                        if (count > 0)
                        {
                            sql += ", ";
                        }
                    }
                    if (mtxDegree.Text != "")
                    {
                        sql += "applicant_Degree= '" + mtxDegree.Text + "'";
                        count++;
                        if (count > 0)
                        {
                            sql += ", ";
                        }
                    }
                    if (mtxStudentNo.Text != "")
                    {
                        sql += "applicant_studentNo = '" + mtxStudentNo.Text + "'";
                        count++;
                        if (count > 0)
                        {
                            sql += ", ";
                        }
                    }

                    //remove last ", " that was added
                    sql = sql.Remove(sql.Length - 2, 2);
                    //complete SQL statement
                    sql += " where applicant_IDNo = '" + mtxID.Text + "'";

                    //run query
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd3 = new SqlCommand(sql, sqlCon);
                        sqlCmd3.ExecuteNonQuery();
                        sqlCon.Close();
                    }*/
    }
}
