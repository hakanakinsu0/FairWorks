using Project.BLL.DesignPatterns.GenericRepository.EFConcRep;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using Project.WinFormUI.Forms.CustomerForms;
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
    public partial class CustomerDashboard : Form
    {
        // Repository sınıfları
        private readonly BuildingRepository _buildingRepository;  // Bina verilerini yöneten repository
        private readonly LocationRepository _locationRepository;  // Konum verilerini yöneten repository
        private readonly FairRepository _fairRepository;  // Fuar verilerini yöneten repository
        private readonly PaymentRepository _paymentRepository;  // Ödeme verilerini yöneten repository
        public Customer LoggedInCustomer { get; set; }  // Giriş yapan müşteri bilgisi
        public string FairName { get; set; }  // Fuarın adı (eklenmiş özellik)



        public CustomerDashboard()
        {
            InitializeComponent();

            // Repository nesneleri oluşturuluyor
            _buildingRepository = new BuildingRepository();
            _paymentRepository = new PaymentRepository();
            _fairRepository = new FairRepository();
            _paymentRepository = new PaymentRepository();
            _locationRepository = new LocationRepository();


            // Şehirleri yükleme ve alanları temizleme işlemleri
            LoadCities();
            ClearFields();
        }

        private void btnSearchBuildings_Click(object sender, EventArgs e)
        {
            // Eğer şehir, ilçe veya fuar ismi seçilmemişse, kullanıcıyı bilgilendiren bir mesaj göster
            if (cmbCity.SelectedIndex == -1 || cmbDistrict.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtFairName.Text))
            {
                MessageBox.Show("Lütfen fuar ismini, şehiri ve ilçeyi seçiniz.");
                return;
            }

            // Eğer seçilen tarih aralığı geçerli değilse, hata mesajını göster ve işlemi durdur
            if (!IsValidDateRange(dtpStartDate.Value, dtpEndDate.Value, out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            // Seçilen şehir, ilçe ve tarih aralığına göre uygun binaları arama işlemi
            List<Building> availableBuildings = _buildingRepository.SearchBuildings(
                cmbCity.SelectedItem.ToString(),
                cmbDistrict.SelectedItem.ToString(),
                dtpStartDate.Value,
                dtpEndDate.Value
            );
            // Eğer uygun binalar bulunduysa, bunları listele
            if (availableBuildings.Any())
            {
                lstBuildings.DataSource = availableBuildings;
                lstBuildings.DisplayMember = "ToString";
                lstBuildings.SelectedIndex = -1;
            }
            else
            {
                // Eğer uygun bina bulunmazsa, kullanıcıyı bilgilendir
                MessageBox.Show("Seçilen tarihlerde uygun bina bulunamadı. İsterseniz talep oluşturabilirsiniz.");
            }
        }


        private bool IsValidDateRange(DateTime startDate, DateTime endDate, out string errorMessage)
        {
            // Başlangıç tarihi ile bitiş tarihinin geçerli olup olmadığını kontrol eder. 
            // Eğer geçerli değilse bir hata mesajı döner.
            if (endDate <= startDate)
            {
                errorMessage = "Bitiş tarihi, başlangıç tarihinden sonra olmalıdır."; // Hata mesajını ayarla.
                return false; // Geçerlilik kontrolü başarısız.
            }
            errorMessage = string.Empty; // Hata mesajı boş.
            return true; // Geçerlilik kontrolü başarılı.
        }

        private void btnConfirmFair_Click(object sender, EventArgs e)
        {
            // Liste kutusundan bir bina seçilip seçilmediğini kontrol et.
            if (lstBuildings.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir bina seçiniz."); // Kullanıcıya bina seçilmediğini bildir.
                return; // Metottan erken çıkış yap.
            }
            // Seçili öğeyi Building (Bina) nesnesine dönüştür.
            Building selectedBuilding = lstBuildings.SelectedItem as Building;

            try
            {
                // Seçilen bina ve tarih aralığına göre fuar maliyetini hesapla.
                decimal buildingCost = _buildingRepository.CalculateFairCost(selectedBuilding, dtpStartDate.Value, dtpEndDate.Value);

                // FairServicesForm'u başlat ve gerekli verileri ayarla.
                FairServicesForm servicesForm = new FairServicesForm
                {
                    LoggedInCustomer = LoggedInCustomer, // Giriş yapmış müşteri bilgilerini ata.
                    SelectedBuilding = selectedBuilding, // Seçilen binayı ayarla.
                    BuildingCost = buildingCost, // Hesaplanan maliyeti ata.
                    StartDate = dtpStartDate.Value, // Talep edilen başlangıç tarihini ayarla.
                    EndDate = dtpEndDate.Value,    // Kullanıcı tarafından belirtilen bitiş tarihini ayarla.
                    FairName = txtFairName.Text   // Fuar adını ata.
                };

                servicesForm.ShowDialog(); // FairServicesForm'u bir diyalog olarak aç.
            }
            catch (Exception ex)
            {
                // İşlem sırasında bir hata oluşursa kullanıcıya hata mesajı göster.
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void btnRequestBuilding_Click(object sender, EventArgs e)
        {
            // Tarih aralığının geçerli olup olmadığını kontrol et.
            if (!IsValidDateRange(dtpStartDate.Value, dtpEndDate.Value, out string errorMessage))
            {
                MessageBox.Show(errorMessage); // Hata mesajını göster.
                return; // Metottan erken çıkış yap.
            }

            // Fuar adının girilip girilmediğini kontrol et.
            if (string.IsNullOrWhiteSpace(txtFairName.Text))
            {
                MessageBox.Show("Lütfen fuar ismini giriniz."); // Kullanıcıya uyarı göster.
                return; // Metottan erken çıkış yap.
            }

            // Kullanıcının bina talebi için özel bir form oluştur ve başlat.
            CustomBuildingRequestForm requestForm = new CustomBuildingRequestForm(txtFairName.Text, dtpStartDate.Value, dtpEndDate.Value, LoggedInCustomer);
            requestForm.ShowDialog(); // Formu diyalog olarak aç.
        }

        private void cmbCity_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Şehir seçiliyse ilgili ilçeleri yükle.
            if (cmbCity.SelectedItem != null)
            {
                // Seçilen şehre ait ilçeleri al.
                List<string> districts = _locationRepository.LoadDistricts(cmbCity.SelectedItem.ToString());

                // İlçeler varsa ComboBox'a bağla.
                if (districts != null && districts.Any())
                {
                    cmbDistrict.DataSource = districts;
                }
                else
                {
                    // İlçeler yoksa ComboBox'u temizle ve uyarı göster.
                    cmbDistrict.DataSource = null;
                    MessageBox.Show("Seçilen şehir için ilçe bulunamadı.");
                }
            }
        }

        private void lstBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen öğe bir bina mı kontrol et.
            if (lstBuildings.SelectedItem is Building selectedBuilding)
            {
                // Seçilen binanın detaylarını etiket üzerinde göster.
                lblBuildingDetails.Text = $"Bina Adı: {selectedBuilding.Name}\nAdres: {selectedBuilding.Address}\n" +
                                          $"Kat Sayısı: {selectedBuilding.NumberOfFloor}\nKat Metrekare: {selectedBuilding.FloorSize}\n" +
                                          $"Kat Başına Oda: {selectedBuilding.RoomPerFloor}\n" +
                                          $"Gün Sayısı: {(dtpEndDate.Value - dtpStartDate.Value).Days + 1}";
            }
            else
            {
                // Eğer bina seçilmediyse bir uyarı mesajı göster.
                lblBuildingDetails.Text = "Bina seçilmedi.";
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Formu kapatır
            Close();
        }

        private void LoadCities()
        {
           // Tüm şehirleri alır.
    List<string> cities = _locationRepository.GetAllCities();

    // Eğer şehirler varsa ComboBox'a bağlanır.
    if (cities != null && cities.Any())
    {
        cmbCity.DataSource = cities;
    }
    else
    {
        // Eğer şehirler yoksa ComboBox temizlenir ve bir hata mesajı gösterilir.
        cmbCity.DataSource = null;
        MessageBox.Show("Şehir verileri yüklenemedi.");
    }
        }

        // Formdaki giriş alanlarını temizler.
        private void ClearFields()
        {
            // Fuar adını temizle.
            txtFairName.Clear();
            // Şehir seçimini sıfırla.
            cmbCity.SelectedIndex = -1;
            // İlçe ComboBox'ını temizle.
            cmbDistrict.DataSource = null;
            // Tarih seçimlerini bugüne ayarla.
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now;
            // Bina listesini temizle.
            lstBuildings.DataSource = null;
        }

        // Müşteriye ait fuarları yükleyip listeleyen yöntem.
        private void LoadFairs()
        {
            try
            {
                // DataGridView içeriğini temizle.
                dgvFairs.DataSource = null;

                // Giriş yapan müşteriye ait fuarları getir ve seçili özelliklerle bir liste oluştur.
                var customerFairs = _fairRepository
                    .Where(f => f.CustomerId == LoggedInCustomer.Id) // Sadece mevcut müşterinin fuarlarını getir.
                    .Select(f => new
                    {
                        f.Id, // Fuar kimliği.
                        FuarAdı = f.Name, // Fuar adı.
                        BaşlangıçTarihi = f.CalculatedStartDate.ToShortDateString(), // Başlangıç tarihi.
                        BitişTarihi = f.EndDate.ToShortDateString(), // Bitiş tarihi.
                        ToplamMaliyet = f.TotalCost.ToString("C"), // Toplam maliyet, para birimi formatında.
                        Durum = f.Status == DataStatus.Deleted ? "İptal Edildi" : "Aktif" // Fuar durumu.
                    })
                    .ToList();

                // Veriyi DataGridView'e bağla ve görünümü yenile.
                dgvFairs.DataSource = customerFairs;
                dgvFairs.Refresh();
            }
            catch (Exception ex)
            {
                // Fuarlar yüklenirken bir hata oluşursa kullanıcıya mesaj göster.
                MessageBox.Show($"Fuarlar yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // TabControl üzerinde sekme değiştirildiğinde çalışacak olay yöntemi.
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Eğer seçili sekme Fuarlar sekmesi (tabPage2) ise fuarları yükle.
            if (tabControl1.SelectedTab == tabPage2)
            {
                LoadFairs(); // Fuarları yükleme işlemi.
            }
        }

        private void btnCancelFair_Click(object sender, EventArgs e)
        {
            // Eğer DataGridView'de seçili satır yoksa kullanıcıyı uyar.
            if (dgvFairs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen iptal etmek istediğiniz fuarı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Metottan erken çıkış yap.
            }

            // Seçili satırdan fuar ID'sini al.
            int selectedFairId = (int)dgvFairs.SelectedRows[0].Cells["Id"].Value;
            var fair = _fairRepository.GetById(selectedFairId); // ID'ye göre fuarı getir.

            // Eğer fuar bulunamazsa hata mesajı göster.
            if (fair == null)
            {
                MessageBox.Show("Seçilen fuar bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Eğer fuar zaten iptal edilmişse kullanıcıya bilgi ver.
            if (fair.Status == DataStatus.Deleted)
            {
                MessageBox.Show("Bu fuar zaten iptal edilmiş.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ödeme işlemleri kontrolü.
            var payment = _paymentRepository.FirstOrDefault(p => p.FairId == fair.Id);
            if (payment != null)
            {
                payment.RefundStatus = RefundStatus.Refunded; // İade durumu tamamlandı olarak güncelle.
                _paymentRepository.Update(payment); // Ödemeyi güncelle.
            }


            // Fuarın durumunu iptal edilmiş olarak güncelle.
            fair.Status = DataStatus.Deleted;
            _fairRepository.Delete(fair); // Fuarı silme işlemi.

            // Güncellenen fuarı tekrar getir ve kullanıcıya bilgi göster.
            var updatedFair = _fairRepository.GetById(selectedFairId);
            MessageBox.Show($"Fuar adı: {updatedFair.Name}, Durumu: {updatedFair.Status}");

            // İptal işleminin başarılı olduğunu ve ödemenin iade edildiğini bildir.
            MessageBox.Show("Fuar başarıyla iptal edildi ve ödeme iadesi gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // DataGridView'i güncellemek için fuarları yeniden yükle.
            LoadFairs();
        }

        private void btnViewFairDetails_Click(object sender, EventArgs e)
        {
            // Eğer DataGridView'de seçili satır yoksa kullanıcıyı uyar.
            if (dgvFairs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen görüntülemek istediğiniz fuarı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Metottan erken çıkış yap.
            }

            // Seçili fuarın ID'sini al.
            int selectedFairId = (int)dgvFairs.SelectedRows[0].Cells["Id"].Value;
            var fair = _fairRepository.GetById(selectedFairId); // ID'ye göre fuarı getir.

            // Eğer fuar bulunamazsa hata mesajı göster.
            if (fair == null)
            {
                MessageBox.Show("Seçilen fuar bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Metottan erken çıkış yap.
            }

            // Fuar detaylarını etiket üzerinde göster.
            lblFairDetails.Text = $"Fuar Adı: {fair.Name}\n" +
                                  $"Başlangıç Tarihi: {fair.CalculatedStartDate:dd/MM/yyyy}\n" +
                                  $"Bitiş Tarihi: {fair.EndDate:dd/MM/yyyy}\n" +
                                  $"Toplam Maliyet: {fair.TotalCost:C2}\n" +
                                  $"Durum: {(fair.Status == DataStatus.Deleted ? "İptal Edildi" : "Aktif")}";
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close(); // Formu kapatır.

        }
    }
}
