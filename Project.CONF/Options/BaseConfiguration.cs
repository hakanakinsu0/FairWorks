using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Options
{
    public abstract class BaseConfiguration<T>:EntityTypeConfiguration<T> where T :BaseEntity
    {
        //sadece miras vermekle görevli olduğu için abstract olarak tanımlanmıştır

        /*
    Bu sınıf , tüm entity sınıfları için ortak olan yapılandırma ayarlarını tanımlayan soyut bir sınıftır. Entity Framework kütüphanesinden EntityTypeConfiguration sınıfını kullanarak, BaseEntity sınıfından türeyen tüm entity'lerin ortak özelliklerinin veritabanındaki sütun adlarını yapılandırır. Böylece farklı entity türleri için yeniden kullanılabilir bir yapı sunar.
    */

        // Constructor: Miras verildiği class'larda varsayılan değerleri atar.
        public BaseConfiguration()
        {

        }
    }
}
