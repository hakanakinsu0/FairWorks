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

        // Repository'ler (Veritabanı işlemleri için kullanılan sınıflar)
        private ServiceDescriptorRepository _serviceDescriptorRepository;
        private ServiceValueRepository _serviceValueRepository;
        private ServiceProviderRepository _serviceProviderRepository;
        private ServiceProviderServiceValueRepository _providerServiceValueRepository;


        // Formun yapıcı metodu
        public AddAdditionalServiceForm()
        {
            InitializeComponent();// Formun bileşenlerini başlatır.

            // Repository örneklerini oluşturur (Veritabanı işlemleri için sınıfların örnekleri).
            _serviceDescriptorRepository = new ServiceDescriptorRepository();
            _serviceValueRepository = new ServiceValueRepository();
            _serviceProviderRepository = new ServiceProviderRepository();
            _providerServiceValueRepository = new ServiceProviderServiceValueRepository();

            InitializeListView();       // ListView kontrolünü başlatır ve yapılandırır.
            LoadExistingProviders();   // Mevcut sağlayıcıları yükler ve kullanıcıya seçim için sunar.
            LoadExistingServices();   // Mevcut hizmetleri yükler ve listeye ekler.
            SetInitialControlState();// Kontrollerin başlangıç durumunu ayarlar (örneğin, hangi alanların aktif/pasif olduğu).

        }

        private void btnAddService_Click(object sender, EventArgs e)
        {

            // Alan doğrulaması yapar; eğer alanlar geçerli değilse işlemi sonlandırır.
            if (!ValidateFields()) return;

            try
            {
                // Girilen hizmet tanımlayıcı adına göre var olan bir tanımlayıcıyı veritabanından getirir.
                ServiceDescriptor descriptor = _serviceDescriptorRepository.GetByName(txtDescriptorName.Text);
                if (descriptor == null) // Eğer böyle bir tanımlayıcı yoksa, yeni bir tanımlayıcı oluşturup veritabanına ekler.
                {
                    descriptor = new ServiceDescriptor
                    {
                        Name = txtDescriptorName.Text, // Kullanıcının girdiği tanımlayıcı adı
                        Description = txtDescriptorDescription.Text // Kullanıcının girdiği açıklama
                    };
                    _serviceDescriptorRepository.Add(descriptor);// Yeni tanımlayıcıyı veritabanına ekler.
                }
                // Yeni bir hizmet değeri nesnesi oluşturur ve ilgili alanları doldurur.
                ServiceValue value = new ServiceValue
                {
                    Name = txtValueName.Text, // Kullanıcının girdiği hizmet değeri adı
                    Cost = nudCost.Value, // Hizmet maliyeti
                    PreparationTime = (int)nudPreparationTime.Value, // Hazırlık süresi
                    BufferTime = (int)nudBufferTime.Value, // Ek süre (tampon süre)
                    ServiceDescriptorId = descriptor.Id // Tanımlayıcı kimliği ile ilişkilendirir
                };
                // Yeni hizmet değerini veritabanına ekler.
                _serviceValueRepository.Add(value);

                // Eğer "Yeni Sağlayıcı" seçeneği işaretlenmemişse ve mevcut sağlayıcılar listesinden bir seçim yapılmışsa işlemi gerçekleştir.
                if (!chkNewProvider.Checked && cmbExistingProviders.SelectedIndex != -1)
                {
                    // Seçilen sağlayıcının kimliğini alır.
                    int selectedProviderId = (int)cmbExistingProviders.SelectedValue;

                    // Seçilen sağlayıcıyı veritabanından getirir.
                    ServiceProvider provider = _serviceProviderRepository.GetById(selectedProviderId);

                    // Eğer sağlayıcı veritabanında mevcutsa işleme devam eder.
                    if (provider != null)
                    {
                        // Hizmet ile sağlayıcı arasında bir ilişki olup olmadığını kontrol eder.
                        if (!_providerServiceValueRepository.IsServiceValueLinkedToProvider(provider.Id, value.Id))
                        {
                            // Eğer ilişki yoksa, yeni bir sağlayıcı-hizmet ilişkisi oluşturur ve veritabanına ekler.
                            ServiceProviderServiceValue providerServiceValue = new ServiceProviderServiceValue
                            {
                                ServiceProviderId = provider.Id, // Sağlayıcı kimliği
                                ServiceValueId = value.Id // Hizmet değeri kimliği
                            };
                            _providerServiceValueRepository.Add(providerServiceValue);// İlişkiyi veritabanına ekler.
                        }
                        else
                        {
                            // Eğer ilişki zaten mevcutsa kullanıcıya bilgi verir.
                            MessageBox.Show("Bu hizmet zaten bu sağlayıcıya atanmış.");
                        }
                    }
                }
                else
                {
                    // Yeni bir hizmet sağlayıcı nesnesi oluşturur ve kullanıcıdan alınan bilgileri doldurur.
                    ServiceProvider provider = new ServiceProvider
                    {
                        ProviderName = txtProviderName.Text, // Sağlayıcı adı
                        Address = txtProviderAddress.Text, // Adres bilgisi
                        City = txtProviderCity.Text, // Şehir
                        District = txtProviderDistrict.Text, // İlçe
                        PhoneNumber = txtProviderPhoneNumber.Text, // Telefon numarası
                        Email = txtProviderEmail.Text // E-posta adresi
                    };

                    _serviceProviderRepository.Add(provider);// Yeni sağlayıcıyı veritabanına ekler.

                    // Sağlayıcı ile hizmet değeri arasında bir ilişki oluşturur.
                    ServiceProviderServiceValue providerServiceValue = new ServiceProviderServiceValue
                    {
                        ServiceProviderId = provider.Id, // Sağlayıcı kimliği
                        ServiceValueId = value.Id // Hizmet değeri kimliği
                    };

                    _providerServiceValueRepository.Add(providerServiceValue); // İlişkiyi veritabanına ekler.
                    LoadExistingProviders();// Mevcut sağlayıcılar listesini yeniler.
                }

                MessageBox.Show("Hizmet başarıyla eklendi!");// Kullanıcıya başarılı bir işlem mesajı gösterir.
                LoadExistingServices();// Mevcut hizmetler listesini yeniler.
                ClearFields();// Tüm alanları temizleyerek formu varsayılan duruma getirir.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");// Bir hata oluşursa kullanıcıya hata mesajını gösterir.
            }
        }

        private void chkNewProvider_CheckedChanged(object sender, EventArgs e)
        {
            // Eğer "Yeni Sağlayıcı" seçeneği işaretlenmişse
            if (chkNewProvider.Checked)
            {
                ClearFields(); // Tüm alanları temizler.
                SetControlsEnabled(true); // Kontrolleri kullanıcı girişine açar.
                cmbExistingProviders.Enabled = false;// Mevcut sağlayıcılar listesini devre dışı bırakır.
                cmbExistingProviders.SelectedIndex = -1;// Mevcut sağlayıcılar listesindeki seçimi kaldırır.
            }
            else
            {
                ClearFields();// Tüm alanları temizler.
                SetControlsEnabled(false);// Kontrolleri kullanıcı girişine kapatır.
                cmbExistingProviders.Enabled = true;// Mevcut sağlayıcılar listesini etkinleştirir.
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close(); // Formu kapat

        }

        private void AddAdditionalServiceForm_Load(object sender, EventArgs e)
        {
            LoadExistingProviders(); // Mevcut sağlayıcıları yükler
            LoadExistingServices();  // Mevcut hizmetleri yükler
        }

        private void cmbExistingProviders_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            // Eğer "Yeni Sağlayıcı" seçeneği işaretlenmişse
            if (chkNewProvider.Checked)
            {
                ClearFields();// Tüm alanları temizler.
                SetControlsEnabled(true);// Kontrolleri kullanıcı girişine açar.

                // Mevcut sağlayıcılar listesini devre dışı bırakır ve seçim yapmayı engeller.
                cmbExistingProviders.Enabled = false;
                cmbExistingProviders.SelectedIndex = -1;
            }
            else
            {
                // Mevcut sağlayıcılar listesini etkinleştirir.
                cmbExistingProviders.Enabled = true;

                // Mevcut sağlayıcılar listesinden geçerli bir seçim yapılıp yapılmadığını kontrol eder.
                if (cmbExistingProviders.SelectedValue != null && int.TryParse(cmbExistingProviders.SelectedValue.ToString(), out int selectedProviderId))
                {
                    // Seçilen sağlayıcıyı veritabanından getirir.
                    ServiceProvider provider = _serviceProviderRepository.GetById(selectedProviderId);

                    if (provider != null)
                    {
                        // Sağlayıcı bilgilerini ilgili alanlara doldurur.
                        txtProviderName.Text = provider.ProviderName;
                        txtProviderAddress.Text = provider.Address;
                        txtProviderCity.Text = provider.City;
                        txtProviderDistrict.Text = provider.District;
                        txtProviderPhoneNumber.Text = provider.PhoneNumber;
                        txtProviderEmail.Text = provider.Email;

                        // Sağlayıcı bilgilerini düzenlenemez hale getirir.
                        txtProviderName.ReadOnly = true;
                        txtProviderAddress.ReadOnly = true;
                        txtProviderCity.ReadOnly = true;
                        txtProviderDistrict.ReadOnly = true;
                        txtProviderPhoneNumber.ReadOnly = true;
                        txtProviderEmail.ReadOnly = true;

                        // Sağlayıcıyla ilişkili ilk hizmet tanımını alır.
                        ServiceDescriptor firstServiceDescriptor = _serviceDescriptorRepository.GetAll()
                            .FirstOrDefault(d => d.ServiceValues.Any(v => v.ProviderServiceValues.Any(psv => psv.ServiceProviderId == provider.Id)));

                        if (firstServiceDescriptor != null)
                        {
                            // Hizmet tanım bilgilerini doldurur.
                            txtDescriptorName.Text = firstServiceDescriptor.Name;
                            txtDescriptorDescription.Text = firstServiceDescriptor.Description;

                            // Hizmet adı ve açıklamasını düzenlenemez hale getirir.
                            txtDescriptorName.ReadOnly = true;
                            txtDescriptorDescription.ReadOnly = true;
                        }
                        else
                        {
                            // Eğer ilişkili hizmet tanımı yoksa alanları temizler.
                            txtDescriptorName.Clear();
                            txtDescriptorDescription.Clear();
                        }

                        // Hizmet değer bilgilerini boş bırakır.
                        txtValueName.Clear();
                        nudCost.Value = 0;
                        nudPreparationTime.Value = 0;
                        nudBufferTime.Value = 0;

                        // Hizmet değer giriş alanlarını düzenlenebilir hale getirir.
                        txtValueName.ReadOnly = false;
                        nudCost.Enabled = true;
                        nudPreparationTime.Enabled = true;
                        nudBufferTime.Enabled = true;

                        // Kontrolleri kullanıcı girişine açar.
                        SetControlsEnabled(true);
                    }
                }
                else
                {
                    // Eğer geçerli bir seçim yapılmadıysa tüm alanları temizler ve girişleri devre dışı bırakır.
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
            // ListView'in görüntüleme modunu 'Detaylar' olarak ayarla
            lstServices.View = View.Details;

            // ListView'e "Sağlayıcı Firma" başlıklı bir sütun ekle ve genişliğini 150 piksel olarak ayarla
            lstServices.Columns.Add("Sağlayıcı Firma", 150);

            // ListView'e "Hizmet İsmi" başlıklı bir sütun ekle ve genişliğini 150 piksel olarak ayarla
            lstServices.Columns.Add("Hizmet İsmi", 150);

            // ListView'e "Maliyet (₺)" başlıklı bir sütun ekle ve genişliğini 100 piksel olarak ayarla
            lstServices.Columns.Add("Maliyet (₺)", 100);
        }

        private void LoadExistingProviders()
        {
            try
            {
                // Aktif sağlayıcıları veritabanından getirir ve gerekli alanları seçerek bir liste oluşturur.
                var providers = _serviceProviderRepository.GetActives()
                    .Select(p => new
                    {
                        // Sağlayıcı adı, şehir ve ilçeyi birlikte görüntülenecek metin olarak ayarlar.
                        Display = $"{p.ProviderName} ({p.City}/{p.District})",
                        Value = p.Id // Sağlayıcı kimliğini bir değer olarak belirler.
                    }).ToList();

                // Mevcut sağlayıcılar listesinin veri kaynağını oluşturulan liste olarak ayarlar.
                cmbExistingProviders.DataSource = providers;

                // Görüntülenecek metin için DisplayMember özelliğini ayarlar.
                cmbExistingProviders.DisplayMember = "Display";

                // Sağlayıcı kimliğini bir değer olarak kullanmak için ValueMember özelliğini ayarlar.
                cmbExistingProviders.ValueMember = "Value";

                // Varsayılan olarak hiçbir öğenin seçili olmamasını sağlar.
                cmbExistingProviders.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");// Bir hata oluşursa kullanıcıya hata mesajını gösterir.
            }
        }

        private void LoadExistingServices()
        {
            try
            {// Sağlayıcı-Hizmet ilişkilerini getirir ve gerekli bilgileri seçerek bir liste oluşturur.
                var providerServiceValues = _providerServiceValueRepository.GetAll()
                    .Select(psv => new
                    {
                        ProviderName = psv.ServiceProvider.ProviderName, // Hizmet sağlayıcının adı
                        ServiceName = psv.ServiceValue.Name,             // Hizmetin adı
                        Cost = psv.ServiceValue.Cost                     // Hizmetin maliyeti
                    })
                    .ToList();

                // ListView kontrolünü temizler, eski verileri kaldırır.
                lstServices.Items.Clear();

                foreach (var service in providerServiceValues)
                {
                    // Yeni bir ListViewItem oluşturur ve sağlayıcı adını ekler.
                    var item = new ListViewItem(service.ProviderName);

                    // Hizmet adını alt öğe olarak ekler.
                    item.SubItems.Add(service.ServiceName);

                    // Maliyet bilgisini para birimi formatında (₺) alt öğe olarak ekler.
                    item.SubItems.Add(service.Cost.ToString("C2"));

                    // ListView'e oluşturulan öğeyi ekler.
                    lstServices.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hizmetler yüklenirken bir hata oluştu: {ex.Message}");// Bir hata oluşursa kullanıcıya hata mesajını gösterir.
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtDescriptorName.Text) || // Hizmet adı boş mu kontrolü
                string.IsNullOrWhiteSpace(txtDescriptorDescription.Text) || // Hizmet açıklaması boş mu kontrolü
                string.IsNullOrWhiteSpace(txtValueName.Text) || // Değer adı boş mu kontrolü
                string.IsNullOrWhiteSpace(txtProviderName.Text) || // Sağlayıcı adı boş mu kontrolü
                string.IsNullOrWhiteSpace(txtProviderAddress.Text) || // Sağlayıcı adresi boş mu kontrolü
                string.IsNullOrWhiteSpace(txtProviderCity.Text) || // Sağlayıcı şehir boş mu kontrolü
                string.IsNullOrWhiteSpace(txtProviderDistrict.Text) || // Sağlayıcı ilçe boş mu kontrolü
                string.IsNullOrWhiteSpace(txtProviderPhoneNumber.Text) || // Sağlayıcı telefon numarası boş mu kontrolü
                string.IsNullOrWhiteSpace(txtProviderEmail.Text) || // Sağlayıcı e-posta boş mu kontrolü
                nudCost.Value <= 0 || // Maliyet sıfır veya negatif mi kontrolü
                nudPreparationTime.Value < 0 || // Hazırlık süresi negatif mi kontrolü
                nudBufferTime.Value < 0) // Yedek süre negatif mi kontrolü
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve geçerli değerler girin."); // Kullanıcıya mesaj göster
                return false; // Geçerli olmayan değerler durumunda işlemi durdur
            }
            return true; // Tüm kontroller geçerliyse true döndür

        }

        private void ClearFields()
        {
            // Formdaki tüm alanları temizler
            txtDescriptorName.Clear(); // Hizmet adı alanını temizler
            txtDescriptorDescription.Clear(); // Hizmet açıklaması alanını temizler
            txtValueName.Clear(); // Değer adı alanını temizler
            nudCost.Value = 0; // Maliyet alanını sıfırlar
            nudPreparationTime.Value = 0; // Hazırlık süresi alanını sıfırlar
            nudBufferTime.Value = 0; // Yedek süre alanını sıfırlar
            txtProviderName.Clear(); // Sağlayıcı adı alanını temizler
            txtProviderAddress.Clear(); // Sağlayıcı adresini temizler
            txtProviderCity.Clear(); // Sağlayıcı şehir bilgisini temizler
            txtProviderDistrict.Clear(); // Sağlayıcı ilçe bilgisini temizler
            txtProviderPhoneNumber.Clear(); // Sağlayıcı telefon numarasını temizler
            txtProviderEmail.Clear(); // Sağlayıcı e-posta bilgisini temizler
        }

        private void SetControlsEnabled(bool isEnabled)
        {
            // Tüm kontrolleri etkinleştirir veya pasifleştirir
            txtDescriptorName.Enabled = isEnabled; // Hizmet adı alanını etkinleştirir veya pasifleştirir
            txtDescriptorDescription.Enabled = isEnabled; // Hizmet açıklaması alanını etkinleştirir veya pasifleştirir
            txtValueName.Enabled = isEnabled; // Değer adı alanını etkinleştirir veya pasifleştirir
            nudCost.Enabled = isEnabled; // Maliyet alanını etkinleştirir veya pasifleştirir
            nudPreparationTime.Enabled = isEnabled; // Hazırlık süresi alanını etkinleştirir veya pasifleştirir
            nudBufferTime.Enabled = isEnabled; // Yedek süre alanını etkinleştirir veya pasifleştirir
            txtProviderName.Enabled = isEnabled; // Sağlayıcı adı alanını etkinleştirir veya pasifleştirir
            txtProviderAddress.Enabled = isEnabled; // Sağlayıcı adresini etkinleştirir veya pasifleştirir
            txtProviderCity.Enabled = isEnabled; // Sağlayıcı şehir bilgisini etkinleştirir veya pasifleştirir
            txtProviderDistrict.Enabled = isEnabled; // Sağlayıcı ilçe bilgisini etkinleştirir veya pasifleştirir
            txtProviderPhoneNumber.Enabled = isEnabled; // Sağlayıcı telefon numarasını etkinleştirir veya pasifleştirir
            txtProviderEmail.Enabled = isEnabled; // Sağlayıcı e-posta bilgisini etkinleştirir veya pasifleştirir
            btnAddService.Enabled = isEnabled; // Hizmet ekleme butonunu etkinleştirir veya pasifleştirir
        }

    }
}
