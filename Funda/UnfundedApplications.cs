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
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Configuration;
using excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
//using Glimpse.AspNet.Tab;
using System.Web.UI;
//using Amazon.Runtime.Internal;

namespace Funda
{
    public partial class UnfundedApplications : Form

    {
        DataTable dtbl = new DataTable();

        string connectionString = @"Data Source=DESKTOP-276FMBL;Initial Catalog=#fundMe;Integrated Security=True";
        public UnfundedApplications()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void UnfundedApplications_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
                dateTimePicker2.Value = DateTime.Now;
                string from = dateTimePicker1.Value.ToString("yyyy-MM-dd"), to = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                string sql = "SELECT TRIM(applicant_firstName) + ' ' + TRIM(applicant_lastName) AS [Name], application_date, application_fundType AS [Fund Type], application_requiredAmount AS [Required Amount] FROM Application, Applicant WHERE Applicant.applicant_IDno = Application.applicant_IDNo AND application_status = 'unfunded' AND DATEDIFF(month, application_date, GETDATE()) >= 6 ORDER BY application_date";

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

        private void WriteToExcel1(DataTable dt)
        {
            excel.Application XlObj = new excel.Application();
            XlObj.Visible = false;
            excel._Workbook WbObj = (excel.Workbook)(XlObj.Workbooks.Add(""));
            excel._Worksheet WsObj = (excel.Worksheet)WbObj.ActiveSheet;
            object misValue = System.Reflection.Missing.Value;
            string fileFullName = label1.Text;


            try
            {
                int row = 3; int col = 1;
                WsObj.Cells[1, 1] = label1.Text;
                WsObj.Cells[1, 1].Style.Font.Bold = true;
                WsObj.Cells[1, 1].Style.Font.Size = "36";
                WsObj.Cells[1, 1].Interior.Color = Color.CadetBlue;
                WsObj.Cells[1, 1].Font.Color = Color.White;
                WsObj.Cells[2, 1] = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " to " +dateTimePicker2.Value.ToString("yyyy-MM-dd");
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
            //finally
            //{
                WbObj.Close(true, misValue, misValue);
            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            WriteToExcel1(dtbl);
        }
    }
}
        

        
  
