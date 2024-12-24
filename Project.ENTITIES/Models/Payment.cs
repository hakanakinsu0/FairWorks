using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Payment : BaseEntity
    {
        //Görev: Yapılan ödemelerle ilgili detayları saklamak için tasarlanmıştır. Bu sınıf, ödemenin miktarını, ödeme yöntemini, durumunu, iade sürecini ve ödeme tarihini içerir. 

        // Ödeme Detayları
        public decimal Amount { get; set; }              // Ödenen miktar
        public PaymentMethod PaymentMethod { get; set; } // Ödeme yöntemi (örneğin, nakit, kredi kartı)
        public PaymentStatus PaymentStatus { get; set; } // Ödeme durumu (örneğin, ödendi, başarısız)
        public RefundStatus RefundStatus { get; set; }   // İade durumu (örneğin, iade talep edildi)
        public DateTime PaymentDate { get; set; }        // Ödeme tarihi

        // Relational Properties
        public virtual List<FairPayment> FairPayments { get; set; } // Ödeme ile ilişkilendirilen fuarlar
    }
}
