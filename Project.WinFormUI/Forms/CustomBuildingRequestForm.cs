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
    public partial class CustomBuildingRequestForm : Form
    {
        string _fairName; // Fuar adı bilgisi
        DateTime _startDate; // Fuarın başlangıç tarihi
        DateTime _endDate; // Fuarın bitiş tarihi

        LocationRepository _locationRepository; // Lokasyon veritabanı işlemleri için repository
        BuildingRepository _buildingRepository;// Bina veritabanı işlemleri için repository

        // Constructor: Formun başlatılması ve gerekli değerlerin alınması
        public CustomBuildingRequestForm(string fairName, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();

            _fairName = fairName; // Fuar adını al
            _startDate = startDate; // Başlangıç tarihini al
            _endDate = endDate; // Bitiş tarihini al

            _locationRepository = new LocationRepository(); // Lokasyon repository örneği oluştur
            _buildingRepository = new BuildingRepository(); // Bina repository örneği oluştur
        }

        // Form yüklendiğinde çalışacak olay
        private void CustomBuildingRequestForm_Load(object sender, EventArgs e)
        {
            // Fuar bilgilerini ilgili label'da göster
            lblFairDetails.Text = $"Fuar Adı: {_fairName}\nTarih Aralığı: {_startDate.ToShortDateString()} - {_endDate.ToShortDateString()}";

            LoadLocations(); // Şehirleri yükle
        }

        // Binaları aramak için butona tıklama olayı
        private void btnSearchBuildings_Click(object sender, EventArgs e)
        {
            // Eğer şehir seçilmemişse hata mesajı göster
            if (cmbLocations.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir şehir seçiniz.");
                return;
            }

            // Kullanıcının bina kriterlerini kontrol et
            if (nudFloorSize.Value <= 0 || nudNumberOfFloor.Value <= 0 || nudRoomPerFloor.Value <= 0)
            {
                MessageBox.Show("Lütfen geçerli değerler giriniz.");
                return;
            }

            // Kullanıcıdan alınan kriterleri değişkenlere ata
            int requestedFloors = (int)nudNumberOfFloor.Value;
            int requestedSize = (int)nudFloorSize.Value;
            int requestedRooms = (int)nudRoomPerFloor.Value;

            // Bina kriterlerinin doğruluğunu kontrol et
            if (AlanlariKontrolEt())
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!");
                return;
            }

            // Kat sayısının geçerli aralıkta olup olmadığı kontrol edilir
            if (!_buildingRepository.IsFloorCountValid((int)nudNumberOfFloor.Value))
            {
                MessageBox.Show("Kat sayısı 1 ile 5 arasında olmalıdır.");
                return;
            }

            // Kat boyutunun geçerli aralıkta olup olmadığı kontrol edilir
            if (!_buildingRepository.IsFloorSizeValid((int)nudFloorSize.Value))
            {
                MessageBox.Show("Kat boyutu 50 ile 300 metrekare arasında olmalıdır.");
                return;
            }

            // Oda sayısının geçerli aralıkta olup olmadığı kontrol edilir
            if (!_buildingRepository.IsRoomCountValid((int)nudRoomPerFloor.Value))
            {
                MessageBox.Show("Kat başına oda sayısı 1 ile 6 arasında olmalıdır.");
                return;
            }

            // Seçilen şehir bilgisini al
            string selectedCity = cmbLocations.SelectedItem.ToString();

            // Şartları sağlayan binaları filtrele
            List<Building> suitableBuildings = _buildingRepository.GetBuildingsByCriteria(selectedCity, requestedFloors, requestedRooms, requestedSize);

            // Uygun bina varsa listeyi güncelle, yoksa kullanıcıya bilgi ver
            if (suitableBuildings.Any())
            {
                lstAvailableBuildings.DataSource = suitableBuildings; // ListBox'a uygun binaları ata
                lstAvailableBuildings.DisplayMember = "ToString"; // Görüntülenecek alan olarak ToString kullan
            }
            else
            {
                lstAvailableBuildings.DataSource = null; // Listeyi temizle
                MessageBox.Show("Kriterlere uygun bina bulunamadı."); // Uygun bina bulunamadı mesajı
            }

            // Varsayılan olarak seçim yapılmamış şekilde ayarla
            lstAvailableBuildings.SelectedIndex = -1;
        }

        // Seçilen binanın detaylarını gösteren olay
        private void lstAvailableBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Eğer bir bina seçilmişse detaylarını göster
            if (lstAvailableBuildings.SelectedItem != null)
            {
                Building selectedBuilding = SecilenBinayiAl(); // Seçilen binayı al

                // Seçilen binanın detaylarını ilgili label'da göster
                lblBuildingDetails.Text = $"Bina Adı: {selectedBuilding.Name}\nAdres: {selectedBuilding.Address}\nKat Sayısı: {selectedBuilding.NumberOfFloor}\nKat Metrekare: {selectedBuilding.FloorSize}\nKat Başına Oda: {selectedBuilding.RoomPerFloor}";
            }
            else lblBuildingDetails.Text = "Bina seçilmedi."; // Hiçbir bina seçilmediyse
        }

        // Bina seçimini onaylama butonu
        private void btnConfirmSelection_Click(object sender, EventArgs e)
        {
            // Eğer bir bina seçilmemişse hata mesajı göster
            if (lstAvailableBuildings.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir bina seçiniz.");
                return;
            }

            // Seçilen binayı al
            Building selectedBuilding = SecilenBinayiAl();

            // Binanın maliyetini hesapla
            decimal buildingCost = _buildingRepository.CalculateFairCost(selectedBuilding, _startDate, _endDate);

            // Onay mesajı göster
            MessageBox.Show($"Seçilen bina onaylandı: {selectedBuilding.Name}");

            // Ek hizmetler formunu aç
            FairServicesForm fairServicesForm = new FairServicesForm
            {
                SelectedBuilding = selectedBuilding, // Seçilen bina bilgisi
                BuildingCost = buildingCost          // Hesaplanan bina maliyeti
            };
            fairServicesForm.ShowDialog();
        }

        // Şehir seçildiğinde listeyi temizleyen olay
        private void cmbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAvailableBuildings.DataSource = null; // Lokasyon değiştiğinde bina listesini temizle
        }

        // Formu kapatma butonu
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close(); // Formu kapat
        }

        // Seçilen binayı döndüren metot
        private Building SecilenBinayiAl()
        {
            return (Building)lstAvailableBuildings.SelectedItem; // Seçilen binayı döndür
        }

        // Şehirleri yükleyen metot
        private void LoadLocations()
        {
            // Benzersiz şehir isimlerini al
            List<string> cities = _locationRepository.GetUniqueCities();

            // Eğer şehirler varsa ComboBox'a yükle, yoksa hata mesajı göster
            if (cities != null && cities.Any())
            {
                cmbLocations.DataSource = cities; // Şehirleri ComboBox'a ata
            }
            else
            {
                cmbLocations.DataSource = null; // ComboBox'u temizle
                MessageBox.Show("Şehir verileri yüklenemedi."); // Hata mesajı
            }
        }
        // Formdaki tüm alanların dolu olup olmadığını kontrol eder
        private bool AlanlariKontrolEt()
        {
            return nudNumberOfFloor.Value <= 0 || nudFloorSize.Value <= 0 || nudRoomPerFloor.Value <= 0 || cmbLocations.SelectedIndex == -1;
        }
    }
}
