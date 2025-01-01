using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class ServiceValue : BaseEntity
    {
        public string Name { get; set; }         // Değer adı (örneğin, "Kahvaltı", "Öğle Yemeği", "Özel Güvenlik")
        public decimal Cost { get; set; }        // Maliyet
        public int PreparationTime { get; set; } // Hizmet için gerekli hazırlık süresi (gün)
        public int BufferTime { get; set; }      // Hizmet için ek tampon süre (gün cinsinden)


        public int ServiceDescriptorId { get; set; } // Hizmet tanımı ile ilişki

        // Relational Properties
        public virtual ServiceDescriptor ServiceDescriptor { get; set; } // Yön: // 1 ServiceValue 1 ServiceDescriptor, 1 ServiceDescriptor N ServiceValue
        //public virtual List<ServiceProvider> Providers { get; set; }     // Yön: // 1 ServiceValue N ServiceProvider, 1 ServiceProvider 1 ServiceValue
        public virtual List<ServiceProviderServiceValue> ProviderServiceValues { get; set; } // Ara tablo ilişkisi

    }
}
