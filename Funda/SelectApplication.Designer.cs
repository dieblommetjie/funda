namespace Funda
{
    partial class SelectApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectApplication));
            this.dgvOut = new System.Windows.Forms.DataGridView();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOut
            // 
            this.dgvOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOut.Location = new System.Drawing.Point(95, 60);
            this.dgvOut.Name = "dgvOut";
            this.dgvOut.RowHeadersWidth = 62;
            this.dgvOut.RowTemplate.Height = 24;
            this.dgvOut.Size = new System.Drawing.Size(647, 311);
            this.dgvOut.TabIndex = 0;
            this.dgvOut.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOut_CellClick);
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(287, 24);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(239, 17);
            this.lblInstruction.TabIndex = 1;
            this.lblInstruction.Text = "Select one of the Applications below:";
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.Location = new System.Drawing.Point(338, 392);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(156, 46);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "  Select";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // SelectApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.dgvOut);
            this.Name = "SelectApplication";
            this.Text = "Select Application";
            this.Load += new System.EventHandler(this.SelectApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOut;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Button btnSelect;
    }
}