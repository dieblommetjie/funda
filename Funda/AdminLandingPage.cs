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
    public partial class AdminLandingPage : Form
    {
        public AdminLandingPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //manages permissions passing users between forms
        string User;
        public void setUser(string user) {
            User = user;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OpeningPage op = new OpeningPage();
            op.Show();
            this.Close();
        }

        private void btnCreateDonor_Click(object sender, EventArgs e)
        {
            CreateDonor cd = new CreateDonor();
            cd.Show();
            this.Close();
        }

        private void btnCreateApplicant_Click(object sender, EventArgs e)
        {
            CreateApplicant ca = new CreateApplicant();
            ca.Show();
            this.Close();
        }

        private void btnCreateApplication_Click(object sender, EventArgs e)
        {
            CreateApplication ca = new CreateApplication();
            ca.Show();
            this.Close();
        }

        private void btnCreateDonation_Click(object sender, EventArgs e)
        {
            CreateDonation cd = new CreateDonation();
            cd.Show();
            this.Close();
        }

        private void btnViewApplication_Click(object sender, EventArgs e)
        {
            ViewApplication v1 = new ViewApplication();
            v1.Show();
            this.Close();
        }

        private void btnUpdateApplicant_Click(object sender, EventArgs e)
        {
            UpdateApplicant v1 = new UpdateApplicant();
            v1.Show();
            //Program.User = "admin";
            this.Close();
            
        }

        private void btnViewDonor_Click(object sender, EventArgs e)
        {
            ViewDonor vd = new ViewDonor();
            vd.Show();
            this.Close();
        }

        private void btnUpdateDonor_Click(object sender, EventArgs e)
        {
            UpdateDonor ud = new UpdateDonor();
            ud.Show();
            this.Close();
        }

        private void btnViewDonation_Click(object sender, EventArgs e)
        {
            ViewDonation vd = new ViewDonation();
            vd.Show();
            this.Close();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            DonorReport ar = new DonorReport();
            ar.Show();
            this.Close();
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            GreenStatus gs = new GreenStatus();
            gs.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewApplicant va = new ViewApplicant();
            va.Show();
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void AdminLandingPage_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LeastFunded lf = new LeastFunded();
            lf.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RedLong lf = new RedLong();
            lf.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UnfundedApplications a = new UnfundedApplications();
            a.Show();
            this.Hide();
        }
    }
}
