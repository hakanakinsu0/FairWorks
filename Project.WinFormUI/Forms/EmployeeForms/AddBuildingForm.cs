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
        // Bina ve lokasyon işlemleri için repository'ler tanımlanır
        BuildingRepository _buildingRepository;
        LocationRepository _locationRepository;

        // Yeni bina nesnesini tutar
        Building _newBuilding;

        // Constructor: Formun başlatılması ve gerekli repository'lerin oluşturulması
        public AddBuildingForm()
        {
            InitializeComponent();

            _buildingRepository = new BuildingRepository(); // Bina repository'si oluşturulur
            _locationRepository = new LocationRepository(); // Lokasyon repository'si oluşturulur

            LoadLocationsAndBuildings(); // Lokasyon ve binaları yükler
            ClearFields(); // Formdaki alanları temizler
        }

        // "Bina Ekle" butonuna tıklandığında çağrılır
        private void btnAddBuilding_Click(object sender, EventArgs e)
        {
            // Alanların kontrolü yapılır, eksik bilgi varsa uyarı gösterilir
            if (AlanlariKontrolEt())
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!");
                return;
            }

            // Bina adının benzersiz olup olmadığı kontrol edilir
            if (!_buildingRepository.IsBuildingUnique(txtBuildingName.Text))
            {
                MessageBox.Show("Bu bina adı zaten mevcut. Lütfen farklı bir isim giriniz.");
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

            try
            {
                // Yeni bina nesnesi oluşturulur ve formdaki bilgiler atanır
                _newBuilding = new Building
                {
                    Name = txtBuildingName.Text,
                    Address = txtAddress.Text,
                    NumberOfFloor = (int)nudNumberOfFloor.Value, // NumericUpDown değeri int'e çevrilir
                    FloorSize = (int)nudFloorSize.Value,
                    RoomPerFloor = (int)nudRoomPerFloor.Value,
                    LocationId = (int)cmbLocation.SelectedValue // Seçilen lokasyonun ID'si
                };

                // Yeni bina repository aracılığıyla veritabanına eklenir
                _buildingRepository.Add(_newBuilding);

                // Başarı mesajı gösterilir
                MessageBox.Show("Bina başarıyla eklendi!");
                ClearFields(); // Alanları temizle
                LoadLocationsAndBuildings(); // Bina ve Lokasyon listesini güncelle
            }
            catch (Exception ex)
            {
                // Hata mesajı gösterilir
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        // "Kapat" butonuna tıklandığında form kapanır
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close(); // Formu kapatır
        }

        /********************Form Metotlari***********************/
        // Formdaki tüm alanları temizler ve varsayılan değerlere ayarlar
        private void ClearFields()
        {
            txtBuildingName.Clear();
            txtAddress.Clear();
            nudNumberOfFloor.Value = 1; // Varsayılan değer olarak 1 atanır
            nudFloorSize.Value = 50;
            nudRoomPerFloor.Value = 1;
            cmbLocation.SelectedIndex = -1; // ComboBox seçimini kaldır
        }

        // Lokasyon ve bina bilgilerini yükler
        private void LoadLocationsAndBuildings()
        {
            // Lokasyon verileri formatlanır ve ComboBox'a yüklenir
            var locationDisplayData = _locationRepository.GetAll().Select(x => new
            {
                Display = x.ToString(), // Lokasyonun formatlanmış hali (örn: İlçe/Şehir)
                Value = x.Id // Lokasyon ID'si
            }).ToList();

            cmbLocation.DataSource = locationDisplayData; // ComboBox'a veri atanır
            cmbLocation.DisplayMember = "Display"; // Görüntülenecek alan
            cmbLocation.ValueMember = "Value"; // Seçilecek alanın değeri (ID)

            // Aktif binalar ListBox'a yüklenir
            lstBuildings.DataSource = _buildingRepository.GetActives(); // Silinmemiş binaları getirir
            lstBuildings.DisplayMember = "ToString"; // Bina bilgilerini göstermek için ToString kullanılır
        }

        // Formdaki tüm alanların dolu olup olmadığını kontrol eder
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
