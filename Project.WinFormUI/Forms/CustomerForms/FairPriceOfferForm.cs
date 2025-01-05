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
        public Customer LoggedInCustomer { get; set; }// Giriş yapan müşteri bilgisi.
        public Building SelectedBuilding { get; set; }// Seçilen bina bilgisi.
        public decimal TotalCost { get; set; }// Toplam maliyet bilgisi.
        public DateTime StartDate { get; set; }// Fuar başlangıç tarihi.
        public DateTime EndDate { get; set; }// Fuar bitiş tarihi.
        public List<string> SelectedServices { get; set; }// Seçilen hizmetlerin listesi.
        public string FairName { get; set; }// Fuar adı.

        // Hesaplanan başlangıç tarihi.
        public DateTime CalculatedStartDate { get; set; } // Eksik olan özelliği tanımladık.                                                
        public Fair SelectedFair { get; set; }   // Seçilen fuar bilgisi.

        
        // Formun yapıcı metodu.
        public FairPriceOfferForm()
        {
            InitializeComponent(); // Formun bileşenlerini başlatır.
        }

        private void FairPriceOfferForm_Load(object sender, EventArgs e)
        {
            // Fiyat teklifi özet bilgilerini oluşturmak için StringBuilder kullanılır.
            string priceOfferDetails = "";

            // Toplam teklif edilen fiyatı ekle.
            priceOfferDetails += ($"Toplam Teklif Edilen Fiyat:\n {TotalCost:C2}");

            // Oluşturulan bilgiyi lblPriceOfferDetails etiketine ata.
            lblPriceOfferDetails.Text = priceOfferDetails.ToString();

            // Yeni teklif girişine ait kontroller başlangıçta gizlenir.
            txtCustomerOffer.Visible = false; // Kullanıcı teklif giriş alanı.
            lblNewOffer.Visible = false;      // Yeni teklif açıklama etiketi.
            btnCancelNewOffer.Visible = false; // İptal butonu.
            btnGonder.Visible = false;        // Gönder butonu.
            label1.Visible = false;           // Ek etiket.
        }

        private void btnAcceptOffer_Click(object sender, EventArgs e)
        {
            try
            {
                // Bina doluluk kontrolü
                if (!IsBuildingAvailable(SelectedBuilding, CalculatedStartDate, EndDate))
                {
                    // Eğer bina belirtilen tarihlerde rezerve edilmişse uyarı mesajı göster ve işlemi durdur.
                    MessageBox.Show("Seçilen tarihlerde bina başka bir fuar için rezerve edilmiştir.", "Tarih Çakışması", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Toplam hazırlık süresini hesapla.
                int preparationDays = CalculatePreparationDays();

                // Yeni fuar nesnesi oluştur.
                Fair newFair = new Fair
                {
                    Name = string.IsNullOrWhiteSpace(FairName) ? "Belirtilmemiş Fuar" : FairName, // Fuar adı yoksa varsayılan isim kullanılır.
                    RequestedStartDate = StartDate, // Kullanıcının istediği başlangıç tarihi.
                    CalculatedStartDate = CalculatedStartDate, // Hesaplanan başlangıç tarihi.
                    EndDate = EndDate, // Fuar bitiş tarihi.
                    TotalCost = TotalCost, // Toplam maliyet.
                    BasePreparationTime = preparationDays, // Temel hazırlık süresi.
                    PreparationDays = preparationDays, // Gerçek hazırlık süresi.
                    CustomerId = LoggedInCustomer.Id, // Giriş yapan müşterinin ID'si.
                    BuildingId = SelectedBuilding.Id, // Seçilen binanın ID'si.
                    IsDelayed = false // Fuar gecikmiş mi? Varsayılan olarak hayır.
                };

                // Fuarı eklemek için repository kullan.
                FairRepository fairRepo = new FairRepository();
                fairRepo.Add(newFair);

                // Eklenen fuarı tekrar getir.
                SelectedFair = fairRepo.FirstOrDefault(f => f.Name == newFair.Name && f.CustomerId == LoggedInCustomer.Id);

                // Eğer fuar eklenememişse hata mesajı göster.
                if (SelectedFair == null || SelectedFair.Id == 0)
                {
                    MessageBox.Show("Fuar kaydı alınamadı. Lütfen tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Başarılı işlem mesajı göster.
                MessageBox.Show("Teklif kabul edildi ve fuar oluşturuldu! Ödeme ekranına yönlendiriliyorsunuz.",
                                "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ödeme formunu aç.
                PaymentForm paymentForm = new PaymentForm
                {
                    LoggedInCustomer = LoggedInCustomer, // Giriş yapan müşteri bilgisi.
                    SelectedFair = SelectedFair, // Yeni oluşturulan fuar bilgisi.
                    TotalCost = TotalCost // Toplam maliyet.
                };

                paymentForm.ShowDialog(); // Ödeme formunu göster.
                this.Close(); // Mevcut formu kapat.
            }
            catch (Exception ex)
            {

                // Hata oluşursa mesaj kutusunda detayları göster.
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
            // Kullanıcı yeni teklif sürecini iptal ettiğinde bilgilendirme mesajı gösterilir.
            MessageBox.Show("Yeni teklif süreci iptal edildi. Fuar oluşturulmadı.", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close(); // Form kapatılır.
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {// Kullanıcının girdiği fiyatın geçerli bir sayı olup olmadığını kontrol eder.
            if (!decimal.TryParse(txtCustomerOffer.Text, out decimal customerOffer) || customerOffer <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir fiyat giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Yeni teklif hesaplama işlemi
            FairRepository fairRepo = new FairRepository();
            decimal finalOffer = fairRepo.CalculateFinalOffer(TotalCost, customerOffer);
           
            // Kullanıcının girdiği teklif, önerilen fiyatın üzerinde olamaz.
            if (customerOffer > finalOffer)
            {
                MessageBox.Show("Girdiğiniz fiyat, önerilen fiyatın üzerinde olamaz. Lütfen daha düşük bir fiyat giriniz.",
                                "Geçersiz Teklif", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Yeni teklif edilen fiyatı etikete yazdır.
            lblNewOffer.Text = $"Yeni Teklif Edilen Fiyat: {finalOffer:C2}";

            // Kullanıcıdan yeni teklifi onaylaması istenir.
            DialogResult result = MessageBox.Show($"Yeni teklif sunuldu: {finalOffer:C2}\nOnaylıyor musunuz?",
                                                  "Yeni Teklif", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {// Toplam hazırlık süresini hesaplar.
                    int preparationDays = CalculatePreparationDays();

                    // Yeni bir fuar nesnesi oluştur.
                    Fair newFair = new Fair
                    {
                        Name = string.IsNullOrWhiteSpace(FairName) ? "Belirtilmemiş Fuar" : FairName,
                        RequestedStartDate = StartDate, // İstenilen başlangıç tarihi
                        CalculatedStartDate = StartDate, // Hesaplanan başlangıç tarihi
                        EndDate = EndDate, // Fuar bitiş tarihi
                        TotalCost = finalOffer, // Yeni teklif edilen toplam maliyet
                        BasePreparationTime = preparationDays, // Bina ve ek hizmetlerin hazırlık süresi
                        PreparationDays = preparationDays, // Hazırlık süresi
                        CustomerId = LoggedInCustomer.Id, // Müşteri kimliği
                        BuildingId = SelectedBuilding.Id, // Seçilen bina kimliği
                        IsDelayed = false // Gecikme durumu (varsayılan olarak hayır)
                    };
                    // Yeni fuar kaydını ekler.
                    SelectedFair = fairRepo.AddFair(newFair);

                    // Fuar kaydının başarılı olup olmadığını kontrol eder.
                    if (SelectedFair == null || SelectedFair.Id == 0)
                    {
                        MessageBox.Show("Fuar kaydı alınamadı. İşlem iptal edildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Ödeme formunu açar.
                    PaymentForm paymentForm = new PaymentForm
                    {
                        LoggedInCustomer = LoggedInCustomer, // Giriş yapan müşteri bilgisi
                        SelectedFair = SelectedFair, // Yeni oluşturulan fuar bilgisi
                        TotalCost = finalOffer // Yeni teklif edilen toplam maliyet
                    };

                    paymentForm.ShowDialog(); // Ödeme formunu göster.
                    Close(); // Mevcut formu kapat.
                }
                catch (Exception ex)
                {
                    // Hata durumunda detaylı mesaj gösterilir.
                    MessageBox.Show($"Fuar oluşturulurken bir hata oluştu: {ex.Message}\nInner Exception: {ex.InnerException?.Message}",
                                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Kullanıcı yeni teklifi onaylamazsa bilgilendirme mesajı gösterilir.
                MessageBox.Show("Fuar iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close(); // Form kapatılır.
            }
        }


        /******************Form Metotlari****************************/
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
                foreach (string serviceName in SelectedServices)
                {
                    // Burada hizmetlerin hazırlık sürelerini almanız gerekecek
                    // Örneğin: ServiceValueRepository'den süreleri alarak ekleme yapabilirsiniz
                    ServiceValueRepository serviceValueRepo = new ServiceValueRepository();
                    ServiceValue serviceValue = serviceValueRepo.FirstOrDefault(sv => sv.Name == serviceName);
                    if (serviceValue != null)
                    {
                        preparationDays += serviceValue.PreparationTime; // Hizmet için hazırlık süresi
                        preparationDays += serviceValue.BufferTime;      // Hizmet için tampon süre
                    }
                }
            }

            return preparationDays;
        }

        private bool IsBuildingAvailable(Building building, DateTime calculatedStartDate, DateTime endDate)
        {
            FairRepository fairRepo = new FairRepository();

            // Binadaki mevcut fuarları al
            List<Fair> existingFairs = fairRepo.Where(f => f.BuildingId == building.Id).ToList();

            foreach (Fair fair in existingFairs)
            {
                // Hesaplanan başlangıç ve bitiş tarihleri ile çakışma kontrolü
                if (calculatedStartDate < fair.EndDate && endDate > fair.CalculatedStartDate)
                {
                    return false; // Çakışma var
                }
            }

            return true; // Çakışma yok
        }
    }
}
