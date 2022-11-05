namespace Funda
{
    partial class ViewDonor
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
            this.components = new System.ComponentModel.Container();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.donor_phone = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.donor_email = new System.Windows.Forms.Label();
            this.mtxDonorPhone = new System.Windows.Forms.MaskedTextBox();
            this.mtxEmail = new System.Windows.Forms.MaskedTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(21, 780);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(138, 42);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(1018, 172);
            this.btnClear.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(138, 42);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 306);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1290, 449);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // donor_phone
            // 
            this.donor_phone.AutoSize = true;
            this.donor_phone.Location = new System.Drawing.Point(142, 150);
            this.donor_phone.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.donor_phone.Name = "donor_phone";
            this.donor_phone.Size = new System.Drawing.Size(204, 25);
            this.donor_phone.TabIndex = 13;
            this.donor_phone.Text = "Donor contact number";
            this.donor_phone.Click += new System.EventHandler(this.applicant_IDno_Click);
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(839, 172);
            this.btnView.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(138, 42);
            this.btnView.TabIndex = 12;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // donor_email
            // 
            this.donor_email.AutoSize = true;
            this.donor_email.Location = new System.Drawing.Point(142, 218);
            this.donor_email.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.donor_email.Name = "donor_email";
            this.donor_email.Size = new System.Drawing.Size(116, 25);
            this.donor_email.TabIndex = 18;
            this.donor_email.Text = "Donor email";
            // 
            // mtxDonorPhone
            // 
            this.mtxDonorPhone.Location = new System.Drawing.Point(419, 146);
            this.mtxDonorPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mtxDonorPhone.Mask = "(999) 000-0000";
            this.mtxDonorPhone.Name = "mtxDonorPhone";
            this.mtxDonorPhone.Size = new System.Drawing.Size(294, 29);
            this.mtxDonorPhone.TabIndex = 20;
            // 
            // mtxEmail
            // 
            this.mtxEmail.Location = new System.Drawing.Point(419, 210);
            this.mtxEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mtxEmail.Name = "mtxEmail";
            this.mtxEmail.Size = new System.Drawing.Size(294, 29);
            this.mtxEmail.TabIndex = 21;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1331, 25);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(502, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 39);
            this.label1.TabIndex = 23;
            this.label1.Text = "Display Donors";
            // 
            // ViewDonor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 838);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mtxEmail);
            this.Controls.Add(this.mtxDonorPhone);
            this.Controls.Add(this.donor_email);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.donor_phone);
            this.Controls.Add(this.btnView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ViewDonor";
            this.Text = "Display Donor";
            this.Load += new System.EventHandler(this.ViewDonor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label donor_phone;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label donor_email;
        private System.Windows.Forms.MaskedTextBox mtxDonorPhone;
        private System.Windows.Forms.MaskedTextBox mtxEmail;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label1;
    }
}