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
        public string FirstName { get; set; }             // Müşterinin adı
        public string LastName { get; set; }              // Müşterinin soyadı
        public string ContactPhoneNumber { get; set; }    // İletişim için telefon numarası
        public string ContactEMail { get; set; }          // İletişim için e-posta adresi
        public string CompanyName { get; set; }           // Müşterinin bağlı olduğu şirket adı

        // Relational Properties
        public virtual List<Fair> Fairs { get; set; }                                   // Müşterinin düzenlediği fuarlar
        public virtual List<CustomBuildingRequest> CustomBuildingRequests { get; set; } // Müşterinin özel bina talepleri
    }
}
