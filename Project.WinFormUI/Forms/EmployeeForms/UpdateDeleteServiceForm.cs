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
    public partial class UpdateDeleteServiceForm : Form
    {
        // Repository'ler
        private ServiceDescriptorRepository _serviceDescriptorRepository;
        private ServiceValueRepository _serviceValueRepository;
        private ServiceProviderRepository _serviceProviderRepository;
        private ServiceProviderServiceValueRepository _providerServiceValueRepository;

        private ServiceProvider _selectedProvider;
        private ServiceValue _selectedServiceValue;

        public UpdateDeleteServiceForm()
        {
            InitializeComponent();

            // Repository örnekleri
            _serviceDescriptorRepository = new ServiceDescriptorRepository();
            _serviceValueRepository = new ServiceValueRepository();
            _serviceProviderRepository = new ServiceProviderRepository();
            _providerServiceValueRepository = new ServiceProviderServiceValueRepository();

            InitializeListBox();
            LoadExistingServices();
        }

        private void lstServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstServices.SelectedIndex != -1) // Bir öğe seçildiyse
            {
                var selectedItem = lstServices.SelectedItem.ToString();

                // Öğe formatı: "Sağlayıcı Adı - Hizmet Adı - Maliyet"
                var parts = selectedItem.Split('-');
                if (parts.Length == 3)
                {
                    string providerName = parts[0].Trim();
                    string serviceName = parts[1].Trim();

                    // Sağlayıcı ve hizmeti veritabanından al
                    _selectedProvider = _serviceProviderRepository.GetByName(providerName);
                    _selectedServiceValue = _serviceValueRepository.GetByName(serviceName);

                    if (_selectedProvider != null && _selectedServiceValue != null)
                    {
                        // Sağlayıcı bilgilerini doldur
                        txtProviderName.Text = _selectedProvider.ProviderName;
                        txtProviderAddress.Text = _selectedProvider.Address;
                        txtProviderCity.Text = _selectedProvider.City;
                        txtProviderDistrict.Text = _selectedProvider.District;
                        txtProviderPhoneNumber.Text = _selectedProvider.PhoneNumber;
                        txtProviderEmail.Text = _selectedProvider.Email;

                        // Sağlayıcı bilgilerini düzenlenemez yap
                        //txtProviderName.ReadOnly = false;
                        //txtProviderAddress.ReadOnly = false;
                        //txtProviderCity.ReadOnly = false;
                        //txtProviderDistrict.ReadOnly = false;
                        //txtProviderPhoneNumber.ReadOnly = false;
                        //txtProviderEmail.ReadOnly = false;

                        // Hizmet bilgilerini doldur
                        txtDescriptorName.Text = _selectedServiceValue.ServiceDescriptor?.Name ?? string.Empty;
                        txtDescriptorDescription.Text = _selectedServiceValue.ServiceDescriptor?.Description ?? string.Empty;

                        txtValueName.Text = _selectedServiceValue.Name;
                        nudCost.Value = _selectedServiceValue.Cost;
                        nudPreparationTime.Value = _selectedServiceValue.PreparationTime;
                        nudBufferTime.Value = _selectedServiceValue.BufferTime;
                    }
                }
            }
            else
            {
                ClearFields();
            }
        }

        private void btnUpdateService_Click(object sender, EventArgs e)
        {
            if (_selectedProvider == null || _selectedServiceValue == null)
            {
                MessageBox.Show("Lütfen bir hizmet seçin.");
                return;
            }

            try
            {
                // Seçilen hizmet değerini güncelle
                _selectedServiceValue.Name = txtValueName.Text;
                _selectedServiceValue.Cost = nudCost.Value;
                _selectedServiceValue.PreparationTime = (int)nudPreparationTime.Value;
                _selectedServiceValue.BufferTime = (int)nudBufferTime.Value;

                _serviceValueRepository.Update(_selectedServiceValue);

                // Seçilen sağlayıcıyı güncelle
                _selectedProvider.ProviderName = txtProviderName.Text;
                _selectedProvider.Address = txtProviderAddress.Text;
                _selectedProvider.City = txtProviderCity.Text;
                _selectedProvider.District = txtProviderDistrict.Text;
                _selectedProvider.PhoneNumber = txtProviderPhoneNumber.Text;
                _selectedProvider.Email = txtProviderEmail.Text;

                _serviceProviderRepository.Update(_selectedProvider);

                MessageBox.Show("Hizmet ve sağlayıcı bilgileri başarıyla güncellendi.");
                LoadExistingServices(); // Listeyi yeniden yükle
                ClearFields();          // Alanları temizle
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında bir hata oluştu: {ex.Message}");
            }
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (_selectedProvider == null || _selectedServiceValue == null)
            {
                MessageBox.Show("Lütfen bir hizmet seçin.");
                return;
            }

            try
            {
                // İlişkili kaydı sil
                var link = _providerServiceValueRepository
                    .FirstOrDefault(psv => psv.ServiceProviderId == _selectedProvider.Id &&
                                           psv.ServiceValueId == _selectedServiceValue.Id);

                if (link != null)
                {
                    _providerServiceValueRepository.Delete(link);
                }

                // Hizmet değerini sil
                _serviceValueRepository.Delete(_selectedServiceValue);

                MessageBox.Show("Hizmet başarıyla silindi.");
                LoadExistingServices();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme sırasında bir hata oluştu: {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();

        }


        private void InitializeListBox()
        {
            // ListBox başlat
            lstServices.Items.Clear();
        }

        private void LoadExistingServices()
        {
            try
            {
                var providerServiceValues = _providerServiceValueRepository.GetAll()
                    .Select(psv => new
                    {
                        ProviderName = psv.ServiceProvider.ProviderName,
                        ServiceName = psv.ServiceValue.Name,
                        Cost = psv.ServiceValue.Cost
                    })
                    .ToList();

                lstServices.Items.Clear(); // ListBox'ı temizle

                foreach (var service in providerServiceValues)
                {
                    // ListBox için her hizmeti string formatında ekle
                    lstServices.Items.Add($"{service.ProviderName} - {service.ServiceName} - {service.Cost:C2}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hizmetler yüklenirken bir hata oluştu: {ex.Message}");
            }
        }

        private void ClearFields()
        {
            txtProviderName.Clear();
            txtProviderAddress.Clear();
            txtProviderCity.Clear();
            txtProviderDistrict.Clear();
            txtProviderPhoneNumber.Clear();
            txtProviderEmail.Clear();

            txtDescriptorName.Clear();
            txtDescriptorDescription.Clear();
            txtValueName.Clear();
            nudCost.Value = 0;
            nudPreparationTime.Value = 0;
            nudBufferTime.Value = 0;

            // Alanları düzenlenebilir hale getir
            txtProviderName.ReadOnly = false;
            txtProviderAddress.ReadOnly = false;
            txtProviderCity.ReadOnly = false;
            txtProviderDistrict.ReadOnly = false;
            txtProviderPhoneNumber.ReadOnly = false;
            txtProviderEmail.ReadOnly = false;
        }

        
    }
}
