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
        BuildingRepository _buildingRepository; // Bina işlemleri için repository
        LocationRepository _locationRepository; // Lokasyon işlemleri için repository

        public Customer LoggedInCustomer { get; set; }

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
            if (cmbCity.SelectedIndex == -1 || cmbDistrict.SelectedIndex == -1 || txtFairName.Text == "")
            {
                MessageBox.Show("Lütfen fuar ismini, şehiri ve ilçeyi seçiniz.");
                return;
            }

            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                MessageBox.Show("Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.");
                return;
            }

            List<Building> availableBuildings = _buildingRepository.GetAvailableBuildings(
                cmbCity.SelectedItem.ToString(),
                cmbDistrict.SelectedItem.ToString(),
                dtpEndDate.Value,
                dtpStartDate.Value
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
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value
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
            // Tarih aralığının kontrolü
            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                MessageBox.Show("Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.");
                return;
            }

            // Fuar ismi kontrolü
            if (txtFairName.Text == "")
            {
                MessageBox.Show("Lütfen fuar ismini giriniz.");
                return;
            }

            // Fuar adı, başlangıç ve bitiş tarihlerini alıp talep formunu açar
            CustomBuildingRequestForm requestForm = new CustomBuildingRequestForm(txtFairName.Text, dtpStartDate.Value, dtpEndDate.Value, LoggedInCustomer)
            {
            };
            requestForm.ShowDialog();
        }

        private void cmbCity_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Şehir seçimi değiştiğinde ilgili ilçeleri yükler
            if (cmbCity.SelectedItem != null)
            {
                // Seçilen şehir için ilçeleri al
                List<string> districts = _locationRepository.GetDistrictsByCity(cmbCity.SelectedItem.ToString());

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
            // Liste kutusunda seçilen bina değiştiğinde detaylarını gösterir
            if (lstBuildings.SelectedItem != null)
            {
                Building selectedBuilding = lstBuildings.SelectedItem as Building;

                // Binanın detaylarını Label'a yazar
                lblBuildingDetails.Text = $"Bina Adı: {selectedBuilding.Name}\nAdres: {selectedBuilding.Address}\nKat Sayısı: {selectedBuilding.NumberOfFloor}\nKat Metrekare: {selectedBuilding.FloorSize}\nKat Başına Oda: {selectedBuilding.RoomPerFloor}\nGün Sayısı: {(dtpEndDate.Value - dtpStartDate.Value).Days + 1}";
            }
            else lblBuildingDetails.Text = "Bina seçilmedi."; // Seçim yapılmamışsa mesaj gösterilir
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

                // Giriş yapan müşteriye ait fuarları getir
                var customerFairs = fairRepo.Where(f =>
                    f.CustomerId == LoggedInCustomer.Id &&
                    (!showDelayed || f.IsDelayed) && // Gecikmiş fuarları göster seçeneği
                    f.Status != DataStatus.Deleted).ToList();

                // Fuarları DataGridView'e yükle
                dgvFairs.DataSource = customerFairs.Select(f => new
                {
                    FuarAdı = f.Name,
                    BaşlangıçTarihi = f.RequestedStartDate.ToShortDateString(),
                    BitişTarihi = f.EndDate.ToShortDateString(),
                    ToplamMaliyet = f.TotalCost.ToString("C"),
                    HazırlıkSüresi = $"{f.PreparationDays} gün",
                    GecikmeDurumu = f.IsDelayed ? "Gecikmiş" : "Zamanında"
                }).ToList();

                // Eğer fuar yoksa DataGridView temizlenir
                if (!customerFairs.Any())
                {
                    dgvFairs.DataSource = null;
                    MessageBox.Show("Henüz fuar bulunmamaktadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fuarlar yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
