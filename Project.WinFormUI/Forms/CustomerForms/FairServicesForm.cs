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

namespace Project.WinFormUI.Forms
{
    public partial class FairServicesForm : Form
    {
        private ServiceValueRepository _serviceValueRepository;
        private ServiceProviderServiceValueRepository _providerServiceValueRepository;

        public Building SelectedBuilding { get; set; }
        public decimal BuildingCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Customer LoggedInCustomer { get; set; }

        public string FairName { get; set; } // FairName özelliği eklendi

        public List<ServiceValue> SelectedServices { get; set; } = new List<ServiceValue>();

        public DateTime CalculatedStartDate { get; set; }

        public decimal FixedWaterCost { get; set; } = 2000m;  // Su tesisatı maliyeti
        public decimal FixedElectricityCost { get; set; } = 2000m;  // Elektrik tesisatı maliyeti





        public FairServicesForm()
        {
            InitializeComponent();
            // Repository'leri başlat
            _serviceValueRepository = new ServiceValueRepository();
            _providerServiceValueRepository = new ServiceProviderServiceValueRepository();

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
            foreach (var serviceValue in SelectedServices)
            {
                preparationDays += serviceValue.PreparationTime; // Hizmet için hazırlık süresi
                preparationDays += serviceValue.BufferTime;      // Hizmet için tampon süre
            }

            return preparationDays;
        }


