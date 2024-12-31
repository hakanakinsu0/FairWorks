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
    public partial class UpdateDeleteLocationForm : Form
    {
        private LocationRepository _locationRepository;
        private Location _selectedLocation;

        public UpdateDeleteLocationForm()
        {
            InitializeComponent();
            _locationRepository = new LocationRepository();
            LoadLocations();
        }

        private void LoadLocations()
        {
            // Aktif lokasyonları yükle
            lstLocations.DataSource = _locationRepository.GetActives();
            lstLocations.DisplayMember = "ToString";
        }

        private void lstLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLocations.SelectedItem != null)
            {
                _selectedLocation = (Location)lstLocations.SelectedItem;

                // Seçilen lokasyon bilgilerini alanlara doldur
                txtCity.Text = _selectedLocation.City;
                txtDistrict.Text = _selectedLocation.District;

                // Seçilen lokasyon bilgilerini Label'de göster
                lblSelectedLocation.Text = $"Seçilen Lokasyon: {_selectedLocation.District}, {_selectedLocation.City}";
            }
            else
            {
                ClearFields();
            }
        }

        private void btnUpdateLocation_Click(object sender, EventArgs e)
        {
            if (_selectedLocation == null)
            {
                MessageBox.Show("Lütfen bir lokasyon seçiniz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text) || string.IsNullOrWhiteSpace(txtDistrict.Text))
            {
                MessageBox.Show("Şehir ve ilçe bilgilerini doldurunuz.");
                return;
            }

            try
            {
                // Lokasyon bilgilerini güncelle
                _selectedLocation.City = txtCity.Text;
                _selectedLocation.District = txtDistrict.Text;

                _locationRepository.Update(_selectedLocation);

                MessageBox.Show("Lokasyon başarıyla güncellendi.");
                LoadLocations(); // Listeyi güncelle
                ClearFields(); // Alanları temizle
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            if (_selectedLocation == null)
            {
                MessageBox.Show("Lütfen bir lokasyon seçiniz.");
                return;
            }

            try
            {
                _locationRepository.Delete(_selectedLocation);
                MessageBox.Show("Lokasyon başarıyla silindi.");
                LoadLocations(); // Listeyi güncelle
                ClearFields(); // Alanları temizle
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void ClearFields()
        {
            txtCity.Clear();
            txtDistrict.Clear();
            lblSelectedLocation.Text = "Seçilen Lokasyon: Yok";
            _selectedLocation = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
