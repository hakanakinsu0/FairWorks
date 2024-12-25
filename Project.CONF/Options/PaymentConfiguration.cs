using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Options
{
    // Payment entity'si için veritabanı yapılandırma ayarlarını tanımlayan sınıftır. BaseConfiguration sınıfından türetilmiştir ve Payment entity'sine özel yapılandırmalarını içerir.
    public class PaymentConfiguration:BaseConfiguration<Payment>
    {
        //Classa ait ayarlamaları sınıf tetiklendiğinde yapılsın istediğimiz için costructora belirli görevler yazılır.
        public PaymentConfiguration()
        {

        }
    }
}
