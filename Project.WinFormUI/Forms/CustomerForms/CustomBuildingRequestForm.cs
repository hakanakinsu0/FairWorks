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
        private readonly string _fairName;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;

        private readonly LocationRepository _locationRepository;
        private readonly BuildingRepository _buildingRepository;

        public Customer LoggedInCustomer { get; set; }


        // Constructor: Formun başlatılması ve gerekli değerlerin alınması
        public CustomBuildingRequestForm(string fairName, DateTime startDate, DateTime endDate, Customer loggedInCustomer)
        {
            InitializeComponent();

            _fairName = fairName;
            _startDate = startDate;
            _endDate = endDate;

            _locationRepository = new LocationRepository();
            _buildingRepository = new BuildingRepository();
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
            if (!ValidateInputs()) return;

            string selectedCity = cmbLocations.SelectedItem.ToString();
            int requestedFloors = (int)nudNumberOfFloor.Value;
            int requestedRooms = (int)nudRoomPerFloor.Value;
            int requestedSize = (int)nudFloorSize.Value;

            var suitableBuildings = _buildingRepository.GetBuildingsByCriteria(selectedCity, requestedFloors, requestedRooms, requestedSize);

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
            if (cmbLocations.SelectedIndex == -1)
            {
                ShowMessage("Lütfen bir şehir seçiniz.", "Geçersiz Giriş");
                return false;
            }

            if (nudFloorSize.Value < 50)
            {
                ShowMessage("Kat metrekare değeri 50'den küçük olamaz.", "Geçersiz Giriş");
                return false;
            }

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
            if (!(lstAvailableBuildings.SelectedItem is Building selectedBuilding))
            {
                ShowMessage("Lütfen bir bina seçiniz.", "Hata");
                return;
            }

            decimal buildingCost = _buildingRepository.CalculateFairCost(selectedBuilding, _startDate, _endDate);

            ShowMessage($"Seçilen bina onaylandı: {selectedBuilding.Name}", "Bilgi");

            FairServicesForm fairServicesForm = new FairServicesForm
            {
                LoggedInCustomer = LoggedInCustomer,
                SelectedBuilding = selectedBuilding,
                BuildingCost = buildingCost,
                StartDate = _startDate,
                EndDate = _endDate,
                FairName = _fairName // Fuar adını geçiriyoruz
            };

            fairServicesForm.ShowDialog();
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
                var cities = _locationRepository.GetUniqueCities();

                if (cities.Any())
                {
                    cmbLocations.DataSource = cities;
                }
                else
                {
                    cmbLocations.DataSource = null;
                    ShowMessage("Şehir verileri yüklenemedi.", "Hata");
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Şehirler yüklenirken bir hata oluştu: {ex.Message}", "Hata");
            }
        }

        private void ShowMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
