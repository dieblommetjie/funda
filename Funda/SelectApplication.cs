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
    public partial class SelectApplication : Form
    {
        string ApplID, connectionString = @"Data Source=DESKTOP-276FMBL;Initial Catalog=#fundMe;Integrated Security=True";
        bool appSelected;

        public void setID(string id) {
            ApplID = id;
        }

        public SelectApplication()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        string Cell = "", Email = "";

        public void setCell(string cell)
        {
            Cell = cell;
        }

        public void setEmail(string email)
        {
            Email = email;
        }

        private void DBShow_Load(object sender, EventArgs e)
        {
            //
        }

        private void dgvOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ApplIndex = -1;
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                ApplIndex = dgv.CurrentRow.Index;
            }
            ApplIndex = getApplicationID(ApplIndex);
            CreateDonation cd = new CreateDonation();
            cd.setApplicationID(ApplIndex);
            appSelected = true;
            Program.ApplIndex = ApplIndex;
        }

        private int getApplicationID(int applIndex) {
            CreateDonation cd = new CreateDonation();
            int appID = -1;
            if (applIndex != -1) {
                using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select application_ID, application_fundType, application_status from Application where application_status != 'Funded' AND applicant_IDno ='" + ApplID + "'", sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    Object o = dtbl.Rows[applIndex]["application_ID"];
                    appID = Convert.ToInt32(Convert.ToString(o).Trim());
                }
            }
            return appID;
        }

        private void SelectApplication_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select application_requiredAmount-application_fundedAmount AS [Funding required], application_fundType AS [Funding Type], application_status AS [Application Status], application_date AS [Application Date] from Application where application_status != 'Funded' AND applicant_IDno ='" + ApplID + "'", sqlCon);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Application");
                dgvOut.DataSource = ds;
                dgvOut.DataMember = "Application";
            }
            appSelected = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (appSelected) {
                SelectDonor sd = new SelectDonor();
                sd.setCell(Cell);
                sd.setEmail(Email);
                sd.ShowDialog();
                this.Close();
            }
            else {
                MessageBox.Show("Please select an application to proceed");
            }
        }
    }
}
