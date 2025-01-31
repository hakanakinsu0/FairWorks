﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class FairServiceProvider : BaseEntity
    {
        //Görev: FairService (Fuar Hizmeti) ve ServiceProvider (Hizmet Sağlayıcı) tabloları arasındaki çoktan çoğa (many-to-many) ilişkiyi temsil eden bir ara tablosu (junction table) olarak tasarlanmıştır.

        // Foreign Keys
        public int FairServiceId { get; set; }       // Hizmetin ID'si
        public int ServiceProviderId { get; set; }   // Sağlayıcının ID'si

        // Relational Properties
        public virtual FairService FairService { get; set; }         // Yön: // 1 FairService N ServiceProvider, 1 ServiceProvider N FairService
        public virtual ServiceProvider ServiceProvider { get; set; } // Yön: // 1 ServiceProvider N FairService, 1 FairService N ServiceProvider
    }
}
