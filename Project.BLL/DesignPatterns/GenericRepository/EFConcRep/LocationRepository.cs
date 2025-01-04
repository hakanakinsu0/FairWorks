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
        /// <summary>
        /// Şehir ve ilçe eşsiz mi kontrol eder.
        /// </summary>
        public bool IsLocationUnique(string city, string district)
        {
            return !Any(x => x.City.ToLower() == city.ToLower() &&
                             x.District.ToLower() == district.ToLower());
        }

        /// <summary>
        /// Tüm şehirleri benzersiz olarak getir.
        /// </summary>
        public List<string> GetAllCities()
        {
            return GetAll()
                .Select(location => location.City)
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Seçilen şehre göre ilçeleri getir.
        /// </summary>
        public List<string> GetDistrictsByCity(string city)
        {
            return GetAll()
                .Where(location => location.City == city)
                .Select(location => location.District)
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Şehirleri alfabetik sıraya göre getir.
        /// </summary>
        public List<string> GetSortedUniqueCities()
        {
            return GetAllCities().OrderBy(city => city).ToList();
        }

    }
}
