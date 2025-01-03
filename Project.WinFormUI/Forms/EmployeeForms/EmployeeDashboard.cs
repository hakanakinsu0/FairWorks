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
        private EmployeeRepository _employeeRepository;
        private EmployeeProfileRepository _employeeProfileRepository;
        private ServiceProviderRepository _serviceProviderRepository;
        private ServiceDescriptorRepository _serviceDescriptorRepository;
        private ServiceValueRepository _serviceValueRepository;
        private BuildingRepository _buildingRepository;
        private LocationRepository _locationRepository;

        public EmployeeDashboard()
        {
            InitializeComponent();

            // Repository örneklerini başlat
            _employeeRepository = new EmployeeRepository();
            _employeeProfileRepository = new EmployeeProfileRepository();
            _serviceProviderRepository = new ServiceProviderRepository();
            _serviceDescriptorRepository = new ServiceDescriptorRepository();
            _serviceValueRepository = new ServiceValueRepository();
            _buildingRepository = new BuildingRepository();
            _locationRepository = new LocationRepository();
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
            lstReportResults.Items.Clear();

            var employees = _employeeRepository.GetAll();

            foreach (var employee in employees)
            {
                var profile = employee.Profile;

                if (profile != null)
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
            lstReportResults.Items.Clear();

            var services = _serviceValueRepository.GetAll();

            foreach (var service in services)
            {
                lstReportResults.Items.Add(
                    $"Hizmet ID: {service.Id} - Adı: {service.Name} - Maliyet: {service.Cost:C2} - Hazırlık Süresi: {service.PreparationTime} gün - Durum: {service.Status}");
            }
        }

        private void btnBuildingReport_Click(object sender, EventArgs e)
        {
            lstReportResults.Items.Clear();

            // Tüm bina verilerini al
            var buildings = _buildingRepository.GetAll();

            foreach (var building in buildings)
            {
                // İlişkili Location'dan City ve District bilgilerini al
                var location = building.Location;

                if (location != null)
                {
                    lstReportResults.Items.Add(
                        $"Bina ID: {building.Id} - Adı: {building.Name} - Adres: {building.Address} - Şehir/İlçe: {location.City}/{location.District} - Durum: {building.Status}");
                }
                else
                {
                    lstReportResults.Items.Add(
                        $"Bina ID: {building.Id} - Adı: {building.Name} - Adres: {building.Address} - Şehir/İlçe: Bilgi Yok - Durum: {building.Status}");
                }
            }
        }

        private void btnLocationReport_Click(object sender, EventArgs e)
        {
            lstReportResults.Items.Clear();

            var locations = _locationRepository.GetAll();

            foreach (var location in locations)
            {
                lstReportResults.Items.Add(
                    $"Lokasyon ID: {location.Id} - Lokasyon : {location.City} / {location.District} - Durum: {location.Status}");
            }
        }

        private void lstReportResults_DoubleClick(object sender, EventArgs e)
        {
            if (lstReportResults.SelectedIndex != -1)
            {
                MessageBox.Show(lstReportResults.SelectedItem.ToString(), "Detaylı Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnMevcutFuarlar_Click(object sender, EventArgs e)
        {
            lstReportResults.Items.Clear();

            // Fuar verilerinin alınması için repository kullanıyoruz
            FairRepository fairRepository = new FairRepository();

            // Mevcut durumdaki fuarları alıyoruz
            var fairs = fairRepository.Where(f => f.Status != Project.ENTITIES.Enums.DataStatus.Deleted).ToList();

            if (fairs.Any())
            {
                foreach (var fair in fairs)
                {
                    lstReportResults.Items.Add(
                        $"Fuar ID: {fair.Id} - Adı: {fair.Name} - Başlangıç Tarihi: {fair.RequestedStartDate:dd/MM/yyyy} - Bitiş Tarihi: {fair.EndDate:dd/MM/yyyy} - Maliyet: {fair.TotalCost:C2}");
                }
            }
            else
            {
                lstReportResults.Items.Add("Mevcut durumda hiçbir fuar bulunamadı.");
            }
        }

        private void btnExitReport_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFuarOdemeleri_Click(object sender, EventArgs e)
        {
            lstReportResults.Items.Clear();

            // Gerekli repository'ler
            FairRepository fairRepository = new FairRepository();
            PaymentRepository paymentRepository = new PaymentRepository();

            // Tüm fuarları al
            var fairs = fairRepository.GetAll();

            if (fairs.Any())
            {
                foreach (var fair in fairs)
                {
                    // Ödeme bilgilerini Payment tablosundan al
                    var payment = paymentRepository.FirstOrDefault(p => p.FairId == fair.Id);

                    // Ödeme durumu ve ödeme şekli kontrolü
                    string paymentStatus = payment?.PaymentStatus.ToString() ?? "Ödenmemiş";
                    string paymentMethod = payment?.PaymentMethod.ToString() ?? "Belirtilmemiş";

                    // Listeye ekleme
                    lstReportResults.Items.Add(
                        $"Fuar Adı: {fair.Name} - Ödeme Durumu: {paymentStatus} - Ödeme Şekli: {paymentMethod}");
                }
            }
            else
            {
                lstReportResults.Items.Add("Hiçbir ödeme kaydı bulunamadı.");
            }
        }
    }
}
