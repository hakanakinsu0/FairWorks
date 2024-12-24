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

        // Foreign Key
        public int ServiceValueId { get; set; }  // Hizmet değeri ile ilişki

        // Relational Properties
        public virtual ServiceValue ServiceValue { get; set; } // Yön: // 1 ServiceProvider 1 ServiceValue, 1 ServiceValue N ServiceProvider
        public virtual List<FairServiceProvider> FairServiceProviders { get; set; } // Yön: // 1 ServiceProvider N FairService, 1 FairService N ServiceProvider

    }
}
