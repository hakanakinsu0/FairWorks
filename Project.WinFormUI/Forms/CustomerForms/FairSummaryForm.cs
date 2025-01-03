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
        public Customer LoggedInCustomer { get; set; }

        public Building SelectedBuilding { get; set; }
        public decimal TotalCost { get; set; }
        public List<string> SelectedServices { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FairName { get; set; } // FairName özelliği eklendi



        public FairSummaryForm()
        {
            InitializeComponent();
        }

        private void FairSummaryForm_Load(object sender, EventArgs e)
        {
            // Özet bilgileri oluştur
            StringBuilder summaryDetails = new StringBuilder();

            // Bina bilgileri
            if (SelectedBuilding != null)
            {
                summaryDetails.AppendLine("Seçilen Bina:");
                summaryDetails.AppendLine($"- Adı: {SelectedBuilding.Name}");
                summaryDetails.AppendLine($"- Adres: {SelectedBuilding.Address}");
                summaryDetails.AppendLine($"- Kat Sayısı: {SelectedBuilding.NumberOfFloor}");
                summaryDetails.AppendLine($"- Oda Başına Kat: {SelectedBuilding.RoomPerFloor}");
                //summaryDetails.AppendLine($"- Bina Maliyeti: {SelectedBuilding.FloorSize * 1000:C2}");
                summaryDetails.AppendLine();
            }

            // Ek hizmet bilgileri
            if (SelectedServices != null && SelectedServices.Count > 0)
            {
                summaryDetails.AppendLine("Seçilen Ek Hizmetler:");
                foreach (var service in SelectedServices)
                {
                    // Hizmet isimlerini göster, maliyet bilgisi ekleme
                    summaryDetails.AppendLine($"- {service.Split('-')[0].Trim()}");
                }
                summaryDetails.AppendLine();
            }
            else
            {
                summaryDetails.AppendLine("Hiçbir Ek Hizmet Seçilmedi.");
            }
            

            // Tarih bilgileri
            summaryDetails.AppendLine("Tarih Bilgileri:");
            summaryDetails.AppendLine($"- Başlangıç Tarihi: {StartDate.ToShortDateString()}");
            summaryDetails.AppendLine($"- Bitiş Tarihi: {EndDate.ToShortDateString()}");
            summaryDetails.AppendLine();

            // Toplam maliyet
            //summaryDetails.AppendLine($"Toplam Maliyet: {TotalCost:C2}");

            // Bilgileri label'a ata
            txtSummaryDetails.Text = summaryDetails.ToString();

        }

        private void btnConfirmSelections_Click(object sender, EventArgs e)
        {
            if (SelectedBuilding == null)
            {
                MessageBox.Show("Bina seçimi yapılmadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var fairPriceOfferForm = new FairPriceOfferForm
            {
                LoggedInCustomer = LoggedInCustomer,
                SelectedBuilding = SelectedBuilding,
                TotalCost = TotalCost,
                StartDate = StartDate,
                EndDate = EndDate,
                SelectedServices = SelectedServices,
                FairName = FairName // Fuar adını geçiriyoruz
            };

            fairPriceOfferForm.ShowDialog();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Geri dön işlemi
            Close();
        }
    }
}
