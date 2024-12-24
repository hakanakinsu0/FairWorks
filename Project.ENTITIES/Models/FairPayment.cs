using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class FairPayment : BaseEntity
    {
        //Görev:  Fair (Fuar) ve Payment (Ödeme) tabloları arasındaki çoktan çoğa (many-to-many) ilişkiyi temsil eden bir ara tablosu (junction table) olarak tasarlanmıştır. 

        // Foreign Keys
        public int FairId { get; set; }          // Fuar ID'si
        public int PaymentId { get; set; }       // Ödeme ID'si

        // Relational Properties
        public virtual Fair Fair { get; set; }       // Yön: // 1 Fair N Payment, 1 Payment N Fair
        public virtual Payment Payment { get; set; } // Yön: // 1 Payment N Fair, 1 Fair N Payment
    }
}
