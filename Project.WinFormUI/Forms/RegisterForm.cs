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
    public partial class RegisterForm : Form
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        CustomerDetailRepository _customerDetailRepository = new CustomerDetailRepository();

        Customer _customer;
        CustomerDetail _customerDetail;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void TextboxlariSifirla()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtCompanyName.Text = "";
            txtContactPhoneNumber.Text = "";
            txtContactEMail.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtCompanyName.Text == "" || txtContactPhoneNumber.Text == "" || txtContactEMail.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "") //Eger herhangi bir textboximiz bos ise bu bloga girer
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            if (!_customerRepository.IsValidEmailFormat(txtContactEMail.Text))
            {
                MessageBox.Show("Geçersiz e-posta formatı. Lütfen doğru bir e-posta adresi giriniz.");
                return;
            }

            if (!_customerDetailRepository.IsValidPhoneNumber(txtContactPhoneNumber.Text))
            {
                MessageBox.Show("Geçersiz telefon numarası formatı. Lütfen doğru bir telefon numarası giriniz.");
                return;
            }
            if (!_customerRepository.IsValidPassword(txtPassword.Text))
            {
                MessageBox.Show("Geçersiz şifre formatı. Lütfen en az 8 karakterli şifre belirleyiniz.");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Şifreler birbiri ile uyuşmamaktadır. Lütfen kontrol ediniz.");
                txtConfirmPassword.Text = "";
                return;
            }

            if (_customerRepository.IsEmailRegistered(txtContactEMail.Text))
            {
                MessageBox.Show("Bu email sistemde kayıtlıdır. Lütfen geçerli bir email giriniz.");
                txtContactEMail.Text = "";
                return;
            }

            _customer = new Customer
            {
                ContactEMail = txtContactEMail.Text,
                Password = txtPassword.Text,
            };

            _customerDetail = new CustomerDetail
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                CompanyName = txtCompanyName.Text,
                ContactPhoneNumber = txtContactPhoneNumber.Text
            };
            try
            {
                _customerRepository.Add(_customer);
                _customerDetail.Id = _customer.Id;
                _customerDetailRepository.Add(_customerDetail);

                MessageBox.Show("Kayıt başarılı bir şekilde tamamlanmıştır.");

                TextboxlariSifirla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
