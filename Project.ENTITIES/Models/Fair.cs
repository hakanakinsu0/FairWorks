using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Fair : BaseEntity
    {
        //Görev: Sistemde düzenlenecek olan bir fuarın temel bilgilerini ve bu fuarla ilgili ilişkileri tutmak için tasarlanmıştır.

        // Fuar Detayları
        public string Name { get; set; }            // Fuarın adı
        public DateTime StartDate { get; set; }     // Fuarın başlangıç tarihi
        public DateTime EndDate { get; set; }       // Fuarın bitiş tarihi
        public decimal TotalCost { get; set; }      // Fuarın toplam maliyeti
        public bool IsDelayed { get; set; }         // Fuarın gecikip gecikmediği durumu
        public string DelayReason { get; set; }     // Fuarın gecikme nedeni (opsiyonel)

        // Foreign Keys
        public int CustomerId { get; set; }         // Fuarı düzenleyen müşteri
        public int BuildingId { get; set; }         // Fuarın düzenleneceği bina

        // Relational Properties
        public virtual Customer Customer { get; set; }                // Yön: // 1 Fair 1 Customer, 1 Customer N Fair
        public virtual Building Building { get; set; }                // Yön: // 1 Fair 1 Building, 1 Building N Fair
        public virtual List<FairService> FairServices { get; set; }   // Yön: // 1 Fair N FairService, 1 FairService 1 Fair
        public virtual List<FairPayment> FairPayments { get; set; }   // Yön: // 1 Fair N FairPayment, 1 FairPayment 1 Fair
        public virtual List<FairEmployee> Employees { get; set; }     // Yön: // 1 Fair N Employee, 1 Employee N Fair (Ara tablo: FairEmployee)

    }
}
