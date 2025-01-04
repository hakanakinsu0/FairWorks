using Project.BLL.DesignPatterns.GenericRepository.EFConcRep;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using Project.WinFormUI.Forms.CustomerForms;
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
    public partial class CustomerDashboard : Form
    {
        // Repository sınıfları
        private readonly BuildingRepository _buildingRepository;
        private readonly LocationRepository _locationRepository;

        public Customer LoggedInCustomer { get; set; }
        public string FairName { get; set; } // FairName özelliği eklendi


        public CustomerDashboard()
        {
            InitializeComponent();

            // Repository nesneleri oluşturuluyor
            _buildingRepository = new BuildingRepository();
            _locationRepository = new LocationRepository();

            // Şehirleri yükleme ve alanları temizleme işlemleri
            LoadCities();
            ClearFields();
        }

        private void btnSearchBuildings_Click(object sender, EventArgs e)
        {
            if (cmbCity.SelectedIndex == -1 || cmbDistrict.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtFairName.Text))
            {
                MessageBox.Show("Lütfen fuar ismini, şehiri ve ilçeyi seçiniz.");
                return;
            }

            if (!IsValidDateRange(dtpStartDate.Value, dtpEndDate.Value, out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            List<Building> availableBuildings = _buildingRepository.SearchBuildings(
                cmbCity.SelectedItem.ToString(),
                cmbDistrict.SelectedItem.ToString(),
                dtpStartDate.Value,
                dtpEndDate.Value
            );

            if (availableBuildings.Any())
            {
                lstBuildings.DataSource = availableBuildings;
                lstBuildings.DisplayMember = "ToString";
                lstBuildings.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Seçilen tarihlerde uygun bina bulunamadı. İsterseniz talep oluşturabilirsiniz.");
            }
        }


        private bool IsValidDateRange(DateTime startDate, DateTime endDate, out string errorMessage)
        {
            if (endDate <= startDate)
            {
                errorMessage = "Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        private void btnConfirmFair_Click(object sender, EventArgs e)
        {
            if (lstBuildings.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir bina seçiniz.");
                return;
            }

            Building selectedBuilding = lstBuildings.SelectedItem as Building;

            try
            {
                decimal buildingCost = _buildingRepository.CalculateFairCost(selectedBuilding, dtpStartDate.Value, dtpEndDate.Value);

                // FairServicesForm'u başlatıyoruz
                FairServicesForm servicesForm = new FairServicesForm
                {
                    LoggedInCustomer = LoggedInCustomer,
                    SelectedBuilding = selectedBuilding,
                    BuildingCost = buildingCost,
                    StartDate = dtpStartDate.Value, // RequestedStartDate olarak kullanılacak
                    EndDate = dtpEndDate.Value,    // Kullanıcının belirttiği bitiş tarihi
                    FairName = txtFairName.Text   // Fuar adı
                };

                servicesForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void btnRequestBuilding_Click(object sender, EventArgs e)
        {
            if (!IsValidDateRange(dtpStartDate.Value, dtpEndDate.Value, out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFairName.Text))
            {
                MessageBox.Show("Lütfen fuar ismini giriniz.");
                return;
            }

            CustomBuildingRequestForm requestForm = new CustomBuildingRequestForm(txtFairName.Text, dtpStartDate.Value, dtpEndDate.Value, LoggedInCustomer);
            requestForm.ShowDialog();
        }

        private void cmbCity_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Şehir seçimi değiştiğinde ilgili ilçeleri yükler
            if (cmbCity.SelectedItem != null)
            {
                // Seçilen şehir için ilçeleri al
                List<string> districts = _locationRepository.LoadDistricts(cmbCity.SelectedItem.ToString());

                if (districts != null && districts.Any()) //İlçeler bulunursa ComboBox'a bağlanır
                {
                    cmbDistrict.DataSource = districts;
                }
                else
                {
                    cmbDistrict.DataSource = null; // İlçe bulunamazsa temizlenir
                    MessageBox.Show("Seçilen şehir için ilçe bulunamadı.");
                }
            }
        }

        private void lstBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBuildings.SelectedItem is Building selectedBuilding)
            {
                lblBuildingDetails.Text = $"Bina Adı: {selectedBuilding.Name}\nAdres: {selectedBuilding.Address}\n" +
                                          $"Kat Sayısı: {selectedBuilding.NumberOfFloor}\nKat Metrekare: {selectedBuilding.FloorSize}\n" +
                                          $"Kat Başına Oda: {selectedBuilding.RoomPerFloor}\n" +
                                          $"Gün Sayısı: {(dtpEndDate.Value - dtpStartDate.Value).Days + 1}";
            }
            else
            {
                lblBuildingDetails.Text = "Bina seçilmedi.";
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Formu kapatır
            Close();
        }

        private void LoadCities()
        {
            // Şehirleri yükler
            List<string> cities = _locationRepository.GetAllCities();

            if (cities != null && cities.Any()) // Eğer şehirler bulunursa
            {
                cmbCity.DataSource = cities;
            }
            else
            {
                cmbCity.DataSource = null; // Şehirler bulunamazsa temizlenir
                MessageBox.Show("Şehir verileri yüklenemedi.");
            }
        }

        private void ClearFields()
        {
            // Formdaki alanları temizler
            txtFairName.Clear();
            cmbCity.SelectedIndex = -1;
            cmbDistrict.DataSource = null;
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now;
            lstBuildings.DataSource = null;
        }

        private void LoadFairs(bool showDelayed = false)
        {
            try
            {
                FairRepository fairRepo = new FairRepository();
                var customerFairs = fairRepo.Where(f =>
                    f.CustomerId == LoggedInCustomer.Id &&
                    (!showDelayed || f.IsDelayed) &&
                    f.Status != DataStatus.Deleted).ToList();

                dgvFairs.DataSource = customerFairs.Select(f => new
                {
                    FuarAdı = f.Name,
                    BaşlangıçTarihi = f.CalculatedStartDate.ToShortDateString(),
                    BitişTarihi = f.EndDate.ToShortDateString(),
                    ToplamMaliyet = f.TotalCost.ToString("C"),
                    HazırlıkSüresi = $"{f.PreparationDays} gün",
                    GecikmeDurumu = f.IsDelayed ? "Gecikmiş" : "Zamanında"
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fuarlar yüklenirken bir hata oluştu: {ex.Message}");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                LoadFairs(); // Fuarlar sekmesine geçildiğinde fuarları yükler
            }
        }
    }
}
