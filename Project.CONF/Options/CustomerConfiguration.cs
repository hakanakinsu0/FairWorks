using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Options
{
    // Customer entity'si için veritabanı yapılandırma ayarlarını tanımlayan sınıftır. BaseConfiguration sınıfından türetilmiştir ve customer entity'sine özel yapılandırmalarını içerir.

    public class CustomerConfiguration:BaseConfiguration<Customer>
    {

        //Classa ait ayarlamaları sınıf tetiklendiğinde yapılsın istediğimiz için costructora belirli görevler yazılır..
        public CustomerConfiguration()
        {

            // Customer ile CustomerDetail arasında birebir bir ilişki kurar. CustomerDetail, Customer'e bağlı olarak, isteğe bağlı (optional) olarak tanımlanmıştır.
            HasOptional(x => x.CustomerDetail).WithRequired(x => x.Customer);
        }
    }
}
