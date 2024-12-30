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


        // çalışan ve çalışan detaylarını temsil edecek nesneler tanımlanır.
        Employee _Employee;
        EmployeeProfile _Profile;



        public AddEmployeeForm()
        {
            InitializeComponent();
            _employeeRepository= new EmployeeRepository();
            _employeeProfileRepository= new EmployeeProfileRepository();


        }

      

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            // Tüm alanların doldurulup doldurulmadığını kontrol eder.
            if (IsAllFieldsFilled()) //Eger herhangi bir textboximiz bos ise bu bloga girer
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

         

            if (!_employeeRepository.IsValidPassword(txtPassword.Text))
            {
                MessageBox.Show("Geçersiz şifre formatı. Lütfen en az 8 karakterli şifre belirleyiniz.");
                return;
            }

            // Girilen şifrelerin birbirine eşit olup olmadığını kontrol eder.
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Şifreler birbiri ile uyuşmamaktadır. Lütfen kontrol ediniz.");
                txtConfirmPassword.Text = "";
                return;
            }

            // Girilen e-posta formatını doğrular.
            if (!_employeeRepository.IsValidEmailFormat(txtEmail.Text))
            {
                MessageBox.Show("Geçersiz e-posta formatı. Lütfen doğru bir e-posta adresi giriniz.");
                return;
            }

            // Yeni çalışan nesnesi oluşturulur.
            _Employee = new Employee
            {
                
                Email = txtEmail.Text,
                Role = (EmployeeRole)cmbRole.SelectedItem,
                ManagerId=(int)cmbManager.SelectedItem,
                Password = txtPassword.Text
            };

            // Yeni çalışan detayı nesnesi oluşturulur.
            _Profile = new EmployeeProfile
            {
               FirstName = txtFirstName.Text,
               LastName = txtLastName.Text,
               TC = txtTC.Text,
               PhoneNumber = txtPhoneNumber.Text,
               Address = txtAddress.Text,
               City = txtCity.Text,
               District = txtDistrict.Text,
            };

            _employeeProfileRepository.Add(_Profile);
            MessageBox.Show("Çalışan başarıyla eklendi");
            ClearFields();
            LoadEmployee();
           



        }

        public bool IsAllFieldsFilled()
        {
            return txtFirstName.Text == "" || txtLastName.Text == "" || txtPhoneNumber.Text == "" || txtEmail.Text == "" || txtDistrict.Text == "" || txtTC.Text == "" || txtConfirmPassword.Text == "" || txtPassword.Text =="" || txtAddress.Text == "" || txtCity.Text =="";
        }


        private void ClearFields()
        {
            txtFirstName.Clear();
            txtAddress.Clear();
            txtLastName.Clear();
            txtCity.Clear();
            txtDistrict.Clear();
            txtConfirmPassword.Clear();
            txtPassword.Clear();
            txtPhoneNumber.Clear();
            txtEmail.Clear();
             
            cmbManager.SelectedIndex = -1; // ComboBox seçimini kaldır
            cmbRole.SelectedIndex = -1;
        }
        private void LoadEmployee()
        {
            lstCurrentEmployees.DataSource = null; // Önce listeyi sıfırla
            lstCurrentEmployees.DataSource = _employeeProfileRepository.GetAll(); // Tüm lokasyonları getir
            lstCurrentEmployees.DisplayMember = "ToString"; 
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            RoleControls();
            manageControls();
        }

        // ComboBox ve ListBox'a enum değerlerini ekleme
        private void RoleControls()
        {
            // Enum değerlerini listeye çevir
            var roles = Enum.GetValues(typeof(EmployeeRole))
                            .Cast<EmployeeRole>()
                            .ToList();

            // ComboBox doldurma
            cmbRole.DataSource = roles;
            cmbRole.SelectedIndex = -1; // İlk eleman seçili (boş) olur
        }

        private void manageControls()
        {
            // Veri kaynağını oluşturun
            var managers = _employeeRepository
                           .Where(x => x.Role == EmployeeRole.Admin)
                           .Select(x => new
                           {
                               FullName = x.Profile.FirstName + " " + x.Profile.LastName,
                               ManagerId = x.ManagerId
                           })
                           .ToList();

            // ComboBox'a veri kaynağını bağlayın
            cmbManager.DataSource = managers;
            cmbManager.DisplayMember = "FullName"; // Görüntülenen alan
            cmbManager.ValueMember = "ManagerId"; // Seçilen öğenin değerini temsil eden alan

        }

    }
}

