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

        // Müşteri Bilgileri

        public string ContactEMail { get; set; }          // İletişim için e-posta adresi
        public string Password { get; set; }              // Şifre 

        // Relational Properties
        public virtual List<Fair> Fairs { get; set; }                                   // Müşterinin düzenlediği fuarlar
        public virtual List<CustomBuildingRequest> CustomBuildingRequests { get; set; } // Müşterinin özel bina talepleri
        public virtual CustomerDetail CustomerDetail { get; set; }                      // Müşterinin detaylı bilgileri

    }
}
