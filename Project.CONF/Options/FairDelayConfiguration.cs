using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Options
{
    // FairDelay entity'si için veritabanı yapılandırma ayarlarını tanımlayan sınıftır. BaseConfiguration sınıfından türetilmiştir ve FairDelay entity'sine özel yapılandırmalarını içerir.
    public class FairDelayConfiguration:BaseConfiguration<FairDelay>
    {
        //Classa ait ayarlamaları sınıf tetiklendiğinde yapılsın istediğimiz için costructora belirli görevler yazılır.
        public FairDelayConfiguration()
        {

        }
    }
}
