namespace Project.WinFormUI.Forms.CustomerForms
{
    partial class FairPriceOfferForm
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
            this.lblPriceOfferDetails = new System.Windows.Forms.Label();
            this.btnAcceptOffer = new System.Windows.Forms.Button();
            this.btnDeclineOffer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtCustomerOffer = new System.Windows.Forms.TextBox();
            this.lblNewOffer = new System.Windows.Forms.Label();
            this.btnSubmitNewOffer = new System.Windows.Forms.Button();
            this.btnCancelNewOffer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPriceOfferDetails
            // 
            this.lblPriceOfferDetails.BackColor = System.Drawing.Color.White;
            this.lblPriceOfferDetails.Location = new System.Drawing.Point(22, 71);
            this.lblPriceOfferDetails.Name = "lblPriceOfferDetails";
            this.lblPriceOfferDetails.Size = new System.Drawing.Size(352, 67);
            this.lblPriceOfferDetails.TabIndex = 0;
            // 
            // btnAcceptOffer
            // 
            this.btnAcceptOffer.Location = new System.Drawing.Point(298, 152);
            this.btnAcceptOffer.Name = "btnAcceptOffer";
            this.btnAcceptOffer.Size = new System.Drawing.Size(76, 23);
            this.btnAcceptOffer.TabIndex = 1;
            this.btnAcceptOffer.Text = "Onayla";
            this.btnAcceptOffer.UseVisualStyleBackColor = true;
            this.btnAcceptOffer.Click += new System.EventHandler(this.btnAcceptOffer_Click);
            // 
            // btnDeclineOffer
            // 
            this.btnDeclineOffer.Location = new System.Drawing.Point(217, 152);
            this.btnDeclineOffer.Name = "btnDeclineOffer";
            this.btnDeclineOffer.Size = new System.Drawing.Size(75, 23);
            this.btnDeclineOffer.TabIndex = 1;
            this.btnDeclineOffer.Text = "Onaylama";
            this.btnDeclineOffer.UseVisualStyleBackColor = true;
            this.btnDeclineOffer.Click += new System.EventHandler(this.btnDeclineOffer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(136, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtCustomerOffer
            // 
            this.txtCustomerOffer.Location = new System.Drawing.Point(136, 226);
            this.txtCustomerOffer.Name = "txtCustomerOffer";
            this.txtCustomerOffer.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerOffer.TabIndex = 2;
            // 
            // lblNewOffer
            // 
            this.lblNewOffer.BackColor = System.Drawing.Color.White;
            this.lblNewOffer.Location = new System.Drawing.Point(25, 266);
            this.lblNewOffer.Name = "lblNewOffer";
            this.lblNewOffer.Size = new System.Drawing.Size(349, 23);
            this.lblNewOffer.TabIndex = 3;
            // 
            // btnSubmitNewOffer
            // 
            this.btnSubmitNewOffer.Location = new System.Drawing.Point(256, 312);
            this.btnSubmitNewOffer.Name = "btnSubmitNewOffer";
            this.btnSubmitNewOffer.Size = new System.Drawing.Size(117, 23);
            this.btnSubmitNewOffer.TabIndex = 4;
            this.btnSubmitNewOffer.Text = "Fiyat Teklifini Onayla";
            this.btnSubmitNewOffer.UseVisualStyleBackColor = true;
            this.btnSubmitNewOffer.Click += new System.EventHandler(this.btnSubmitNewOffer_Click);
            // 
            // btnCancelNewOffer
            // 
            this.btnCancelNewOffer.Location = new System.Drawing.Point(162, 312);
            this.btnCancelNewOffer.Name = "btnCancelNewOffer";
            this.btnCancelNewOffer.Size = new System.Drawing.Size(88, 23);
            this.btnCancelNewOffer.TabIndex = 5;
            this.btnCancelNewOffer.Text = "Iptal Et";
            this.btnCancelNewOffer.UseVisualStyleBackColor = true;
            this.btnCancelNewOffer.Click += new System.EventHandler(this.btnCancelNewOffer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Talep Edilen Fiyat";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(21, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(148, 23);
            this.label13.TabIndex = 15;
            this.label13.Text = "FUAR OLUŞTUR";
            // 
            // FairPriceOfferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelNewOffer);
            this.Controls.Add(this.btnSubmitNewOffer);
            this.Controls.Add(this.lblNewOffer);
            this.Controls.Add(this.txtCustomerOffer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDeclineOffer);
            this.Controls.Add(this.btnAcceptOffer);
            this.Controls.Add(this.lblPriceOfferDetails);
            this.Name = "FairPriceOfferForm";
            this.Text = "FairPriceOfferForm";
            this.Load += new System.EventHandler(this.FairPriceOfferForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPriceOfferDetails;
        private System.Windows.Forms.Button btnAcceptOffer;
        private System.Windows.Forms.Button btnDeclineOffer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtCustomerOffer;
        private System.Windows.Forms.Label lblNewOffer;
        private System.Windows.Forms.Button btnSubmitNewOffer;
        private System.Windows.Forms.Button btnCancelNewOffer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
    }
}