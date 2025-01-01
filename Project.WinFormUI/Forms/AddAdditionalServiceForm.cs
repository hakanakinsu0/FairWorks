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
    public partial class AddAdditionalServiceForm : Form
    {
        // Repository'ler
        private ServiceDescriptorRepository _serviceDescriptorRepository;
        private ServiceValueRepository _serviceValueRepository;
        private ServiceProviderRepository _serviceProviderRepository;
        private ServiceProviderServiceValueRepository _providerServiceValueRepository;

        public AddAdditionalServiceForm()
        {
            InitializeComponent();

            // Repository örnekleri
            _serviceDescriptorRepository = new ServiceDescriptorRepository();
            _serviceValueRepository = new ServiceValueRepository();
            _serviceProviderRepository = new ServiceProviderRepository();
            _providerServiceValueRepository = new ServiceProviderServiceValueRepository();

            InitializeListView();
            LoadExistingProviders();
            LoadExistingServices();
            SetInitialControlState();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            try
            {
                ServiceDescriptor descriptor = _serviceDescriptorRepository.GetByName(txtDescriptorName.Text);
                if (descriptor == null)
                {
                    descriptor = new ServiceDescriptor
                    {
                        Name = txtDescriptorName.Text,
                        Description = txtDescriptorDescription.Text
                    };
                    _serviceDescriptorRepository.Add(descriptor);
                }

                ServiceValue value = new ServiceValue
                {
                    Name = txtValueName.Text,
                    Cost = nudCost.Value,
                    PreparationTime = (int)nudPreparationTime.Value,
                    BufferTime = (int)nudBufferTime.Value,
                    ServiceDescriptorId = descriptor.Id
                };

                _serviceValueRepository.Add(value);

                if (!chkNewProvider.Checked && cmbExistingProviders.SelectedIndex != -1)
                {
                    int selectedProviderId = (int)cmbExistingProviders.SelectedValue;
                    ServiceProvider provider = _serviceProviderRepository.GetById(selectedProviderId);

                    if (provider != null)
                    {
                        // İlişki mevcutsa ekleme yapma
                        if (!_providerServiceValueRepository.IsServiceValueLinkedToProvider(provider.Id, value.Id))
                        {
                            ServiceProviderServiceValue providerServiceValue = new ServiceProviderServiceValue
                            {
                                ServiceProviderId = provider.Id,
                                ServiceValueId = value.Id
                            };
                            _providerServiceValueRepository.Add(providerServiceValue);
                        }
                        else
                        {
                            MessageBox.Show("Bu hizmet zaten bu sağlayıcıya atanmış.");
                        }
                    }
                }
                else
                {
                    ServiceProvider provider = new ServiceProvider
                    {
                        ProviderName = txtProviderName.Text,
                        Address = txtProviderAddress.Text,
                        City = txtProviderCity.Text,
                        District = txtProviderDistrict.Text,
                        PhoneNumber = txtProviderPhoneNumber.Text,
                        Email = txtProviderEmail.Text
                    };

                    _serviceProviderRepository.Add(provider);

                    ServiceProviderServiceValue providerServiceValue = new ServiceProviderServiceValue
                    {
                        ServiceProviderId = provider.Id,
                        ServiceValueId = value.Id
                    };

                    _providerServiceValueRepository.Add(providerServiceValue);
                    LoadExistingProviders();
                }

                MessageBox.Show("Hizmet başarıyla eklendi!");
                LoadExistingServices();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void chkNewProvider_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNewProvider.Checked)
            {
                ClearFields();
                SetControlsEnabled(true);
                cmbExistingProviders.Enabled = false;
                cmbExistingProviders.SelectedIndex = -1;
            }
            else
            {
                ClearFields();
                SetControlsEnabled(false);
                cmbExistingProviders.Enabled = true;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void AddAdditionalServiceForm_Load(object sender, EventArgs e)
        {
            LoadExistingProviders(); // Mevcut sağlayıcıları yükler
            LoadExistingServices();  // Mevcut hizmetleri yükler
        }


        private void cmbExistingProviders_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (chkNewProvider.Checked)
            {
                ClearFields();
                SetControlsEnabled(true);
                cmbExistingProviders.Enabled = false;
                cmbExistingProviders.SelectedIndex = -1;
            }
            else
            {
                cmbExistingProviders.Enabled = true;

                if (cmbExistingProviders.SelectedValue != null && int.TryParse(cmbExistingProviders.SelectedValue.ToString(), out int selectedProviderId))
                {
                    ServiceProvider provider = _serviceProviderRepository.GetById(selectedProviderId);
                    if (provider != null)
                    {
                        // Sağlayıcı bilgilerini doldur
                        txtProviderName.Text = provider.ProviderName;
                        txtProviderAddress.Text = provider.Address;
                        txtProviderCity.Text = provider.City;
                        txtProviderDistrict.Text = provider.District;
                        txtProviderPhoneNumber.Text = provider.PhoneNumber;
                        txtProviderEmail.Text = provider.Email;

                        // Sağlayıcı bilgilerini düzenlenemez yap
                        txtProviderName.ReadOnly = true;
                        txtProviderAddress.ReadOnly = true;
                        txtProviderCity.ReadOnly = true;
                        txtProviderDistrict.ReadOnly = true;
                        txtProviderPhoneNumber.ReadOnly = true;
                        txtProviderEmail.ReadOnly = true;

                        // İlk ilişkili hizmet tanımını al
                        ServiceDescriptor firstServiceDescriptor = _serviceDescriptorRepository.GetAll()
                            .FirstOrDefault(d => d.ServiceValues.Any(v => v.ProviderServiceValues.Any(psv => psv.ServiceProviderId == provider.Id)));

                        if (firstServiceDescriptor != null)
                        {
                            txtDescriptorName.Text = firstServiceDescriptor.Name;
                            txtDescriptorDescription.Text = firstServiceDescriptor.Description;

                            // Hizmet adı ve açıklamasını düzenlenemez yap
                            txtDescriptorName.ReadOnly = true;
                            txtDescriptorDescription.ReadOnly = true;
                        }
                        else
                        {
                            txtDescriptorName.Clear();
                            txtDescriptorDescription.Clear();
                        }

                        // Hizmet değer bilgilerini boş bırak
                        txtValueName.Clear();
                        nudCost.Value = 0;
                        nudPreparationTime.Value = 0;
                        nudBufferTime.Value = 0;

                        // Hizmet değer giriş alanlarını düzenlenebilir yap
                        txtValueName.ReadOnly = false;
                        nudCost.Enabled = true;
                        nudPreparationTime.Enabled = true;
                        nudBufferTime.Enabled = true;

                        SetControlsEnabled(true);
                    }
                }
                else
                {
                    ClearFields();
                    SetControlsEnabled(false);
                }
            }
        }


        private void SetInitialControlState()
        {
            // Başlangıçta Checkbox seçili, yeni sağlayıcı ekleme modunda olacak
            chkNewProvider.Checked = true;
            SetControlsEnabled(true);
            cmbExistingProviders.Enabled = false; // Mevcut sağlayıcı seçeneği pasif
        }

        private void InitializeListView()
        {
            // ListView sütunları tanımlanır
            lstServices.View = View.Details;
            lstServices.Columns.Add("Sağlayıcı Firma", 150);
            lstServices.Columns.Add("Hizmet İsmi", 150);
            lstServices.Columns.Add("Maliyet (₺)", 100);
        }

        private void LoadExistingProviders()
        {
            try
            {
                var providers = _serviceProviderRepository.GetActives()
                    .Select(p => new
                    {
                        Display = $"{p.ProviderName} ({p.City}/{p.District})",
                        Value = p.Id
                    }).ToList();

                cmbExistingProviders.DataSource = providers;
                cmbExistingProviders.DisplayMember = "Display";
                cmbExistingProviders.ValueMember = "Value";
                cmbExistingProviders.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void LoadExistingServices()
        {
            try
            {
                var providerServiceValues = _providerServiceValueRepository.GetAll()
                    .Select(psv => new
                    {
                        ProviderName = psv.ServiceProvider.ProviderName, // ServiceProvider üzerinden erişim
                        ServiceName = psv.ServiceValue.Name,             // ServiceValue üzerinden erişim
                        Cost = psv.ServiceValue.Cost                     // Maliyet bilgisi
                    })
                    .ToList();

                lstServices.Items.Clear(); // ListView'i temizle

                foreach (var service in providerServiceValues)
                {
                    var item = new ListViewItem(service.ProviderName); // Sağlayıcı Firma Adı
                    item.SubItems.Add(service.ServiceName);           // Hizmet İsmi
                    item.SubItems.Add(service.Cost.ToString("C2"));   // Maliyet (₺ formatında)
                    lstServices.Items.Add(item);                     // ListView'e ekle
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hizmetler yüklenirken bir hata oluştu: {ex.Message}");
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtDescriptorName.Text) ||
                string.IsNullOrWhiteSpace(txtDescriptorDescription.Text) ||
                string.IsNullOrWhiteSpace(txtValueName.Text) ||
                string.IsNullOrWhiteSpace(txtProviderName.Text) ||
                string.IsNullOrWhiteSpace(txtProviderAddress.Text) ||
                string.IsNullOrWhiteSpace(txtProviderCity.Text) ||
                string.IsNullOrWhiteSpace(txtProviderDistrict.Text) ||
                string.IsNullOrWhiteSpace(txtProviderPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(txtProviderEmail.Text) ||
                nudCost.Value <= 0 || nudPreparationTime.Value < 0 || nudBufferTime.Value < 0)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve geçerli değerler girin.");
                return false;
            }
            return true;
        }

        private void ClearFields()
        {
            // Formdaki tüm alanları temizler
            txtDescriptorName.Clear();
            txtDescriptorDescription.Clear();
            txtValueName.Clear();
            nudCost.Value = 0;
            nudPreparationTime.Value = 0;
            nudBufferTime.Value = 0;
            txtProviderName.Clear();
            txtProviderAddress.Clear();
            txtProviderCity.Clear();
            txtProviderDistrict.Clear();
            txtProviderPhoneNumber.Clear();
            txtProviderEmail.Clear();
        }

        private void SetControlsEnabled(bool isEnabled)
        {
            // Tüm kontrolleri etkinleştirir veya pasifleştirir
            txtDescriptorName.Enabled = isEnabled;
            txtDescriptorDescription.Enabled = isEnabled;
            txtValueName.Enabled = isEnabled;
            nudCost.Enabled = isEnabled;
            nudPreparationTime.Enabled = isEnabled;
            nudBufferTime.Enabled = isEnabled;
            txtProviderName.Enabled = isEnabled;
            txtProviderAddress.Enabled = isEnabled;
            txtProviderCity.Enabled = isEnabled;
            txtProviderDistrict.Enabled = isEnabled;
            txtProviderPhoneNumber.Enabled = isEnabled;
            txtProviderEmail.Enabled = isEnabled;
            btnAddService.Enabled = isEnabled;
        }

    }
}
