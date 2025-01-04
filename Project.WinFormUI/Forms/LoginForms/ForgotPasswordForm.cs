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
    public partial class ForgotPasswordForm : Form
    {
        // Repositories: Veri tabanı işlemleri için gerekli olan repository nesneleri.
        CustomerDetailRepository _customerDetailRepository;
        CustomerRepository _customerRepository;

        // Müşteri bilgilerini tutacak nesne
        Customer _customer;

        public ForgotPasswordForm()
        {
            InitializeComponent();

            // Başlangıçta şifre ile ilgili kontrolleri gizler
            KontrolleriGizle(false);

            // Repositories örneklerini oluştur
            _customerDetailRepository = new CustomerDetailRepository();
            _customerRepository = new CustomerRepository();
        }

        // İptal butonuna basıldığında formu kapatır
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Submit butonuna basıldığında müşterinin bilgilerini kontrol eder
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Eğer zorunlu alanlardan biri boşsa hata mesajı göster
            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtCompanyName.Text == "" || txtContactEMail.Text == "")
            {
                ShowError("Lütfen tüm alanları doldurunuz.");
                return;
            }

            // Girilen bilgilerin doğruluğunu kontrol et
            if (!_customerDetailRepository.ValidateCustomerDetails(txtFirstName.Text, txtLastName.Text, txtCompanyName.Text, txtContactEMail.Text))
            {
                ShowError("Girdiğiniz bilgiler doğru değil. Lütfen kontrol ediniz.");
                return;
            }

            else KontrolleriGizle(true); // Kontroller doğruysa şifre giriş alanlarını görünür hale getir
        }

        // Şifreyi kaydet butonuna basıldığında işlemleri gerçekleştirir
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Eğer şifre alanlarından biri boşsa hata mesajı göster
            if (txtPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                ShowError("Lütfen tüm alanları doldurunuz.");
                return;
            }

            // Şifrelerin birbirine eşit olup olmadığını kontrol eder
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowError("Şifreler birbiri ile uyuşmamaktadır. Lütfen kontrol ediniz.");
                txtConfirmPassword.Text = ""; // Uyum olmadığında şifreyi temizler
                return;
            }

            // Şifre formatını kontrol eder (örneğin en az 8 karakter)
            if (!_customerRepository.IsValidPassword(txtPassword.Text))
            {
                ShowError("Geçersiz şifre formatı. Lütfen en az 8 karakterli şifre belirleyiniz.");
                return;
            }

            // E-posta adresine göre müşteri bilgilerini getirir
            _customer = _customerRepository.GetByEmail(txtContactEMail.Text);

            // Eğer müşteri bulunamazsa hata mesajı göster
            if (_customer == null)
            {
                ShowError("Müşteri bulunamadı. Lütfen tekrar deneyiniz.");
                return;
            }

            // Yeni şifreyi şifreleyerek kaydeder
            _customer.Password = PasswordEncryptor.Encode(txtPassword.Text);

            // Kullanıcının şifresini günceller ve işlem sonucunda bilgilendirme mesajı gösterir.
            try
            {
                _customerRepository.UpdatePassword(txtContactEMail.Text, txtPassword.Text);
                ShowInfo("Şifre başarılı bir şekilde güncellenmiştir.");
                Close();
            }

            // Şifre güncelleme sırasında bir hata oluşursa, hata mesajını kullanıcıya bildirir.
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        // Şifre giriş alanlarını görünür veya gizli hale getirir
        private void KontrolleriGizle(bool visiable)
        {
            label5.Visible = visiable;
            label6.Visible = visiable;
            label7.Visible = visiable;
            txtPassword.Visible = visiable;
            txtConfirmPassword.Visible = visiable;
            btnSave.Visible = visiable;
        }

        //Kullanıcıya bir hata mesajı göstermek için kullanılan yardımcı metot.
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Kullanıcıya bilgilendirme mesajı göstermek için kullanılan yardımcı metot.
        private void ShowInfo(string message)
        {
            MessageBox.Show(message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
