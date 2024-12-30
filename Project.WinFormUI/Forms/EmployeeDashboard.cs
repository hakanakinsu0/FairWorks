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
    }
}
