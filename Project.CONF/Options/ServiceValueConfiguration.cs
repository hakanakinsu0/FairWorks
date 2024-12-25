using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Options
{
    // ServiceValue entity'si için veritabanı yapılandırma ayarlarını tanımlayan sınıftır. BaseConfiguration sınıfından türetilmiştir ve ServiceValue entity'sine özel yapılandırmalarını içerir.
    public class ServiceValueConfiguration:BaseConfiguration<ServiceValue>
    {
        //Classa ait ayarlamaları sınıf tetiklendiğinde yapılsın istediğimiz için costructora belirli görevler yazılır..
        public ServiceValueConfiguration()
        {

        }
    }
}
