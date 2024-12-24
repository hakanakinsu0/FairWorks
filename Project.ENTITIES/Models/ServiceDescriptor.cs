using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class ServiceDescriptor : BaseEntity
    {
        //Görev: Sisteme ait ekstra hizmetlerin tanımını ve bu hizmetlere ilişkin bilgileri tutar.

        public string Name { get; set; }         // Hizmet adı (örneğin, "Yemek Servisi", "Güvenlik")
        public string Description { get; set; } // Hizmet açıklaması

        // Relational Properties
        public virtual List<ServiceValue> ServiceValues { get; set; } // Yön: // 1 ServiceDescriptor N ServiceValue, 1 ServiceValue 1 ServiceDescriptor

    }
}
