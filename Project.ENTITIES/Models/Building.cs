using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Building : BaseEntity
    {
        //Görev: Sistemde mevcut olan binaların detaylarını tutmak için tasarlanmıştır.

        // Bina Detayları
        public string Name { get; set; }           // Binanın adı
        public string Address { get; set; }        // Binanın açık adresi
        public int NumberOfFloor { get; set; }     // Binadaki kat sayısı
        public int FloorSize { get; set; }         // Her katın metrekaresi
        public int RoomPerFloor { get; set; }      // Her kattaki oda sayısı

        // Foreign Keys
        public int LocationId { get; set; }        // Binanın konum bilgisine ait Foreign Key

        // Relational Properties
        public virtual Location Location { get; set; }  // 1 Building 1 Location, 1 Location N Building

        public virtual List<Fair> Fairs { get; set; }   // 1 Building N Fair, 1 Fair 1 Building
    }
}
