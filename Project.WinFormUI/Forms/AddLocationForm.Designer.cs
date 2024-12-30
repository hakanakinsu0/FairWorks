namespace Project.WinFormUI.Forms
{
    partial class AddLocationForm
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
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddLocation = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lstLocations = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(51, 108);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(240, 20);
            this.txtCity.TabIndex = 7;
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(51, 82);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(240, 20);
            this.txtDistrict.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "İl :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "İlçe :";
            // 
            // btnAddLocation
            // 
            this.btnAddLocation.Location = new System.Drawing.Point(201, 134);
            this.btnAddLocation.Name = "btnAddLocation";
            this.btnAddLocation.Size = new System.Drawing.Size(90, 23);
            this.btnAddLocation.TabIndex = 11;
            this.btnAddLocation.Text = "Lokasyon Ekle";
            this.btnAddLocation.UseVisualStyleBackColor = true;
            this.btnAddLocation.Click += new System.EventHandler(this.btnAddLocation_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(105, 134);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "İptal";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lstLocations
            // 
            this.lstLocations.FormattingEnabled = true;
            this.lstLocations.Location = new System.Drawing.Point(315, 85);
            this.lstLocations.Name = "lstLocations";
            this.lstLocations.Size = new System.Drawing.Size(383, 225);
            this.lstLocations.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(47, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "LOKASYON EKLE";
            // 
            // AddLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddLocation);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstLocations);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtDistrict);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Name = "AddLocationForm";
            this.Text = "Lokasyon Ekle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddLocation;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox lstLocations;
        private System.Windows.Forms.Label label1;
    }
}