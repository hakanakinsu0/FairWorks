using Project.BLL.DesignPatterns.GenericRepository.EFConcRep;
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
    public partial class EmployeeDashboard : Form
    {
        private EmployeeRepository _employeeRepository; // Çalışanlarla ilgili veritabanı işlemleri için repository
        private EmployeeProfileRepository _employeeProfileRepository; // Çalışan profilleriyle ilgili işlemler için repository
        private ServiceProviderRepository _serviceProviderRepository; // Hizmet sağlayıcılarla ilgili işlemler için repository
        private ServiceDescriptorRepository _serviceDescriptorRepository; // Hizmet tanımlarıyla ilgili işlemler için repository
        private ServiceValueRepository _serviceValueRepository; // Hizmet değerleriyle ilgili işlemler için repository
        private BuildingRepository _buildingRepository; // Bina bilgileriyle ilgili işlemler için repository
        private LocationRepository _locationRepository; // Konum bilgileriyle ilgili işlemler için repository

        public EmployeeDashboard()
        {
            InitializeComponent();

            // Repository nesnelerinin örneklerini oluştur
            _employeeRepository = new EmployeeRepository(); // Çalışan repository'sini başlat
            _employeeProfileRepository = new EmployeeProfileRepository(); // Çalışan profil repository'sini başlat
            _serviceProviderRepository = new ServiceProviderRepository(); // Hizmet sağlayıcı repository'sini başlat
            _serviceDescriptorRepository = new ServiceDescriptorRepository(); // Hizmet tanımı repository'sini başlat
            _serviceValueRepository = new ServiceValueRepository(); // Hizmet değeri repository'sini başlat
            _buildingRepository = new BuildingRepository(); // Bina repository'sini başlat
            _locationRepository = new LocationRepository(); // Konum repository'sini başlat
        }

        #region EkleSekmesi
        /*--------------------------Ekle Sekmesi-----------------------*/

        // Yeni bina ekleme butonu olayı: AddBuildingForm'u açar
        private void btnAddBuilding_Click(object sender, EventArgs e)
        {
            AddBuildingForm addBuildingForm = new AddBuildingForm();
            addBuildingForm.ShowDialog();
        }

        // Yeni lokasyon ekleme butonu olayı: AddLocationForm'u açar
        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            AddLocationForm addLocationForm = new AddLocationForm();
            addLocationForm.ShowDialog();
        }

        // Yeni çalışan ekleme butonu olayı: AddEmployeeForm'u açar
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
            addEmployeeForm.ShowDialog();
        }


        private void btnAddService_Click(object sender, EventArgs e)
        {
            AddAdditionalServiceForm addAdditionalServiceForm = new AddAdditionalServiceForm();
            addAdditionalServiceForm.ShowDialog();
        }

        // Çıkış butonu olayı: Formu kapatır
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Guncelle/Sil Sekmesi
        /*--------------------------Guncelle/Sil Sekmesi-----------------------*/

        // Bina güncelleme/silme butonu olayı: UpdateDeleteBuildingForm'u açar
        private void btnUpdateBuilding_Click(object sender, EventArgs e)
        {
            UpdateDeleteBuildingForm updateDeleteBuildingForm = new UpdateDeleteBuildingForm();
            updateDeleteBuildingForm.ShowDialog();
        }

        // Lokasyon güncelleme/silme butonu olayı: UpdateDeleteLocationForm'u açar
        private void btnUpdateLocation_Click(object sender, EventArgs e)
        {
            UpdateDeleteLocationForm updateDeleteLocationForm = new UpdateDeleteLocationForm();
            updateDeleteLocationForm.ShowDialog();
        }

        // Çalışan güncelleme/silme butonu olayı: UpdateDeleteEmployeeForm'u açar
        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            UpdateDeleteEmployeeForm updateDeleteEmployeeForm = new UpdateDeleteEmployeeForm();
            updateDeleteEmployeeForm.ShowDialog();
        }

        private void btnUpdateService_Click(object sender, EventArgs e)
        {
            UpdateDeleteServiceForm updateDeleteServiceForm = new UpdateDeleteServiceForm();
            updateDeleteServiceForm.ShowDialog();
        }

        // Güncelleme ekranından çıkış butonu: Formu kapatır
        private void btnExitUpdate_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion


        /*--------------------------Raporlar Sekmesi-----------------------*/

        private void btnEmployeeReport_Click(object sender, EventArgs e)
        {
            lstReportResults.Items.Clear();// Rapor sonuçlarını göstermek için kullanılan listeyi temizle

            var employees = _employeeRepository.GetAll();// Tüm çalışanları veritabanından al

            foreach (var employee in employees) // Her bir çalışan için döngü başlat
            {
                var profile = employee.Profile;// Çalışanın profil bilgilerini al

                if (profile != null) // Eğer profil bilgisi mevcutsa, detaylı bilgi ekle
                {
                    lstReportResults.Items.Add(
                        $"ID: {employee.Id} - İsim Soyisim: {profile.FirstName} {profile.LastName} - Rol: {employee.Role} - Durum: {employee.Status}");
                }
                else
                {
                    lstReportResults.Items.Add(
                        $"ID: {employee.Id} - İsim: Bilinmiyor, Email: {employee.Email}, Rol: {employee.Role}, Durum: {employee.Status}");
                }
            }
        }

        private void btnServiceReport_Click(object sender, EventArgs e)
        {

            lstReportResults.Items.Clear();// Rapor sonuçlarını göstermek için kullanılan listeyi temizle

            var services = _serviceValueRepository.GetAll();// Tüm hizmetleri veritabanından al

            foreach (var service in services)// Her bir hizmet için döngü başlat
            {
                // Hizmet bilgilerini biçimlendirilmiş şekilde listeye ekle
                lstReportResults.Items.Add(
                    $"Hizmet ID: {service.Id} - Adı: {service.Name} - Maliyet: {service.Cost:C2} - Hazırlık Süresi: {service.PreparationTime} gün - Durum: {service.Status}");
            }
        }

        private void btnBuildingReport_Click(object sender, EventArgs e)
        {
            lstReportResults.Items.Clear();// Rapor sonuçlarını göstermek için kullanılan listeyi temizle


            var buildings = _buildingRepository.GetAll();// Tüm bina verilerini veritabanından al


            // Her bir bina için döngü başlat
            foreach (var building in buildings)
            {
                // Binanın ilişkili konum bilgisini al
                var location = building.Location;

                if (location != null)// Eğer konum bilgisi mevcutsa, detaylı bilgi ekle
                {
                    lstReportResults.Items.Add(
                        $"Bina ID: {building.Id} - Adı: {building.Name} - Adres: {building.Address} - Şehir/İlçe: {location.City}/{location.District} - Durum: {building.Status}");
                }
                else
                {
                    // Eğer konum bilgisi yoksa, şehir ve ilçe bilgisi olmadan ekle
                    lstReportResults.Items.Add(
                        $"Bina ID: {building.Id} - Adı: {building.Name} - Adres: {building.Address} - Şehir/İlçe: Bilgi Yok - Durum: {building.Status}");
                }
            }
        }

        private void btnLocationReport_Click(object sender, EventArgs e)
        {
            lstReportResults.Items.Clear();
            // Rapor sonuçlarını göstermek için kullanılan listeyi temizle

            var locations = _locationRepository.GetAll();// Tüm lokasyon verilerini veritabanından al

            foreach (var location in locations)// Her bir lokasyon için döngü başlat
            {
                // Lokasyon bilgilerini biçimlendirilmiş şekilde listeye ekle
                lstReportResults.Items.Add(
                    $"Lokasyon ID: {location.Id} - Lokasyon : {location.City} / {location.District} - Durum: {location.Status}");
            }
        }

        private void lstReportResults_DoubleClick(object sender, EventArgs e)
        {
            if (lstReportResults.SelectedIndex != -1)    // Eğer bir öğe seçilmişse
            {
                MessageBox.Show(lstReportResults.SelectedItem.ToString(), "Detaylı Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);        // Seçilen öğenin detaylarını bir mesaj kutusunda göster

            }
        }



        private void btnMevcutFuarlar_Click(object sender, EventArgs e)
        {
            lstReportResults.Items.Clear();// Rapor sonuçlarını göstermek için kullanılan listeyi temizle

            // Fuar verilerinin alınması için bir repository nesnesi oluşturuyoruz
            FairRepository fairRepository = new FairRepository();

            // Mevcut durumdaki (silinmemiş) fuarları veritabanından alıyoruz
            var fairs = fairRepository.Where(f => f.Status != Project.ENTITIES.Enums.DataStatus.Deleted).ToList();

            if (fairs.Any())// Eğer herhangi bir fuar bulunmuşsa
            {
                foreach (var fair in fairs)// Her bir fuar için döngü başlat
                {
                    // Fuar bilgilerini biçimlendirilmiş şekilde listeye ekle
                    lstReportResults.Items.Add(
                        $"Fuar ID: {fair.Id} - Adı: {fair.Name} - Başlangıç Tarihi: {fair.RequestedStartDate:dd/MM/yyyy} - Bitiş Tarihi: {fair.EndDate:dd/MM/yyyy} - Maliyet: {fair.TotalCost:C2}");
                }
            }
            else
            {
                // Eğer hiç fuar bulunamamışsa, kullanıcıya bilgilendirici bir mesaj ekle
                lstReportResults.Items.Add("Mevcut durumda hiçbir fuar bulunamadı.");
            }
        }

        private void btnExitReport_Click(object sender, EventArgs e)
        {
            Close();//formu kapatır
        }

        private void btnFuarOdemeleri_Click(object sender, EventArgs e)
        {
            lstReportResults.Items.Clear();// Rapor sonuçlarını göstermek için kullanılan listeyi temizle


            // Gerekli repository'leri oluştur
            FairRepository fairRepository = new FairRepository();
            PaymentRepository paymentRepository = new PaymentRepository();

            // Tüm fuar verilerini veritabanından al
            var fairs = fairRepository.GetAll();

            if (fairs.Any())// Eğer fuar verileri mevcutsa

            {
                foreach (var fair in fairs)    // Her bir fuar için döngü başlat

                {
                    // İlgili fuarın ödeme bilgilerini Payment tablosundan al
                    var payment = paymentRepository.FirstOrDefault(p => p.FairId == fair.Id);


                    string paymentStatus = payment?.PaymentStatus.ToString() ?? "Ödenmemiş";// Ödeme durumu kontrolü: Eğer ödeme bilgisi yoksa "Ödenmemiş" olarak ayarla
                    string paymentMethod = payment?.PaymentMethod.ToString() ?? "Belirtilmemiş";// Ödeme şekli kontrolü: Eğer ödeme şekli bilgisi yoksa "Belirtilmemiş" olarak ayarla

                    // Fuar ve ödeme bilgilerini listeye ekle
                    lstReportResults.Items.Add(
                        $"Fuar Adı: {fair.Name} - Ödeme Durumu: {paymentStatus} - Ödeme Şekli: {paymentMethod}");
                }
            }
            else
            {
                // Eğer hiçbir fuar verisi yoksa kullanıcıyı bilgilendirmek için bir mesaj ekle
                lstReportResults.Items.Add("Hiçbir ödeme kaydı bulunamadı.");
            }
        }

      
    }
}
