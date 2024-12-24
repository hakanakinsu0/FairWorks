using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class ServiceProvider : BaseEntity
    {
        //Gorev :  Hizmet sağlayıcıları ile ilgili detayları tutmak için tasarlanmıştır. Bu sınıf, sağlayıcının adı, adresi, iletişim bilgileri ve hizmet maliyeti gibi bilgileri içerir.

        // Sağlayıcı Detayları
        public string ProviderName { get; set; } // Sağlayıcı şirket adı
        public string Address { get; set; }      // Açık adres
        public string District { get; set; }     // İlçe
        public string City { get; set; }         // İl
        public string PhoneNumber { get; set; }  // Telefon numarası
        public string Email { get; set; }        // E-posta
        public decimal Cost { get; set; }        // Hizmet maliyeti

        // Foreign Key
        public int AdditionalServiceId { get; set; } // Ek hizmet ilişkisi

        // Relational Properties
        public virtual AdditionalService AdditionalService { get; set; }            // Ek hizmet ile ilişki
        public virtual List<FairServiceProvider> FairServiceProviders { get; set; } // Fuar hizmet sağlayıcıları ile ilişki
    }
}
