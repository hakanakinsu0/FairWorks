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
        private string _fairName;
        private DateTime _startDate;
        private DateTime _endDate;

        private LocationRepository _locationRepository;
        private BuildingRepository _buildingRepository;

        public CustomBuildingRequestForm(string fairName, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            _fairName = fairName;
            _startDate = startDate;
            _endDate = endDate;

            _locationRepository = new LocationRepository();
            _buildingRepository = new BuildingRepository();
        }

        private void CustomBuildingRequestForm_Load(object sender, EventArgs e)
        {
            lblFairDetails.Text = $"Fuar Adı: {_fairName}\n" +
                              $"Tarih Aralığı: {_startDate.ToShortDateString()} - {_endDate.ToShortDateString()}";

            LoadLocations();
        }

        private void btnSearchBuildings_Click(object sender, EventArgs e)
        {
            if (cmbLocations.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir şehir seçiniz.");
                return;
            }

            if (nudFloorSize.Value <= 0 || nudNumberOfFloor.Value <= 0 || nudRoomPerFloor.Value <= 0)
            {
                MessageBox.Show("Lütfen geçerli değerler giriniz.");
                return;
            }

            int requestedFloors = (int)nudNumberOfFloor.Value;
            int requestedSize = (int)nudFloorSize.Value;
            int requestedRooms = (int)nudRoomPerFloor.Value;

            if (!_buildingRepository.IsFloorCountValid(requestedFloors) ||
                !_buildingRepository.IsFloorSizeValid(requestedSize) ||
                !_buildingRepository.IsRoomCountValid(requestedRooms))
            {
                MessageBox.Show("Girilen değerler uygun değil.");
                return;
            }

            string selectedCity = cmbLocations.SelectedItem.ToString();

            // Şartları sağlayan binaları filtrele
            var suitableBuildings = _buildingRepository.GetAll()
                .Where(b => b.Location.City == selectedCity &&
                            b.NumberOfFloor == requestedFloors && // Kat sayısı eşit
                            b.RoomPerFloor == requestedRooms &&   // Oda sayısı eşit
                            b.FloorSize >= requestedSize)         // Metrekare eşit veya daha büyük
                .ToList();

            if (suitableBuildings.Any())
            {
                lstAvailableBuildings.DataSource = suitableBuildings;
                lstAvailableBuildings.DisplayMember = "ToString";
            }
            else
            {
                lstAvailableBuildings.DataSource = null;
                MessageBox.Show("Kriterlere uygun bina bulunamadı.");
            }
        }

        private void lstAvailableBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAvailableBuildings.SelectedItem != null)
            {
                if (lstAvailableBuildings.SelectedItem != null)
                {
                    var selectedBuilding = (Building)lstAvailableBuildings.SelectedItem;

                    lblBuildingDetails.Text = $"Bina Adı: {selectedBuilding.Name}\n" +
                                              $"Adres: {selectedBuilding.Address}\n" +
                                              $"Kat Sayısı: {selectedBuilding.NumberOfFloor}\n" +
                                              $"Kat Metrekare: {selectedBuilding.FloorSize}\n" +
                                              $"Kat Başına Oda: {selectedBuilding.RoomPerFloor}";
                }
                else
                {
                    lblBuildingDetails.Text = "Bina seçilmedi.";
                }
            }
        }

        private void btnConfirmSelection_Click(object sender, EventArgs e)
        {
            if (lstAvailableBuildings.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir bina seçiniz.");
                return;
            }

            var selectedBuilding = (Building)lstAvailableBuildings.SelectedItem;

            MessageBox.Show($"Seçilen bina onaylandı: {selectedBuilding.Name}");

            // Fuar oluşturma işlemi ve ek hizmetler ekranı
            FairServicesForm fairServicesForm = new FairServicesForm { };
            fairServicesForm.ShowDialog();
        }

        private void LoadLocations()
        {
            var cities = _locationRepository.GetAll()
                .Select(location => location.City) // Şehir isimlerini al
                .Distinct()                        // Benzersiz olanları seç
                .ToList();

            if (cities != null && cities.Any())
            {
                cmbLocations.DataSource = cities; // Benzersiz şehirleri ComboBox'a ata
            }
            else
            {
                cmbLocations.DataSource = null;
                MessageBox.Show("Şehir verileri yüklenemedi.");
            }
        }


        private void cmbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAvailableBuildings.DataSource = null; // Lokasyon değiştiğinde listeyi temizle
        }
    }
}
