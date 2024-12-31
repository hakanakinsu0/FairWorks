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
            this.button2 = new System.Windows.Forms.Button();
            this.btnUpdateLocation = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnUpdateBuilding = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tbcEmployeeDashboard.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.tbcEmployeeDashboard.Size = new System.Drawing.Size(939, 462);
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
            this.tabPage1.Size = new System.Drawing.Size(931, 433);
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
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.btnUpdateLocation);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.btnUpdateBuilding);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(931, 433);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 80);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Hizmet Güncelle";
            this.button2.UseVisualStyleBackColor = true;
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(35, 80);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 28);
            this.button4.TabIndex = 4;
            this.button4.Text = "Çalışan Güncelle";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(931, 433);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Raporlar";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(931, 433);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Gecikme Yönetimi";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // EmployeeDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tbcEmployeeDashboard);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExitUpdate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnUpdateLocation;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnUpdateBuilding;
    }
}