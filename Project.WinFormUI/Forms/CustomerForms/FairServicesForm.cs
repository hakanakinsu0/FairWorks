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
    public partial class FairServicesForm : Form
    {
        private ServiceValueRepository _serviceValueRepository;
        private ServiceProviderServiceValueRepository _providerServiceValueRepository;

        public Building SelectedBuilding { get; set; }
        public decimal BuildingCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Customer LoggedInCustomer { get; set; }


        public FairServicesForm()
        {
            InitializeComponent();
            // Repository'leri başlat
            _serviceValueRepository = new ServiceValueRepository();
            _providerServiceValueRepository = new ServiceProviderServiceValueRepository();


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
            var serviceValue = _serviceValueRepository.FirstOrDefault(sv => sv.Name == serviceName);

            if (serviceValue == null)
            {
                MessageBox.Show($"{serviceName} hizmeti bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var relatedServiceProviders = _providerServiceValueRepository
                .Where(psv => psv.ServiceValueId == serviceValue.Id)
                .Select(psv => new
                {
                    ProviderName = psv.ServiceProvider.ProviderName,
                    Cost = psv.ServiceValue.Cost,
                    ServiceValueId = psv.ServiceValueId
                })
                .ToList();

            if (!relatedServiceProviders.Any())
            {
                MessageBox.Show($"{serviceName} için uygun sağlayıcı bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            targetListBox.Items.Clear();
            foreach (var provider in relatedServiceProviders)
            {
                var item = new ListViewItem($"{provider.ProviderName} - Teklif: {provider.Cost:C2}")
                {
                    Tag = provider.ServiceValueId // ID'yi burada sakla
                };
                targetListBox.Items.Add(item);
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

            lblSecilenler.Text = secimler.ToString();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmAll_Click(object sender, EventArgs e)
        {
            if (StartDate == default || EndDate == default)
            {
                MessageBox.Show("Tarih bilgisi eksik!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int days = (EndDate - StartDate).Days + 1;

            var selectedServices = new List<string>();
            var selectedServiceValueIds = new List<int>();

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
                                    // selectedItem bir ListBoxItem'dır ve Tag özelliğinde ServiceValueId saklıdır.
                                    if (selectedItem is ListViewItem listViewItem && listViewItem.Tag is int serviceValueId)
                                    {
                                        selectedServiceValueIds.Add(serviceValueId);
                                        selectedServices.Add(listViewItem.Text); // Seçilen hizmetleri listeye ekle
                                    }
                                    else
                                    {
                                        MessageBox.Show("Bir veya daha fazla hizmet doğru formatta değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (!selectedServiceValueIds.Any())
            {
                MessageBox.Show("Hiçbir hizmet seçilmedi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Toplam maliyeti hesapla
            var totalServiceCost = _providerServiceValueRepository.CalculateTotalCostForServices(selectedServiceValueIds, days);
            var finalCost = BuildingCost + totalServiceCost;

            // Yeni formu aç
            FairSummaryForm summaryForm = new FairSummaryForm
            {
                LoggedInCustomer = LoggedInCustomer,
                SelectedBuilding = SelectedBuilding,
                TotalCost = finalCost,
                SelectedServices = selectedServices,
                StartDate = StartDate,
                EndDate = EndDate
            };

            summaryForm.ShowDialog();
        }
    }
}
