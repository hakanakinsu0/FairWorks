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
            this.btnExitUpdate = new System.Windows.Forms.Button();
            this.btnUpdateService = new System.Windows.Forms.Button();
            this.btnUpdateLocation = new System.Windows.Forms.Button();
            this.btnUpdateEmployee = new System.Windows.Forms.Button();
            this.btnUpdateBuilding = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnExitReport = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.lstReportResults = new System.Windows.Forms.ListBox();
            this.flpReportButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEmployeeReport = new System.Windows.Forms.Button();
            this.btnServiceReport = new System.Windows.Forms.Button();
            this.btnBuildingReport = new System.Windows.Forms.Button();
            this.btnLocationReport = new System.Windows.Forms.Button();
            this.btnMevcutFuarlar = new System.Windows.Forms.Button();
            this.btnFuarOdemeleri = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tbcEmployeeDashboard.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.flpReportButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcEmployeeDashboard
            // 
            this.tbcEmployeeDashboard.Controls.Add(this.tabPage1);
            this.tbcEmployeeDashboard.Controls.Add(this.tabPage2);
            this.tbcEmployeeDashboard.Controls.Add(this.tabPage4);
            this.tbcEmployeeDashboard.Controls.Add(this.tabPage5);
            this.tbcEmployeeDashboard.Location = new System.Drawing.Point(17, 16);
            this.tbcEmployeeDashboard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbcEmployeeDashboard.Name = "tbcEmployeeDashboard";
            this.tbcEmployeeDashboard.SelectedIndex = 0;
            this.tbcEmployeeDashboard.Size = new System.Drawing.Size(1205, 699);
            this.tbcEmployeeDashboard.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnExit);
            this.tabPage1.Controls.Add(this.btnAddService);
            this.tabPage1.Controls.Add(this.btnAddLocation);
            this.tabPage1.Controls.Add(this.btnAddEmployee);
            this.tabPage1.Controls.Add(this.btnAddBuilding);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1197, 670);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ekle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(40, 154);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(259, 28);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Çıkış Yap";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(173, 118);
            this.btnAddService.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(125, 28);
            this.btnAddService.TabIndex = 0;
            this.btnAddService.Text = "Hizmet Ekle";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnAddLocation
            // 
            this.btnAddLocation.Location = new System.Drawing.Point(173, 82);
            this.btnAddLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddLocation.Name = "btnAddLocation";
            this.btnAddLocation.Size = new System.Drawing.Size(125, 28);
            this.btnAddLocation.TabIndex = 0;
            this.btnAddLocation.Text = "Lokasyon Ekle";
            this.btnAddLocation.UseVisualStyleBackColor = true;
            this.btnAddLocation.Click += new System.EventHandler(this.btnAddLocation_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(40, 118);
            this.btnAddEmployee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(125, 28);
            this.btnAddEmployee.TabIndex = 0;
            this.btnAddEmployee.Text = "Çalışan Ekle";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnAddBuilding
            // 
            this.btnAddBuilding.Location = new System.Drawing.Point(40, 82);
            this.btnAddBuilding.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddBuilding.Name = "btnAddBuilding";
            this.btnAddBuilding.Size = new System.Drawing.Size(125, 28);
            this.btnAddBuilding.TabIndex = 0;
            this.btnAddBuilding.Text = "Bina Ekle";
            this.btnAddBuilding.UseVisualStyleBackColor = true;
            this.btnAddBuilding.Click += new System.EventHandler(this.btnAddBuilding_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnExitUpdate);
            this.tabPage2.Controls.Add(this.btnUpdateService);
            this.tabPage2.Controls.Add(this.btnUpdateLocation);
            this.tabPage2.Controls.Add(this.btnUpdateEmployee);
            this.tabPage2.Controls.Add(this.btnUpdateBuilding);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(1197, 670);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Güncelle / Sil";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnExitUpdate
            // 
            this.btnExitUpdate.Location = new System.Drawing.Point(35, 116);
            this.btnExitUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExitUpdate.Name = "btnExitUpdate";
            this.btnExitUpdate.Size = new System.Drawing.Size(259, 28);
            this.btnExitUpdate.TabIndex = 6;
            this.btnExitUpdate.Text = "Çıkış Yap";
            this.btnExitUpdate.UseVisualStyleBackColor = true;
            this.btnExitUpdate.Click += new System.EventHandler(this.btnExitUpdate_Click);
            // 
            // btnUpdateService
            // 
            this.btnUpdateService.Location = new System.Drawing.Point(168, 80);
            this.btnUpdateService.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateService.Name = "btnUpdateService";
            this.btnUpdateService.Size = new System.Drawing.Size(125, 28);
            this.btnUpdateService.TabIndex = 2;
            this.btnUpdateService.Text = "Hizmet Güncelle";
            this.btnUpdateService.UseVisualStyleBackColor = true;
            this.btnUpdateService.Click += new System.EventHandler(this.btnUpdateService_Click);
            // 
            // btnUpdateLocation
            // 
            this.btnUpdateLocation.Location = new System.Drawing.Point(168, 44);
            this.btnUpdateLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateLocation.Name = "btnUpdateLocation";
            this.btnUpdateLocation.Size = new System.Drawing.Size(149, 28);
            this.btnUpdateLocation.TabIndex = 3;
            this.btnUpdateLocation.Text = "Lokasyon Güncelle";
            this.btnUpdateLocation.UseVisualStyleBackColor = true;
            this.btnUpdateLocation.Click += new System.EventHandler(this.btnUpdateLocation_Click);
            // 
            // btnUpdateEmployee
            // 
            this.btnUpdateEmployee.Location = new System.Drawing.Point(35, 80);
            this.btnUpdateEmployee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateEmployee.Name = "btnUpdateEmployee";
            this.btnUpdateEmployee.Size = new System.Drawing.Size(125, 28);
            this.btnUpdateEmployee.TabIndex = 4;
            this.btnUpdateEmployee.Text = "Çalışan Güncelle";
            this.btnUpdateEmployee.UseVisualStyleBackColor = true;
            this.btnUpdateEmployee.Click += new System.EventHandler(this.btnUpdateEmployee_Click);
            // 
            // btnUpdateBuilding
            // 
            this.btnUpdateBuilding.Location = new System.Drawing.Point(35, 44);
            this.btnUpdateBuilding.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateBuilding.Name = "btnUpdateBuilding";
            this.btnUpdateBuilding.Size = new System.Drawing.Size(125, 28);
            this.btnUpdateBuilding.TabIndex = 5;
            this.btnUpdateBuilding.Text = "Bina Güncelle";
            this.btnUpdateBuilding.UseVisualStyleBackColor = true;
            this.btnUpdateBuilding.Click += new System.EventHandler(this.btnUpdateBuilding_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnExitReport);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.lstReportResults);
            this.tabPage4.Controls.Add(this.flpReportButtons);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1197, 670);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Raporlar";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnExitReport
            // 
            this.btnExitReport.Location = new System.Drawing.Point(24, 202);
            this.btnExitReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExitReport.Name = "btnExitReport";
            this.btnExitReport.Size = new System.Drawing.Size(100, 28);
            this.btnExitReport.TabIndex = 45;
            this.btnExitReport.Text = "İptal";
            this.btnExitReport.UseVisualStyleBackColor = true;
            this.btnExitReport.Click += new System.EventHandler(this.btnExitReport_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(23, 28);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 28);
            this.label13.TabIndex = 43;
            this.label13.Text = "RAPORLAR";
            // 
            // lstReportResults
            // 
            this.lstReportResults.FormattingEnabled = true;
            this.lstReportResults.ItemHeight = 16;
            this.lstReportResults.Location = new System.Drawing.Point(24, 287);
            this.lstReportResults.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstReportResults.Name = "lstReportResults";
            this.lstReportResults.Size = new System.Drawing.Size(1143, 308);
            this.lstReportResults.TabIndex = 3;
            this.lstReportResults.DoubleClick += new System.EventHandler(this.lstReportResults_DoubleClick);
            // 
            // flpReportButtons
            // 
            this.flpReportButtons.Controls.Add(this.btnEmployeeReport);
            this.flpReportButtons.Controls.Add(this.btnServiceReport);
            this.flpReportButtons.Controls.Add(this.btnBuildingReport);
            this.flpReportButtons.Controls.Add(this.btnLocationReport);
            this.flpReportButtons.Controls.Add(this.btnMevcutFuarlar);
            this.flpReportButtons.Controls.Add(this.btnFuarOdemeleri);
            this.flpReportButtons.Location = new System.Drawing.Point(24, 90);
            this.flpReportButtons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpReportButtons.Name = "flpReportButtons";
            this.flpReportButtons.Size = new System.Drawing.Size(845, 76);
            this.flpReportButtons.TabIndex = 2;
            // 
            // btnEmployeeReport
            // 
            this.btnEmployeeReport.Location = new System.Drawing.Point(4, 4);
            this.btnEmployeeReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEmployeeReport.Name = "btnEmployeeReport";
            this.btnEmployeeReport.Size = new System.Drawing.Size(140, 28);
            this.btnEmployeeReport.TabIndex = 0;
            this.btnEmployeeReport.Text = "Çalışan Raporu";
            this.btnEmployeeReport.UseVisualStyleBackColor = true;
            this.btnEmployeeReport.Click += new System.EventHandler(this.btnEmployeeReport_Click);
            // 
            // btnServiceReport
            // 
            this.btnServiceReport.Location = new System.Drawing.Point(152, 4);
            this.btnServiceReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnServiceReport.Name = "btnServiceReport";
            this.btnServiceReport.Size = new System.Drawing.Size(140, 28);
            this.btnServiceReport.TabIndex = 1;
            this.btnServiceReport.Text = "Hizmet Raporu";
            this.btnServiceReport.UseVisualStyleBackColor = true;
            this.btnServiceReport.Click += new System.EventHandler(this.btnServiceReport_Click);
            // 
            // btnBuildingReport
            // 
            this.btnBuildingReport.Location = new System.Drawing.Point(300, 4);
            this.btnBuildingReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuildingReport.Name = "btnBuildingReport";
            this.btnBuildingReport.Size = new System.Drawing.Size(140, 28);
            this.btnBuildingReport.TabIndex = 1;
            this.btnBuildingReport.Text = "Bina Raporu";
            this.btnBuildingReport.UseVisualStyleBackColor = true;
            this.btnBuildingReport.Click += new System.EventHandler(this.btnBuildingReport_Click);
            // 
            // btnLocationReport
            // 
            this.btnLocationReport.Location = new System.Drawing.Point(448, 4);
            this.btnLocationReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLocationReport.Name = "btnLocationReport";
            this.btnLocationReport.Size = new System.Drawing.Size(140, 28);
            this.btnLocationReport.TabIndex = 1;
            this.btnLocationReport.Text = "Lokasyon Raporu";
            this.btnLocationReport.UseVisualStyleBackColor = true;
            this.btnLocationReport.Click += new System.EventHandler(this.btnLocationReport_Click);
            // 
            // btnMevcutFuarlar
            // 
            this.btnMevcutFuarlar.Location = new System.Drawing.Point(596, 4);
            this.btnMevcutFuarlar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMevcutFuarlar.Name = "btnMevcutFuarlar";
            this.btnMevcutFuarlar.Size = new System.Drawing.Size(119, 28);
            this.btnMevcutFuarlar.TabIndex = 2;
            this.btnMevcutFuarlar.Text = "Mevcut Fuarlar";
            this.btnMevcutFuarlar.UseVisualStyleBackColor = true;
            this.btnMevcutFuarlar.Click += new System.EventHandler(this.btnMevcutFuarlar_Click);
            // 
            // btnFuarOdemeleri
            // 
            this.btnFuarOdemeleri.Location = new System.Drawing.Point(723, 4);
            this.btnFuarOdemeleri.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFuarOdemeleri.Name = "btnFuarOdemeleri";
            this.btnFuarOdemeleri.Size = new System.Drawing.Size(116, 28);
            this.btnFuarOdemeleri.TabIndex = 3;
            this.btnFuarOdemeleri.Text = "Fuar Ödemeleri";
            this.btnFuarOdemeleri.UseVisualStyleBackColor = true;
            this.btnFuarOdemeleri.Click += new System.EventHandler(this.btnFuarOdemeleri_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1197, 670);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Gecikme Yönetimi";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // EmployeeDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 799);
            this.Controls.Add(this.tbcEmployeeDashboard);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EmployeeDashboard";
            this.Text = "EmployeeDashboard";

            this.tbcEmployeeDashboard.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.flpReportButtons.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExitUpdate;
        private System.Windows.Forms.Button btnUpdateService;
        private System.Windows.Forms.Button btnUpdateLocation;
        private System.Windows.Forms.Button btnUpdateEmployee;
        private System.Windows.Forms.Button btnUpdateBuilding;
        private System.Windows.Forms.ListBox lstReportResults;
        private System.Windows.Forms.FlowLayoutPanel flpReportButtons;
        private System.Windows.Forms.Button btnEmployeeReport;
        private System.Windows.Forms.Button btnServiceReport;
        private System.Windows.Forms.Button btnBuildingReport;
        private System.Windows.Forms.Button btnLocationReport;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnExitReport;
        private System.Windows.Forms.Button btnMevcutFuarlar;
        private System.Windows.Forms.Button btnFuarOdemeleri;
    }
}