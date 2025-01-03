using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Enums
{
    public enum PaymentMethod
    {
        //Gorev : Sistemdeki ödeme yöntemlerini tanımlamak ve sınırlı bir seçenek seti sunarak bu yöntemlerin kullanımı sırasında hata yapma olasılığını azaltmak için kullanılır.
       
        Cash = 1,        // Nakit ödeme
        CreditCart = 2,  // Kredi kartı ile ödeme
        BankTransfer = 3, // Banka havalesi ile ödeme
    }
}
