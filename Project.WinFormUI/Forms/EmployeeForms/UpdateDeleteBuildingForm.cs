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
        
        // BuildingRepository ve LocationRepository nesneleri tanımlanıyor
        private BuildingRepository _buildingRepository;
        private LocationRepository _locationRepository;

        private Building _selectedBuilding;// Seçilen bina nesnesi için bir değişken tanımlanıyor
       
        public UpdateDeleteBuildingForm()// Formun yapıcı metodu

        {
            InitializeComponent();    // Formun bileşenlerini başlat

            // Repository örneklerini oluştur
            _buildingRepository = new BuildingRepository();
            _locationRepository = new LocationRepository();
            LoadLocationsAndBuildings();    // Lokasyon ve bina verilerini yükle
            ClearFields();   // Form alanlarını temizle

        }

        private void LoadLocationsAndBuildings()
        {

            // Lokasyonları yükleme işlemi
            var locationDisplayData = _locationRepository.GetAll().Select(x => new
            {
                // Lokasyonun görüntülenecek bilgisi ve ID'si için anonim bir tip oluşturuluyor
                Display = x.ToString(),
                Value = x.Id
            }).ToList();

            // Lokasyon verilerini ComboBox'a bağla
            cmbLocation.DataSource = locationDisplayData;// Veriler ComboBox'ın veri kaynağına atanıyor
            cmbLocation.DisplayMember = "Display";// Görüntülenecek olan özellik
            cmbLocation.ValueMember = "Value";// Seçildiğinde alınacak olan değer

            // Aktif binaları listeleme işlemi
            lstBuildings.DataSource = _buildingRepository.GetActives(); // Sadece aktif binalar alınır ve listeye bağlanır
            lstBuildings.DisplayMember = "ToString";// Liste elemanlarının nasıl görüneceği belirtiliyor
        }

        private void lstBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBuildings.SelectedItem != null)// Eğer listeden bir bina seçilmişse

            {
                _selectedBuilding = (Building)lstBuildings.SelectedItem;    // Seçilen öğe, Building tipine dönüştürülür

                // Seçilen binanın detaylarını ilgili alanlara yansıt
                txtBuildingName.Text = _selectedBuilding.Name; // Bina adını TextBox'a yaz
                txtAddress.Text = _selectedBuilding.Address; // Adresi TextBox'a yaz
                nudNumberOfFloor.Value = _selectedBuilding.NumberOfFloor; // Kat sayısını NumericUpDown'a yaz
                nudFloorSize.Value = _selectedBuilding.FloorSize; // Kat metrekare bilgisini NumericUpDown'a yaz
                nudRoomPerFloor.Value = _selectedBuilding.RoomPerFloor; // Kat başına oda sayısını NumericUpDown'a yaz
                cmbLocation.SelectedValue = _selectedBuilding.LocationId; // Lokasyon seçimini ComboBox'ta yap


                // Seçilen binanın detaylarını bir Label'e yazdır
                lblSelectedBuilding.Text = $"Bina Adı: {_selectedBuilding.Name}\n" +
                                           $"Adres: {_selectedBuilding.Address}\n" +
                                           $"Kat Sayısı: {_selectedBuilding.NumberOfFloor}\n" +
                                           $"Kat Metrekare: {_selectedBuilding.FloorSize}\n" +
                                           $"Kat Başına Oda: {_selectedBuilding.RoomPerFloor}\n" +
                                           $"Lokasyon: {_selectedBuilding.Location?.ToString()}"; // Eğer lokasyon varsa yazdır, yoksa boş bırak
            }
            else
            {
                // Eğer herhangi bir bina seçilmemişse, kullanıcıyı bilgilendir
                lblSelectedBuilding.Text = "Seçilen Bina: Yok";
            }
        }

        private void btnUpdateBuilding_Click(object sender, EventArgs e)
        {
            // Eğer seçilen bina yoksa, kullanıcıyı bilgilendir
            if (_selectedBuilding == null)
            {
                MessageBox.Show("Lütfen bir bina seçiniz.");
                return; // Fonksiyonu sonlandır
            }

            // Güncelleme işlemi için geçerlilik kontrolleri yapılıyor
            if (!_buildingRepository.IsFloorCountValid((int)nudNumberOfFloor.Value) ||
                !_buildingRepository.IsFloorSizeValid((int)nudFloorSize.Value) ||
                !_buildingRepository.IsRoomCountValid((int)nudRoomPerFloor.Value))
            {
                // Eğer herhangi bir değer geçersizse, kullanıcıyı bilgilendir
                MessageBox.Show("Girilen değerler uygun değil.");
                return; // Fonksiyonu sonlandır
            }

            try
            {
                // Seçilen binanın özelliklerini formdaki verilere göre güncelle
                _selectedBuilding.Name = txtBuildingName.Text; // Bina adı
                _selectedBuilding.Address = txtAddress.Text; // Adres
                _selectedBuilding.NumberOfFloor = (int)nudNumberOfFloor.Value; // Kat sayısı
                _selectedBuilding.FloorSize = (int)nudFloorSize.Value; // Kat büyüklüğü
                _selectedBuilding.RoomPerFloor = (int)nudRoomPerFloor.Value; // Kat başına oda sayısı
                _selectedBuilding.LocationId = (int)cmbLocation.SelectedValue; // Lokasyon ID
                                                                               // Bina bilgilerini repository aracılığıyla güncelle
                _buildingRepository.Update(_selectedBuilding);

                // Güncelleme başarılı olduğunda kullanıcıyı bilgilendir
                MessageBox.Show("Bina başarıyla güncellendi.");
                LoadLocationsAndBuildings();  // Güncellenmiş listeyi yükle
                ClearFields();// Form alanlarını temizle

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}"); // Hata oluşursa, kullanıcıya hata mesajı göster
            }
        }

        private void btnDeleteBuilding_Click(object sender, EventArgs e)
        { // Eğer seçilen bina yoksa, kullanıcıyı bilgilendir
            if (_selectedBuilding == null)
            {
                MessageBox.Show("Lütfen bir bina seçiniz.");
                return; // Fonksiyonu sonlandır
            }

            try
            {
                // Seçilen bina silinir
                _buildingRepository.Delete(_selectedBuilding);

                // Silme işlemi başarılı ise kullanıcıyı bilgilendir
                MessageBox.Show("Bina başarıyla silindi.");

                // Listeyi güncelle
                LoadLocationsAndBuildings();

                // Form alanlarını temizle
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}"); // Hata oluşursa, kullanıcıya hata mesajı göster
            }
        }

        private void ClearFields()
        {
            // TextBox'ları temizle
            txtBuildingName.Clear();
            txtAddress.Clear();
            // NumericUpDown değerlerini sıfırla
            nudNumberOfFloor.Value = 1;
            nudFloorSize.Value = 50;
            nudRoomPerFloor.Value = 1;

            cmbLocation.SelectedIndex = -1;    // ComboBox'ı sıfırla
                                               // Seçilen bina bilgisini sıfırla
            lblSelectedBuilding.Text = "Seçilen Bina: Yok";
            _selectedBuilding = null;
            lstBuildings.SelectedIndex = -1;    // Listeyi sıfırla
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();//formu kapatır
        }

     
    }
}
