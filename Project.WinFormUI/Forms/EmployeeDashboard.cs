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

        /*--------------------------Ekle Sekmesi-----------------------*/

        // Yeni bina ekleme butonu olayı: AddBuildingForm'u açar
        private void btnAddBuilding_Click(object sender, EventArgs e)
        {
            AddBuildingForm addBuildingForm = new AddBuildingForm();
            addBuildingForm.ShowDialog();
        }

        // Yeni lokasyon ekleme butonu olayı: AddLocationForm'u açar
        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            AddLocationForm addLocationForm = new AddLocationForm();
            addLocationForm.ShowDialog();
        }

        // Yeni çalışan ekleme butonu olayı: AddEmployeeForm'u açar
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
            addEmployeeForm.ShowDialog();
        }

        // Çıkış butonu olayı: Formu kapatır
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*--------------------------Guncelle/Sil Sekmesi-----------------------*/

        // Bina güncelleme/silme butonu olayı: UpdateDeleteBuildingForm'u açar
        private void btnUpdateBuilding_Click(object sender, EventArgs e)
        {
            UpdateDeleteBuildingForm updateDeleteBuildingForm = new UpdateDeleteBuildingForm();
            updateDeleteBuildingForm.ShowDialog();
        }

        // Lokasyon güncelleme/silme butonu olayı: UpdateDeleteLocationForm'u açar
        private void btnUpdateLocation_Click(object sender, EventArgs e)
        {
            UpdateDeleteLocationForm updateDeleteLocationForm = new UpdateDeleteLocationForm();
            updateDeleteLocationForm.ShowDialog();
        }

        // Çalışan güncelleme/silme butonu olayı: UpdateDeleteEmployeeForm'u açar
        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            UpdateDeleteEmployeeForm updateDeleteEmployeeForm= new UpdateDeleteEmployeeForm();
            updateDeleteEmployeeForm.ShowDialog();
        }

        // Güncelleme ekranından çıkış butonu: Formu kapatır
        private void btnExitUpdate_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
