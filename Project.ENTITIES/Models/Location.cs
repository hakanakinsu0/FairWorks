using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Location : BaseEntity
    {
        //Görev: Bir şehir ve ilçe bilgisini tutmak için tasarlanmıştır.

        // Lokasyon Bilgileri
        public string City { get; set; }        // Şehir adı (örneğin, "İstanbul")
        public string District { get; set; }    // İlçe adı (örneğin, "Kadıköy")

        // Relational Properties
        public virtual List<Building> Buildings { get; set; }                           // Lokasyondaki binalar
        public virtual List<CustomBuildingRequest> CustomBuildingRequests { get; set; } // Özel bina talepleri
    }
}
