namespace Funda
{
    partial class ViewDonation
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
            this.donor_email = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.donor_phone = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.lblAppID = new System.Windows.Forms.Label();
            this.mtxCell = new System.Windows.Forms.MaskedTextBox();
            this.mtxEmail = new System.Windows.Forms.MaskedTextBox();
            this.mtxID = new System.Windows.Forms.MaskedTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // donor_email
            // 
            this.donor_email.AutoSize = true;
            this.donor_email.Location = new System.Drawing.Point(178, 181);
            this.donor_email.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.donor_email.Name = "donor_email";
            this.donor_email.Size = new System.Drawing.Size(116, 25);
            this.donor_email.TabIndex = 26;
            this.donor_email.Text = "Donor email";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(17, 744);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(138, 42);
            this.btnBack.TabIndex = 25;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(1072, 171);
            this.btnClear.Margin = new System.Windows.Forms.Padding(6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(138, 42);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(71, 310);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1289, 395);
            this.dataGridView1.TabIndex = 23;
            // 
            // donor_phone
            // 
            this.donor_phone.AutoSize = true;
            this.donor_phone.Location = new System.Drawing.Point(178, 128);
            this.donor_phone.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.donor_phone.Name = "donor_phone";
            this.donor_phone.Size = new System.Drawing.Size(204, 25);
            this.donor_phone.TabIndex = 21;
            this.donor_phone.Text = "Donor contact number";
            this.donor_phone.Click += new System.EventHandler(this.donor_phone_Click);
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(891, 171);
            this.btnView.Margin = new System.Windows.Forms.Padding(6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(138, 42);
            this.btnView.TabIndex = 20;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblAppID
            // 
            this.lblAppID.AutoSize = true;
            this.lblAppID.Location = new System.Drawing.Point(178, 242);
            this.lblAppID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAppID.Name = "lblAppID";
            this.lblAppID.Size = new System.Drawing.Size(201, 25);
            this.lblAppID.TabIndex = 28;
            this.lblAppID.Text = "* Applicant ID number";
            // 
            // mtxCell
            // 
            this.mtxCell.Location = new System.Drawing.Point(431, 123);
            this.mtxCell.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.mtxCell.Mask = "(999) 000-0000";
            this.mtxCell.Name = "mtxCell";
            this.mtxCell.Size = new System.Drawing.Size(284, 29);
            this.mtxCell.TabIndex = 30;
            // 
            // mtxEmail
            // 
            this.mtxEmail.Location = new System.Drawing.Point(431, 177);
            this.mtxEmail.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.mtxEmail.Name = "mtxEmail";
            this.mtxEmail.Size = new System.Drawing.Size(284, 29);
            this.mtxEmail.TabIndex = 31;
            // 
            // mtxID
            // 
            this.mtxID.Location = new System.Drawing.Point(431, 237);
            this.mtxID.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.mtxID.Mask = "0000000000000";
            this.mtxID.Name = "mtxID";
            this.mtxID.Size = new System.Drawing.Size(284, 29);
            this.mtxID.TabIndex = 32;
            this.mtxID.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(519, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 39);
            this.label1.TabIndex = 33;
            this.label1.Text = "Display Donations";
            // 
            // ViewDonation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 807);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtxID);
            this.Controls.Add(this.mtxEmail);
            this.Controls.Add(this.mtxCell);
            this.Controls.Add(this.lblAppID);
            this.Controls.Add(this.donor_email);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.donor_phone);
            this.Controls.Add(this.btnView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "ViewDonation";
            this.Text = "Display donation";
            this.Load += new System.EventHandler(this.ViewDonation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label donor_email;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label donor_phone;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblAppID;
        private System.Windows.Forms.MaskedTextBox mtxCell;
        private System.Windows.Forms.MaskedTextBox mtxEmail;
        private System.Windows.Forms.MaskedTextBox mtxID;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.Label label1;
    }
}