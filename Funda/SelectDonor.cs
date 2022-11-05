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
    public partial class SelectDonor : Form
    {
        string connectionString = @"Data Source=DESKTOP-276FMBL;Initial Catalog=#fundMe;Integrated Security=True";
        bool donSelected;

        public SelectDonor()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        string Cell = "", Email = "";

        public void setCell(string cell)
        {
            Cell = cell;
        }

        public void setEmail(string email) {
            Email = email;
        }

        private void DBShow_Load(object sender, EventArgs e)
        {
            //
        }

        private void dgvOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int donIndex = -1;
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                donIndex = dgv.CurrentRow.Index;
            }
            donIndex = getDonorID(donIndex);
            CreateDonation cd = new CreateDonation();
            cd.setApplicationID(donIndex);
            donSelected = true;
            Program.DonIndex = donIndex;
        }

        private int getDonorID(int donIndex)
        {
            CreateDonation cd = new CreateDonation();
            int donID = -1;
            if (donIndex != -1)
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    string sql = "";
                    if (Cell != "" || Email != "")
                    {
                        if (Email != "")
                        {
                            sql = "Select donor_ID, donor_firstName, donor_lastName, donor_orgType, donor_fundBalance from Donor where donor_fundBalance>0 AND admin_ID = " + 1 + " AND donor_email = '" + Email + "'";
                        }
                        else
                        {
                            sql = "Select donor_ID, donor_firstName, donor_lastName, donor_orgType, donor_fundBalance from Donor where donor_fundBalance>0 AND admin_ID = " + 1 + " AND donor_phone = '" + Cell + "'";
                        }
                        
                    }
                    else
                    {
                        sql = "Select donor_ID, donor_firstName, donor_lastName, donor_orgType, donor_fundBalance from Donor where donor_fundBalance>0 AND admin_ID = " + 1 + " AND donor_phone = '" + Cell + "' AND donor_email = '" + Email + "'";
                    }
                    SqlDataAdapter sqlDa = new SqlDataAdapter(sql, sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    Object o = dtbl.Rows[donIndex]["donor_ID"];
                    donID = Convert.ToInt32(Convert.ToString(o).Trim());
                }
            }
            return donID;
        }

        private void SelectDonor_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                //Filters differently based on user input
                string sql = "";
                if (Cell != "" || Email != "")
                {
                    if (Email != "")
                    {
                        sql = "Select donor_firstName AS [First Name], donor_lastName AS [Last Name], donor_orgType AS [Organisation Type], donor_fundBalance [Available Funds] from Donor where donor_fundBalance>0 AND admin_ID = " + 1 + " AND donor_email = '" + Email + "'";
                    }
                    else
                    {
                        sql = "Select donor_firstName AS [First Name], donor_lastName AS [Last Name], donor_orgType AS [Organisation Type], donor_fundBalance [Available Funds] from Donor where donor_fundBalance>0 AND admin_ID = " + 1 + " AND donor_phone = '" + Cell + "'";
                    }

                }
                else
                {
                    sql = "Select donor_firstName AS [First Name], donor_lastName AS [Last Name], donor_orgType AS [Organisation Type], donor_fundBalance [Available Funds] from Donor where donor_fundBalance>0 AND admin_ID = " + 1 + " AND donor_phone = '" + Cell + "' AND donor_email = '" + Email + "'";
                }
                //
                SqlDataAdapter sda = new SqlDataAdapter(sql, sqlCon);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Donor");
                dgvOut.DataSource = ds;
                dgvOut.DataMember = "Donor";
                sqlCon.Close();
                donSelected = false;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (donSelected)
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select an application to proceed");
            }
        }
    }
}
