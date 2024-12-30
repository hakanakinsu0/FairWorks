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
    public partial class AddBuildingForm : Form
    {
        BuildingRepository _buildingRepository;
        LocationRepository _locationRepository;

        Building _newBuilding;

        public AddBuildingForm()
        {
            InitializeComponent();
            _buildingRepository = new BuildingRepository();
            _locationRepository = new LocationRepository();
            LoadLocationsAndBuildings();
            ClearFields();
        }


        private void btnAddBuilding_Click(object sender, EventArgs e)
        {
            // Alanların kontrolü
            if (AlanlariKontrolEt())
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!");
                return;
            }

            // Giriş doğrulama
            if (!_buildingRepository.IsBuildingUnique(txtBuildingName.Text))
            {
                MessageBox.Show("Bu bina adı zaten mevcut. Lütfen farklı bir isim giriniz.");
                return;
            }

            if (!_buildingRepository.IsFloorCountValid((int)nudNumberOfFloor.Value))
            {
                MessageBox.Show("Kat sayısı 1 ile 5 arasında olmalıdır.");
                return;
            }

            if (!_buildingRepository.IsFloorSizeValid((int)nudFloorSize.Value))
            {
                MessageBox.Show("Kat boyutu 50 ile 300 metrekare arasında olmalıdır.");
                return;
            }

            if (!_buildingRepository.IsRoomCountValid((int)nudRoomPerFloor.Value))
            {
                MessageBox.Show("Kat başına oda sayısı 1 ile 6 arasında olmalıdır.");
                return;
            }

            try
            {
                // Yeni bina nesnesini oluştur
                _newBuilding = new Building
                {
                    Name = txtBuildingName.Text,
                    Address = txtAddress.Text,
                    NumberOfFloor = (int)nudNumberOfFloor.Value, // NumericUpDown değeri int'e çevrilir
                    FloorSize = (int)nudFloorSize.Value,
                    RoomPerFloor = (int)nudRoomPerFloor.Value,
                    LocationId = (int)cmbLocation.SelectedValue // Seçilen lokasyonun ID'si
                };

                // Bina ekleme işlemi
                _buildingRepository.Add(_newBuilding);

                MessageBox.Show("Bina başarıyla eklendi!");
                ClearFields(); // Alanları temizle
                LoadLocationsAndBuildings(); // Bina ve Lokasyon listesini güncelle
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void ClearFields()
        {
            txtBuildingName.Clear();
            txtAddress.Clear();
            nudNumberOfFloor.Value = 1; // Varsayılan değer olarak 1 atanır
            nudFloorSize.Value = 50;
            nudRoomPerFloor.Value = 1;
            cmbLocation.SelectedIndex = -1; // ComboBox seçimini kaldır
        }

        private void LoadLocationsAndBuildings()
        {
            var locationDisplayData = _locationRepository.GetAll().Select(x => new
            {
                Display = x.ToString(), // ToString ile formatlanmış hali
                Value = x.Id           // ID değeri
            }).ToList();

            cmbLocation.DataSource = locationDisplayData;
            cmbLocation.DisplayMember = "Display"; // Görüntülenecek alan
            cmbLocation.ValueMember = "Value";    // ID olarak seçilecek alan

            lstBuildings.DataSource = _buildingRepository.GetAll();
            lstBuildings.DisplayMember = "ToString";
        }

        private bool AlanlariKontrolEt()
        {
            return txtBuildingName.Text == "" ||
                            txtAddress.Text == "" ||
                            nudNumberOfFloor.Value <= 0 ||
                            nudFloorSize.Value <= 0 ||
                            nudRoomPerFloor.Value <= 0 ||
                            cmbLocation.SelectedIndex == -1;
        }
    }
}
