namespace Project.WinFormUI.Forms
{
    partial class EmployeeDashboard
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
            this.tbcEmployeeDashboard = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnAddLocation = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnAddBuilding = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tbcEmployeeDashboard.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcEmployeeDashboard
            // 
            this.tbcEmployeeDashboard.Controls.Add(this.tabPage1);
            this.tbcEmployeeDashboard.Controls.Add(this.tabPage2);
            this.tbcEmployeeDashboard.Controls.Add(this.tabPage3);
            this.tbcEmployeeDashboard.Controls.Add(this.tabPage4);
            this.tbcEmployeeDashboard.Controls.Add(this.tabPage5);
            this.tbcEmployeeDashboard.Controls.Add(this.tabPage6);
            this.tbcEmployeeDashboard.Location = new System.Drawing.Point(13, 13);
            this.tbcEmployeeDashboard.Name = "tbcEmployeeDashboard";
            this.tbcEmployeeDashboard.SelectedIndex = 0;
            this.tbcEmployeeDashboard.Size = new System.Drawing.Size(704, 375);
            this.tbcEmployeeDashboard.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnExit);
            this.tabPage1.Controls.Add(this.btnAddService);
            this.tabPage1.Controls.Add(this.btnAddLocation);
            this.tabPage1.Controls.Add(this.btnAddEmployee);
            this.tabPage1.Controls.Add(this.btnAddBuilding);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(696, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ekle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(30, 125);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(194, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Çıkış Yap";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(130, 96);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(94, 23);
            this.btnAddService.TabIndex = 0;
            this.btnAddService.Text = "Hizmet Ekle";
            this.btnAddService.UseVisualStyleBackColor = true;
            // 
            // btnAddLocation
            // 
            this.btnAddLocation.Location = new System.Drawing.Point(130, 67);
            this.btnAddLocation.Name = "btnAddLocation";
            this.btnAddLocation.Size = new System.Drawing.Size(94, 23);
            this.btnAddLocation.TabIndex = 0;
            this.btnAddLocation.Text = "Lokasyon Ekle";
            this.btnAddLocation.UseVisualStyleBackColor = true;
            this.btnAddLocation.Click += new System.EventHandler(this.btnAddLocation_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(30, 96);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(94, 23);
            this.btnAddEmployee.TabIndex = 0;
            this.btnAddEmployee.Text = "Çalışan Ekle";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            // 
            // btnAddBuilding
            // 
            this.btnAddBuilding.Location = new System.Drawing.Point(30, 67);
            this.btnAddBuilding.Name = "btnAddBuilding";
            this.btnAddBuilding.Size = new System.Drawing.Size(94, 23);
            this.btnAddBuilding.TabIndex = 0;
            this.btnAddBuilding.Text = "Bina Ekle";
            this.btnAddBuilding.UseVisualStyleBackColor = true;
            this.btnAddBuilding.Click += new System.EventHandler(this.btnAddBuilding_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(696, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Güncelle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Bina Ekle";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(696, 349);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sil";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(696, 349);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Raporlar";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(696, 349);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Gecikme Yönetimi";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(696, 349);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Çalışan İşlemleri";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // EmployeeDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbcEmployeeDashboard);
            this.Name = "EmployeeDashboard";
            this.Text = "EmployeeDashboard";
            this.tbcEmployeeDashboard.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcEmployeeDashboard;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnAddLocation;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnAddBuilding;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button button1;
    }
}