namespace Project.WinFormUI.Forms
{
    partial class UpdateDeleteLocationForm
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
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeleteLocation = new System.Windows.Forms.Button();
            this.btnUpdateLocation = new System.Windows.Forms.Button();
            this.lblSelectedLocation = new System.Windows.Forms.Label();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lstLocations = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(165, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(386, 23);
            this.label13.TabIndex = 32;
            this.label13.Text = "LOKASYON BİLGİLERİNİ GÜNCELLE VE SİL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "İlçe :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "İl :";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(428, 124);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "İptal";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteLocation
            // 
            this.btnDeleteLocation.Location = new System.Drawing.Point(509, 124);
            this.btnDeleteLocation.Name = "btnDeleteLocation";
            this.btnDeleteLocation.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteLocation.TabIndex = 24;
            this.btnDeleteLocation.Text = "Sil";
            this.btnDeleteLocation.UseVisualStyleBackColor = true;
            this.btnDeleteLocation.Click += new System.EventHandler(this.btnDeleteLocation_Click);
            // 
            // btnUpdateLocation
            // 
            this.btnUpdateLocation.Location = new System.Drawing.Point(590, 124);
            this.btnUpdateLocation.Name = "btnUpdateLocation";
            this.btnUpdateLocation.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateLocation.TabIndex = 23;
            this.btnUpdateLocation.Text = "Güncelle";
            this.btnUpdateLocation.UseVisualStyleBackColor = true;
            this.btnUpdateLocation.Click += new System.EventHandler(this.btnUpdateLocation_Click);
            // 
            // lblSelectedLocation
            // 
            this.lblSelectedLocation.BackColor = System.Drawing.Color.White;
            this.lblSelectedLocation.Location = new System.Drawing.Point(394, 176);
            this.lblSelectedLocation.Name = "lblSelectedLocation";
            this.lblSelectedLocation.Size = new System.Drawing.Size(271, 147);
            this.lblSelectedLocation.TabIndex = 22;
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(428, 98);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(237, 20);
            this.txtDistrict.TabIndex = 17;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(428, 72);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(237, 20);
            this.txtCity.TabIndex = 16;
            // 
            // lstLocations
            // 
            this.lstLocations.FormattingEnabled = true;
            this.lstLocations.Location = new System.Drawing.Point(26, 72);
            this.lstLocations.Name = "lstLocations";
            this.lstLocations.Size = new System.Drawing.Size(362, 251);
            this.lstLocations.TabIndex = 15;
            this.lstLocations.SelectedIndexChanged += new System.EventHandler(this.lstLocations_SelectedIndexChanged);
            // 
            // UpdateDeleteLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 347);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteLocation);
            this.Controls.Add(this.btnUpdateLocation);
            this.Controls.Add(this.lblSelectedLocation);
            this.Controls.Add(this.txtDistrict);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lstLocations);
            this.Name = "UpdateDeleteLocationForm";
            this.Text = "UpdateDeleteLocationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDeleteLocation;
        private System.Windows.Forms.Button btnUpdateLocation;
        private System.Windows.Forms.Label lblSelectedLocation;
        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.ListBox lstLocations;
    }
}