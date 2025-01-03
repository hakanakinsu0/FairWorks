using Project.BLL.DesignPatterns.GenericRepository.EFConcRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinFormUI.Forms.CustomerForms
{
    public partial class FairPriceOfferForm : Form
    {
        public Customer LoggedInCustomer { get; set; }
        public Building SelectedBuilding { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> SelectedServices { get; set; }

        public string FairName { get; set; } // CustomerDashboard'dan alınacak fuar ismi


        public Fair SelectedFair { get; set; } // Fuar bilgisi ödeme ekranına aktarılacak


        public FairPriceOfferForm()
        {
            InitializeComponent();

        }

        private void FairPriceOfferForm_Load(object sender, EventArgs e)
        {
            // Özet bilgilerini oluşturarak lblPriceOfferDetails label'ına yükle
            StringBuilder priceOfferDetails = new StringBuilder();

            // Toplam maliyet
            priceOfferDetails.AppendLine($"Toplam Teklif Edilen Fiyat:\n {TotalCost:C2}");

            // Bilgileri lblPriceOfferDetails'a ata
            lblPriceOfferDetails.Text = priceOfferDetails.ToString();

            // Yeni teklif için kontroller başlangıçta gizlenir
            txtCustomerOffer.Visible = false;
            lblNewOffer.Visible = false;
            btnCancelNewOffer.Visible = false;
            btnGonder.Visible = false;
            label1.Visible = false;
        }

        private void btnAcceptOffer_Click(object sender, EventArgs e)
        {
            try
            {
                // Fuar nesnesi oluşturuluyor
                Fair newFair = new Fair
                {
                    Name = string.IsNullOrWhiteSpace(FairName)
                       ? "Belirtilmemiş Fuar" // Eğer müşteri bir isim belirtmezse
                       : FairName,            // CustomerDashboard'dan gelen değer
                    RequestedStartDate = StartDate,
                    CalculatedStartDate = StartDate,
                    EndDate = EndDate,
                    TotalCost = TotalCost,
                    BasePreparationTime = 5,
                    PreparationDays = (EndDate - StartDate).Days,
                    CustomerId = LoggedInCustomer.Id,
                    BuildingId = SelectedBuilding.Id,
                    IsDelayed = false
                };

                // Repository üzerinden ekleme işlemi yapılır
                FairRepository fairRepo = new FairRepository();
                fairRepo.Add(newFair);

                // Eklenen fuarı veritabanından tekrar al
                SelectedFair = fairRepo.FirstOrDefault(f => f.Name == newFair.Name && f.CustomerId == LoggedInCustomer.Id);

                if (SelectedFair == null || SelectedFair.Id == 0)
                {
                    MessageBox.Show("Fuar kaydı alınamadı. Lütfen tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kullanıcıya başarılı mesajı gösteriliyor
                MessageBox.Show("Teklif kabul edildi ve fuar oluşturuldu! Ödeme ekranına yönlendiriliyorsunuz.",
                                "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // PaymentForm açılıyor
                PaymentForm paymentForm = new PaymentForm
                {
                    LoggedInCustomer = LoggedInCustomer,
                    SelectedFair = SelectedFair, // Seçilen fuar aktarılıyor
                    TotalCost = TotalCost
                };

                paymentForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fuar oluşturulurken bir hata oluştu: {ex.Message}\nInner Exception: {ex.InnerException?.Message}",
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      


        private void btnDeclineOffer_Click(object sender, EventArgs e)
        {
            // Müşterinin talep ettiği fiyatı almak için kontrolleri göster
            txtCustomerOffer.Visible = true;
            lblNewOffer.Visible = true;
            btnCancelNewOffer.Visible = true;
            btnGonder.Visible = true;
            label1.Visible = true;

            MessageBox.Show("Lütfen talep ettiğiniz fiyatı giriniz.", "Teklif Alınıyor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // İptal işlemi
            Close();
        }


        private void btnCancelNewOffer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeni teklif süreci iptal edildi. Fuar oluşturulmadı.", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtCustomerOffer.Text, out decimal customerOffer) || customerOffer <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir fiyat giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // %10 indirimli fiyat
            decimal discountedPrice = TotalCost * 0.9m;

            // Yeni teklif hesaplama
            decimal finalOffer = discountedPrice >= customerOffer
                ? discountedPrice
                : (discountedPrice + customerOffer) / 2;

            lblNewOffer.Text = $"Yeni Teklif Edilen Fiyat: {finalOffer:C2}";

            // Müşteri onaylarsa ödeme ekranına yönlendirme
            DialogResult result = MessageBox.Show($"Yeni teklif sunuldu: {finalOffer:C2}\nOnaylıyor musunuz?",
                                                   "Yeni Teklif", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Fair newFair = new Fair
                {
                    Name = string.IsNullOrWhiteSpace(FairName)
                       ? "Belirtilmemiş Fuar" // Eğer müşteri bir isim belirtmezse
                       : FairName,            // CustomerDashboard'dan gelen değer
                    RequestedStartDate = StartDate,
                    CalculatedStartDate = StartDate,
                    EndDate = EndDate,
                    TotalCost = finalOffer,
                    BasePreparationTime = 5,
                    PreparationDays = (EndDate - StartDate).Days,
                    CustomerId = LoggedInCustomer.Id,
                    BuildingId = SelectedBuilding.Id,
                    IsDelayed = false
                };

                FairRepository fairRepo = new FairRepository();
                fairRepo.Add(newFair);

                SelectedFair = fairRepo.FirstOrDefault(f => f.Name == newFair.Name && f.CustomerId == LoggedInCustomer.Id);

                if (SelectedFair == null || SelectedFair.Id == 0)
                {
                    MessageBox.Show("Fuar kaydı alınamadı. İşlem iptal edildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PaymentForm paymentForm = new PaymentForm
                {
                    LoggedInCustomer = LoggedInCustomer,
                    SelectedFair = SelectedFair, // Seçilen fuar aktarılıyor
                    TotalCost = finalOffer
                };

                paymentForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Fuar iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
