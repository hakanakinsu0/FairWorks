using Project.BLL.DesignPatterns.GenericRepository.EFConcRep;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using Sifrelemeler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinFormUI.Forms
{
    public partial class AddEmployeeForm : Form
    {

        // Repository sınıfları aracılığıyla veritabanı işlemleri yapmak için gerekli örnekler oluşturuluyor.
        EmployeeRepository _employeeRepository;  // Çalışan verilerini işlemek için kullanılan repository
        EmployeeProfileRepository _employeeProfileRepository; // Çalışan profillerini işlemek için kullanılan repository

        Employee _employee;  // Yeni eklenen çalışan nesnesi
        EmployeeProfile _employeeProfile;  // Çalışan profil bilgileri

        public AddEmployeeForm()
        {
            InitializeComponent();
            // Repository örneklerini başlatıyoruz
            _employeeRepository = new EmployeeRepository();  // Çalışan verilerini almak ve güncellemek için kullanılır
            _employeeProfileRepository = new EmployeeProfileRepository();  // Çalışan profillerini almak ve güncellemek için kullanılır

            _employee = new Employee();  // Yeni bir çalışan nesnesi oluşturuluyor

            LoadRoles();  // Rol listesini yükler
            LoadManagers();  // Yönetici listesini yükler
            LoadEmployeeList();  // Mevcut çalışanları listeye yükler
            ClearFields();  // Formu temizler
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();//formu kapat
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            // Alanların boş olup olmadığını kontrol et
            if (AreFieldsEmpty())
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");  // Eğer alanlar boşsa uyarı mesajı göster
                return;  // Fonksiyonu sonlandır
            }


            // TC Kimlik Numarası doğrulaması
            if (txtTC.Text.Length != 11)
            {
                MessageBox.Show("TC Kimlik Numarası 11 haneli ve yalnızca rakamlardan oluşmalıdır.");  // TC Kimlik numarasının uzunluğu kontrol edilir
                return;  // Fonksiyonu sonlandır
            }


            // Telefon numarası doğrulaması
            if (!_employeeProfileRepository.IsValidPhoneNumber(txtPhoneNumber.Text))
            {
                MessageBox.Show("Telefon numarası en az 10 haneli ve yalnızca rakamlardan oluşmalıdır.");  // Telefon numarasının geçerliliği kontrol edilir
                return;  // Fonksiyonu sonlandır
            }


            // Şifre kontrolü
            if (!_employeeRepository.IsValidPassword(txtPassword.Text))
            {
                MessageBox.Show("Şifre en az 8 karakterden oluşmalıdır.");  // Şifrenin geçerliliği kontrol edilir
                return;  // Fonksiyonu sonlandır
            }

            // Şifre doğrulama - Şifrelerin eşleşip eşleşmediği kontrol edilir
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Şifreler eşleşmiyor. Lütfen tekrar kontrol ediniz.");  // Şifreler eşleşmiyorsa uyarı gösterilir
                txtConfirmPassword.Clear();  // Şifre onay alanı temizlenir
                return;  // Fonksiyonu sonlandır
            }

            // E-posta doğrulaması
            if (!_employeeRepository.IsValidEmailFormat(txtEmail.Text))
            {
                MessageBox.Show("Geçersiz e-posta formatı.");  // E-posta formatının geçerliliği kontrol edilir
                return;  // Fonksiyonu sonlandır
            }

            try
            {
                // Yeni Employee oluşturuluyor
                _employee = new Employee
                {
                    Email = txtEmail.Text,  // E-posta alınıyor
                    Role = (EmployeeRole)cmbRole.SelectedItem,  // Rol seçimi yapılır
                    ManagerId = cmbManager.SelectedValue != null ? (int?)cmbManager.SelectedValue : null,  // Yönetici seçimi yapılır (eğer varsa)
                    Password = PasswordEncryptor.Encode(txtPassword.Text)  // Şifre encode edilir (şifre şifrelenir)
                };
                // Employee nesnesi veritabanına ekleniyor
                _employeeRepository.Add(_employee);

                // Yeni EmployeeProfile oluşturuluyor
                _employeeProfile = new EmployeeProfile
                {
                    FirstName = txtFirstName.Text,  // Çalışanın adı
                    LastName = txtLastName.Text,  // Çalışanın soyadı
                    TC = txtTC.Text,  // Çalışanın TC kimlik numarası
                    PhoneNumber = txtPhoneNumber.Text,  // Telefon numarası
                    Address = txtAddress.Text,  // Adres bilgisi
                    City = txtCity.Text,  // Şehir bilgisi
                    District = txtDistrict.Text,  // İlçe bilgisi
                    Employee = _employee  // Employee nesnesi ile ilişkilendirme yapılır
                };

                // EmployeeProfile veritabanına ekleniyor
                _employeeProfileRepository.Add(_employeeProfile);

                // Başarı mesajı gösterilir
                MessageBox.Show("Çalışan başarıyla eklendi.");

                // Alanlar temizlenir
                ClearFields();

                // Çalışan listesi güncellenir
                LoadEmployeeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");    // Hata oluşursa mesaj gösterilir

            }
        }


        /******************Form Metotlari*********************/

        private void LoadRoles()
        {
            List<EmployeeRole> roles = new List<EmployeeRole>    // Çalışan rolleri listesini oluşturuyoruz

            {
               EmployeeRole.Admin,       // Admin rolü
               EmployeeRole.Organizer,   // Organizer rolü
               EmployeeRole.Support,     // Support rolü
               EmployeeRole.Sales,       // Sales rolü
               EmployeeRole.Finance      // Finance rolü
            };

            // Rolleri ComboBox'a bağlıyoruz
            cmbRole.DataSource = roles;
            cmbRole.SelectedIndex = -1;  // Başlangıçta hiçbir seçim yapılmaz
        }

        private void LoadManagers()
        {
            if (_employee.Role == EmployeeRole.Admin)// Eğer çalışan Admin rolüne sahipse, sadece Admin olanları yükle
            {
                // Admin rolüne sahip olanları filtreliyoruz
                var managerDisplayData = _employeeRepository
                    .GetAll()  // Tüm çalışanları al
                    .Where(x => x.Role == EmployeeRole.Admin) // Admin rolüne sahip olanları filtrele
                    .Select(x => new
                    {
                        Display = x.ToString(), // Çalışanın ismini veya formatlanmış bilgisini almak
                        Value = x.Id            // Çalışanın ID'sini almak
                    })
                    .ToList();

                // Filtrelenmiş verileri ComboBox'a bağlıyoruz
                cmbManager.DataSource = managerDisplayData;
                cmbManager.DisplayMember = "Display"; // Görüntülenecek alan: Adı vs.
                cmbManager.ValueMember = "Value";    // Seçilecek alan: ID
            }



        }

        private void LoadEmployeeList()
        {
            // Aktif çalışanları listeye yüklüyoruz
            lstCurrentEmployees.DataSource = _employeeProfileRepository.GetActives();
            lstCurrentEmployees.DisplayMember = "ToString";  // Görüntülenecek alan: Çalışan bilgisi
        }

        private void ClearFields()
        {

            // Tüm alanları temizler
            txtFirstName.Clear();      // Ad alanını temizler
            txtLastName.Clear();       // Soyad alanını temizler
            txtPhoneNumber.Clear();    // Telefon numarası alanını temizler
            txtEmail.Clear();          // E-posta alanını temizler
            txtDistrict.Clear();       // İlçe alanını temizler
            txtTC.Clear();             // TC Kimlik Numarası alanını temizler
            txtConfirmPassword.Clear();// Şifre onay alanını temizler
            txtPassword.Clear();       // Şifre alanını temizler
            txtAddress.Clear();        // Adres alanını temizler
            txtCity.Clear();           // Şehir alanını temizler

            // ComboBox seçimlerini sıfırlar
            cmbManager.SelectedIndex = -1;  // Yöneticiyi seçili yapmaz
            cmbRole.SelectedIndex = -1;     // Rolü seçili yapmaz
        }

        private bool AreFieldsEmpty()
        {
            // Alanlardan herhangi biri boşsa true döner
            return txtFirstName.Text == "" ||  // Ad alanı boş mu?
                        txtLastName.Text == "" ||   // Soyad alanı boş mu?
                        txtPhoneNumber.Text == "" || // Telefon numarası boş mu?
                        txtEmail.Text == "" ||      // E-posta alanı boş mu?
                        txtDistrict.Text == "" ||   // İlçe alanı boş mu?
                        txtTC.Text == "" ||         // TC Kimlik Numarası boş mu?
                        txtConfirmPassword.Text == "" || // Şifre onay boş mu?
                        txtPassword.Text == "" ||   // Şifre boş mu?
                        txtAddress.Text == "" ||    // Adres alanı boş mu?
                        txtCity.Text == "";         // Şehir alanı boş mu?
        }

     
    }
}

