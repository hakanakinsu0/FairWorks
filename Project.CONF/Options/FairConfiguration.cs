using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Options
{
    // Fair entity'si için veritabanı yapılandırma ayarlarını tanımlayan sınıftır. BaseConfiguration sınıfından türetilmiştir ve Fair entity'sine özel yapılandırmalarını içerir.
    public class FairConfiguration:BaseConfiguration<Fair>
    {
        //Classa ait ayarlamaları sınıf tetiklendiğinde yapılsın istediğimiz için costructora belirli görevler yazılır.
        public FairConfiguration()
        {

        }
    }
}
