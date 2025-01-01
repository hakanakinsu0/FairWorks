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
        // Repository sınıfları
        BuildingRepository _buildingRepository; // Bina işlemleri için repository
        LocationRepository _locationRepository; // Lokasyon işlemleri için repository

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
            // Fuar ismi, şehir ve ilçe seçiminin kontrolü
            if (cmbCity.SelectedIndex == -1 || cmbDistrict.SelectedIndex == -1 || txtFairName.Text == "")
            {
                MessageBox.Show("Lütfen fuar ismini, şehiri ve ilçeyi seçiniz.");
                return;
            }

            // Tarih aralığının kontrolü
            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                MessageBox.Show("Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.");
                return;
            }

            // Uygun binaları arama işlemi
            List<Building> availableBuildings = _buildingRepository.GetAvailableBuildings(cmbCity.SelectedItem.ToString(), cmbDistrict.SelectedItem.ToString(), dtpEndDate.Value, dtpStartDate.Value);

            if (availableBuildings.Any()) // Eğer uygun bina bulunursa
            {
                lstBuildings.DataSource = availableBuildings;
                lstBuildings.DisplayMember = "ToString";
                lstBuildings.SelectedIndex = -1;
            }
            // Uygun bina bulunamazsa mesaj gösterilir
            else MessageBox.Show("Seçilen tarihlerde uygun bina bulunamadı. İsterseniz talep olusturabilirsiniz.");
        }

        private void btnConfirmFair_Click(object sender, EventArgs e)
        {
            // Kullanıcının bir bina seçip seçmediğini kontrol eder
            if (lstBuildings.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir bina seçiniz.");
                return;
            }

            // Seçilen bina bilgilerini alır
            Building selectedBuilding = lstBuildings.SelectedItem as Building;

            try
            {
                // Binanın maliyetini hesapla
                decimal buildingCost = _buildingRepository.CalculateFairCost(selectedBuilding);

                // Onay mesajı göster
                MessageBox.Show($"Seçilen bina onaylandı: {selectedBuilding.Name}");

                // Ek hizmetler formunu açar ve bina bilgilerini gönderir
                FairServicesForm servicesForm = new FairServicesForm
                {
                    SelectedBuilding = selectedBuilding, // Seçilen bina bilgisi
                    BuildingCost = buildingCost          // Hesaplanan bina maliyeti
                };

                servicesForm.ShowDialog();
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj gösterilir
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
            CustomBuildingRequestForm requestForm = new CustomBuildingRequestForm(txtFairName.Text, dtpStartDate.Value, dtpEndDate.Value);
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
                lblBuildingDetails.Text = $"Bina Adı: {selectedBuilding.Name}\nAdres: {selectedBuilding.Address}\nKat Sayısı: {selectedBuilding.NumberOfFloor}\nKat Metrekare: {selectedBuilding.FloorSize}\nKat Başına Oda: {selectedBuilding.RoomPerFloor}\nGün Sayısı: {(dtpEndDate.Value - dtpStartDate.Value).Days + 2}";
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
    }
}
