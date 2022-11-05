using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Funda
{
    public partial class ViewApplicant : Form
    {
        string connectionString = @"Data Source=DESKTOP-276FMBL;Initial Catalog=#fundMe;Integrated Security=True";

        public ViewApplicant()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void btnView_Click(object sender, EventArgs e)
        {
            bool blnValidInput = true;
            bool blnValidApplicant = true;
            blnValidInput = ValidateInput(blnValidInput);

            if (blnValidInput)
            {
                //blnValidApplicant = VerifyExistenceApplicant(blnValidApplicant);
                if (blnValidApplicant)
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string applicant = mtxID.Text;

                        string sql = "SELECT applicant_IDno AS [ID number], TRIM(applicant_firstName) + ' ' + TRIM(applicant_lastName) AS [Name], applicant_cell AS [Cell Number], TRIM(applicant_degree) AS [Degree], TRIM(applicant_addressLine1) + ', ' +  TRIM(applicant_addressLine2) AS [Address], TRIM(applicant_email) AS [Email], TRIM(applicant_university) AS [University], TRIM(applicant_studentNo) AS [Student Number], TRIM(applicant_status) AS [Status]";
                        if (mtxID.Text != "" || tbEmail.Text != "")
                        {
                            if (mtxID.Text != "")
                            {
                                sql += " from Applicant where applicant_IDno ='" + mtxID.Text + "'";
                            }
                            else if (tbEmail.Text != "")
                            {
                                sql += " from Applicant where applicant_email ='" + tbEmail.Text + "'";
                            }
                            else
                            {
                                sql += " from Applicant where applicant_IDno ='" + mtxID.Text + "' AND applicant_email ='" + tbEmail.Text + "'";
                            }
                        }
                        else if (mtxID.Text != "" || tbFName.Text != "")
                        {
                            if (mtxID.Text != "")
                            {
                                sql += " from Applicant where applicant_IDno ='" + mtxID.Text + "'";
                            }
                            else if (tbFName.Text != "")
                            {
                                sql += " from Applicant where applicant_firstName ='" + tbFName.Text + "'";
                            }
                            else
                            {
                                sql += " from Applicant where applicant_IDno ='" + mtxID.Text + "' AND applicant_firstName ='" + tbFName.Text + "'";
                            }
                        }
                        else if (tbFName.Text != "" || tbEmail.Text != "")
                        {
                            if (tbEmail.Text != "")
                            {
                                sql += " from Applicant where applicant_email ='" + tbEmail.Text + "'";
                            }
                            else if (tbFName.Text != "")
                            {
                                sql += " from Applicant where applicant_firstName ='" + tbFName.Text + "'";
                            }
                            else
                            {
                                sql += " from Applicant where applicant_email ='" + tbEmail.Text + "' AND applicant_firstName ='" + tbFName.Text + "'";
                            }
                        }
                        else
                        {
                            sql += " from Applicant where applicant_IDno ='" + mtxID.Text + "' AND applicant_email ='" + tbEmail.Text + "' AND applicant_firstName ='" + tbFName.Text + "'";
                        }

                        SqlDataAdapter sqlDa = new SqlDataAdapter(sql, sqlCon);
                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);

                        if (dtbl.Rows.Count == 0)
                        {
                            MessageBox.Show("Applicant does not exist", "Error");
                        }
                        else
                        {
                            //Correct column lengths
                            dataGridView1.AutoResizeColumns();
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                            dataGridView1.DataSource = dtbl;
                        }
                    }
                }
               
            }
            
        }

        private bool ValidateInput(bool blnValidInput)
        {
            if ((mtxID.Text == "" || mtxID.Text.Length != 13) && tbFName.Text == "" && (tbEmail.Text == "" || tbEmail.Text.Contains("@") == false))
            {
                MessageBox.Show("Please enter a valid search criteria", "Error");
                blnValidInput = false;
            }
            
            return blnValidInput;
        }

        private bool VerifyExistenceApplicant(bool AppExist)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa;
                string sql;
                if (mtxID.Text != "" || tbEmail.Text != "")
                {
                    if (mtxID.Text != "")
                    {
                        sql = "Select * from Applicant where applicant_IDno ='" + mtxID.Text + "'";
                    }
                    else if (tbEmail.Text != "") {
                        sql = "Select * from Applicant where applicant_email ='" + tbEmail.Text + "'";
                    }
                    else
                    {
                        sql = "Select * from Applicant where applicant_IDno ='" + mtxID.Text + "' AND applicant_email ='" + tbEmail.Text + "'";
                    }
                }
                else if (mtxID.Text != "" || tbFName.Text != "")
                {
                    if (mtxID.Text != "")
                    {
                        sql = "Select * from Applicant where applicant_IDno ='" + mtxID.Text + "'";
                    }
                    else if (tbFName.Text != "") {
                        sql = "Select * from Applicant where applicant_firstName ='" + tbFName.Text + "'";
                    }
                    else
                    {
                        sql = "Select * from Applicant where applicant_IDno ='" + mtxID.Text + "' AND applicant_firstName ='" + tbFName.Text + "'";
                    }
                }
                else if (tbFName.Text != "" || tbEmail.Text != "")
                {
                    if (tbEmail.Text != "")
                    {
                        sql = "Select * from Applicant where applicant_email ='" + tbEmail.Text + "'";
                    }
                    else if (tbFName.Text != ""){
                        sql = "Select * from Applicant where applicant_firstName ='" + tbFName.Text + "'";
                    }
                    else
                    {
                        sql = "Select * from Applicant where applicant_email ='" + tbEmail.Text + "' AND applicant_firstName ='" + tbFName.Text + "'";
                    }
                }
                else
                {
                    sql = "Select * from Applicant where applicant_IDno ='" + mtxID.Text + "' AND applicant_email ='" + tbEmail.Text + "' AND applicant_firstName ='" + tbFName.Text + "'";
                }
                sqlDa = new SqlDataAdapter(sql, sqlCon);
                //Search APPLICANT table for the applicant ID - to check if it exists

                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                if (dtbl.Rows.Count == 0)
                {
                    MessageBox.Show("The applicant does not exist", "Error");
                    AppExist = false;
                }
                sqlCon.Close();
            }
            return AppExist;
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            ViewApplicant NewForm = new ViewApplicant();
            NewForm.Show();
            this.Dispose(false);
        }

        private void ViewApplicant_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(mtxID, "13 digit identity number");
        }
    }
}
