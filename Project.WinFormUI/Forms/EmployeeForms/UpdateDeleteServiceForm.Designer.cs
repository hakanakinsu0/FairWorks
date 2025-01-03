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
            this.txtProviderEmail = new System.Windows.Forms.TextBox();
            this.txtProviderPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtProviderDistrict = new System.Windows.Forms.TextBox();
            this.txtProviderCity = new System.Windows.Forms.TextBox();
            this.txtProviderAddress = new System.Windows.Forms.TextBox();
            this.txtProviderName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpServiceDetails = new System.Windows.Forms.GroupBox();
            this.nudBufferTime = new System.Windows.Forms.NumericUpDown();
            this.nudPreparationTime = new System.Windows.Forms.NumericUpDown();
            this.nudCost = new System.Windows.Forms.NumericUpDown();
            this.txtValueName = new System.Windows.Forms.TextBox();
            this.txtDescriptorDescription = new System.Windows.Forms.TextBox();
            this.txtDescriptorName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUpdateService = new System.Windows.Forms.Button();
            this.btnDeleteService = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.grpProviderDetails.SuspendLayout();
            this.grpServiceDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBufferTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreparationTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).BeginInit();
            this.SuspendLayout();
            // 
            // lstServices
            // 
            this.lstServices.FormattingEnabled = true;
            this.lstServices.ItemHeight = 16;
            this.lstServices.Location = new System.Drawing.Point(16, 127);
            this.lstServices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstServices.Name = "lstServices";
            this.lstServices.Size = new System.Drawing.Size(1091, 276);
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
            this.grpProviderDetails.Location = new System.Drawing.Point(16, 426);
            this.grpProviderDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpProviderDetails.Name = "grpProviderDetails";
            this.grpProviderDetails.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpProviderDetails.Size = new System.Drawing.Size(448, 252);
            this.grpProviderDetails.TabIndex = 1;
            this.grpProviderDetails.TabStop = false;
            this.grpProviderDetails.Text = "Sağlayıcı Bilgileri";
            // 
            // txtProviderEmail
            // 
            this.txtProviderEmail.Location = new System.Drawing.Point(127, 201);
            this.txtProviderEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProviderEmail.Name = "txtProviderEmail";
            this.txtProviderEmail.Size = new System.Drawing.Size(284, 22);
            this.txtProviderEmail.TabIndex = 1;
            // 
            // txtProviderPhoneNumber
            // 
            this.txtProviderPhoneNumber.Location = new System.Drawing.Point(127, 169);
            this.txtProviderPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProviderPhoneNumber.Name = "txtProviderPhoneNumber";
            this.txtProviderPhoneNumber.Size = new System.Drawing.Size(284, 22);
            this.txtProviderPhoneNumber.TabIndex = 1;
            // 
            // txtProviderDistrict
            // 
            this.txtProviderDistrict.Location = new System.Drawing.Point(127, 137);
            this.txtProviderDistrict.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProviderDistrict.Name = "txtProviderDistrict";
            this.txtProviderDistrict.Size = new System.Drawing.Size(284, 22);
            this.txtProviderDistrict.TabIndex = 1;
            // 
            // txtProviderCity
            // 
            this.txtProviderCity.Location = new System.Drawing.Point(127, 105);
            this.txtProviderCity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProviderCity.Name = "txtProviderCity";
            this.txtProviderCity.Size = new System.Drawing.Size(284, 22);
            this.txtProviderCity.TabIndex = 1;
            // 
            // txtProviderAddress
            // 
            this.txtProviderAddress.Location = new System.Drawing.Point(127, 73);
            this.txtProviderAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProviderAddress.Name = "txtProviderAddress";
            this.txtProviderAddress.Size = new System.Drawing.Size(284, 22);
            this.txtProviderAddress.TabIndex = 1;
            // 
            // txtProviderName
            // 
            this.txtProviderName.Location = new System.Drawing.Point(127, 41);
            this.txtProviderName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProviderName.Name = "txtProviderName";
            this.txtProviderName.Size = new System.Drawing.Size(284, 22);
            this.txtProviderName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 204);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "E-Mail :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 172);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Telefon :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "İlçe :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "İl :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Adres :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sağlayıcı Adı :";
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
            this.grpServiceDetails.Location = new System.Drawing.Point(487, 426);
            this.grpServiceDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpServiceDetails.Name = "grpServiceDetails";
            this.grpServiceDetails.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpServiceDetails.Size = new System.Drawing.Size(448, 252);
            this.grpServiceDetails.TabIndex = 2;
            this.grpServiceDetails.TabStop = false;
            this.grpServiceDetails.Text = "Hizmet Bilgileri";
            // 
            // nudBufferTime
            // 
            this.nudBufferTime.Location = new System.Drawing.Point(187, 201);
            this.nudBufferTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudBufferTime.Name = "nudBufferTime";
            this.nudBufferTime.Size = new System.Drawing.Size(253, 22);
            this.nudBufferTime.TabIndex = 2;
            // 
            // nudPreparationTime
            // 
            this.nudPreparationTime.Location = new System.Drawing.Point(187, 169);
            this.nudPreparationTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudPreparationTime.Name = "nudPreparationTime";
            this.nudPreparationTime.Size = new System.Drawing.Size(253, 22);
            this.nudPreparationTime.TabIndex = 2;
            // 
            // nudCost
            // 
            this.nudCost.Location = new System.Drawing.Point(187, 137);
            this.nudCost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudCost.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCost.Name = "nudCost";
            this.nudCost.Size = new System.Drawing.Size(253, 22);
            this.nudCost.TabIndex = 2;
            // 
            // txtValueName
            // 
            this.txtValueName.Location = new System.Drawing.Point(187, 105);
            this.txtValueName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtValueName.Name = "txtValueName";
            this.txtValueName.Size = new System.Drawing.Size(252, 22);
            this.txtValueName.TabIndex = 1;
            // 
            // txtDescriptorDescription
            // 
            this.txtDescriptorDescription.Location = new System.Drawing.Point(187, 73);
            this.txtDescriptorDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescriptorDescription.Name = "txtDescriptorDescription";
            this.txtDescriptorDescription.Size = new System.Drawing.Size(252, 22);
            this.txtDescriptorDescription.TabIndex = 1;
            // 
            // txtDescriptorName
            // 
            this.txtDescriptorName.Location = new System.Drawing.Point(187, 41);
            this.txtDescriptorName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescriptorName.Name = "txtDescriptorName";
            this.txtDescriptorName.Size = new System.Drawing.Size(252, 22);
            this.txtDescriptorName.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 204);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Tampon Süresi (gün) :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 171);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Hazırlık Süresi (gün) :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 139);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Maliyet (₺) :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 108);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Hizmet Değer Adı :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 76);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Hizmet Açıklaması :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Hizmet Tanımı Adı :";
            // 
            // btnUpdateService
            // 
            this.btnUpdateService.Location = new System.Drawing.Point(968, 426);
            this.btnUpdateService.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateService.Name = "btnUpdateService";
            this.btnUpdateService.Size = new System.Drawing.Size(140, 28);
            this.btnUpdateService.TabIndex = 3;
            this.btnUpdateService.Text = "Hizmeti Güncelle";
            this.btnUpdateService.UseVisualStyleBackColor = true;
            this.btnUpdateService.Click += new System.EventHandler(this.btnUpdateService_Click);
            // 
            // btnDeleteService
            // 
            this.btnDeleteService.Location = new System.Drawing.Point(968, 462);
            this.btnDeleteService.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteService.Name = "btnDeleteService";
            this.btnDeleteService.Size = new System.Drawing.Size(140, 28);
            this.btnDeleteService.TabIndex = 3;
            this.btnDeleteService.Text = "Hizmeti Sil";
            this.btnDeleteService.UseVisualStyleBackColor = true;
            this.btnDeleteService.Click += new System.EventHandler(this.btnDeleteService_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(968, 497);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "İptal";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(308, 53);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(488, 28);
            this.label13.TabIndex = 15;
            this.label13.Text = "EK HİZMET BİLGİLERİNİ GÜNCELLE VE SİL";
            // 
            // UpdateDeleteServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 713);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteService);
            this.Controls.Add(this.btnUpdateService);
            this.Controls.Add(this.grpServiceDetails);
            this.Controls.Add(this.grpProviderDetails);
            this.Controls.Add(this.lstServices);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UpdateDeleteServiceForm";
            this.Text = "Hizmet Güncelle/Sil";
            this.Load += new System.EventHandler(this.UpdateDeleteServiceForm_Load);
            this.grpProviderDetails.ResumeLayout(false);
            this.grpProviderDetails.PerformLayout();
            this.grpServiceDetails.ResumeLayout(false);
            this.grpServiceDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBufferTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreparationTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).EndInit();
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