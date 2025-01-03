namespace Project.WinFormUI.Forms
{
    partial class CustomerDashboard
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBuildingDetails = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirmFair = new System.Windows.Forms.Button();
            this.btnRequestBuilding = new System.Windows.Forms.Button();
            this.btnSearchBuildings = new System.Windows.Forms.Button();
            this.lstBuildings = new System.Windows.Forms.ListBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cmbDistrict = new System.Windows.Forms.ComboBox();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.txtFairName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvFairs = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFairs)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(751, 405);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.lblBuildingDetails);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnConfirmFair);
            this.tabPage1.Controls.Add(this.btnRequestBuilding);
            this.tabPage1.Controls.Add(this.btnSearchBuildings);
            this.tabPage1.Controls.Add(this.lstBuildings);
            this.tabPage1.Controls.Add(this.dtpStartDate);
            this.tabPage1.Controls.Add(this.dtpEndDate);
            this.tabPage1.Controls.Add(this.cmbDistrict);
            this.tabPage1.Controls.Add(this.cmbCity);
            this.tabPage1.Controls.Add(this.txtFairName);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(743, 379);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Fuar Oluştur";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(28, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Seçilen Bina Özellikleri";
            // 
            // lblBuildingDetails
            // 
            this.lblBuildingDetails.BackColor = System.Drawing.Color.White;
            this.lblBuildingDetails.Location = new System.Drawing.Point(31, 253);
            this.lblBuildingDetails.Name = "lblBuildingDetails";
            this.lblBuildingDetails.Size = new System.Drawing.Size(291, 112);
            this.lblBuildingDetails.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(63, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(148, 23);
            this.label13.TabIndex = 14;
            this.label13.Text = "FUAR OLUŞTUR";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(166, 182);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirmFair
            // 
            this.btnConfirmFair.Location = new System.Drawing.Point(641, 273);
            this.btnConfirmFair.Name = "btnConfirmFair";
            this.btnConfirmFair.Size = new System.Drawing.Size(85, 23);
            this.btnConfirmFair.TabIndex = 5;
            this.btnConfirmFair.Text = "Seçimi Onayla";
            this.btnConfirmFair.UseVisualStyleBackColor = true;
            this.btnConfirmFair.Click += new System.EventHandler(this.btnConfirmFair_Click);
            // 
            // btnRequestBuilding
            // 
            this.btnRequestBuilding.Location = new System.Drawing.Point(537, 273);
            this.btnRequestBuilding.Name = "btnRequestBuilding";
            this.btnRequestBuilding.Size = new System.Drawing.Size(98, 23);
            this.btnRequestBuilding.TabIndex = 5;
            this.btnRequestBuilding.Text = "Özel Bina Talebi";
            this.btnRequestBuilding.UseVisualStyleBackColor = true;
            this.btnRequestBuilding.Click += new System.EventHandler(this.btnRequestBuilding_Click);
            // 
            // btnSearchBuildings
            // 
            this.btnSearchBuildings.Location = new System.Drawing.Point(247, 182);
            this.btnSearchBuildings.Name = "btnSearchBuildings";
            this.btnSearchBuildings.Size = new System.Drawing.Size(75, 23);
            this.btnSearchBuildings.TabIndex = 5;
            this.btnSearchBuildings.Text = "Gönder";
            this.btnSearchBuildings.UseVisualStyleBackColor = true;
            this.btnSearchBuildings.Click += new System.EventHandler(this.btnSearchBuildings_Click);
            // 
            // lstBuildings
            // 
            this.lstBuildings.FormattingEnabled = true;
            this.lstBuildings.Location = new System.Drawing.Point(387, 42);
            this.lstBuildings.Name = "lstBuildings";
            this.lstBuildings.Size = new System.Drawing.Size(339, 225);
            this.lstBuildings.TabIndex = 4;
            this.lstBuildings.SelectedIndexChanged += new System.EventHandler(this.lstBuildings_SelectedIndexChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(122, 130);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDate.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(122, 156);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtpEndDate.TabIndex = 3;
            // 
            // cmbDistrict
            // 
            this.cmbDistrict.FormattingEnabled = true;
            this.cmbDistrict.Location = new System.Drawing.Point(122, 102);
            this.cmbDistrict.Name = "cmbDistrict";
            this.cmbDistrict.Size = new System.Drawing.Size(121, 21);
            this.cmbDistrict.TabIndex = 2;
            // 
            // cmbCity
            // 
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(122, 75);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(121, 21);
            this.cmbCity.TabIndex = 2;
            this.cmbCity.SelectedIndexChanged += new System.EventHandler(this.cmbCity_SelectedIndexChanged_1);
            // 
            // txtFairName
            // 
            this.txtFairName.Location = new System.Drawing.Point(122, 49);
            this.txtFairName.Name = "txtFairName";
            this.txtFairName.Size = new System.Drawing.Size(121, 20);
            this.txtFairName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Bitiş Tarihi :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Başlangıç Tarihi :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "İl :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "İlçe :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fuar Adı :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvFairs);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(743, 379);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fuarlarım";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvFairs
            // 
            this.dgvFairs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFairs.Location = new System.Drawing.Point(19, 29);
            this.dgvFairs.Name = "dgvFairs";
            this.dgvFairs.Size = new System.Drawing.Size(703, 241);
            this.dgvFairs.TabIndex = 0;
            // 
            // CustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 429);
            this.Controls.Add(this.tabControl1);
            this.Name = "CustomerDashboard";
            this.Text = "CustomerDashboard";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFairs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSearchBuildings;
        private System.Windows.Forms.ListBox lstBuildings;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.ComboBox cmbDistrict;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.TextBox txtFairName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirmFair;
        private System.Windows.Forms.Button btnRequestBuilding;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblBuildingDetails;
        private System.Windows.Forms.DataGridView dgvFairs;
    }
}