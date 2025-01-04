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
    public partial class FairSummaryForm : Form
    {
        public Customer LoggedInCustomer { get; set; }  // Giriş yapan müşteri bilgisi
        public Building SelectedBuilding { get; set; }  // Seçilen bina bilgisi
        public decimal TotalCost { get; set; }  // Toplam maliyet
        public List<string> SelectedServices { get; set; }  // Seçilen ek hizmetler
        public DateTime StartDate { get; set; }  // Başlangıç tarihi
        public DateTime EndDate { get; set; }  // Bitiş tarihi
        public string FairName { get; set; }  // Fuar adı
        public DateTime CalculatedStartDate { get; set; }  // Hesaplanan başlangıç tarihi

        // Formun yapıcı metodu
        public FairSummaryForm()
        {
            InitializeComponent();  // Form bileşenlerini başlat
        }

        private void FairSummaryForm_Load(object sender, EventArgs e)
        {   
            // Özet bilgileri oluşturmak için StringBuilder kullanılır
            StringBuilder summaryDetails = new StringBuilder();

            // Bina bilgilerini ekle
            if (SelectedBuilding != null)
            {
                summaryDetails.AppendLine("Seçilen Bina:");
                summaryDetails.AppendLine($"- Adı: {SelectedBuilding.Name}");
                summaryDetails.AppendLine($"- Adres: {SelectedBuilding.Address}");
                summaryDetails.AppendLine($"- Kat Sayısı: {SelectedBuilding.NumberOfFloor}");
                summaryDetails.AppendLine($"- Oda Başına Kat: {SelectedBuilding.RoomPerFloor}");
                summaryDetails.AppendLine();
            }

            // Ek hizmet bilgilerini ekle
            if (SelectedServices != null && SelectedServices.Count > 0)
            {
                summaryDetails.AppendLine("Seçilen Ek Hizmetler:");

                foreach (var service in SelectedServices)
                {
                    summaryDetails.AppendLine($"- {service}");
                }

                summaryDetails.AppendLine();
            }
            else
            {
                summaryDetails.AppendLine("Hiçbir Ek Hizmet Seçilmedi.");
            }

            // Tarih bilgilerini ekle
            summaryDetails.AppendLine("Tarih Bilgileri:");
            summaryDetails.AppendLine($"- Başlangıç Tarihi: {CalculatedStartDate.ToShortDateString()}");
            summaryDetails.AppendLine($"- Bitiş Tarihi: {EndDate.ToShortDateString()}");
            summaryDetails.AppendLine();

            // Bilgileri TextBox'a aktar
            txtSummaryDetails.Text = summaryDetails.ToString();

        }

        private void btnConfirmSelections_Click(object sender, EventArgs e)
        {
            if (SelectedBuilding == null)  // Eğer bina seçilmemişse uyarı ver
            {
                MessageBox.Show("Bina seçimi yapılmadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Fuar fiyat teklifi formunu başlat
            var fairPriceOfferForm = new FairPriceOfferForm
            {
                LoggedInCustomer = LoggedInCustomer,  // Giriş yapan müşteri bilgisi
                SelectedBuilding = SelectedBuilding,  // Seçilen bina
                TotalCost = TotalCost,  // Toplam maliyet
                StartDate = StartDate,  // Başlangıç tarihi
                EndDate = EndDate,  // Bitiş tarihi
                SelectedServices = SelectedServices,  // Seçilen hizmetler
                FairName = FairName,  // Fuar adı
                CalculatedStartDate = CalculatedStartDate // Hesaplanan başlangıç tarihi
            };

            fairPriceOfferForm.ShowDialog();  // Fuar fiyat teklifi formunu göster
            this.Close();  // Bu formu kapat
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Geri dön işlemi
            Close();
        }
    }
}
