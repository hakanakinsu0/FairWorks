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
    public partial class ForgotPasswordForm : Form
    {
        CustomerDetailRepository _customerDetailRepository = new CustomerDetailRepository();
        CustomerRepository _customerRepository = new CustomerRepository();

        Customer _customer;

        public ForgotPasswordForm()
        {
            InitializeComponent();

            KontrolleriGizle(false);
        }

        private void KontrolleriGizle(bool visiable)
        {
            label5.Visible = visiable;
            label6.Visible = visiable;
            label7.Visible = visiable;
            txtPassword.Visible = visiable;
            txtConfirmPassword.Visible = visiable;
            btnSave.Visible = visiable;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtCompanyName.Text == "" || txtContactEMail.Text == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            if (!(_customerDetailRepository.IsFirstNameRegistered(txtFirstName.Text) || _customerDetailRepository.IsLastNameRegistered(txtLastName.Text) || _customerDetailRepository.IsCompanyNameRegistered(txtCompanyName.Text) || _customerRepository.IsEmailRegistered(txtContactEMail.Text)))
            {
                MessageBox.Show("Girdiğiniz bilgiler doğru değil. Lütfen kontrol ediniz.");
                return;
            }
            else
            {
                KontrolleriGizle(true);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Şifreler birbiri ile uyuşmamaktadır. Lütfen kontrol ediniz.");
                txtConfirmPassword.Text = "";
                return;
            }
            if (!_customerRepository.IsValidPassword(txtPassword.Text))
            {
                MessageBox.Show("Geçersiz şifre formatı. Lütfen en az 8 karakterli şifre belirleyiniz.");
                return;
            }

            _customer = _customerRepository.Where(x => x.ContactEMail == txtContactEMail.Text).FirstOrDefault();

            if (_customer == null)
            {
                MessageBox.Show("Müşteri bulunamadı. Lütfen tekrar deneyiniz.");
                return;
            }

            _customer.Password = txtPassword.Text;

            try
            {
                _customerRepository.Update(_customer);
                MessageBox.Show("Şifre başarılı bir şekilde güncellenmiştir.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
