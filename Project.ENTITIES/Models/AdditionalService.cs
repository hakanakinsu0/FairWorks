using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class AdditionalService : BaseEntity
    {
        //Görev: Sisteme ait ekstra hizmetlerin tanımını ve bu hizmetlere ilişkin bilgileri tutar.

        public string Category { get; set; }    // Hizmetin kategorisi
        public string ServiceName { get; set; } // Hizmet adi
        public string Description { get; set; } // Hizmet aciklamasi

        //Relational Properties
        public virtual List<AdditionalFairService> AdditionalFairServices { get; set; } //1 AdditionalService n FairService, 1 FairService n AdditionalService
        public virtual List<ServiceProvider> ServiceProviders { get; set; }             //1 ServiceProvider 1 AdditionalService, 1 AdditionalService n ServiceProvider
    }
}
