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
    public partial class CustomerDashboard : Form
    {
        BuildingRepository _buildingRepository;
        LocationRepository _locationRepository;
        FairRepository _fairRepository;

        public CustomerDashboard()
        {
            InitializeComponent();
            _buildingRepository = new BuildingRepository();
            _locationRepository = new LocationRepository();
            _fairRepository = new FairRepository();
            LoadCities();
            ClearFields();
        }

        private void btnSearchBuildings_Click(object sender, EventArgs e)
        {
            if (cmbCity.SelectedIndex == -1 || cmbDistrict.SelectedIndex == -1 || txtFairName.Text=="")
            {
                MessageBox.Show("Lütfen fuar ismini, şehiri ve ilçeyi seçiniz.");
                return;
            }

            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                MessageBox.Show("Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.");
                return;
            }

            // Uygun binaları ara
            List<Building> availableBuildings = _buildingRepository.GetAvailableBuildings(cmbCity.SelectedItem.ToString(), cmbDistrict.SelectedItem.ToString(), dtpEndDate.Value, dtpStartDate.Value);

            if (availableBuildings.Any())
            {
                lstBuildings.DataSource = availableBuildings;
                lstBuildings.DisplayMember = "ToString";
                lstBuildings.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Seçilen tarihlerde uygun bina bulunamadı. İsterseniz talep olusturabilirsiniz.");
            }
        }

        private void btnConfirmFair_Click(object sender, EventArgs e)
        {
            // Kullanıcının bina seçip seçmediğini kontrol et
            if (lstBuildings.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir bina seçiniz.");
                return;
            }

            // Seçilen bina bilgilerini al
            Building selectedBuilding = lstBuildings.SelectedItem as Building;

            try
            {
                // Binanın maliyetini hesapla
                decimal buildingCost = _buildingRepository.CalculateFairCost(selectedBuilding);

                // Ek hizmetler formunu aç
                FairServicesForm servicesForm = new FairServicesForm
                {
                    SelectedBuilding = selectedBuilding, // Seçilen bina bilgisi
                    BuildingCost = buildingCost         // Hesaplanan bina maliyeti
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
            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                MessageBox.Show("Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.");
                return;
            }

            if (txtFairName.Text == "")
            {
                MessageBox.Show("Lütfen fuar ismini giriniz.");
                return;
            }

            // Fuar adı, başlangıç ve bitiş tarihlerini al ve formu aç
            CustomBuildingRequestForm requestForm = new CustomBuildingRequestForm(
                txtFairName.Text, dtpStartDate.Value, dtpEndDate.Value);
            requestForm.ShowDialog();
        }

        private void cmbCity_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbCity.SelectedItem != null)
            {
                string selectedCity = cmbCity.SelectedItem.ToString();

                // Seçilen şehir için ilçeleri al
                List<string> districts = _locationRepository.GetDistrictsByCity(selectedCity);

                if (districts != null && districts.Any())
                {
                    cmbDistrict.DataSource = districts;
                }
                else
                {
                    cmbDistrict.DataSource = null;
                    MessageBox.Show("Seçilen şehir için ilçe bulunamadı.");
                }
            }
        }

        private void lstBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBuildings.SelectedItem != null)
            {
                var selectedBuilding = (Building)lstBuildings.SelectedItem;

                // Gün sayısını hesapla (başlangıç ve bitiş günlerini dahil et)
                int dayCount = (dtpEndDate.Value - dtpStartDate.Value).Days + 2;

                // Seçilen binanın detaylarını Label'da göster
                lblBuildingDetails.Text = $"Bina Adı: {selectedBuilding.Name}\n" +
                                           $"Adres: {selectedBuilding.Address}\n" +
                                           $"Kat Sayısı: {selectedBuilding.NumberOfFloor}\n" +
                                           $"Kat Metrekare: {selectedBuilding.FloorSize}\n" +
                                           $"Kat Başına Oda: {selectedBuilding.RoomPerFloor}\n" +
                                           $"Gün Sayısı: {dayCount}";
            }
            else
            {
                lblBuildingDetails.Text = "Bina seçilmedi.";
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadCities()
        {
            var cities = _locationRepository.GetAllCities();
            if (cities != null && cities.Any())
            {
                cmbCity.DataSource = cities;
            }
            else
            {
                cmbCity.DataSource = null;
                MessageBox.Show("Şehir verileri yüklenemedi.");
            }
        }

        private void ClearFields()
        {
            txtFairName.Clear();
            cmbCity.SelectedIndex = -1;
            cmbDistrict.DataSource = null;
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now;
            lstBuildings.DataSource = null;
        }
    }
}
