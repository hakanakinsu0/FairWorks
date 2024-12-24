using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class AdditionalFairService : BaseEntity
    {
        //Gorev : FairService (Fuar Hizmeti) ve AdditionalService (Ekstra Hizmet) tabloları arasında bir çoktan çoğa (many-to-many) ilişkiyi temsil eden bir ara tablosu (junction table) olarak tasarlanmıştır.

        //Foreign Keys
        public int FairServiceId { get; set; }       // Fuar Hizmetine ait ID
        public int AdditionalServiceId { get; set; } // Ekstra Hizmete ait ID

        // Relational Properties
        public virtual FairService FairService { get; set; }             // Fuar hizmeti ile ilişki
        public virtual AdditionalService AdditionalService { get; set; } // Ekstra hizmet ile ilişki
    }
}
