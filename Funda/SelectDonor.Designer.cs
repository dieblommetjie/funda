namespace Funda
{
    partial class SelectDonor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDonor));
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.dgvOut = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.Location = new System.Drawing.Point(318, 392);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(170, 46);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "  Select";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(294, 26);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(209, 17);
            this.lblInstruction.TabIndex = 4;
            this.lblInstruction.Text = "Select one of the Donors below:";
            // 
            // dgvOut
            // 
            this.dgvOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOut.Location = new System.Drawing.Point(77, 61);
            this.dgvOut.Name = "dgvOut";
            this.dgvOut.RowHeadersWidth = 62;
            this.dgvOut.RowTemplate.Height = 24;
            this.dgvOut.Size = new System.Drawing.Size(647, 311);
            this.dgvOut.TabIndex = 3;
            this.dgvOut.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOut_CellClick);
            // 
            // SelectDonor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.dgvOut);
            this.Name = "SelectDonor";
            this.Text = "Select Donor";
            this.Load += new System.EventHandler(this.SelectDonor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.DataGridView dgvOut;
    }
}