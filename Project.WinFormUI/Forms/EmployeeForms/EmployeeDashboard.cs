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
    public partial class EmployeeDashboard : Form
    {
        // Repository nesnelerinin tanımları
        EmployeeRepository _employeeRepository;
        ServiceValueRepository _serviceValueRepository;
        BuildingRepository _buildingRepository;
        LocationRepository _locationRepository;
        FairDelayRepository _fairDelayRepository;
        FairRepository _fairRepository;

        public EmployeeDashboard()
        {
            InitializeComponent();

            // Repository nesnelerinin başlatılması
            _employeeRepository = new EmployeeRepository();
            _serviceValueRepository = new ServiceValueRepository();
            _buildingRepository = new BuildingRepository();
            _locationRepository = new LocationRepository();
            _fairDelayRepository = new FairDelayRepository();
            _fairRepository = new FairRepository();

            LoadFairs(); // Başlangıçta fuarları yükleme

            // DataGridView seçimi değiştiğinde detayları güncellemek için olay bağlama
            dgvFairs.SelectionChanged += dgvFairs_SelectionChanged;
        }

        #region EkleSekmesi
        /*--------------------------Ekle Sekmesi-----------------------*/

        // Yeni bina ekleme butonu olayı: AddBuildingForm'u açar
        private void btnAddBuilding_Click(object sender, EventArgs e)
        {
            OpenForm(new AddBuildingForm());
        }

        // Yeni lokasyon ekleme butonu olayı: AddLocationForm'u açar
        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            OpenForm(new AddLocationForm());
        }

        // Yeni çalışan ekleme butonu olayı: AddEmployeeForm'u açar
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            OpenForm(new AddEmployeeForm());
        }

        // Yeni hizmet ekleme butonu olayı
        private void btnAddService_Click(object sender, EventArgs e)
        {
            OpenForm(new AddAdditionalServiceForm());
        }

        // Çıkış butonu olayı: Formu kapatır
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Guncelle/Sil Sekmesi
        /*--------------------------Guncelle/Sil Sekmesi-----------------------*/

        // Bina güncelleme/silme butonu olayı: UpdateDeleteBuildingForm'u açar
        private void btnUpdateBuilding_Click(object sender, EventArgs e)
        {
            OpenForm(new UpdateDeleteBuildingForm());
        }

        // Lokasyon güncelleme/silme butonu olayı: UpdateDeleteLocationForm'u açar
        private void btnUpdateLocation_Click(object sender, EventArgs e)
        {
            OpenForm(new UpdateDeleteLocationForm());
        }

        // Çalışan güncelleme/silme butonu olayı: UpdateDeleteEmployeeForm'u açar
        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            OpenForm(new UpdateDeleteEmployeeForm());
        }

        // Hizmet güncelleme veya silme işlemleri için formu açar
        private void btnUpdateService_Click(object sender, EventArgs e)
        {
            OpenForm(new UpdateDeleteServiceForm());
        }

        // Güncelleme ekranından çıkış butonu: Formu kapatır
        private void btnExitUpdate_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Raporlar Sekmesi

        /*--------------------------Raporlar Sekmesi-----------------------*/

        // Çalışan raporlarını yükler
        private void btnEmployeeReport_Click(object sender, EventArgs e)
        {
            LoadReport(_employeeRepository.GetFormattedEmployeeReport);
        }
        
        // Hizmet raporlarını yükler
        private void btnServiceReport_Click(object sender, EventArgs e)
        {
            LoadReport(_serviceValueRepository.GetFormattedServiceReport);
        }

        // Bina raporlarını yükler
        private void btnBuildingReport_Click(object sender, EventArgs e)
        {
            LoadReport(_buildingRepository.GetFormattedBuildingReport);
        }

        // Lokasyon raporlarını yükler
        private void btnLocationReport_Click(object sender, EventArgs e)
        {
            LoadReport(_locationRepository.GetFormattedLocationReport);
        }

        // Mevcut fuarları raporlar
        private void btnMevcutFuarlar_Click(object sender, EventArgs e)
        {
            LoadReport(_fairRepository.GetFormattedFairList);
        }

        // Fuar ödemeleri raporlarını yükler
        private void btnFuarOdemeleri_Click(object sender, EventArgs e)
        {
            LoadReport(_fairRepository.GetFormattedFairPayments);
        }

        // Rapor detaylarına çift tıklama işlemi
        private void lstReportResults_DoubleClick(object sender, EventArgs e)
        {
            if (lstReportResults.SelectedIndex != -1)    // Eğer bir öğe seçilmişse
            {
                MessageBox.Show(lstReportResults.SelectedItem.ToString(), "Detaylı Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);        // Seçilen öğenin detaylarını bir mesaj kutusunda göster

            }
        }

        // Rapor ekranından çıkış işlemi
        private void btnExitReport_Click(object sender, EventArgs e)
        {
            Close();//formu kapatır
        }

        #endregion

        #region Gecikme Yonetimi Sekmesi
        /*--------------------------Gecikme Yonetimi Sekmesi-----------------------*/

        // Gecikme bilgisi kaydetme işlemi
        private void btnSaveDelay_Click(object sender, EventArgs e)
        {
            Fair fair = GetSelectedFair();
            if (fair == null) return;

            int delayDuration = (int)nudDelayDuration.Value;
            string delayReason = txtDelayReason.Text;

            if (delayDuration <= 0 || delayReason=="")
            {
                MessageBox.Show("Gecikme süresi ve nedeni girilmelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFairDelay(fair, delayDuration, delayReason);

            MessageBox.Show("Gecikme bilgisi başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadDelayHistory(fair.Id);
            ClearFields();
            LoadFairs();
        }

        // Gecikme geçmişini görüntüleme işlemi
        private void btnViewDelays_Click(object sender, EventArgs e)
        {
            Fair selectedFair = GetSelectedFair(); // Seçilen fuarı al
            if (selectedFair == null) return; // Eğer seçim yoksa metot sonlandırılır.

            LoadDelayHistory(selectedFair.Id); // Fuarın gecikme geçmişi yüklenir.
        }

        // DataGridView seçim değişikliğinde detayları günceller
        private void dgvFairs_SelectionChanged(object sender, EventArgs e)
        {
            UpdateSelectedFairDetails();// Seçilen fuar detaylarını günceller.
        }
        #endregion

        #region Form Metotlari


        // Gecikme geçmişini yükler
        private void LoadDelayHistory(int fairId)
        {
            lstDelayHistory.Items.Clear();

            // Gecikme geçmişi, BaseRepository'nin Where metoduyla alınır.
            List<string> delays = _fairDelayRepository.Where(fd => fd.FairId == fairId)
                                             .Select(fd => $"Gecikme Süresi: {fd.DelayDuration} gün - Sebep: {fd.DelayReason} - Yeni Başlangıç: {fd.NewStartDate.ToShortDateString()} - Yeni Bitiş: {fd.NewEndDate.ToShortDateString()}")
                                             .ToList();

            if (!delays.Any())
            {
                lstDelayHistory.Items.Add("Bu fuar için gecikme bilgisi bulunmamaktadır.");
                return;
            }

            lstDelayHistory.Items.AddRange(delays.ToArray());
        }

        // Seçili fuarı alır
        private Fair GetSelectedFair()
        {
            if (dgvFairs.SelectedRows.Count == 0) return null; // Seçim yoksa null döner.

            if (!int.TryParse(dgvFairs.SelectedRows[0].Cells["Id"].Value.ToString(), out int selectedFairId))
            {
                return null; // ID dönüştürülemezse null döner.
            }

            return _fairRepository.GetById(selectedFairId);
        }

        // Form alanlarını temizler
        private void ClearFields()
        {
            // Gecikme süresi sıfırlanır.
            nudDelayDuration.Value = 0;

            // Gecikme sebebi metin kutusu temizlenir.
            txtDelayReason.Clear();

            // Gecikme geçmişi listesi temizlenir.
            lstDelayHistory.Items.Clear();
        }

        // Fuar listesini yükler
        private void LoadFairs()
        {
            var fairs = _fairRepository.GetAll().Select(f => new
            {
                f.Id,
                FuarAdı = f.Name,
                HesaplananBaşlangıç = f.CalculatedStartDate.ToShortDateString(),
                BitişTarihi = f.EndDate.ToShortDateString(),
                ToplamMaliyet = f.TotalCost.ToString("C"),
                GecikmeDurumu = f.IsDelayed ? "Evet" : "Hayır"
            }).ToList();

            dgvFairs.DataSource = fairs;
        }

        // Seçili fuarın detaylarını günceller
        private void UpdateSelectedFairDetails()
        {
            Fair fair = GetSelectedFair();
            if (fair == null)
            {
                lblSelectedFairDetails.Text = "Seçilen bir fuar yok."; // Seçim yoksa bilgi etiketi boş kalır.
                return;
            }

            // Seçim varsa detayları göster.
            lblSelectedFairDetails.Text = $"Fuar Adı: {fair.Name}\n" +
                                          $"Hesaplanan Başlangıç: {fair.CalculatedStartDate}\n" +
                                          $"Bitiş Tarihi: {fair.EndDate}\n" +
                                          $"Maliyet: {fair.TotalCost:C2}\n" +
                                          $"Gecikme Durumu: {(fair.IsDelayed ? "Evet" : "Hayır")}";
        }

        // Form açma işlemi
        private void OpenForm(Form form)
        {
            form.ShowDialog();
        }

        // Rapor yükleme işlemi
        private void LoadReport(Func<List<string>> getReportData)
        {
            lstReportResults.Items.Clear();
            List<string> reportData = getReportData();
            if (!reportData.Any())
            {
                lstReportResults.Items.Add("Rapor için veri bulunamadı.");
                return;
            }
            lstReportResults.Items.AddRange(reportData.ToArray());
        }

        // Gecikme bilgisi kaydetme işlemi
        private void SaveFairDelay(Fair fair, int delayDuration, string delayReason)
        {
            DateTime newStartDate = fair.CalculatedStartDate.AddDays(delayDuration);
            DateTime newEndDate = fair.EndDate.AddDays(delayDuration);

            FairDelay fairDelay = new FairDelay
            {
                FairId = fair.Id,
                DelayDuration = delayDuration,
                DelayReason = delayReason,
                NewStartDate = newStartDate,
                NewEndDate = newEndDate,
                CreatedDate = DateTime.Now
            };

            _fairDelayRepository.Add(fairDelay);

            fair.CalculatedStartDate = newStartDate;
            fair.EndDate = newEndDate;
            fair.IsDelayed = true;
            _fairRepository.Update(fair);
        }

        #endregion

       
    }
}
