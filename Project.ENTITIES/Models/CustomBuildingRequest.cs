using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class CustomBuildingRequest : BaseEntity
    {
        //Görev: Müşterilerin özel bina taleplerini tutmak için tasarlanmıştır.

        // Müşterinin özel bina taleplerine ait bilgiler
        public int NumberOfFloor { get; set; }     // İstenilen kat sayısı
        public int FloorSize { get; set; }         // Her katın metrekaresi
        public int RoomsPerFloor { get; set; }     // Her kattaki oda sayısı
        public DateTime RequestDate { get; set; }  // Talep tarihi

        // Foreign Keys
        public int CustomerId { get; set; }        // Talebi yapan müşterinin ID'si
        public int LocationId { get; set; }        // Talep edilen lokasyonun ID'si

        // Relational Properties
        public virtual Customer Customer { get; set; }  // Yön: // 1 CustomBuildingRequest 1 Customer, 1 Customer N CustomBuildingRequest

        public virtual Location Location { get; set; }  // Yön: // 1 CustomBuildingRequest 1 Location, 1 Location N CustomBuildingRequest

    }
}
