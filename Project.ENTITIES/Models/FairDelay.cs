using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class FairDelay : BaseEntity
    {
        // Görev: Fuar gecikmelerinin detaylarını tutar.

        // Gecikme Detayları
        public int DelayDuration { get; set; }      // Gecikme süresi (gün)
        public string DelayReason { get; set; }     // Gecikme nedeni
        public DateTime NewStartDate { get; set; }  // Gecikme sonrası başlangıç tarihi
        public DateTime NewEndDate { get; set; }    // Gecikme sonrası bitiş tarihi

        // Foreign Keys
        public int FairId { get; set; }             // Hangi fuara ait gecikme

        // Relational Properties
        public virtual Fair Fair { get; set; }      // Yön: // 1 Fair N Delay, 1 Delay 1 Fair
    }
}
