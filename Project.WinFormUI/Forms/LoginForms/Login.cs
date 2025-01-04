using Project.BLL.DesignPatterns.GenericRepository.EFConcRep;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using Project.WinFormUI.Forms;
using Sifrelemeler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Project.WinFormUI
{
    public partial class Login : Form
    {
        // Repository'ler tanımlanır
        CustomerRepository _customerRepository;
        Customer _customer;

        EmployeeRepository _employeeRepository;
        
        public static int LoggedInCustomerId { get; private set; } // Static property ile global erişim. Giriş yapan müşterinin kimliğini (ID) uygulama boyunca kolayca erişilebilir bir şekilde tutmak için tanımlanmıştır.

        public Login()
        {
            InitializeComponent();

            //Repository'lerin ornekleri baslangicta alinir.
            _customerRepository = new CustomerRepository();
            _employeeRepository = new EmployeeRepository();
            _customer = new Customer();

            // Şifre giriş alanı gizlenir
            txtPassword.UseSystemPasswordChar = true;
        }

        // Kullanıcı kayıt ekranını açar
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            return;
        }

        // Şifremi unuttum ekranını açar
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.ShowDialog();
            return;
        }

        // Giriş işlemini gerçekleştirir
        private void btnLogin_Click(object sender, EventArgs e)
        {

            // E-posta ve şifre kontrolü
            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                ShowError("Lütfen e-posta ve şifre giriniz.");
                return;
            }

            // E-posta formatının doğruluğunu kontrol eder
            if (!_customerRepository.IsValidEmailFormat(txtEmail.Text))
            {
                ShowError("Geçersiz e-posta formatı. Lütfen doğru bir e-posta adresi giriniz.");
                return;
            }

            // Kullanıcının girdiği şifre encode edilir
            string encryptedPassword = PasswordEncryptor.Encode(txtPassword.Text);

            // Kullanıcı olup olmadığını kontrol eder
            if (_customerRepository.GetByEmailAndPassword(txtEmail.Text, encryptedPassword) != null)
            {
                Customer loggedInCustomer = _customerRepository.FirstOrDefault(c => c.ContactEMail == txtEmail.Text && c.Password == encryptedPassword);


                //LoggedInCustomerId = _customer.Id; // Giriş yapan müşterinin ID'sini sakla
                CustomerDashboard customerDashboard = new CustomerDashboard() { LoggedInCustomer=loggedInCustomer}; // Müşteri için dashboard formu
                customerDashboard.ShowDialog();
                TextboxlariTemizle();
                return;
            }

            // Çalışan olup olmadığını kontrol eder
            if (_employeeRepository.GetByEmailAndPassword(txtEmail.Text, encryptedPassword) != null)
            {
                EmployeeDashboard employeeDashboard = new EmployeeDashboard(); // Çalışan için dashboard formu
                employeeDashboard.ShowDialog();
                TextboxlariTemizle();
                return;
            }
            // Eğer hiçbir eşleşme bulunamazsa hata mesajı gösterilir
            ShowError("E-posta veya şifre hatalı.");
        }

        // Şifre göster/gizle checkbox'ının kontrol edildiğinde davranışı
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked; // Şifreyi göster veya gizle
        }

        //Textboxlara girilmis olan ifadeleri temizler.
        private void TextboxlariTemizle()
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
        }

        //Kullanıcıya bir hata mesajı göstermek için kullanılan yardımcı metot.
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
