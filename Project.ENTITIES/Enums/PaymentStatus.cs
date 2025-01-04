using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Enums
{
    public enum PaymentStatus
    {
        //Gorev : Bir ödemenin durumunu tanımlamak ve bu durumun sistem içinde izlenmesini sağlamak için kullanılır.

        Paid = 1,        // Ödeme başarılı bir şekilde tamamlandı.
        Negotiation = 2, // Ödeme pazarlık aşamasında.
        Failed = 3 ,      // Ödeme başarısız oldu.
        Cancelled = 4    // Ödeme iptal edildi. (Yeni eklendi)

    }
}
