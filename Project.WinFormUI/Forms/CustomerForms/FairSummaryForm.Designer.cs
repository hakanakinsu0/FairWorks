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
            this.btnConfirmSelections = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSummaryDetails = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(21, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 23);
            this.label13.TabIndex = 16;
            this.label13.Text = "FUAR ÖZETİ";
            // 
            // txtSummaryDetails
            // 
            this.txtSummaryDetails.Location = new System.Drawing.Point(25, 57);
            this.txtSummaryDetails.Multiline = true;
            this.txtSummaryDetails.Name = "txtSummaryDetails";
            this.txtSummaryDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSummaryDetails.Size = new System.Drawing.Size(360, 367);
            this.txtSummaryDetails.TabIndex = 17;
            // 
            // FairSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 450);
            this.Controls.Add(this.txtSummaryDetails);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnConfirmSelections);
            this.Name = "FairSummaryForm";
            this.Text = "FairSummaryForm";
            this.Load += new System.EventHandler(this.FairSummaryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnConfirmSelections;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSummaryDetails;
    }
}