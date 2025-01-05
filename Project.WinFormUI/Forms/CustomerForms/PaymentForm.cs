using Project.BLL.DesignPatterns.GenericRepository.EFConcRep;
using Project.ENTITIES.Enums;
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

namespace Project.WinFormUI.Forms.CustomerForms
{
    public partial class PaymentForm : Form
    {
        public Customer LoggedInCustomer { get; set; }  // Giriş yapan müşteri bilgisi
        public Fair SelectedFair { get; set; }  // Seçilen fuar bilgisi
        public decimal TotalCost { get; set; }  // Toplam maliyet bilgisi

        public PaymentForm()
        {
            InitializeComponent();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            // Toplam tutarı label'da göster
            lblTotalCost.Text = $"Toplam Tutar: {TotalCost:C2}";

            // PaymentMethod enum'undaki değerleri ComboBox'a yükle
            cmbPaymentMethod.DataSource = Enum.GetValues(typeof(PaymentMethod));
            cmbPaymentMethod.SelectedIndex = -1; // Varsayılan seçim yok
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            // Fuar kaydının geçerli olup olmadığını kontrol et
            if (SelectedFair == null || SelectedFair.Id == 0)
            {
                MessageBox.Show("Fuar bilgisi eksik veya hatalı. Ödeme işlemi gerçekleştirilemez.",
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbPaymentMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir ödeme yöntemi seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ödeme yöntemi belirleniyor
            PaymentMethod selectedMethod = (PaymentMethod)cmbPaymentMethod.SelectedItem;

            // Ödeme nesnesi oluşturuluyor
            Payment payment = new Payment
            {
                FairId = SelectedFair.Id, // Doğru FairId atanıyor
                Amount = TotalCost,
                PaymentDate = DateTime.Now,
                PaymentMethod = selectedMethod,
                PaymentStatus = PaymentStatus.Paid, // Başlangıçta başarılı olarak işaretleniyor
                RefundStatus = RefundStatus.None
            };

            try
            {
                PaymentRepository paymentRepo = new PaymentRepository();
                if (paymentRepo.ProcessPayment(payment, out string errorMessage))
                {
                    MessageBox.Show("Ödeme başarıyla tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CloseAllFairRelatedForms(); // Tüm ilgili formları kapat
                }
                else
                {
                    MessageBox.Show($"Ödeme sırasında bir hata oluştu: {errorMessage}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ödeme sırasında bir hata oluştu: {ex.Message}\nInner Exception: {ex.InnerException?.Message}",
                                 "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*************Form Metotlari**********************/
        private void CloseAllFairRelatedForms()
        {
            // Fair ile ilgili açık formları kapatır
            FairServicesForm fairServicesForm = Application.OpenForms.OfType<FairServicesForm>().FirstOrDefault();
            FairSummaryForm fairSummaryForm = Application.OpenForms.OfType<FairSummaryForm>().FirstOrDefault();
            FairPriceOfferForm fairPriceOfferForm = Application.OpenForms.OfType<FairPriceOfferForm>().FirstOrDefault();

            fairServicesForm.Close();
            fairSummaryForm.Close();
            fairPriceOfferForm.Close();
            Close();
        }
    }
}
