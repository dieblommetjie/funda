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
    public partial class ViewDonation : Form
    {
        public ViewDonation()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        string connectionString = @"Data Source=DESKTOP-276FMBL;Initial Catalog=#fundMe;Integrated Security=True";

        private void donor_phone_Click(object sender, EventArgs e)
        {

        }

        private bool ValidateInput(bool blnValidInput)
        {
            if (mtxCell.Text == "" && mtxEmail.Text == "" && mtxID.Text == "")
            {
                MessageBox.Show("Please enter valid details");
                blnValidInput = false;
            }
            /*if (mtxID.Text == "" || mtxID.Text.Length != 13)
            {
                MessageBox.Show("Please enter an applicant ID");
                blnValidInput = false;
            }
            if (mtxID.Text != "" || mtxID.Text.Contains("@") == false)
            {
                MessageBox.Show("Please enter a valid email address", "Error");
                blnValidInput = false;
            }*/
            return blnValidInput;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            bool blnValidInput = true;
            blnValidInput = ValidateInput(blnValidInput);

            if (blnValidInput)
            {

                /*
                 
                 */

                string sql = "";
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    if (mtxCell.Text == "(   )    -" || mtxEmail.Text == "") {
                        if (mtxCell.Text == "(   )    -" && mtxEmail.Text == "")
                        {
                            sql = "Select donor_ID from Donor";
                        }
                        else if (mtxCell.Text == "(   )    -")
                        {
                            sql = "Select donor_ID From Donor Where donor_email = '" + mtxEmail.Text + "'";
                        }
                        else
                        {
                            sql = "Select donor_ID From Donor Where donor_phone = '" + mtxCell.Text + "'";
                        }
                        
                    }
                   
                    else
                    {
                        sql = "Select donor_ID From Donor Where donor_email = '" + mtxEmail.Text + "' AND donor_phone = '" + mtxCell.Text + "'";
                    }

                    SqlDataAdapter sqlDaID = new SqlDataAdapter(sql, sqlCon);
                    DataTable dtblID = new DataTable();
                    sqlDaID.Fill(dtblID);
                    SqlDataAdapter sqlDa;
                    if (dtblID.Rows.Count != 0)
                    {
                        Object o = dtblID.Rows[0]["donor_ID"];
                        int donorID = Convert.ToInt32(Convert.ToString(o).Trim());
                        if (mtxID.Text == "")
                        {
                            sqlDa = new SqlDataAdapter("Select donor_firstName AS [Donor Name], applicant_firstName AS [Applicant Name], donation_amount AS [Donation Amount], donation_date AS [Date of Donation] From Donation, Applicant, Application, Donor Where Applicant.applicant_IDno = Application.applicant_IDNo AND Donor.donor_ID=Donation.donor_ID AND Donor.donor_ID = " + donorID , sqlCon);
                        }
                        else
                        {
                            sqlDa = new SqlDataAdapter("Select donor_firstName AS [Donor Name], applicant_firstName AS [Applicant Name], donation_amount AS [Donation Amount], donation_date AS [Date of Donation] From Donation, Application, Applicant, Donor Where Applicant.applicant_IDno = Application.applicant_IDNo AND Donor.donor_ID=Donation.donor_ID AND Donor.donor_ID = " + donorID + " AND Applicant.applicant_IDNo = '" +mtxID.Text+"'" , sqlCon);

                        }
                    }
                    else
                    {
                        sqlDa = new SqlDataAdapter("Select donor_firstName AS [Donor Name], applicant_firstName AS [Applicant Name], donation_amount AS [Donation Amount], donation_date AS [Date of Donation] From Donation, Application, Applicant, Donor Where Applicant.applicant_IDno = Application.applicant_IDNo AND Donor.donor_ID=Donation.donor_ID AND Applicant.applicant_IDno = '" + mtxID.Text + "'", sqlCon);
                    }


                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);

                    if (dtbl.Rows.Count == 0 || dtblID.Rows.Count == 0)
                    {
                        MessageBox.Show("Donor or applicant does not exist", "Error");
                    }
                    else
                    {
                        //Correct column lengths
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                        dataGridView1.DataSource = dtbl;
                    }
                    
                    sqlCon.Close();
                }
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ViewDonation NewForm = new ViewDonation();
            NewForm.Show();
            this.Dispose(false);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminLandingPage ap = new AdminLandingPage();
            ap.Show();
            this.Hide();
        }

        private void ViewDonation_Load(object sender, EventArgs e)
        {
            toolTip3.SetToolTip(mtxID, "13 digit identity number that is found on above the bar code on your ID book/card");
            toolTip1.SetToolTip(mtxCell, "The 10 digit telephone number where you can be contacted");
            toolTip2.SetToolTip(mtxEmail, "Your contactable email address");
        }
    }
}
