using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFConcRep
{
    public class LocationRepository:BaseRepository<Location>
    {
        public bool IsLocationUnique(string city, string district)
        {
            return !Any(x => x.City.ToLower() == city.ToLower() &&
                             x.District.ToLower() == district.ToLower());
        }

        // Tüm şehirleri döndürür, tekrarlayan şehirleri kaldırır
        public List<string> GetAllCities()
        {
            //return GetAll() // Tüm lokasyonları al
            //    .Select(x => x.City) // Sadece City alanını seç
            //    .Distinct() // Tekrarlayan şehirleri kaldır
            //    .ToList(); // Listeye dönüştür

            return GetAll().Select(location => location.City).Distinct().ToList();

        }

        // Seçilen şehre göre ilçeleri döndürür
        public List<string> GetDistrictsByCity(string city)
        {
            // Şehre göre ilçeleri filtreleyip benzersiz olarak döndür
            return GetAll().Where(location => location.City == city)
                           .Select(location => location.District)
                           .Distinct()
                           .ToList();
        }

        public List<string> GetUniqueCities()
        {
            return GetAll()
                .Select(location => location.City)
                .Distinct()
                .ToList();
        }




    }
}
