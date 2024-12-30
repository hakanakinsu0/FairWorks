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

    }
}
