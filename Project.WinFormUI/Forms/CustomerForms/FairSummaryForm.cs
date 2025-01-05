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
            // Özet bilgilerini bir string değişkeninde oluştur
            string summaryDetails = "";

            // Bina bilgilerini ekle
            if (SelectedBuilding != null)
            {
                //\r\n : Platforma özgü yeni satır karakteri ekler ve daha uyumlu çalışır.
                summaryDetails += $"Seçilen Bina:\r\n";
                summaryDetails += $"- Adı: {SelectedBuilding.Name}\r\n";
                summaryDetails += $"- Adres: {SelectedBuilding.Address}\r\n";
                summaryDetails += $"- Kat Sayısı: {SelectedBuilding.NumberOfFloor}\r\n";
                summaryDetails += $"- Oda Başına Kat: {SelectedBuilding.RoomPerFloor}\r\n\r\n";
            }

            // Ek hizmet bilgilerini ekle
            if (SelectedServices != null && SelectedServices.Count > 0)
            {
                summaryDetails += $"Seçilen Ek Hizmetler:\r\n";

                foreach (var service in SelectedServices)
                {
                    summaryDetails += $"- {service}\r\n";
                }

                summaryDetails += "\r\n";
            }
            else
            {
                summaryDetails += "Hiçbir Ek Hizmet Seçilmedi.\r\n";
            }

            // Tarih bilgilerini ekle
            summaryDetails += "Tarih Bilgileri:\r\n";
            summaryDetails += $"- Başlangıç Tarihi: {CalculatedStartDate.ToShortDateString()}\r\n";
            summaryDetails += $"- Bitiş Tarihi: {EndDate.ToShortDateString()}\r\n\r\n";

            // Bilgileri TextBox'a aktar
            txtSummaryDetails.Text = summaryDetails;
        }

        private void btnConfirmSelections_Click(object sender, EventArgs e)
        {
            if (SelectedBuilding == null)  // Eğer bina seçilmemişse uyarı ver
            {
                MessageBox.Show("Bina seçimi yapılmadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Fuar fiyat teklifi formunu başlat
            FairPriceOfferForm fairPriceOfferForm = new FairPriceOfferForm
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
            Close();  // Bu formu kapat
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Geri dön işlemi
            Close();
        }
    }
}
