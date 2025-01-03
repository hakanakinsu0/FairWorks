using Project.BLL.DesignPatterns.GenericRepository.EFConcRep;
using Project.ENTITIES.Models;
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

namespace Project.WinFormUI.Forms
{
    public partial class RegisterForm : Form
    {
        // Repository sınıfları aracılığıyla veritabanı işlemlerini gerçekleştirmek için örnekler oluşturulur.
        CustomerRepository _customerRepository;
        CustomerDetailRepository _customerDetailRepository;

        // Müşteri ve müşteri detaylarını temsil edecek nesneler tanımlanır.
        Customer _customer;
        CustomerDetail _customerDetail;

        public RegisterForm()
        {
            InitializeComponent();

            _customerRepository = new CustomerRepository();
            _customerDetailRepository = new CustomerDetailRepository();
        }

        // İptal butonuna basıldığında formu kapatır.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Kaydet butonuna basıldığında çalışacak olan metot.
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Tüm alanların doldurulup doldurulmadığını kontrol eder.
            if (IsAllFieldsFilled()) //Eger herhangi bir textboximiz bos ise bu bloga girer
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            // Girilen e-posta formatını doğrular.
            if (!_customerRepository.IsValidEmailFormat(txtContactEMail.Text))
            {
                MessageBox.Show("Geçersiz e-posta formatı. Lütfen doğru bir e-posta adresi giriniz.");
                return;
            }

            // Girilen telefon numarasının formatını doğrular.
            if (!_customerDetailRepository.IsValidPhoneNumber(txtContactPhoneNumber.Text))
            {
                MessageBox.Show("Geçersiz telefon numarası formatı. Lütfen doğru bir telefon numarası giriniz.");
                return;
            }

            // Şifrenin geçerli bir formatta olup olmadığını kontrol eder.
            if (!_customerRepository.IsValidPassword(txtPassword.Text))
            {
                MessageBox.Show("Geçersiz şifre formatı. Lütfen en az 8 karakterli şifre belirleyiniz.");
                return;
            }

            // Girilen e-postanın zaten kayıtlı olup olmadığını kontrol eder.
            if (_customerRepository.IsEmailRegistered(txtContactEMail.Text))
            {
                MessageBox.Show("Bu email sistemde kayıtlıdır. Lütfen geçerli bir email giriniz.");
                txtContactEMail.Text = "";
                return;
            }

            // Girilen şifrelerin birbirine eşit olup olmadığını kontrol eder.
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Şifreler birbiri ile uyuşmamaktadır. Lütfen kontrol ediniz.");
                txtConfirmPassword.Text = "";
                return;
            }

            // Yeni müşteri nesnesi oluşturulur.
            _customer = new Customer
            {
                ContactEMail = txtContactEMail.Text,
                Password = PasswordEncryptor.Encode(txtPassword.Text),
            };

            // Yeni müşteri detayı nesnesi oluşturulur.
            _customerDetail = new CustomerDetail
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                CompanyName = txtCompanyName.Text,
                ContactPhoneNumber = txtContactPhoneNumber.Text
            };

            try
            {
                // Müşteri ve müşteri detayı birlikte kayıt edilir.
                _customerRepository.Add(_customer);
                _customerDetail.Id = _customer.Id;
                _customerDetailRepository.Add(_customerDetail);

                MessageBox.Show("Kayıt başarılı bir şekilde tamamlanmıştır.");
                Close(); // İşlem tamamlandıktan sonra formu kapatır.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Hata mesajını kullanıcıya gösterir.
            }
        }

        // Tüm alanların doldurulup doldurulmadığını kontrol eden yardımcı metot.
        private bool IsAllFieldsFilled()
        {
            return txtFirstName.Text == "" || txtLastName.Text == "" || txtCompanyName.Text == "" || txtContactPhoneNumber.Text == "" || txtContactEMail.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "";
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
