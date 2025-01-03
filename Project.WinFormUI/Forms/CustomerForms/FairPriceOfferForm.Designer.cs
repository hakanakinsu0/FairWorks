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
            this.btnCancelNewOffer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGonder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPriceOfferDetails
            // 
            this.lblPriceOfferDetails.BackColor = System.Drawing.Color.White;
            this.lblPriceOfferDetails.Location = new System.Drawing.Point(22, 71);
            this.lblPriceOfferDetails.Name = "lblPriceOfferDetails";
            this.lblPriceOfferDetails.Size = new System.Drawing.Size(364, 67);
            this.lblPriceOfferDetails.TabIndex = 0;
            // 
            // btnAcceptOffer
            // 
            this.btnAcceptOffer.Location = new System.Drawing.Point(310, 152);
            this.btnAcceptOffer.Name = "btnAcceptOffer";
            this.btnAcceptOffer.Size = new System.Drawing.Size(76, 23);
            this.btnAcceptOffer.TabIndex = 1;
            this.btnAcceptOffer.Text = "Onayla";
            this.btnAcceptOffer.UseVisualStyleBackColor = true;
            this.btnAcceptOffer.Click += new System.EventHandler(this.btnAcceptOffer_Click);
            // 
            // btnDeclineOffer
            // 
            this.btnDeclineOffer.Location = new System.Drawing.Point(229, 152);
            this.btnDeclineOffer.Name = "btnDeclineOffer";
            this.btnDeclineOffer.Size = new System.Drawing.Size(75, 23);
            this.btnDeclineOffer.TabIndex = 1;
            this.btnDeclineOffer.Text = "Onaylama";
            this.btnDeclineOffer.UseVisualStyleBackColor = true;
            this.btnDeclineOffer.Click += new System.EventHandler(this.btnDeclineOffer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(148, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtCustomerOffer
            // 
            this.txtCustomerOffer.Location = new System.Drawing.Point(124, 226);
            this.txtCustomerOffer.Name = "txtCustomerOffer";
            this.txtCustomerOffer.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerOffer.TabIndex = 2;
            // 
            // lblNewOffer
            // 
            this.lblNewOffer.BackColor = System.Drawing.Color.White;
            this.lblNewOffer.Location = new System.Drawing.Point(25, 266);
            this.lblNewOffer.Name = "lblNewOffer";
            this.lblNewOffer.Size = new System.Drawing.Size(361, 23);
            this.lblNewOffer.TabIndex = 3;
            // 
            // btnCancelNewOffer
            // 
            this.btnCancelNewOffer.Location = new System.Drawing.Point(311, 223);
            this.btnCancelNewOffer.Name = "btnCancelNewOffer";
            this.btnCancelNewOffer.Size = new System.Drawing.Size(75, 23);
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
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Talep Edilen Fiyat :";
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
            // btnGonder
            // 
            this.btnGonder.Location = new System.Drawing.Point(230, 224);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(75, 23);
            this.btnGonder.TabIndex = 16;
            this.btnGonder.Text = "Gönder";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // FairPriceOfferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 314);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelNewOffer);
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
        private System.Windows.Forms.Button btnCancelNewOffer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnGonder;
    }
}