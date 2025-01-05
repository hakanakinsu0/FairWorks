using Project.BLL.DesignPatterns.GenericRepository.EFConcRep;
using Project.ENTITIES.Models;
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
    public partial class UpdateDeleteEmployeeForm : Form
    {
        // EmployeeProfile ve Employee verilerini yönetmek için repository nesneleri
        EmployeeProfileRepository _ProfileRepository;
        EmployeeProfile _selectedProfile;

        EmployeeRepository _employeRepository;
        Employee _selectedEmployee;


        public UpdateDeleteEmployeeForm()
        {

            // Repository nesnelerini başlat
            _ProfileRepository = new EmployeeProfileRepository();
            _employeRepository = new EmployeeRepository();
            InitializeComponent();// Form bileşenlerini yükle
            LoadProfile();         // Profilleri listeye yükle

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Formu kapat
            Close();
        }

        private void lstEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Listeden bir öğe seçildiyse
            if (lstEmployees.SelectedItem != null)
            {
                _selectedProfile = (EmployeeProfile)lstEmployees.SelectedItem; // Seçilen profili ata

                // Employee nesnesini Profile üzerinden al
                _selectedEmployee = _selectedProfile.Employee;

                // Form alanlarını seçilen profil ve çalışan bilgileriyle doldur
                txtCity.Text = _selectedProfile.City;
                txtDistrict.Text = _selectedProfile.District;
                txtAddress.Text = _selectedProfile.Address;
                txtEmail.Text = _selectedEmployee?.Email ?? string.Empty; // Null kontrolü yap
                txtFirstName.Text = _selectedProfile.FirstName;
                txtLastName.Text = _selectedProfile.LastName;
                txtPhoneNumber.Text = _selectedProfile.PhoneNumber;
                txtTC.Text = _selectedProfile.TC;

                // Label'ı seçilen çalışanın adıyla güncelle
                lblSelectedEmployee.Text = $"Seçilen Çalışan: {_selectedProfile.FirstName} {_selectedProfile.LastName}";
            }
            else
            {
                ClearFields(); // Eğer bir seçim yoksa alanları temizle
            }


        }
        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {

            // Eğer bir çalışan seçilmemişse uyarı göster
            if (_selectedProfile == null || _selectedEmployee == null)
            {
                MessageBox.Show("Lütfen bir Çalışan seçiniz.");
                return;
            }

            try
            {
                // Seçilen profili sil
                _ProfileRepository.Delete(_selectedProfile);
                _employeRepository.Delete(_selectedEmployee);

                // Kullanıcıya başarı mesajı göster
                MessageBox.Show("Çalışan başarıyla silindi.");

                LoadProfile(); // Listeyi yeniden yükle
                ClearFields(); // Formu temizle
            }
            catch (Exception ex)
            {
                // Hata oluşursa kullanıcıya bildir
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            // Eğer bir çalışan seçilmemişse uyarı göster
            if (_selectedProfile == null)
            {
                MessageBox.Show("Lütfen bir Çalışan seçiniz.");
                return;
            }

            try
            {
                // Seçilen profilin bilgilerini güncelle
                _selectedProfile.City = txtCity.Text;
                _selectedProfile.District = txtDistrict.Text;
                _selectedProfile.Address = txtAddress.Text;
                _selectedProfile.TC = txtTC.Text;
                _selectedProfile.PhoneNumber = txtPhoneNumber.Text;
                _selectedEmployee.Email = txtEmail.Text;
                _selectedProfile.FirstName = txtFirstName.Text;
                _selectedProfile.LastName = txtLastName.Text;

                // Güncellenen bilgileri veritabanına kaydet
                _ProfileRepository.Update(_selectedProfile);
                _employeRepository.Update(_selectedEmployee);

                // Kullanıcıya başarı mesajı göster
                MessageBox.Show("Çalışan başarıyla güncellendi.");

                LoadProfile(); // Listeyi yeniden yükle
                ClearFields(); // Formu temizle
            }
            catch (Exception ex)
            {
                // Hata oluşursa kullanıcıya bildir
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        /***********Form Metotlari********************/
        private void LoadProfile()
        {
            // Aktif Profilleri yükle
            lstEmployees.DataSource = _ProfileRepository.GetActives();// Aktif profilleri getir
            lstEmployees.DisplayMember = "ToString"; // Listeleme için ToString özelliğini kullan
        }

        private void ClearFields()
        {
            // Formdaki tüm alanları temizle
            txtCity.Clear();
            txtDistrict.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhoneNumber.Clear();
            txtTC.Clear();

            // Label'ı varsayılan değerle güncelle
            lblSelectedEmployee.Text = "Seçilen çalışan: Yok";

            // Seçilen profil ve çalışan nesnelerini null olarak ayarla
            _selectedProfile = null;
        }

    }
}  
    
