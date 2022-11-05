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
    public partial class ViewApplication : Form
    {
        string connectionString = @"Data Source=DESKTOP-276FMBL;Initial Catalog=#fundMe;Integrated Security=True";
        public ViewApplication()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if ((mtxID.Text == "" || mtxID.Text.Length != 13))
            {
                MessageBox.Show("Please enter a valid appicant ID number", "Error");
            }
            else
            {
                bool blnValidApp = true;
                blnValidApp = VerifyExistenceApplicant(blnValidApp);
                if (blnValidApp)
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string applicant = mtxID.Text;

                        SqlDataAdapter sqlDa = new SqlDataAdapter("Select application_date AS [Date], application_fundType AS [Type], application_requiredAmount-application_fundedAmount AS [Outstanding Amount] From Application Where applicant_IDNo = '" + mtxID.Text + "' order by Date ", sqlCon);
                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dataGridView1.DataSource = dtbl;
                    }
                }
                
            }
        }

        private bool VerifyExistenceApplicant(bool AppExist)
        {
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            ViewApplication NewForm = new ViewApplication();
            NewForm.Show();
            this.Dispose(false);
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

        private void ViewApplication_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(mtxID, "13 digit identity number");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
