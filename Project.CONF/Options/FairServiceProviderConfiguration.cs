using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Options
{
    // FairServiceProvider entity'si için veritabanı yapılandırma ayarlarını tanımlayan sınıftır. BaseConfiguration sınıfından türetilmiştir ve FairServiceProvider entity'sine özel yapılandırmalarını içerir.
    public class FairServiceProviderConfiguration:BaseConfiguration<FairServiceProvider>
    {

        //Classa ait ayarlamaları sınıf tetiklendiğinde yapılsın istediğimiz için costructora belirli görevler yazılır.
        public FairServiceProviderConfiguration()
        {
            //Id özelliği veritabanında bir sütun olarak oluşturulmaz.
            Ignore(x => x.Id);

            //FairServiceId ve ServiceProviderId alanlarından oluşan bir bileşik anahtar(composite key) tanımlanır. Bu, tablodaki her kaydın FairServiceId ve ServiceProviderId kombinasyonuyla benzersiz olmasını sağlar.
            HasKey(x => new
            {
                x.ServiceProviderId,
                x.FairServiceId
            });
        }
    }
}
