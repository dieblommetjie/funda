using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Funda
{
    public partial class OpeningPage : Form
    {
        public OpeningPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            //Change forms to the Admin landing page
            AdminLandingPage ap = new AdminLandingPage();
            ap.Show();
            this.Hide();
            //serves to help us manage permissions
            Program.User = "admin";
        }

        private void btnApplicant_Click(object sender, EventArgs e)
        {
            //Switch forms to the Applicant Landing Page
            ApplicantLandingPage ap = new ApplicantLandingPage();
            ap.Show();
            this.Hide();
            //serves to help us manage permissions
            Program.User = "appl";
        }

        private void OpeningPage_Load(object sender, EventArgs e)
        {

        }
    }
}
