namespace Project.WinFormUI.Forms
{
    partial class UpdateDeleteBuildingForm
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
            this.lstBuildings = new System.Windows.Forms.ListBox();
            this.txtBuildingName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.nudNumberOfFloor = new System.Windows.Forms.NumericUpDown();
            this.nudFloorSize = new System.Windows.Forms.NumericUpDown();
            this.nudRoomPerFloor = new System.Windows.Forms.NumericUpDown();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblSelectedBuilding = new System.Windows.Forms.Label();
            this.btnUpdateBuilding = new System.Windows.Forms.Button();
            this.btnDeleteBuilding = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFloorSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomPerFloor)).BeginInit();
            this.SuspendLayout();
            // 
            // lstBuildings
            // 
            this.lstBuildings.FormattingEnabled = true;
            this.lstBuildings.ItemHeight = 16;
            this.lstBuildings.Location = new System.Drawing.Point(16, 102);
            this.lstBuildings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstBuildings.Name = "lstBuildings";
            this.lstBuildings.Size = new System.Drawing.Size(481, 436);
            this.lstBuildings.TabIndex = 0;
            this.lstBuildings.SelectedIndexChanged += new System.EventHandler(this.lstBuildings_SelectedIndexChanged);
            // 
            // txtBuildingName
            // 
            this.txtBuildingName.Location = new System.Drawing.Point(605, 102);
            this.txtBuildingName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBuildingName.Name = "txtBuildingName";
            this.txtBuildingName.Size = new System.Drawing.Size(407, 22);
            this.txtBuildingName.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(605, 134);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(407, 22);
            this.txtAddress.TabIndex = 2;
            // 
            // nudNumberOfFloor
            // 
            this.nudNumberOfFloor.Location = new System.Drawing.Point(605, 166);
            this.nudNumberOfFloor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudNumberOfFloor.Name = "nudNumberOfFloor";
            this.nudNumberOfFloor.Size = new System.Drawing.Size(408, 22);
            this.nudNumberOfFloor.TabIndex = 3;
            // 
            // nudFloorSize
            // 
            this.nudFloorSize.Location = new System.Drawing.Point(605, 198);
            this.nudFloorSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudFloorSize.Name = "nudFloorSize";
            this.nudFloorSize.Size = new System.Drawing.Size(408, 22);
            this.nudFloorSize.TabIndex = 3;
            // 
            // nudRoomPerFloor
            // 
            this.nudRoomPerFloor.Location = new System.Drawing.Point(605, 230);
            this.nudRoomPerFloor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudRoomPerFloor.Name = "nudRoomPerFloor";
            this.nudRoomPerFloor.Size = new System.Drawing.Size(408, 22);
            this.nudRoomPerFloor.TabIndex = 3;
            // 
            // cmbLocation
            // 
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(604, 262);
            this.cmbLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(408, 24);
            this.cmbLocation.TabIndex = 4;
            // 
            // lblSelectedBuilding
            // 
            this.lblSelectedBuilding.BackColor = System.Drawing.Color.White;
            this.lblSelectedBuilding.Location = new System.Drawing.Point(508, 358);
            this.lblSelectedBuilding.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedBuilding.Name = "lblSelectedBuilding";
            this.lblSelectedBuilding.Size = new System.Drawing.Size(505, 181);
            this.lblSelectedBuilding.TabIndex = 5;
            // 
            // btnUpdateBuilding
            // 
            this.btnUpdateBuilding.Location = new System.Drawing.Point(728, 311);
            this.btnUpdateBuilding.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateBuilding.Name = "btnUpdateBuilding";
            this.btnUpdateBuilding.Size = new System.Drawing.Size(100, 28);
            this.btnUpdateBuilding.TabIndex = 6;
            this.btnUpdateBuilding.Text = "Güncelle";
            this.btnUpdateBuilding.UseVisualStyleBackColor = true;
            this.btnUpdateBuilding.Click += new System.EventHandler(this.btnUpdateBuilding_Click);
            // 
            // btnDeleteBuilding
            // 
            this.btnDeleteBuilding.Location = new System.Drawing.Point(620, 311);
            this.btnDeleteBuilding.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteBuilding.Name = "btnDeleteBuilding";
            this.btnDeleteBuilding.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteBuilding.TabIndex = 6;
            this.btnDeleteBuilding.Text = "Sil";
            this.btnDeleteBuilding.UseVisualStyleBackColor = true;
            this.btnDeleteBuilding.Click += new System.EventHandler(this.btnDeleteBuilding_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(512, 311);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "İptal";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(507, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Bina Ismi :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(508, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bina Adresi :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(508, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kat Sayısı :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(508, 201);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Metre Kare :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(508, 233);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Oda Sayısı :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(508, 266);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Lokasyon :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(279, 42);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(421, 28);
            this.label13.TabIndex = 14;
            this.label13.Text = "BİNA BİLGİLERİNİ GÜNCELLE VE SİL";
            // 
            // UpdateDeleteBuildingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 554);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteBuilding);
            this.Controls.Add(this.btnUpdateBuilding);
            this.Controls.Add(this.lblSelectedBuilding);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.nudRoomPerFloor);
            this.Controls.Add(this.nudFloorSize);
            this.Controls.Add(this.nudNumberOfFloor);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtBuildingName);
            this.Controls.Add(this.lstBuildings);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UpdateDeleteBuildingForm";
            this.Text = "Bina Güncelle / Sil";
           
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFloorSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomPerFloor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBuildings;
        private System.Windows.Forms.TextBox txtBuildingName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.NumericUpDown nudNumberOfFloor;
        private System.Windows.Forms.NumericUpDown nudFloorSize;
        private System.Windows.Forms.NumericUpDown nudRoomPerFloor;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblSelectedBuilding;
        private System.Windows.Forms.Button btnUpdateBuilding;
        private System.Windows.Forms.Button btnDeleteBuilding;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
    }
}