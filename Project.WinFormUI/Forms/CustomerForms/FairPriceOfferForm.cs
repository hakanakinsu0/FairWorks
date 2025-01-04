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
        public string FairName { get; set; }
        public DateTime CalculatedStartDate { get; set; } // Eksik olan özelliği tanımladık

        public Fair SelectedFair { get; set; }


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

        private int CalculatePreparationDays()
        {
            int preparationDays = 0;

            // Bina hazırlık süresi
            if (SelectedBuilding != null)
            {
                preparationDays += SelectedBuilding.NumberOfFloor * 3; // Kat başına 3 gün
                preparationDays += SelectedBuilding.RoomPerFloor * 2;  // Oda başına 2 gün
            }

            // Ek hizmetlerin hazırlık ve tampon sürelerini ekle
            if (SelectedServices != null && SelectedServices.Any())
            {
                foreach (var serviceName in SelectedServices)
                {
                    // Burada hizmetlerin hazırlık sürelerini almanız gerekecek
                    // Örneğin: ServiceValueRepository'den süreleri alarak ekleme yapabilirsiniz
                    var serviceValueRepo = new ServiceValueRepository();
                    var serviceValue = serviceValueRepo.FirstOrDefault(sv => sv.Name == serviceName);
                    if (serviceValue != null)
                    {
                        preparationDays += serviceValue.PreparationTime; // Hizmet için hazırlık süresi
                        preparationDays += serviceValue.BufferTime;      // Hizmet için tampon süre
                    }
                }
            }

            return preparationDays;
        }

        private void btnAcceptOffer_Click(object sender, EventArgs e)
        {
            try
            {
                // Bina doluluk kontrolü
                if (!IsBuildingAvailable(SelectedBuilding, CalculatedStartDate, EndDate))
                {
                    MessageBox.Show("Seçilen tarihlerde bina başka bir fuar için rezerve edilmiştir.", "Tarih Çakışması", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Toplam hazırlık süresini hesapla
                int preparationDays = CalculatePreparationDays();

                // Yeni fuar nesnesi oluştur
                Fair newFair = new Fair
                {
                    Name = string.IsNullOrWhiteSpace(FairName) ? "Belirtilmemiş Fuar" : FairName,
                    RequestedStartDate = StartDate,
                    CalculatedStartDate = CalculatedStartDate,
                    EndDate = EndDate,
                    TotalCost = TotalCost,
                    BasePreparationTime = preparationDays,
                    PreparationDays = preparationDays,
                    CustomerId = LoggedInCustomer.Id,
                    BuildingId = SelectedBuilding.Id,
                    IsDelayed = false
                };

                FairRepository fairRepo = new FairRepository();
                fairRepo.Add(newFair);

                // Eklenen fuarı tekrar al
                SelectedFair = fairRepo.FirstOrDefault(f => f.Name == newFair.Name && f.CustomerId == LoggedInCustomer.Id);

                if (SelectedFair == null || SelectedFair.Id == 0)
                {
                    MessageBox.Show("Fuar kaydı alınamadı. Lütfen tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Teklif kabul edildi ve fuar oluşturuldu! Ödeme ekranına yönlendiriliyorsunuz.",
                                "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ödeme formunu aç
                PaymentForm paymentForm = new PaymentForm
                {
                    LoggedInCustomer = LoggedInCustomer,
                    SelectedFair = SelectedFair,
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

        private bool IsBuildingAvailable(Building building, DateTime calculatedStartDate, DateTime endDate)
        {
            FairRepository fairRepo = new FairRepository();

            // Binadaki mevcut fuarları al
            var existingFairs = fairRepo.Where(f => f.BuildingId == building.Id).ToList();

            foreach (var fair in existingFairs)
            {
                // Hesaplanan başlangıç ve bitiş tarihleri ile çakışma kontrolü
                if (calculatedStartDate < fair.EndDate && endDate > fair.CalculatedStartDate)
                {
                    return false; // Çakışma var
                }
            }

            return true; // Çakışma yok
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

            // Yeni teklif hesaplama
            FairRepository fairRepo = new FairRepository();
            decimal finalOffer = fairRepo.CalculateFinalOffer(TotalCost, customerOffer);

            if (customerOffer > finalOffer)
            {
                MessageBox.Show("Girdiğiniz fiyat, önerilen fiyatın üzerinde olamaz. Lütfen daha düşük bir fiyat giriniz.",
                                "Geçersiz Teklif", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblNewOffer.Text = $"Yeni Teklif Edilen Fiyat: {finalOffer:C2}";

            DialogResult result = MessageBox.Show($"Yeni teklif sunuldu: {finalOffer:C2}\nOnaylıyor musunuz?",
                                                   "Yeni Teklif", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Toplam hazırlık süresini hesapla
                    int preparationDays = CalculatePreparationDays();

                    // Yeni fuar nesnesini oluştur
                    Fair newFair = new Fair
                    {
                        Name = string.IsNullOrWhiteSpace(FairName) ? "Belirtilmemiş Fuar" : FairName,
                        RequestedStartDate = StartDate,
                        CalculatedStartDate = StartDate,
                        EndDate = EndDate,
                        TotalCost = finalOffer,
                        BasePreparationTime = preparationDays, // Bina + Ek Hizmetler
                        PreparationDays = preparationDays,    // Aynı hazırlık süresi kaydediliyor
                        CustomerId = LoggedInCustomer.Id,
                        BuildingId = SelectedBuilding.Id,
                        IsDelayed = false
                    };

                    // Fuarı ekle
                    SelectedFair = fairRepo.AddFair(newFair);

                    if (SelectedFair == null || SelectedFair.Id == 0)
                    {
                        MessageBox.Show("Fuar kaydı alınamadı. İşlem iptal edildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Ödeme formunu aç
                    PaymentForm paymentForm = new PaymentForm
                    {
                        LoggedInCustomer = LoggedInCustomer,
                        SelectedFair = SelectedFair,
                        TotalCost = finalOffer
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
            else
            {
                MessageBox.Show("Fuar iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
