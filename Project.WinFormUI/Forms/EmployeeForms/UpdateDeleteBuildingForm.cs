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
    public partial class UpdateDeleteBuildingForm : Form
    {
        private BuildingRepository _buildingRepository;
        private LocationRepository _locationRepository;
        private Building _selectedBuilding;

        public UpdateDeleteBuildingForm()
        {
            InitializeComponent();

            _buildingRepository = new BuildingRepository();
            _locationRepository = new LocationRepository();
            LoadLocationsAndBuildings();
            ClearFields();
        }

        private void LoadLocationsAndBuildings()
        {
            // Lokasyonları yükleme
            var locationDisplayData = _locationRepository.GetAll().Select(x => new
            {
                Display = x.ToString(),
                Value = x.Id
            }).ToList();

            cmbLocation.DataSource = locationDisplayData;
            cmbLocation.DisplayMember = "Display";
            cmbLocation.ValueMember = "Value";

            // Aktif binaları listeleme
            lstBuildings.DataSource = _buildingRepository.GetActives();
            lstBuildings.DisplayMember = "ToString";
        }

        private void lstBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBuildings.SelectedItem != null)
            {
                _selectedBuilding = (Building)lstBuildings.SelectedItem;

                // Seçilen binanın detaylarını ilgili alanlara yansıt
                txtBuildingName.Text = _selectedBuilding.Name;
                txtAddress.Text = _selectedBuilding.Address;
                nudNumberOfFloor.Value = _selectedBuilding.NumberOfFloor;
                nudFloorSize.Value = _selectedBuilding.FloorSize;
                nudRoomPerFloor.Value = _selectedBuilding.RoomPerFloor;
                cmbLocation.SelectedValue = _selectedBuilding.LocationId;

                // Seçilen binanın detaylarını Label'e yazdır
                lblSelectedBuilding.Text = $"Bina Adı: {_selectedBuilding.Name}\n" +
                                            $"Adres: {_selectedBuilding.Address}\n" +
                                            $"Kat Sayısı: {_selectedBuilding.NumberOfFloor}\n" +
                                            $"Kat Metrekare: {_selectedBuilding.FloorSize}\n" +
                                            $"Kat Başına Oda: {_selectedBuilding.RoomPerFloor}\n" +
                                            $"Lokasyon: {_selectedBuilding.Location?.ToString()}";
            }
            else
            {
                lblSelectedBuilding.Text = "Seçilen Bina: Yok";
            }
        }

        private void btnUpdateBuilding_Click(object sender, EventArgs e)
        {
            if (_selectedBuilding == null)
            {
                MessageBox.Show("Lütfen bir bina seçiniz.");
                return;
            }

            // Güncelleme işlemi
            if (!_buildingRepository.IsFloorCountValid((int)nudNumberOfFloor.Value) ||
                !_buildingRepository.IsFloorSizeValid((int)nudFloorSize.Value) ||
                !_buildingRepository.IsRoomCountValid((int)nudRoomPerFloor.Value))
            {
                MessageBox.Show("Girilen değerler uygun değil.");
                return;
            }

            try
            {
                _selectedBuilding.Name = txtBuildingName.Text;
                _selectedBuilding.Address = txtAddress.Text;
                _selectedBuilding.NumberOfFloor = (int)nudNumberOfFloor.Value;
                _selectedBuilding.FloorSize = (int)nudFloorSize.Value;
                _selectedBuilding.RoomPerFloor = (int)nudRoomPerFloor.Value;
                _selectedBuilding.LocationId = (int)cmbLocation.SelectedValue;

                _buildingRepository.Update(_selectedBuilding);

                MessageBox.Show("Bina başarıyla güncellendi.");
                LoadLocationsAndBuildings(); // Listeyi güncelle
                ClearFields();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void btnDeleteBuilding_Click(object sender, EventArgs e)
        {
            if (_selectedBuilding == null)
            {
                MessageBox.Show("Lütfen bir bina seçiniz.");
                return;
            }

            try
            {
                _buildingRepository.Delete(_selectedBuilding);
                MessageBox.Show("Bina başarıyla silindi.");
                LoadLocationsAndBuildings(); // Listeyi güncelle
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void ClearFields()
        {
            txtBuildingName.Clear();
            txtAddress.Clear();
            nudNumberOfFloor.Value = 1;
            nudFloorSize.Value = 50;
            nudRoomPerFloor.Value = 1;
            cmbLocation.SelectedIndex = -1;
            lblSelectedBuilding.Text = "Seçilen Bina: Yok";
            _selectedBuilding = null;
            lstBuildings.SelectedIndex = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateDeleteBuildingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
