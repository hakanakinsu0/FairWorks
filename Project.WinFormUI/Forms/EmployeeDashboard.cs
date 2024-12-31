using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinFormUI.Forms
{
    public partial class EmployeeDashboard : Form
    {
        public EmployeeDashboard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddBuilding_Click(object sender, EventArgs e)
        {
            AddBuildingForm addBuildingForm = new AddBuildingForm();
            addBuildingForm.ShowDialog();
        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            AddLocationForm addLocationForm = new AddLocationForm();
            addLocationForm.ShowDialog();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
            addEmployeeForm.ShowDialog();
        }

        private void btnUpdateBuilding_Click(object sender, EventArgs e)
        {
            UpdateDeleteBuildingForm updateDeleteBuildingForm = new UpdateDeleteBuildingForm();
            updateDeleteBuildingForm.ShowDialog();
        }

        private void btnExitUpdate_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdateLocation_Click(object sender, EventArgs e)
        {
            UpdateDeleteLocationForm updateDeleteLocationForm = new UpdateDeleteLocationForm();
            updateDeleteLocationForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateDeleteEmployeeForm updateDeleteEmployeeForm= new UpdateDeleteEmployeeForm();
            updateDeleteEmployeeForm.ShowDialog();
        }
    }
}
