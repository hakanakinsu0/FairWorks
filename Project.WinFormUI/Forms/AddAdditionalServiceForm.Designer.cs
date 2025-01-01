namespace Project.WinFormUI.Forms
{
    partial class AddAdditionalServiceForm
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
            this.txtDescriptorName = new System.Windows.Forms.TextBox();
            this.txtDescriptorDescription = new System.Windows.Forms.TextBox();
            this.txtValueName = new System.Windows.Forms.TextBox();
            this.nudCost = new System.Windows.Forms.NumericUpDown();
            this.nudPreparationTime = new System.Windows.Forms.NumericUpDown();
            this.nudBufferTime = new System.Windows.Forms.NumericUpDown();
            this.txtProviderName = new System.Windows.Forms.TextBox();
            this.txtProviderAddress = new System.Windows.Forms.TextBox();
            this.txtProviderCity = new System.Windows.Forms.TextBox();
            this.txtProviderDistrict = new System.Windows.Forms.TextBox();
            this.txtProviderPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtProviderEmail = new System.Windows.Forms.TextBox();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lstServices = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbExistingProviders = new System.Windows.Forms.ComboBox();
            this.chkNewProvider = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreparationTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBufferTime)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescriptorName
            // 
            this.txtDescriptorName.Location = new System.Drawing.Point(129, 122);
            this.txtDescriptorName.Name = "txtDescriptorName";
            this.txtDescriptorName.Size = new System.Drawing.Size(120, 20);
            this.txtDescriptorName.TabIndex = 0;
            // 
            // txtDescriptorDescription
            // 
            this.txtDescriptorDescription.Location = new System.Drawing.Point(129, 148);
            this.txtDescriptorDescription.Name = "txtDescriptorDescription";
            this.txtDescriptorDescription.Size = new System.Drawing.Size(120, 20);
            this.txtDescriptorDescription.TabIndex = 0;
            // 
            // txtValueName
            // 
            this.txtValueName.Location = new System.Drawing.Point(129, 174);
            this.txtValueName.Name = "txtValueName";
            this.txtValueName.Size = new System.Drawing.Size(120, 20);
            this.txtValueName.TabIndex = 1;
            // 
            // nudCost
            // 
            this.nudCost.Location = new System.Drawing.Point(129, 200);
            this.nudCost.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCost.Name = "nudCost";
            this.nudCost.Size = new System.Drawing.Size(120, 20);
            this.nudCost.TabIndex = 2;
            // 
            // nudPreparationTime
            // 
            this.nudPreparationTime.Location = new System.Drawing.Point(129, 226);
            this.nudPreparationTime.Name = "nudPreparationTime";
            this.nudPreparationTime.Size = new System.Drawing.Size(120, 20);
            this.nudPreparationTime.TabIndex = 2;
            // 
            // nudBufferTime
            // 
            this.nudBufferTime.Location = new System.Drawing.Point(129, 252);
            this.nudBufferTime.Name = "nudBufferTime";
            this.nudBufferTime.Size = new System.Drawing.Size(120, 20);
            this.nudBufferTime.TabIndex = 2;
            // 
            // txtProviderName
            // 
            this.txtProviderName.Location = new System.Drawing.Point(129, 278);
            this.txtProviderName.Name = "txtProviderName";
            this.txtProviderName.Size = new System.Drawing.Size(120, 20);
            this.txtProviderName.TabIndex = 3;
            // 
            // txtProviderAddress
            // 
            this.txtProviderAddress.Location = new System.Drawing.Point(129, 304);
            this.txtProviderAddress.Name = "txtProviderAddress";
            this.txtProviderAddress.Size = new System.Drawing.Size(120, 20);
            this.txtProviderAddress.TabIndex = 3;
            // 
            // txtProviderCity
            // 
            this.txtProviderCity.Location = new System.Drawing.Point(129, 330);
            this.txtProviderCity.Name = "txtProviderCity";
            this.txtProviderCity.Size = new System.Drawing.Size(120, 20);
            this.txtProviderCity.TabIndex = 3;
            // 
            // txtProviderDistrict
            // 
            this.txtProviderDistrict.Location = new System.Drawing.Point(129, 356);
            this.txtProviderDistrict.Name = "txtProviderDistrict";
            this.txtProviderDistrict.Size = new System.Drawing.Size(120, 20);
            this.txtProviderDistrict.TabIndex = 3;
            // 
            // txtProviderPhoneNumber
            // 
            this.txtProviderPhoneNumber.Location = new System.Drawing.Point(129, 382);
            this.txtProviderPhoneNumber.Name = "txtProviderPhoneNumber";
            this.txtProviderPhoneNumber.Size = new System.Drawing.Size(120, 20);
            this.txtProviderPhoneNumber.TabIndex = 3;
            // 
            // txtProviderEmail
            // 
            this.txtProviderEmail.Location = new System.Drawing.Point(129, 408);
            this.txtProviderEmail.Name = "txtProviderEmail";
            this.txtProviderEmail.Size = new System.Drawing.Size(120, 20);
            this.txtProviderEmail.TabIndex = 3;
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(174, 434);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(75, 23);
            this.btnAddService.TabIndex = 4;
            this.btnAddService.Text = "Hizmet Ekle";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(93, 434);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "İptal";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lstServices
            // 
            this.lstServices.HideSelection = false;
            this.lstServices.Location = new System.Drawing.Point(291, 122);
            this.lstServices.Name = "lstServices";
            this.lstServices.Size = new System.Drawing.Size(526, 333);
            this.lstServices.TabIndex = 5;
            this.lstServices.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hizmet Adı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hizmet Açıklaması :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hizmet Değer Adı :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Maliyet (₺) :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Hazırlık Süresi (Gün) :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tampon Süresi (Gün) :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Sağlayıcı Adı :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 307);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Adres :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Şehir :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 359);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "İlçe :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 385);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Telefon Numarası :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 411);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "E-Posta :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(244, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 23);
            this.label13.TabIndex = 14;
            this.label13.Text = "HİZMET EKLE";
            // 
            // cmbExistingProviders
            // 
            this.cmbExistingProviders.FormattingEnabled = true;
            this.cmbExistingProviders.Location = new System.Drawing.Point(444, 86);
            this.cmbExistingProviders.Name = "cmbExistingProviders";
            this.cmbExistingProviders.Size = new System.Drawing.Size(121, 21);
            this.cmbExistingProviders.TabIndex = 15;
            this.cmbExistingProviders.SelectedIndexChanged += new System.EventHandler(this.cmbExistingProviders_SelectedIndexChanged_1);
            // 
            // chkNewProvider
            // 
            this.chkNewProvider.AutoSize = true;
            this.chkNewProvider.Location = new System.Drawing.Point(17, 86);
            this.chkNewProvider.Name = "chkNewProvider";
            this.chkNewProvider.Size = new System.Drawing.Size(99, 17);
            this.chkNewProvider.TabIndex = 16;
            this.chkNewProvider.Text = "Yeni Firma Ekle";
            this.chkNewProvider.UseVisualStyleBackColor = true;
            this.chkNewProvider.CheckedChanged += new System.EventHandler(this.chkNewProvider_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(290, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(148, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Mevcut Firmaya Ekleme Yap :";
            // 
            // AddAdditionalServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 483);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.chkNewProvider);
            this.Controls.Add(this.cmbExistingProviders);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstServices);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddService);
            this.Controls.Add(this.txtProviderEmail);
            this.Controls.Add(this.txtProviderCity);
            this.Controls.Add(this.txtProviderPhoneNumber);
            this.Controls.Add(this.txtProviderAddress);
            this.Controls.Add(this.txtProviderDistrict);
            this.Controls.Add(this.txtProviderName);
            this.Controls.Add(this.nudBufferTime);
            this.Controls.Add(this.nudPreparationTime);
            this.Controls.Add(this.nudCost);
            this.Controls.Add(this.txtValueName);
            this.Controls.Add(this.txtDescriptorDescription);
            this.Controls.Add(this.txtDescriptorName);
            this.Name = "AddAdditionalServiceForm";
            this.Text = "AddAdditionalServiceForm";
            this.Load += new System.EventHandler(this.AddAdditionalServiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreparationTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBufferTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescriptorName;
        private System.Windows.Forms.TextBox txtDescriptorDescription;
        private System.Windows.Forms.TextBox txtValueName;
        private System.Windows.Forms.NumericUpDown nudCost;
        private System.Windows.Forms.NumericUpDown nudPreparationTime;
        private System.Windows.Forms.NumericUpDown nudBufferTime;
        private System.Windows.Forms.TextBox txtProviderName;
        private System.Windows.Forms.TextBox txtProviderAddress;
        private System.Windows.Forms.TextBox txtProviderCity;
        private System.Windows.Forms.TextBox txtProviderDistrict;
        private System.Windows.Forms.TextBox txtProviderPhoneNumber;
        private System.Windows.Forms.TextBox txtProviderEmail;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lstServices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbExistingProviders;
        private System.Windows.Forms.CheckBox chkNewProvider;
        private System.Windows.Forms.Label label14;
    }
}