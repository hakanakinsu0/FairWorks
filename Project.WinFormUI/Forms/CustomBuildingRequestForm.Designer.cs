namespace Project.WinFormUI.Forms
{
    partial class CustomBuildingRequestForm
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
            this.nudNumberOfFloor = new System.Windows.Forms.NumericUpDown();
            this.nudFloorSize = new System.Windows.Forms.NumericUpDown();
            this.nudRoomPerFloor = new System.Windows.Forms.NumericUpDown();
            this.lstAvailableBuildings = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearchBuildings = new System.Windows.Forms.Button();
            this.btnConfirmSelection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBuildingDetails = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblFairDetails = new System.Windows.Forms.Label();
            this.cmbLocations = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFloorSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomPerFloor)).BeginInit();
            this.SuspendLayout();
            // 
            // nudNumberOfFloor
            // 
            this.nudNumberOfFloor.Location = new System.Drawing.Point(79, 150);
            this.nudNumberOfFloor.Name = "nudNumberOfFloor";
            this.nudNumberOfFloor.Size = new System.Drawing.Size(120, 20);
            this.nudNumberOfFloor.TabIndex = 0;
            // 
            // nudFloorSize
            // 
            this.nudFloorSize.Location = new System.Drawing.Point(79, 176);
            this.nudFloorSize.Name = "nudFloorSize";
            this.nudFloorSize.Size = new System.Drawing.Size(120, 20);
            this.nudFloorSize.TabIndex = 0;
            // 
            // nudRoomPerFloor
            // 
            this.nudRoomPerFloor.Location = new System.Drawing.Point(79, 202);
            this.nudRoomPerFloor.Name = "nudRoomPerFloor";
            this.nudRoomPerFloor.Size = new System.Drawing.Size(120, 20);
            this.nudRoomPerFloor.TabIndex = 0;
            // 
            // lstAvailableBuildings
            // 
            this.lstAvailableBuildings.FormattingEnabled = true;
            this.lstAvailableBuildings.Location = new System.Drawing.Point(319, 72);
            this.lstAvailableBuildings.Name = "lstAvailableBuildings";
            this.lstAvailableBuildings.Size = new System.Drawing.Size(423, 212);
            this.lstAvailableBuildings.TabIndex = 2;
            this.lstAvailableBuildings.SelectedIndexChanged += new System.EventHandler(this.lstAvailableBuildings_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(119, 261);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSearchBuildings
            // 
            this.btnSearchBuildings.Location = new System.Drawing.Point(200, 261);
            this.btnSearchBuildings.Name = "btnSearchBuildings";
            this.btnSearchBuildings.Size = new System.Drawing.Size(75, 23);
            this.btnSearchBuildings.TabIndex = 3;
            this.btnSearchBuildings.Text = "Gönder";
            this.btnSearchBuildings.UseVisualStyleBackColor = true;
            this.btnSearchBuildings.Click += new System.EventHandler(this.btnSearchBuildings_Click);
            // 
            // btnConfirmSelection
            // 
            this.btnConfirmSelection.Location = new System.Drawing.Point(654, 294);
            this.btnConfirmSelection.Name = "btnConfirmSelection";
            this.btnConfirmSelection.Size = new System.Drawing.Size(88, 23);
            this.btnConfirmSelection.TabIndex = 3;
            this.btnConfirmSelection.Text = "Seçimi Onayla";
            this.btnConfirmSelection.UseVisualStyleBackColor = true;
            this.btnConfirmSelection.Click += new System.EventHandler(this.btnConfirmSelection_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kat Sayısı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Metre Kare :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Oda Sayısı :";
            // 
            // lblBuildingDetails
            // 
            this.lblBuildingDetails.BackColor = System.Drawing.Color.White;
            this.lblBuildingDetails.Location = new System.Drawing.Point(316, 294);
            this.lblBuildingDetails.Name = "lblBuildingDetails";
            this.lblBuildingDetails.Size = new System.Drawing.Size(332, 112);
            this.lblBuildingDetails.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(127, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(266, 23);
            this.label13.TabIndex = 15;
            this.label13.Text = "ÖZEL BİNA TALEBİ OLUŞTUR";
            // 
            // lblFairDetails
            // 
            this.lblFairDetails.BackColor = System.Drawing.Color.White;
            this.lblFairDetails.Location = new System.Drawing.Point(12, 72);
            this.lblFairDetails.Name = "lblFairDetails";
            this.lblFairDetails.Size = new System.Drawing.Size(263, 64);
            this.lblFairDetails.TabIndex = 4;
            // 
            // cmbLocations
            // 
            this.cmbLocations.FormattingEnabled = true;
            this.cmbLocations.Location = new System.Drawing.Point(79, 228);
            this.cmbLocations.Name = "cmbLocations";
            this.cmbLocations.Size = new System.Drawing.Size(121, 21);
            this.cmbLocations.TabIndex = 16;
            this.cmbLocations.SelectedIndexChanged += new System.EventHandler(this.cmbLocations_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lokasyon :";
            // 
            // CustomBuildingRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 426);
            this.Controls.Add(this.cmbLocations);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblFairDetails);
            this.Controls.Add(this.lblBuildingDetails);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirmSelection);
            this.Controls.Add(this.btnSearchBuildings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstAvailableBuildings);
            this.Controls.Add(this.nudRoomPerFloor);
            this.Controls.Add(this.nudFloorSize);
            this.Controls.Add(this.nudNumberOfFloor);
            this.Name = "CustomBuildingRequestForm";
            this.Text = "CustomBuildingRequestForm";
            this.Load += new System.EventHandler(this.CustomBuildingRequestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFloorSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomPerFloor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudNumberOfFloor;
        private System.Windows.Forms.NumericUpDown nudFloorSize;
        private System.Windows.Forms.NumericUpDown nudRoomPerFloor;
        private System.Windows.Forms.ListBox lstAvailableBuildings;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearchBuildings;
        private System.Windows.Forms.Button btnConfirmSelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBuildingDetails;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblFairDetails;
        private System.Windows.Forms.ComboBox cmbLocations;
        private System.Windows.Forms.Label label4;
    }
}