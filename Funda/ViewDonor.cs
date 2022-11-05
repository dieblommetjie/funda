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
    public partial class ViewDonor : Form
    {
        public ViewDonor()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        string connectionString = @"Data Source=DESKTOP-276FMBL;Initial Catalog=#fundMe;Integrated Security=True"; 

        //manages permissions passing users between forms
        //string User;
        

        private void applicant_IDno_Click(object sender, EventArgs e)
        {

        }

        private void ViewDonor_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(mtxDonorPhone, "The 10 digit telephone number where you can be contacted");
            toolTip2.SetToolTip(mtxEmail, "Your student or personal email address");
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if ((mtxEmail.Text == "" && mtxDonorPhone.Text == ""))
            {
                MessageBox.Show("Please enter valid search criteria", "Error");
            }
            else
            {
                if (mtxEmail.Text != "" && mtxEmail.Text.Contains("@") == false)
                {
                    MessageBox.Show("Please enter a valid email address", "Error");
                }
                else
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string phone = mtxDonorPhone.Text;
                        string email = mtxEmail.Text;
                        SqlDataAdapter sqlDa;

                        if (mtxDonorPhone.Text == "(   )    -" || mtxEmail.Text == "")
                        {
                            if (mtxEmail.Text == "")
                            {
                                sqlDa = new SqlDataAdapter("Select donor_firstName AS [First Name], donor_lastName AS [Last Name], TRIM(donor_orgType) AS [Organisation Type], TRIM(donor_organisation) AS [Orgranisation] donor_maxAmount AS [Donation Limit], donor_fundBalance AS [Amount Donated], donor_city AS [City] From Donor Where donor_phone = '" + mtxDonorPhone.Text + "' order by donor_firstName ", sqlCon);
                            }
                            else
                            {
                                sqlDa = new SqlDataAdapter("Select donor_firstName AS [First Name], donor_lastName AS [Last Name], TRIM(donor_orgType) AS [Organisation Type], TRIM(donor_organisation) AS [Orgranisation], donor_maxAmount AS [Donation Limit], donor_fundBalance AS [Amount Donated], donor_city AS [City] From Donor Where donor_email = '" + mtxEmail.Text + "' order by donor_firstName ", sqlCon);
                            }
                        }
                        else
                        {
                            sqlDa = new SqlDataAdapter("Select donor_firstName AS [First Name], donor_lastName AS [Last Name], TRIM(donor_orgType) AS [Organisation Type], TRIM(donor_orgranisation) AS [Orgranisation], donor_maxAmount AS [Donation Limit], donor_fundBalance AS [Amount Donated], donor_city AS [City] From Donor Where donor_phone = '" + mtxDonorPhone.Text + "' AND donor_email = '" + mtxEmail.Text + "' order by donor_firstName ", sqlCon);
                        }

                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);

                        if (dtbl.Rows.Count == 0)
                        {
                            MessageBox.Show("Donor does not exist", "Error");
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ViewDonor NewForm = new ViewDonor();
            NewForm.Show();
            this.Dispose(false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminLandingPage ap = new AdminLandingPage();
            ap.Show();
            this.Hide();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
