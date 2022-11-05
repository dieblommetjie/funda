namespace Funda
{
    partial class ApplicantLandingPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicantLandingPage));
            this.btnReport = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCreateApplication = new System.Windows.Forms.Button();
            this.btnViewApplication = new System.Windows.Forms.Button();
            this.btnUpdateApplicant = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.Location = new System.Drawing.Point(168, 213);
            this.btnReport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(264, 58);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "  Funding Type Stats";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(5, 331);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(73, 30);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCreateApplication
            // 
            this.btnCreateApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateApplication.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateApplication.Image")));
            this.btnCreateApplication.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateApplication.Location = new System.Drawing.Point(168, 20);
            this.btnCreateApplication.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreateApplication.Name = "btnCreateApplication";
            this.btnCreateApplication.Size = new System.Drawing.Size(264, 60);
            this.btnCreateApplication.TabIndex = 5;
            this.btnCreateApplication.Text = "  New Application";
            this.btnCreateApplication.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateApplication.UseVisualStyleBackColor = true;
            // 
            // btnViewApplication
            // 
            this.btnViewApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewApplication.Image = ((System.Drawing.Image)(resources.GetObject("btnViewApplication.Image")));
            this.btnViewApplication.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewApplication.Location = new System.Drawing.Point(168, 85);
            this.btnViewApplication.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnViewApplication.Name = "btnViewApplication";
            this.btnViewApplication.Size = new System.Drawing.Size(264, 59);
            this.btnViewApplication.TabIndex = 6;
            this.btnViewApplication.Text = "  View Application";
            this.btnViewApplication.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewApplication.UseVisualStyleBackColor = true;
            // 
            // btnUpdateApplicant
            // 
            this.btnUpdateApplicant.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateApplicant.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateApplicant.Image")));
            this.btnUpdateApplicant.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateApplicant.Location = new System.Drawing.Point(168, 150);
            this.btnUpdateApplicant.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdateApplicant.Name = "btnUpdateApplicant";
            this.btnUpdateApplicant.Size = new System.Drawing.Size(264, 58);
            this.btnUpdateApplicant.TabIndex = 7;
            this.btnUpdateApplicant.Text = "  Edit Profile";
            this.btnUpdateApplicant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateApplicant.UseVisualStyleBackColor = true;
            this.btnUpdateApplicant.Click += new System.EventHandler(this.btnUpdateApplication_Click);
            // 
            // ApplicantLandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnUpdateApplicant);
            this.Controls.Add(this.btnViewApplication);
            this.Controls.Add(this.btnCreateApplication);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnReport);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ApplicantLandingPage";
            this.Text = "Applicant";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCreateApplication;
        private System.Windows.Forms.Button btnViewApplication;
        private System.Windows.Forms.Button btnUpdateApplicant;
    }
}