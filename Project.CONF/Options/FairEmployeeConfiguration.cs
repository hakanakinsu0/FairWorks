using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Options
{
    // FairEmployee entity'si için veritabanı yapılandırma ayarlarını tanımlayan sınıftır. BaseConfiguration sınıfından türetilmiştir ve FairEmployee entity'sine özel yapılandırmalarını içerir.
    public class FairEmployeeConfiguration:BaseConfiguration<FairEmployee>
    {
        //Classa ait ayarlamaları sınıf tetiklendiğinde yapılsın istediğimiz için costructora belirli görevler yazılır.
        public FairEmployeeConfiguration()
        {
            //Id özelliği veritabanında bir sütun olarak oluşturulmaz.
            Ignore(x => x.Id);


            //FairId ve EmpoloyeeId alanlarından oluşan bir bileşik anahtar(composite key) tanımlanır. Bu, tablodaki her kaydın FairId ve EmpoloyeeId kombinasyonuyla benzersiz olmasını sağlar.
            HasKey(x => new
            {
                x.EmployeeId,
                x.FairId
            });
        }
    }
}
