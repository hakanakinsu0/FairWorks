using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class FairService : BaseEntity
    {
        //Görev: Bir fuar için sağlanan hizmetleri temsil eder

        // Fuar Hizmeti Detayları
        public string Name { get; set; }            // Hizmet adı (örneğin, "Teknik Destek")
        public decimal Cost { get; set; }           // Hizmet maliyeti
        public bool IsMandatory { get; set; }       // Hizmet zorunlu mu?

        // Foreign Key
        public int FairId { get; set; }             // Hangi fuara ait

        // Relational Properties
        public virtual Fair Fair { get; set; }                                          // Hizmetin ait olduğu fuar
        public virtual List<FairServiceProvider> FairServiceProviders { get; set; }     // Hizmet sağlayıcıları
        public virtual List<AdditionalFairService> AdditionalFairServices { get; set; } // Ek hizmetler
    }
}
