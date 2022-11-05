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
using excel = Microsoft.Office.Interop.Excel;

namespace Funda
{
    public partial class DonorReport : Form
    {
        string connectionString = @"Data Source=DESKTOP-276FMBL;Initial Catalog=#fundMe;Integrated Security=True";

        DataTable dtbl = new DataTable();
        public DonorReport()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void WriteToExcel1(DataTable dt)
        {
            excel.Application XlObj = new excel.Application();
            XlObj.Visible = false;
            excel._Workbook WbObj = (excel.Workbook)(XlObj.Workbooks.Add(""));
            excel._Worksheet WsObj = (excel.Worksheet)WbObj.ActiveSheet;
            object misValue = System.Reflection.Missing.Value;
            string fileFullName = lblHeading.Text;


            try
            {
                int row = 3; int col = 1;
                WsObj.Cells[1, 1] = lblHeading.Text;
                WsObj.Cells[1, 1].Style.Font.Bold = true;
                WsObj.Cells[1, 1].Style.Font.Size = "36";
                WsObj.Cells[1, 1].Interior.Color = Color.CadetBlue;
                WsObj.Cells[1, 1].Font.Color = Color.White;
                WsObj.Cells[2, 1] = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " to " + dateTimePicker2.Value.ToString("yyyy-MM-dd");
                WsObj.Cells[2, 1].Style.Font.Bold = true;
                WsObj.Cells[2, 1].Style.Font.Size = "20";

                foreach (DataColumn column in dt.Columns)
                {
                    //adding columns
                    WsObj.Cells[row, col] = column.ColumnName;
                    WsObj.Cells[row, col].Interior.Color = Color.LightGray;
                    WsObj.Cells[row, col].Style.Font.Bold = true;
                    WsObj.Cells[row, col].Style.Font.Size = "20";
                    col++;
                }
                //reset column and row variables
                col = 1;
                row++;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //adding data
                    foreach (var cell in dt.Rows[i].ItemArray)
                    {
                        WsObj.Cells[row, col] = cell;
                        WsObj.Cells[row, col].Style.Font.Size = "14";
                        col++;
                    }
                    col = 1;
                    row++;
                }
                WsObj.Rows.AutoFit();
                WsObj.Columns.AutoFit();
                WbObj.SaveAs(fileFullName, excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                WbObj.Close(true, misValue, misValue);
            }
        }
        private void AdminReport_Load(object sender, EventArgs e)
        {
            

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string sql = "SELECT donor_firstName AS [First Name], donor_lastName AS [Last Name], donor_orgType AS[Organisation Type], donor_email AS[Email], donor_phone AS[Phone number], donor_fundBalance AS[Fund Balance] FROM Donor WHERE donor_fundBalance< 0.2 * donor_maxAmount";
                SqlDataAdapter sqlDa = new SqlDataAdapter(sql, sqlCon);
                sqlDa.Fill(dtbl);

                //Correct column lengths
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dataGridView1.DataSource = dtbl;
                sqlCon.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminLandingPage ap = new AdminLandingPage();
            ap.Show();
            this.Hide();
        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void lblHeading_Click(object sender, EventArgs e)
        {

        }

        private void Export_Click(object sender, EventArgs e)
        {
            WriteToExcel1(dtbl);
        }
    }
}
