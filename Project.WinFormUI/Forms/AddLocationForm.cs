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
        LocationRepository _locationRepository;
        Location _newLocation;
        public AddLocationForm()
        {
            InitializeComponent();
            _locationRepository = new LocationRepository();
            LoadLocations(); // Listeyi Güncelle
        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (txtCity.Text=="" || txtDistrict.Text=="")
            {
                MessageBox.Show("Lütfen şehir ve ilçe bilgilerini doldurun.");
                return;
            }

            // Benzersizlik Kontrolü
            if (!_locationRepository.IsLocationUnique(txtCity.Text, txtDistrict.Text))
            {
                MessageBox.Show("Bu lokasyon zaten mevcut.");
                return;
            }

            // Yeni Lokasyon Nesnesi
            _newLocation = new Location
            {
                City = txtCity.Text,
                District = txtDistrict.Text
            };

            // Veritabanına Ekle
            try
            {
                _locationRepository.Add(_newLocation);
                MessageBox.Show("Lokasyon başarıyla eklendi.");
                LoadLocations(); // Listeyi Güncelle
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
        private void LoadLocations()
        {
            lstLocations.DataSource = null; // Önce listeyi sıfırla
            lstLocations.DataSource = _locationRepository.GetAll(); // Tüm lokasyonları getir
            lstLocations.DisplayMember = "ToString"; // Görünecek alan (örn. "İstanbul - Ataşehir")
            //lstLocations.ValueMember = "Id"; // Gizli ID değeri
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
