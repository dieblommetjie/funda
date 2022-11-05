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
    public partial class GreenStatus : Form
    {
        string connectionString = @"Data Source=DESKTOP-276FMBL;Initial Catalog=#fundMe;Integrated Security=True";
    
        public GreenStatus()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool blnValidInput = true;
            bool blnValidID = true;
            blnValidInput = ValidateInput(blnValidInput);
            if (blnValidInput)
            {
                if (blnValidID = VerifyExistence(blnValidID))
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        string sql = "UPDATE Applicant SET applicant_status = 'Green' where applicant_IDNo = '" + mtxID.Text + "'";
                        sqlCon.Open();
                        SqlCommand sqlCmd3 = new SqlCommand(sql, sqlCon);
                        sqlCmd3.ExecuteNonQuery();
                        sqlCon.Close();
                        MessageBox.Show("Update to green status successful!", "Confirmation");
                    }
                }
            }
        }

        private bool VerifyExistence(bool exist)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                //Search APPLICANT table for the applicant ID - to check if it exists
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Applicant where applicant_IDno ='" + mtxID.Text + "'", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                Object o = dtbl.Rows[0]["applicant_status"];
                string status = Convert.ToString(o).Trim();
                if (dtbl.Rows.Count == 0)
                {
                    MessageBox.Show("The applicant with ID number " + mtxID.Text + " does not exist", "Error");
                    exist = false;
                }
                else if(status == "Green") {
                    MessageBox.Show("The applicant with ID number " + mtxID.Text + " already has green status", "Error");
                    exist = false;
                }
                sqlCon.Close();
            }

            return exist;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminLandingPage ap = new AdminLandingPage();
            ap.Show();
            this.Hide();
        }

        private bool ValidateInput(bool blnValidInput) {
            if (mtxID.Text == "") {
                blnValidInput = false;
                MessageBox.Show("Please enter an applicant ID number", "Error");
            }
            //validate cell length
            if (mtxID.Text.Length != 13)
            {
                MessageBox.Show("Please enter a valid ID number", "Error");
                blnValidInput = false;
            }
            return blnValidInput;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void GreenStatus_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(mtxID, "13 digit identity number");
           
        }
    }
}
