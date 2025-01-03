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

        // Repository sınıfları aracılığıyla veritabanı işlemlerini gerçekleştirmek için örnekler oluşturulur.
        EmployeeRepository _employeeRepository;
        EmployeeProfileRepository _employeeProfileRepository;

        Employee _employee;
        EmployeeProfile _employeeProfile;

        public AddEmployeeForm()
        {
            InitializeComponent();
            _employeeRepository = new EmployeeRepository();
            _employeeProfileRepository = new EmployeeProfileRepository();
            _employee = new Employee();
            LoadRoles();
            LoadManagers();
            LoadEmployeeList();
            ClearFields();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            // Alanlar boş mu?
            if (AreFieldsEmpty())
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            // TC Kimlik Numarası doğrulaması
            if (txtTC.Text.Length != 11)
            {
                MessageBox.Show("TC Kimlik Numarası 11 haneli ve yalnızca rakamlardan oluşmalıdır.");
                return;
            }

            // Telefon numarası doğrulaması
            if (!_employeeProfileRepository.IsValidPhoneNumber(txtPhoneNumber.Text))
            {
                MessageBox.Show("Telefon numarası en az 10 haneli ve yalnızca rakamlardan oluşmalıdır.");
                return;
            }

            // Şifre kontrolü
            if (!_employeeRepository.IsValidPassword(txtPassword.Text))
            {
                MessageBox.Show("Şifre en az 8 karakterden oluşmalıdır.");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Şifreler eşleşmiyor. Lütfen tekrar kontrol ediniz.");
                txtConfirmPassword.Clear();
                return;
            }

            // E-posta doğrulaması
            if (!_employeeRepository.IsValidEmailFormat(txtEmail.Text))
            {
                MessageBox.Show("Geçersiz e-posta formatı.");
                return;
            }

            try
            {
                // Yeni Employee oluştur
                _employee = new Employee
                {
                    Email = txtEmail.Text,
                    Role = (EmployeeRole)cmbRole.SelectedItem,
                    ManagerId = cmbManager.SelectedValue != null ? (int?)cmbManager.SelectedValue : null,
                    Password = PasswordEncryptor.Encode(txtPassword.Text) // Şifre encode edilir
                };

                _employeeRepository.Add(_employee);

                // Yeni EmployeeProfile oluştur
                _employeeProfile = new EmployeeProfile
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    TC = txtTC.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Address = txtAddress.Text,
                    City = txtCity.Text,
                    District = txtDistrict.Text,
                    Employee = _employee // İlişkilendirme
                };

                _employeeProfileRepository.Add(_employeeProfile);

                MessageBox.Show("Çalışan başarıyla eklendi.");

                ClearFields(); // Alanları temizle
                LoadEmployeeList(); // Listeyi güncelle
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void LoadRoles()
        {
            List<EmployeeRole> roles = new List<EmployeeRole>
            {
                EmployeeRole.Admin,
                EmployeeRole.Organizer,
                EmployeeRole.Support,
                EmployeeRole.Sales,
                EmployeeRole.Finance
            };

            cmbRole.DataSource = roles;
            cmbRole.SelectedIndex = -1;
        }

        private void LoadManagers()
        {
            if (_employee.Role == EmployeeRole.Admin)
            {
                // Sadece Admin rolüne sahip olanları filtreleyin
                var managerDisplayData = _employeeRepository
                    .GetAll()
                    .Where(x => x.Role == EmployeeRole.Admin) // Admin rolüne göre filtreleme
                    .Select(x => new
                    {
                        Display = x.ToString(), // ToString ile formatlanmış hali
                        Value = x.Id            // ID değeri
                    })
                    .ToList();

                // Filtrelenmiş verileri ComboBox'a bağlayın
                cmbManager.DataSource = managerDisplayData;
                cmbManager.DisplayMember = "Display"; // Görüntülenecek alan
                cmbManager.ValueMember = "Value";    // ID olarak seçilecek alan
            }



        }

        private void LoadEmployeeList()
        {
            lstCurrentEmployees.DataSource = _employeeProfileRepository.GetActives();
            lstCurrentEmployees.DisplayMember = "ToString";
        }

        private void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            txtDistrict.Clear();
            txtTC.Clear();
            txtConfirmPassword.Clear();
            txtPassword.Clear();
            txtAddress.Clear();
            txtCity.Clear();

            cmbManager.SelectedIndex = -1;
            cmbRole.SelectedIndex = -1;
        }

        private bool AreFieldsEmpty()
        {
            return txtFirstName.Text == "" ||
                      txtLastName.Text == "" ||
                      txtPhoneNumber.Text == "" ||
                      txtEmail.Text == "" ||
                      txtDistrict.Text == "" ||
                      txtTC.Text == "" ||
                      txtConfirmPassword.Text == "" ||
                      txtPassword.Text == "" ||
                      txtAddress.Text == "" ||
                      txtCity.Text == "";
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {

        }
    }
}

