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
    public partial class ApplicantLandingPage : Form
    {
        public ApplicantLandingPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //manages permissions passing users between forms
        string User;
        public void setUser(string user)
        {
            User = user;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OpeningPage op = new OpeningPage();
            op.Show();
            this.Close();
        }

        private void btnCreateApplicatio_Click(object sender, EventArgs e)
        {
            CreateApplication ca = new CreateApplication();
            ca.Show();
            this.Close();
        }

        private void btnViewApplication_Click(object sender, EventArgs e)
        {
            ViewApplication v1 = new ViewApplication();
            v1.Show();
            this.Close();
        }

        private void btnUpdateApplication_Click(object sender, EventArgs e)
        {
            UpdateApplicant v1 = new UpdateApplicant();
            v1.Show();
            this.Close(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            LeastFunded a = new LeastFunded();
            a.Show();
            this.Hide();
        }
    }
}
