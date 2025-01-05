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
        // Repository'ler ve seçilen hizmet bilgilerini tutacak değişkenler
        ServiceDescriptorRepository _serviceDescriptorRepository;
        ServiceValueRepository _serviceValueRepository;
        ServiceProviderRepository _serviceProviderRepository;
        ServiceProviderServiceValueRepository _providerServiceValueRepository;

        // Seçilen sağlayıcı ve hizmet değeri nesneleri
        // Bu nesneler, kullanıcının seçim yaptığı sağlayıcı ve hizmet değerini tutar
        ServiceProvider _selectedProvider;  // Seçilen hizmet sağlayıcısı
        ServiceValue _selectedServiceValue; // Seçilen hizmet değeri


        public UpdateDeleteServiceForm()
        {

            InitializeComponent();
            // Repository örneklerini başlat
            _serviceDescriptorRepository = new ServiceDescriptorRepository();
            _serviceValueRepository = new ServiceValueRepository();
            _serviceProviderRepository = new ServiceProviderRepository();
            _providerServiceValueRepository = new ServiceProviderServiceValueRepository();
            // Hizmetler listesine yükleme işlemini başlat
            InitializeListBox();

            // Mevcut hizmetleri yükle
            LoadExistingServices();
        }

        private void lstServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstServices.SelectedIndex != -1) // Eğer listeden bir öğe seçilmişse
            {
                string selectedItem = lstServices.SelectedItem.ToString();

                // Öğe formatı: "Sağlayıcı Adı - Hizmet Adı - Maliyet"
                string[] parts = selectedItem.Split('-');
                if (parts.Length == 3)
                {
                    string providerName = parts[0].Trim();
                    string serviceName = parts[1].Trim();

                    // Sağlayıcı ve hizmeti veritabanından al
                    _selectedProvider = _serviceProviderRepository.GetByName(providerName);
                    _selectedServiceValue = _serviceValueRepository.GetByName(serviceName);

                    if (_selectedProvider != null && _selectedServiceValue != null) // Sağlayıcı ve hizmet verileri bulunduysa, detayları alanlara doldur
                    {
                        // Sağlayıcı bilgilerini doldur
                        txtProviderName.Text = _selectedProvider.ProviderName; // Sağlayıcı adını doldurur
                        txtProviderAddress.Text = _selectedProvider.Address;   // Sağlayıcı adresini doldurur
                        txtProviderCity.Text = _selectedProvider.City;         // Sağlayıcı şehir bilgisini doldurur
                        txtProviderDistrict.Text = _selectedProvider.District; // Sağlayıcı ilçe bilgisini doldurur
                        txtProviderPhoneNumber.Text = _selectedProvider.PhoneNumber; // Sağlayıcı telefon numarasını doldurur
                        txtProviderEmail.Text = _selectedProvider.Email;      // Sağlayıcı e-posta bilgisini doldurur

                        // Hizmet bilgilerini doldur
                        txtDescriptorName.Text = _selectedServiceValue.ServiceDescriptor?.Name ?? string.Empty; // Hizmet açıklamasını doldurur (varsa)
                        txtDescriptorDescription.Text = _selectedServiceValue.ServiceDescriptor?.Description ?? string.Empty; // Hizmet açıklamasının detaylarını doldurur (varsa)

                        txtValueName.Text = _selectedServiceValue.Name; // Hizmet adını doldurur
                        nudCost.Value = _selectedServiceValue.Cost; // Hizmet maliyetini doldurur
                        nudPreparationTime.Value = _selectedServiceValue.PreparationTime; // Hazırlık süresini doldurur
                        nudBufferTime.Value = _selectedServiceValue.BufferTime; // Tampon süresini doldurur
                    }
                }
            }
            else
            {
                ClearFields();   // Seçim yapılmamışsa alanları temizle

            }
        }

        private void btnUpdateService_Click(object sender, EventArgs e)
        {
            if (_selectedProvider == null || _selectedServiceValue == null) // Eğer herhangi bir hizmet seçilmemişse, kullanıcıya uyarı ver

            {
                MessageBox.Show("Lütfen bir hizmet seçin.");
                return;
            }

            try
            {
                // Seçilen hizmet değerini güncelle
                _selectedServiceValue.Name = txtValueName.Text; // Hizmet adını günceller
                _selectedServiceValue.Cost = nudCost.Value; // Hizmet maliyetini günceller
                _selectedServiceValue.PreparationTime = (int)nudPreparationTime.Value; // Hazırlık süresini günceller
                _selectedServiceValue.BufferTime = (int)nudBufferTime.Value; // Tampon süresini günceller

                _serviceValueRepository.Update(_selectedServiceValue); // Güncellenen hizmet değerini veritabanına kaydeder

                // Seçilen sağlayıcıyı güncelle
                _selectedProvider.ProviderName = txtProviderName.Text; // Sağlayıcı adını günceller
                _selectedProvider.Address = txtProviderAddress.Text; // Sağlayıcı adresini günceller
                _selectedProvider.City = txtProviderCity.Text; // Sağlayıcı şehir bilgisini günceller
                _selectedProvider.District = txtProviderDistrict.Text; // Sağlayıcı ilçe bilgisini günceller
                _selectedProvider.PhoneNumber = txtProviderPhoneNumber.Text; // Sağlayıcı telefon numarasını günceller
                _selectedProvider.Email = txtProviderEmail.Text; // Sağlayıcı e-posta bilgisini günceller

                _serviceProviderRepository.Update(_selectedProvider); // Güncellenen sağlayıcı bilgisini veritabanına kaydeder

                MessageBox.Show("Hizmet ve sağlayıcı bilgileri başarıyla güncellendi.");   // Başarılı güncelleme mesajı

                // Listeyi yeniden yükle
                LoadExistingServices();

                // Alanları temizle
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında bir hata oluştu: {ex.Message}"); // Hata durumunda mesaj göster

            }
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {

            if (_selectedProvider == null || _selectedServiceValue == null)  // Hizmet veya sağlayıcı seçilmediyse kullanıcıyı uyar

            {
                MessageBox.Show("Lütfen bir hizmet seçin.");
                return;
            }

            try
            {
                // Sağlayıcı ve hizmet değeri arasındaki ilişkiyi bul ve sil
                ServiceProviderServiceValue link = _providerServiceValueRepository
                    .FirstOrDefault(psv => psv.ServiceProviderId == _selectedProvider.Id &&
                                           psv.ServiceValueId == _selectedServiceValue.Id);
                // Eğer ilişki mevcutsa, bu ilişkili kaydı sil
                if (link != null)
                {
                    _providerServiceValueRepository.Delete(link); // İlgili link kaydını sil
                }

                // Hizmet değerini sil
                _serviceValueRepository.Delete(_selectedServiceValue);

                // Başarılı silme mesajı
                MessageBox.Show("Hizmet başarıyla silindi.");

                // Listeyi güncelle
                LoadExistingServices();

                // Alanları temizle
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme sırasında bir hata oluştu: {ex.Message}");  // Silme sırasında hata oluşursa mesaj göster

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close(); // Formu kapat


        }

        /************Form Metotları**************/
        // ListBox'ı başlatan metod
        private void InitializeListBox()
        {
            // ListBox öğelerini temizle
            lstServices.Items.Clear();
        }

        // Mevcut hizmetleri yükleyen metod
        private void LoadExistingServices()
        {
            try
            {
                // Sağlayıcı ve hizmet bilgilerini birleştirerek listeyi oluştur
                var providerServiceValues = _providerServiceValueRepository.GetAll()
                    .Select(psv => new
                    {
                        ProviderName = psv.ServiceProvider.ProviderName,
                        ServiceName = psv.ServiceValue.Name,
                        Cost = psv.ServiceValue.Cost
                    })
                    .ToList();

                // ListBox'ı temizle
                lstServices.Items.Clear();

                // ListBox'a her bir hizmeti ekle
                foreach (var service in providerServiceValues)
                {
                    // Hizmeti uygun formatta ekle (Sağlayıcı adı - Hizmet adı - Maliyet)
                    lstServices.Items.Add($"{service.ProviderName} - {service.ServiceName} - {service.Cost:C2}");
                }
            }
            catch (Exception ex)
            {
                // Hata oluşursa, hata mesajını göster
                MessageBox.Show($"Hizmetler yüklenirken bir hata oluştu: {ex.Message}");
            }

        }
        // Alanları temizleyen metod
        private void ClearFields()
        {

            // Sağlayıcı bilgilerini içeren alanları temizle
            txtProviderName.Clear(); // Sağlayıcı adını temizler
            txtProviderAddress.Clear(); // Sağlayıcı adresini temizler
            txtProviderCity.Clear(); // Sağlayıcı şehir bilgisini temizler
            txtProviderDistrict.Clear(); // Sağlayıcı ilçe bilgisini temizler
            txtProviderPhoneNumber.Clear(); // Sağlayıcı telefon numarasını temizler
            txtProviderEmail.Clear(); // Sağlayıcı e-posta bilgisini temizler

            // Hizmet bilgilerini içeren alanları temizle
            txtDescriptorName.Clear(); // Hizmet açıklama adını temizler
            txtDescriptorDescription.Clear(); // Hizmet açıklamasını temizler
            txtValueName.Clear(); // Hizmet değer adını temizler
            nudCost.Value = 0; // Maliyet sıfırlanır
            nudPreparationTime.Value = 0; // Hazırlık süresi sıfırlanır
            nudBufferTime.Value = 0; // Yedek süre sıfırlanır

            // Alanları düzenlenebilir hale getir
            txtProviderName.ReadOnly = false; // Sağlayıcı adı alanını düzenlenebilir yapar
            txtProviderAddress.ReadOnly = false; // Sağlayıcı adresi alanını düzenlenebilir yapar
            txtProviderCity.ReadOnly = false; // Sağlayıcı şehir alanını düzenlenebilir yapar
            txtProviderDistrict.ReadOnly = false; // Sağlayıcı ilçe alanını düzenlenebilir yapar
            txtProviderPhoneNumber.ReadOnly = false; // Sağlayıcı telefon numarası alanını düzenlenebilir yapar
            txtProviderEmail.ReadOnly = false; // Sağlayıcı e-posta alanını düzenlenebilir yapar
        }

    }
}
