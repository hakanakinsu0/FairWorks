using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Enums
{
    public enum DataStatus
    {
        //Gorev : Veri tabanında bulunan kayıtların durumunu temsil etmek için kullanılır.

        Inserted = 1,  // Kayıt yeni oluşturuldu.
        Updated = 2,   // Kayıt üzerinde değişiklik yapıldı.
        Deleted = 3    // Kayıt silindi veya işlevsiz hale getirildi.
    }
}
