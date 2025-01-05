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
    public partial class AddLocationForm : Form
    {
        LocationRepository _locationRepository; // Lokasyon işlemleri için repository
        Location _newLocation; // Yeni lokasyon nesnesini tutar

        // Constructor: Formun başlatılması ve repository örneğinin oluşturulması
        public AddLocationForm()
        {
            InitializeComponent();

            _locationRepository = new LocationRepository(); // Lokasyon repository'si oluşturulur
            LoadLocations(); // Aktif lokasyonları yükler
        }

        // "Lokasyon Ekle" butonuna tıklandığında çağrılır
        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            // Şehir ve ilçe alanlarının boş olup olmadığını kontrol eder
            if (txtCity.Text == "" || txtDistrict.Text == "")
            {
                MessageBox.Show("Lütfen şehir ve ilçe bilgilerini doldurun.");
                return;
            }

            // Lokasyonun benzersiz olup olmadığını kontrol eder
            if (!_locationRepository.IsLocationUnique(txtCity.Text, txtDistrict.Text))
            {
                MessageBox.Show("Bu lokasyon zaten mevcut.");
                return;
            }

            // Yeni lokasyon nesnesi oluşturulur ve formdaki bilgiler atanır
            _newLocation = new Location
            {
                City = txtCity.Text,
                District = txtDistrict.Text
            };

            // Lokasyonu veritabanına ekleme işlemi
            try
            {
                _locationRepository.Add(_newLocation); // Repository aracılığıyla ekleme yapılır
                MessageBox.Show("Lokasyon başarıyla eklendi."); // Başarı mesajı gösterilir
                LoadLocations(); // Lokasyon listesini günceller
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi verilir
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        // "Kapat" butonuna tıklandığında formu kapatır
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close(); // Formu kapatır
        }


        /*****************Form Metotlari********************/
        // Lokasyon listesini yükler
        private void LoadLocations()
        {
            lstLocations.DataSource = null; // Listeyi temizler
            lstLocations.DataSource = _locationRepository.GetActives(); // Aktif lokasyonları getirir
            lstLocations.DisplayMember = "ToString"; // Görünecek alan olarak ToString kullanılır
        }
    }
}
