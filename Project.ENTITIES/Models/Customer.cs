using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Customer : BaseEntity
    {
        //Görev: Müşterilere ait temel bilgileri tutmak için tasarlanmıştır.

        // Müşteride En Çok Kullanılan Bilgiler
        public string ContactEMail { get; set; }          // İletişim için e-posta adresi
        public string Password { get; set; }              // Şifre 

        // Relational Properties
        public virtual List<Fair> Fairs { get; set; }                                   // Yön: // 1 Customer N Fair, 1 Fair 1 Customer
        public virtual List<CustomBuildingRequest> CustomBuildingRequests { get; set; } // Yön: // 1 Customer N CustomBuildingRequest, 1 CustomBuildingRequest 1 Customer
        public virtual CustomerDetail CustomerDetail { get; set; }                      // Yön: // 1 Customer 1 CustomerDetail, 1 CustomerDetail 1 Customer
    }
}
