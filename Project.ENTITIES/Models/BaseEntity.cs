using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public abstract class BaseEntity
    {
        //Görev: Tüm tabloların ortak özelliklerini barındırmak için tasarlanmış soyut bir sınıftır (abstract class).

        // Constructor: Miras verildiği class'larda varsayılan değerleri atar.
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;      // Kayıt oluşturma tarihi, otomatik olarak atanır.
            Status = DataStatus.Inserted;    // Varsayılan olarak kayıt "Inserted" (yeni eklenmiş) durumunda başlar.
        }

        public int Id { get; set; }                   // Her tablo için benzersiz bir kimlik alanı
        public DateTime CreatedDate { get; set; }     // Kayıt oluşturulma tarihi
        public DateTime? ModifiedDate { get; set; }   // Kayıt değiştirilme tarihi
        public DateTime? DeletedDate { get; set; }    // Kayıt silinme tarihi
        public DataStatus Status { get; set; }        // Kayıt durumu (Inserted, Updated, Deleted)
    }
}
