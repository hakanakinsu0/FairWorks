namespace Project.WinFormUI.Forms
{
    partial class FairSummaryForm
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
            this.lblSummaryDetails = new System.Windows.Forms.Label();
            this.btnConfirmSelections = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSummaryDetails
            // 
            this.lblSummaryDetails.BackColor = System.Drawing.Color.White;
            this.lblSummaryDetails.Location = new System.Drawing.Point(22, 57);
            this.lblSummaryDetails.Name = "lblSummaryDetails";
            this.lblSummaryDetails.Size = new System.Drawing.Size(365, 371);
            this.lblSummaryDetails.TabIndex = 0;
            // 
            // btnConfirmSelections
            // 
            this.btnConfirmSelections.Location = new System.Drawing.Point(405, 57);
            this.btnConfirmSelections.Name = "btnConfirmSelections";
            this.btnConfirmSelections.Size = new System.Drawing.Size(110, 23);
            this.btnConfirmSelections.TabIndex = 1;
            this.btnConfirmSelections.Text = "Seçimleri Onayla";
            this.btnConfirmSelections.UseVisualStyleBackColor = true;
            this.btnConfirmSelections.Click += new System.EventHandler(this.btnConfirmSelections_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.Location = new System.Drawing.Point(405, 87);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(75, 23);
            this.btnGoBack.TabIndex = 2;
            this.btnGoBack.Text = "Geri Dön";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // FairSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnConfirmSelections);
            this.Controls.Add(this.lblSummaryDetails);
            this.Name = "FairSummaryForm";
            this.Text = "FairSummaryForm";
            this.Load += new System.EventHandler(this.FairSummaryForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSummaryDetails;
        private System.Windows.Forms.Button btnConfirmSelections;
        private System.Windows.Forms.Button btnGoBack;
    }
}