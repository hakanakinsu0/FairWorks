namespace Project.WinFormUI.Forms
{
    partial class UpdateDeleteServiceForm
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
            this.lstServices = new System.Windows.Forms.ListBox();
            this.grpProviderDetails = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProviderName = new System.Windows.Forms.TextBox();
            this.txtProviderAddress = new System.Windows.Forms.TextBox();
            this.txtProviderCity = new System.Windows.Forms.TextBox();
            this.txtProviderDistrict = new System.Windows.Forms.TextBox();
            this.txtProviderPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtProviderEmail = new System.Windows.Forms.TextBox();
            this.grpServiceDetails = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDescriptorName = new System.Windows.Forms.TextBox();
            this.txtDescriptorDescription = new System.Windows.Forms.TextBox();
            this.txtValueName = new System.Windows.Forms.TextBox();
            this.nudCost = new System.Windows.Forms.NumericUpDown();
            this.nudPreparationTime = new System.Windows.Forms.NumericUpDown();
            this.nudBufferTime = new System.Windows.Forms.NumericUpDown();
            this.btnUpdateService = new System.Windows.Forms.Button();
            this.btnDeleteService = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.grpProviderDetails.SuspendLayout();
            this.grpServiceDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreparationTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBufferTime)).BeginInit();
            this.SuspendLayout();
            // 
            // lstServices
            // 
            this.lstServices.FormattingEnabled = true;
            this.lstServices.Location = new System.Drawing.Point(12, 103);
            this.lstServices.Name = "lstServices";
            this.lstServices.Size = new System.Drawing.Size(819, 225);
            this.lstServices.TabIndex = 0;
            this.lstServices.SelectedIndexChanged += new System.EventHandler(this.lstServices_SelectedIndexChanged);
            // 
            // grpProviderDetails
            // 
            this.grpProviderDetails.Controls.Add(this.txtProviderEmail);
            this.grpProviderDetails.Controls.Add(this.txtProviderPhoneNumber);
            this.grpProviderDetails.Controls.Add(this.txtProviderDistrict);
            this.grpProviderDetails.Controls.Add(this.txtProviderCity);
            this.grpProviderDetails.Controls.Add(this.txtProviderAddress);
            this.grpProviderDetails.Controls.Add(this.txtProviderName);
            this.grpProviderDetails.Controls.Add(this.label6);
            this.grpProviderDetails.Controls.Add(this.label5);
            this.grpProviderDetails.Controls.Add(this.label4);
            this.grpProviderDetails.Controls.Add(this.label3);
            this.grpProviderDetails.Controls.Add(this.label2);
            this.grpProviderDetails.Controls.Add(this.label1);
            this.grpProviderDetails.Location = new System.Drawing.Point(12, 346);
            this.grpProviderDetails.Name = "grpProviderDetails";
            this.grpProviderDetails.Size = new System.Drawing.Size(336, 205);
            this.grpProviderDetails.TabIndex = 1;
            this.grpProviderDetails.TabStop = false;
            this.grpProviderDetails.Text = "Sağlayıcı Bilgileri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sağlayıcı Adı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Adres :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "İl :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "İlçe :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Telefon :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "E-Mail :";
            // 
            // txtProviderName
            // 
            this.txtProviderName.Location = new System.Drawing.Point(95, 33);
            this.txtProviderName.Name = "txtProviderName";
            this.txtProviderName.Size = new System.Drawing.Size(214, 20);
            this.txtProviderName.TabIndex = 1;
            // 
            // txtProviderAddress
            // 
            this.txtProviderAddress.Location = new System.Drawing.Point(95, 59);
            this.txtProviderAddress.Name = "txtProviderAddress";
            this.txtProviderAddress.Size = new System.Drawing.Size(214, 20);
            this.txtProviderAddress.TabIndex = 1;
            // 
            // txtProviderCity
            // 
            this.txtProviderCity.Location = new System.Drawing.Point(95, 85);
            this.txtProviderCity.Name = "txtProviderCity";
            this.txtProviderCity.Size = new System.Drawing.Size(214, 20);
            this.txtProviderCity.TabIndex = 1;
            // 
            // txtProviderDistrict
            // 
            this.txtProviderDistrict.Location = new System.Drawing.Point(95, 111);
            this.txtProviderDistrict.Name = "txtProviderDistrict";
            this.txtProviderDistrict.Size = new System.Drawing.Size(214, 20);
            this.txtProviderDistrict.TabIndex = 1;
            // 
            // txtProviderPhoneNumber
            // 
            this.txtProviderPhoneNumber.Location = new System.Drawing.Point(95, 137);
            this.txtProviderPhoneNumber.Name = "txtProviderPhoneNumber";
            this.txtProviderPhoneNumber.Size = new System.Drawing.Size(214, 20);
            this.txtProviderPhoneNumber.TabIndex = 1;
            // 
            // txtProviderEmail
            // 
            this.txtProviderEmail.Location = new System.Drawing.Point(95, 163);
            this.txtProviderEmail.Name = "txtProviderEmail";
            this.txtProviderEmail.Size = new System.Drawing.Size(214, 20);
            this.txtProviderEmail.TabIndex = 1;
            // 
            // grpServiceDetails
            // 
            this.grpServiceDetails.Controls.Add(this.nudBufferTime);
            this.grpServiceDetails.Controls.Add(this.nudPreparationTime);
            this.grpServiceDetails.Controls.Add(this.nudCost);
            this.grpServiceDetails.Controls.Add(this.txtValueName);
            this.grpServiceDetails.Controls.Add(this.txtDescriptorDescription);
            this.grpServiceDetails.Controls.Add(this.txtDescriptorName);
            this.grpServiceDetails.Controls.Add(this.label12);
            this.grpServiceDetails.Controls.Add(this.label11);
            this.grpServiceDetails.Controls.Add(this.label10);
            this.grpServiceDetails.Controls.Add(this.label9);
            this.grpServiceDetails.Controls.Add(this.label8);
            this.grpServiceDetails.Controls.Add(this.label7);
            this.grpServiceDetails.Location = new System.Drawing.Point(365, 346);
            this.grpServiceDetails.Name = "grpServiceDetails";
            this.grpServiceDetails.Size = new System.Drawing.Size(336, 205);
            this.grpServiceDetails.TabIndex = 2;
            this.grpServiceDetails.TabStop = false;
            this.grpServiceDetails.Text = "Hizmet Bilgileri";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Hizmet Tanımı Adı :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Hizmet Açıklaması :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Hizmet Değer Adı :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Maliyet (₺) :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Hazırlık Süresi (gün) :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Tampon Süresi (gün) :";
            // 
            // txtDescriptorName
            // 
            this.txtDescriptorName.Location = new System.Drawing.Point(140, 33);
            this.txtDescriptorName.Name = "txtDescriptorName";
            this.txtDescriptorName.Size = new System.Drawing.Size(190, 20);
            this.txtDescriptorName.TabIndex = 1;
            // 
            // txtDescriptorDescription
            // 
            this.txtDescriptorDescription.Location = new System.Drawing.Point(140, 59);
            this.txtDescriptorDescription.Name = "txtDescriptorDescription";
            this.txtDescriptorDescription.Size = new System.Drawing.Size(190, 20);
            this.txtDescriptorDescription.TabIndex = 1;
            // 
            // txtValueName
            // 
            this.txtValueName.Location = new System.Drawing.Point(140, 85);
            this.txtValueName.Name = "txtValueName";
            this.txtValueName.Size = new System.Drawing.Size(190, 20);
            this.txtValueName.TabIndex = 1;
            // 
            // nudCost
            // 
            this.nudCost.Location = new System.Drawing.Point(140, 111);
            this.nudCost.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCost.Name = "nudCost";
            this.nudCost.Size = new System.Drawing.Size(190, 20);
            this.nudCost.TabIndex = 2;
            // 
            // nudPreparationTime
            // 
            this.nudPreparationTime.Location = new System.Drawing.Point(140, 137);
            this.nudPreparationTime.Name = "nudPreparationTime";
            this.nudPreparationTime.Size = new System.Drawing.Size(190, 20);
            this.nudPreparationTime.TabIndex = 2;
            // 
            // nudBufferTime
            // 
            this.nudBufferTime.Location = new System.Drawing.Point(140, 163);
            this.nudBufferTime.Name = "nudBufferTime";
            this.nudBufferTime.Size = new System.Drawing.Size(190, 20);
            this.nudBufferTime.TabIndex = 2;
            // 
            // btnUpdateService
            // 
            this.btnUpdateService.Location = new System.Drawing.Point(726, 346);
            this.btnUpdateService.Name = "btnUpdateService";
            this.btnUpdateService.Size = new System.Drawing.Size(105, 23);
            this.btnUpdateService.TabIndex = 3;
            this.btnUpdateService.Text = "Hizmeti Güncelle";
            this.btnUpdateService.UseVisualStyleBackColor = true;
            this.btnUpdateService.Click += new System.EventHandler(this.btnUpdateService_Click);
            // 
            // btnDeleteService
            // 
            this.btnDeleteService.Location = new System.Drawing.Point(726, 375);
            this.btnDeleteService.Name = "btnDeleteService";
            this.btnDeleteService.Size = new System.Drawing.Size(105, 23);
            this.btnDeleteService.TabIndex = 3;
            this.btnDeleteService.Text = "Hizmeti Sil";
            this.btnDeleteService.UseVisualStyleBackColor = true;
            this.btnDeleteService.Click += new System.EventHandler(this.btnDeleteService_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(726, 404);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "İptal";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(231, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(388, 23);
            this.label13.TabIndex = 15;
            this.label13.Text = "EK HİZMET BİLGİLERİNİ GÜNCELLE VE SİL";
            // 
            // UpdateDeleteServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 579);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteService);
            this.Controls.Add(this.btnUpdateService);
            this.Controls.Add(this.grpServiceDetails);
            this.Controls.Add(this.grpProviderDetails);
            this.Controls.Add(this.lstServices);
            this.Name = "UpdateDeleteServiceForm";
            this.Text = "Hizmet Güncelle/Sil";
            this.grpProviderDetails.ResumeLayout(false);
            this.grpProviderDetails.PerformLayout();
            this.grpServiceDetails.ResumeLayout(false);
            this.grpServiceDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreparationTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBufferTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstServices;
        private System.Windows.Forms.GroupBox grpProviderDetails;
        private System.Windows.Forms.TextBox txtProviderEmail;
        private System.Windows.Forms.TextBox txtProviderPhoneNumber;
        private System.Windows.Forms.TextBox txtProviderDistrict;
        private System.Windows.Forms.TextBox txtProviderCity;
        private System.Windows.Forms.TextBox txtProviderAddress;
        private System.Windows.Forms.TextBox txtProviderName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpServiceDetails;
        private System.Windows.Forms.NumericUpDown nudBufferTime;
        private System.Windows.Forms.NumericUpDown nudPreparationTime;
        private System.Windows.Forms.NumericUpDown nudCost;
        private System.Windows.Forms.TextBox txtValueName;
        private System.Windows.Forms.TextBox txtDescriptorDescription;
        private System.Windows.Forms.TextBox txtDescriptorName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpdateService;
        private System.Windows.Forms.Button btnDeleteService;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label13;
    }
}