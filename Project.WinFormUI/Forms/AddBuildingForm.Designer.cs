namespace Project.WinFormUI.Forms
{
    partial class AddBuildingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBuildingName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.nudNumberOfFloor = new System.Windows.Forms.NumericUpDown();
            this.nudFloorSize = new System.Windows.Forms.NumericUpDown();
            this.nudRoomPerFloor = new System.Windows.Forms.NumericUpDown();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lstBuildings = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddBuilding = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFloorSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomPerFloor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(107, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "BİNA EKLE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bina Adresi :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kat Sayısı :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 262);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Konum :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 229);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Oda Sayısı :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 197);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Metre Kare :";
            // 
            // txtBuildingName
            // 
            this.txtBuildingName.Location = new System.Drawing.Point(112, 98);
            this.txtBuildingName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBuildingName.Name = "txtBuildingName";
            this.txtBuildingName.Size = new System.Drawing.Size(319, 22);
            this.txtBuildingName.TabIndex = 4;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(112, 130);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(319, 22);
            this.txtAddress.TabIndex = 4;
            // 
            // nudNumberOfFloor
            // 
            this.nudNumberOfFloor.Location = new System.Drawing.Point(112, 162);
            this.nudNumberOfFloor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudNumberOfFloor.Name = "nudNumberOfFloor";
            this.nudNumberOfFloor.Size = new System.Drawing.Size(160, 22);
            this.nudNumberOfFloor.TabIndex = 5;
            // 
            // nudFloorSize
            // 
            this.nudFloorSize.Location = new System.Drawing.Point(112, 194);
            this.nudFloorSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudFloorSize.Name = "nudFloorSize";
            this.nudFloorSize.Size = new System.Drawing.Size(160, 22);
            this.nudFloorSize.TabIndex = 5;
            // 
            // nudRoomPerFloor
            // 
            this.nudRoomPerFloor.Location = new System.Drawing.Point(112, 226);
            this.nudRoomPerFloor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudRoomPerFloor.Name = "nudRoomPerFloor";
            this.nudRoomPerFloor.Size = new System.Drawing.Size(160, 22);
            this.nudRoomPerFloor.TabIndex = 5;
            // 
            // cmbLocation
            // 
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(112, 258);
            this.cmbLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(160, 24);
            this.cmbLocation.TabIndex = 6;
            // 
            // lstBuildings
            // 
            this.lstBuildings.FormattingEnabled = true;
            this.lstBuildings.ItemHeight = 16;
            this.lstBuildings.Location = new System.Drawing.Point(493, 98);
            this.lstBuildings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstBuildings.Name = "lstBuildings";
            this.lstBuildings.Size = new System.Drawing.Size(509, 276);
            this.lstBuildings.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(217, 292);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "İptal";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddBuilding
            // 
            this.btnAddBuilding.Location = new System.Drawing.Point(332, 292);
            this.btnAddBuilding.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddBuilding.Name = "btnAddBuilding";
            this.btnAddBuilding.Size = new System.Drawing.Size(100, 28);
            this.btnAddBuilding.TabIndex = 8;
            this.btnAddBuilding.Text = "Bina Ekle";
            this.btnAddBuilding.UseVisualStyleBackColor = true;
            this.btnAddBuilding.Click += new System.EventHandler(this.btnAddBuilding_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 102);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Bina İsmi :";
            // 
            // AddBuildingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 398);
            this.Controls.Add(this.btnAddBuilding);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstBuildings);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.nudRoomPerFloor);
            this.Controls.Add(this.nudFloorSize);
            this.Controls.Add(this.nudNumberOfFloor);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtBuildingName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddBuildingForm";
            this.Text = "Bina Ekleme";
            this.Load += new System.EventHandler(this.AddBuildingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFloorSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomPerFloor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBuildingName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.NumericUpDown nudNumberOfFloor;
        private System.Windows.Forms.NumericUpDown nudFloorSize;
        private System.Windows.Forms.NumericUpDown nudRoomPerFloor;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.ListBox lstBuildings;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddBuilding;
        private System.Windows.Forms.Label label7;
    }
}