        private void CheckPreparationDate()
        {
            int preparationDays = CalculatePreparationDays();
            DateTime today = DateTime.Now.Date; // Bugünün tarihi
            DateTime earliestStartDate = today.AddDays(preparationDays); // Hazırlık süresine göre önerilen başlangıç tarihi

            // Kullanıcı başlangıç tarihi kontrolü
            if (StartDate < earliestStartDate)
            {
                MessageBox.Show($"Seçilen tarih uygun değil. En erken başlanabilecek tarih: {earliestStartDate.ToShortDateString()}",
                                "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Kullanıcı başlangıç tarihini önerilen başlangıç tarihine ayarlıyoruz
                StartDate = earliestStartDate;
            }

            // CalculatedStartDate ve EndDate hesaplama
            CalculatedStartDate = StartDate;
            EndDate = CalculatedStartDate.AddDays((EndDate - StartDate).Days); // Kullanıcının belirttiği süre kadar ileri
        }



        private void FairServicesForm_Load(object sender, EventArgs e)
        {
            // Catering Hizmetleri yüklemeleri
            LoadSabahKahvaltisiOffers();
            LoadOgleYemegiOffers();
            LoadAksamYemegiOffers();
            LoadCayKahveServisiOffers();
            LoadAtistirmalikBufesiOffers();

            // Güvenlik Hizmetleri yüklemeleri
            LoadGeceGuvenlikOffers();
            LoadGunduzGuvenlikOffers();
            LoadVipOzelKorumaOffers();
            LoadKameraIzlemeOffers();

            // Yangın Önleme Hizmetleri yüklemeleri
            LoadYanginSondurmeOffers();
            LoadYanginAlarmOffers();
            LoadDumanDedektoruOffers();

            // Teknik Destek Hizmetleri yüklemeleri
            LoadBilgisayarAgDestegiOffers();
            LoadSesGoruntuSistemleriOffers();
            LoadElektrikAydinlatmaOffers();

            // Temizlik Hizmetleri yüklemeleri
            LoadGunlukGenelTemizlikOffers();
            LoadCopToplamaOffers();

            // Bina bilgisi
            if (SelectedBuilding != null)
            {
                lblBuildingDetails.Text = $"Seçilen Bina: {SelectedBuilding.Name}\n" +
                                          $"Adres: {SelectedBuilding.Address}\n" +
                                          $"Kat Sayısı: {SelectedBuilding.NumberOfFloor}\n" +
                                          $"Bina Maliyeti: {BuildingCost:C2}";
            }
            else
            {
                lblBuildingDetails.Text = "Bina bilgisi bulunamadı.";
            }


        }




        private void LoadServiceOffers(string serviceName, ListBox targetListBox)
        {
            try
            {
                // İlgili hizmet değerlerini alıyoruz
                var serviceValues = _serviceValueRepository
                    .Where(sv => sv.Name == serviceName)
                    .ToList();

                if (!serviceValues.Any())
                {
                    MessageBox.Show($"{serviceName} hizmeti için sağlayıcı bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    targetListBox.Items.Clear();
                    return;
                }

                // İlgili sağlayıcı-hizmet ilişkilerini alıyoruz
                var serviceValueIds = serviceValues.Select(sv => sv.Id).ToList();
                var providerServiceValues = _providerServiceValueRepository
                    .Where(psv => serviceValueIds.Contains(psv.ServiceValueId))
                    .ToList();

                // Sağlayıcı bilgilerini alıyoruz
                var serviceProviders = providerServiceValues
                    .Select(psv => psv.ServiceProvider)
                    .Where(sp => sp != null)
                    .Distinct()
                    .ToList();

                // ListBox'ı temizle ve yeni değerleri yükle
                targetListBox.Items.Clear();
                foreach (var serviceValue in serviceValues)
                {
                    var relatedProviders = providerServiceValues
                        .Where(psv => psv.ServiceValueId == serviceValue.Id)
                        .Select(psv => psv.ServiceProvider)
                        .ToList();

                    foreach (var provider in relatedProviders)
                    {
                        if (provider != null)
                        {
                            var item = new ListViewItem($"{provider.ProviderName} - Maliyet: {serviceValue.Cost:C2}")
                            {
                                Tag = serviceValue.Id // Tag içine ServiceValue ID ekliyoruz
                            };
                            targetListBox.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hizmet teklifleri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Catering Hizmetleri
        private void LoadSabahKahvaltisiOffers() => LoadServiceOffers("Sabah Kahvaltısı", lstSabahKahvaltisiOffers);
        private void LoadOgleYemegiOffers() => LoadServiceOffers("Öğle Yemeği", lstOgleYemegiOffers);
        private void LoadAksamYemegiOffers() => LoadServiceOffers("Akşam Yemeği", lstAksamYemegiOffers);
        private void LoadCayKahveServisiOffers() => LoadServiceOffers("Çay/Kahve Servisi", lstCayKahveOffers);
        private void LoadAtistirmalikBufesiOffers() => LoadServiceOffers("Atıştırmalık Büfesi", lstAtistirmalikOffers);

        // Güvenlik Hizmetleri
        private void LoadGeceGuvenlikOffers() => LoadServiceOffers("Gece Güvenlik Hizmeti", lstGeceGuvenlikOffers);
        private void LoadGunduzGuvenlikOffers() => LoadServiceOffers("Gündüz Güvenlik Hizmeti", lstGunduzGuvenlikOffers);
        private void LoadVipOzelKorumaOffers() => LoadServiceOffers("VIP Özel Koruma", lstVipOzelKorumaOffers);
        private void LoadKameraIzlemeOffers() => LoadServiceOffers("Kamera İzleme Sistemi", lstKameraIzlemeOffers);

        // Yangın Önleme Hizmetleri
        private void LoadYanginSondurmeOffers() => LoadServiceOffers("Yangın Söndürme Cihazı Kiralama", lstYanginSondurmeCihaziOffers);
        private void LoadYanginAlarmOffers() => LoadServiceOffers("Yangın Alarm Sistemi Kurulumu", lstYanginAlarmSistemiOffers);
        private void LoadDumanDedektoruOffers() => LoadServiceOffers("Duman Dedektörleri Kiralama", lstDumanDedektoruOffers);

        // Teknik Destek Hizmetleri
        private void LoadBilgisayarAgDestegiOffers() => LoadServiceOffers("Bilgisayar ve Ağ Desteği", lstBilgisayarAgDestegiOffers);
        private void LoadSesGoruntuSistemleriOffers() => LoadServiceOffers("Ses ve Görüntü Sistemleri Desteği", lstSesGoruntuDestegiOffers);
        private void LoadElektrikAydinlatmaOffers() => LoadServiceOffers("Elektrik ve Aydınlatma Sorunları Çözümü", lstElektrikAydinlatmaDestegiOffers);

        // Temizlik Hizmetleri
        private void LoadGunlukGenelTemizlikOffers() => LoadServiceOffers("Günlük Genel Temizlik", lstGunlukGenelTemizlikOffers);
        private void LoadCopToplamaOffers() => LoadServiceOffers("Çöp Toplama ve Atık Yönetimi", lstCopToplamaAtikYonetimiOffers);


        private void btnConfirmSelection_Click(object sender, EventArgs e)
        {
            lblSecilenler.Text = string.Empty;
            StringBuilder secimler = new StringBuilder();

            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                secimler.AppendLine($"{tabPage.Text}:");

                foreach (Control group in tabPage.Controls)
                {
                    if (group is GroupBox groupBox)
                    {
                        foreach (Control control in groupBox.Controls)
                        {
                            if (control is ListBox listBox && listBox.SelectedItems.Count > 0)
                            {
                                secimler.AppendLine($"- {groupBox.Text}");
                                foreach (var selectedItem in listBox.SelectedItems)
                                {
                                    secimler.AppendLine($"  -- {selectedItem}");
                                }
                            }
                        }
                    }
                }

                if (secimler.ToString().Trim() == $"{tabPage.Text}:")
                {
                    secimler.AppendLine("- Hiçbir seçim yapılmadı.");
                }
            }
            // Sabit hizmetleri ekle
            secimler.AppendLine("\nSabit Hizmetler:");
            secimler.AppendLine($"- Su Tesisatı: {FixedWaterCost:C2}");
            secimler.AppendLine($"- Elektrik Tesisatı: {FixedElectricityCost:C2}");

            lblSecilenler.Text = secimler.ToString();
        }



        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
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

        private decimal CalculateTotalCost()
        {
            int totalDays = (EndDate - CalculatedStartDate).Days+1; // Toplam gün sayısı

            // Seçilen hizmetlerin toplam maliyeti
            decimal totalServiceCost = SelectedServices.Sum(s => s.Cost * totalDays);

            // Sabit hizmet maliyetlerini ekle
            decimal fixedServicesCost = (FixedWaterCost + FixedElectricityCost) * totalDays;

            // Toplam bina maliyeti + hizmet maliyetleri
            decimal totalCost = BuildingCost + totalServiceCost + fixedServicesCost;

            return totalCost;
        }

        private void UpdateSelectedServices()
        {
            SelectedServices.Clear(); // Önce listeyi temizliyoruz

            // TabPage'leri dolaşarak seçilen hizmetleri listeye ekle
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                foreach (Control group in tabPage.Controls)
                {
                    if (group is GroupBox groupBox)
                    {
                        foreach (Control control in groupBox.Controls)
                        {
                            if (control is ListBox listBox && listBox.SelectedItems.Count > 0)
                            {
                                foreach (var selectedItem in listBox.SelectedItems)
                                {
                                    if (selectedItem is ListViewItem listViewItem && listViewItem.Tag is int serviceValueId)
                                    {
                                        var serviceValue = _serviceValueRepository.GetById(serviceValueId);
                                        if (serviceValue != null)
                                        {
                                            SelectedServices.Add(serviceValue); // Ek hizmet listeye ekleniyor
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (!SelectedServices.Any())
            {
                MessageBox.Show("Hiçbir hizmet seçilmedi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnConfirmAll_Click(object sender, EventArgs e)
        {

            UpdateSelectedServices(); // Seçilen hizmetleri güncelle

            int preparationDays = CalculatePreparationDays(); // Hazırlık günlerini yeniden hesapla
            DateTime calculatedStartDate = StartDate.AddDays(preparationDays); // Güncellenmiş hazırlık süresini kullan

            if (calculatedStartDate <= StartDate)
            {
                CalculatedStartDate = StartDate;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(
                    $"Hazırlık süresi nedeniyle önerilen başlangıç tarihi: {calculatedStartDate.ToShortDateString()}.\n" +
                    $"Talep edilen başlangıç tarihi: {StartDate.ToShortDateString()}.\n\n" +
                    $"Hesaplanan tarihi kabul etmek istiyor musunuz?",
                    "Başlangıç Tarihi Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    CalculatedStartDate = calculatedStartDate;
                }
                else
                {
                    MessageBox.Show("İşlem iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Sabit hizmetlerin maliyetlerini hesapla
            int fairDuration = (EndDate - StartDate).Days+1;
            decimal fixedServicesCost = (FixedWaterCost + FixedElectricityCost) * fairDuration;

            MessageBox.Show(
                $"Sabit Hizmetler Maliyeti:\n" +
                $"- Su Tesisatı: {FixedWaterCost:C2}\n" +
                $"- Elektrik Tesisatı: {FixedElectricityCost:C2}\n\n" +
                $"Bu hizmetlerin toplam maliyeti: {fixedServicesCost:C2}",
                "Sabit Hizmetler",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Toplam süreyi hesapla ve bitiş tarihini güncelle
            EndDate = CalculatedStartDate.AddDays(fairDuration);

            // Bina doluluk kontrolü
            if (!IsBuildingAvailable(SelectedBuilding, CalculatedStartDate, EndDate))
            {
                MessageBox.Show("Seçilen tarihlerde bina başka bir fuar için rezerve edilmiştir.", "Tarih Çakışması", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Özet formunu aç
            FairSummaryForm summaryForm = new FairSummaryForm
            {
                LoggedInCustomer = LoggedInCustomer,
                SelectedBuilding = SelectedBuilding,
                TotalCost = CalculateTotalCost(),
                SelectedServices = SelectedServices.Select(s => s.Name).ToList(),
                StartDate = StartDate,
                EndDate = EndDate,
                CalculatedStartDate = CalculatedStartDate,
                FairName = FairName
            };

            summaryForm.ShowDialog();
        }

    }
}
