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
        // Özel alanlar: Fuar adı, başlangıç ve bitiş tarihi bilgilerini saklar.
        private readonly string _fairName;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;

        // Repository nesneleri: Konum ve bina bilgileri ile ilgili işlemler için kullanılır.
        private readonly LocationRepository _locationRepository;
        private readonly BuildingRepository _buildingRepository;

        // Giriş yapan müşteri bilgisi (public property).
        public Customer LoggedInCustomer { get; set; }


        // Constructor: Formun başlatılması ve gerekli değerlerin alınması.
        public CustomBuildingRequestForm(string fairName, DateTime startDate, DateTime endDate, Customer loggedInCustomer)
        {
            InitializeComponent(); // Formun bileşenlerini başlatır.

            // Parametrelerden alınan değerler özel alanlara atanır.
            _fairName = fairName;
            _startDate = startDate;
            _endDate = endDate;

            // Repository nesneleri oluşturulur.
            _locationRepository = new LocationRepository();
            _buildingRepository = new BuildingRepository();

            // Giriş yapan müşteri bilgisi atanır.
            LoggedInCustomer = loggedInCustomer;
        }


        // Form yüklendiğinde çalışacak olay
        private void CustomBuildingRequestForm_Load(object sender, EventArgs e)
        {
            lblFairDetails.Text = $"Fuar Adı: {_fairName}\nTarih Aralığı: {_startDate:dd/MM/yyyy} - {_endDate:dd/MM/yyyy}";
            nudFloorSize.Minimum = 49; // Minimum değeri 50 olarak ayarla
            LoadLocations();
        }

        // Binaları aramak için butona tıklama olayı
        private void btnSearchBuildings_Click(object sender, EventArgs e)
        {
            // Kullanıcı girişi doğrulaması yapılır.
            if (!ValidateInputs()) return;

            // Kullanıcının seçtiği şehir ve bina kriterleri alınır.
            string selectedCity = cmbLocations.SelectedItem.ToString();
            int requestedFloors = (int)nudNumberOfFloor.Value;
            int requestedRooms = (int)nudRoomPerFloor.Value;
            int requestedSize = (int)nudFloorSize.Value;

            // Kriterlere uygun binalar repository üzerinden getirilir.
            var suitableBuildings = _buildingRepository.GetBuildingsByCriteria(selectedCity, requestedFloors, requestedRooms, requestedSize);

            // Eğer uygun binalar varsa listeye eklenir, aksi halde bilgi mesajı gösterilir.
            if (suitableBuildings.Any())
            {
                lstAvailableBuildings.DataSource = suitableBuildings;
                lstAvailableBuildings.DisplayMember = "ToString";
            }
            else
            {
                lstAvailableBuildings.DataSource = null;
                ShowMessage("Kriterlere uygun bina bulunamadı.", "Bilgi");
            }
        }

        private bool ValidateInputs()
        {
            // Şehir seçimi doğrulanır.
            if (!IsCitySelected()) return false;

            // Kat boyutlarının geçerliliği kontrol edilir.
            if (!IsFloorSizeValid()) return false;

            // Kat ve oda sayılarının doğruluğu kontrol edilir.
            if (!AreFloorAndRoomCountsValid()) return false;

            return true; // Tüm doğrulamalardan geçtiyse true döner.
        }

        private bool IsCitySelected()// Şehir seçiminin doğruluğunu kontrol eder.

        {
            if (cmbLocations.SelectedIndex == -1)
            {
                ShowMessage("Lütfen bir şehir seçiniz.", "Geçersiz Giriş");
                return false;
            }
            return true;
        }

        private bool IsFloorSizeValid()// Kat metrekare boyutunun doğruluğunu kontrol eder.

        {
            if (nudFloorSize.Value < 50)
            {
                ShowMessage("Kat metrekare değeri 50'den küçük olamaz.", "Geçersiz Giriş");
                return false;
            }
            return true;
        }

        private bool AreFloorAndRoomCountsValid()// Kat ve oda sayılarının geçerliliğini kontrol eder.

        {
            if (nudNumberOfFloor.Value <= 0 || nudRoomPerFloor.Value <= 0)
            {
                ShowMessage("Kat sayısı ve oda sayısı sıfırdan büyük olmalıdır.", "Geçersiz Giriş");
                return false;
            }
            return true;
        }

        // Seçilen binanın detaylarını gösteren olay
        private void lstAvailableBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Eğer bir bina seçildiyse detaylar gösterilir, aksi takdirde bilgi mesajı gösterilir.
            if (lstAvailableBuildings.SelectedItem is Building selectedBuilding)
            {
                lblBuildingDetails.Text = $"Bina Adı: {selectedBuilding.Name}\nAdres: {selectedBuilding.Address}\nKat Sayısı: {selectedBuilding.NumberOfFloor}\nKat Metrekare: {selectedBuilding.FloorSize}\nKat Başına Oda: {selectedBuilding.RoomPerFloor}";
            }
            else
            {
                lblBuildingDetails.Text = "Bina seçilmedi.";
            }
        }

        // Bina seçimini onaylama butonu
        private void btnConfirmSelection_Click(object sender, EventArgs e)
        {
            // Eğer bir bina seçilmemişse hata mesajı gösterilir.
            if (!(lstAvailableBuildings.SelectedItem is Building selectedBuilding))
            {
                ShowMessage("Lütfen bir bina seçiniz.", "Hata");
                return;
            }

            // Seçilen binanın maliyeti hesaplanır.
            decimal buildingCost = _buildingRepository.CalculateFairCost(selectedBuilding, _startDate, _endDate);

            // Seçim onaylandığında bilgi mesajı gösterilir.
            ShowMessage($"Seçilen bina onaylandı: {selectedBuilding.Name}", "Bilgi");

            // Fuar hizmetleri formu oluşturulur ve gösterilir.
            FairServicesForm fairServicesForm = new FairServicesForm
            {
                LoggedInCustomer = LoggedInCustomer, // Giriş yapan müşteri bilgisi atanır.
                SelectedBuilding = selectedBuilding, // Seçilen bina atanır.
                BuildingCost = buildingCost, // Hesaplanan maliyet atanır.
                StartDate = _startDate, // Başlangıç tarihi atanır.
                EndDate = _endDate, // Bitiş tarihi atanır.
                FairName = _fairName // Fuar adı atanır.
            };

            fairServicesForm.ShowDialog(); // Form diyalog penceresi olarak açılır.
        }

        // Şehir seçildiğinde listeyi temizleyen olay
        private void cmbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAvailableBuildings.DataSource = null;
        }

        // Formu kapatma butonu
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close(); // Formu kapat
        }

        private void LoadLocations()
        {
            try
            {
                // Şehir listesini repository'den al
                var cities = _locationRepository.GetSortedUniqueCities();

                if (cities != null && cities.Any())
                {
                    // Şehirleri ComboBox'a yükle
                    cmbLocations.DataSource = cities;
                }
                else
                {
                    // Şehirler bulunamazsa ComboBox'u temizle
                    cmbLocations.DataSource = null;
                    ShowMessage("Şehir verileri bulunamadı.", "Hata");
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda ComboBox'u temizle ve mesaj göster
                cmbLocations.DataSource = null;
                ShowMessage($"Şehirler yüklenirken bir hata oluştu: {ex.Message}", "Hata");
            }
        }

        // Mesaj kutusu gösterme metodu.
        private void ShowMessage(string message, string caption, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon); // Belirtilen mesaj, başlık ve ikon ile gösterilir.
        }


    }
}
