using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Options
{
    public class CustomerDetailConfiguration:BaseConfiguration<CustomerDetail>
    {
        // CustomerDetail entity'si için veritabanı yapılandırma ayarlarını tanımlayan sınıftır. BaseConfiguration sınıfından türetilmiştir ve CustomerDetail entity'sine özel yapılandırmalarını içerir.


        //Classa ait ayarlamaları sınıf tetiklendiğinde yapılsın istediğimiz için costructora belirli görevler yazılır..
        public CustomerDetailConfiguration()
        {

        }
    }
}
