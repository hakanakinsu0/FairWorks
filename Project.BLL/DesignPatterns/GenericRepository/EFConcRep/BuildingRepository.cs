using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFConcRep
{
    public class BuildingRepository : BaseRepository<Building>
    {
        public bool IsBuildingUnique(string buildingName)
        {
            return !Any(x => x.Name.ToLower() == buildingName.ToLower());
        }

        public bool IsFloorCountValid(int floorCount)
        {
            return floorCount >= 1 && floorCount <= 5;
        }

        public bool IsFloorSizeValid(int floorSize)
        {
            return floorSize >= 50 && floorSize <= 300;
        }

        public bool IsRoomCountValid(int roomCount)
        {
            return roomCount >= 1 && roomCount <= 6;
        }

        /// <summary>
        /// Şehir, ilçe ve tarih aralığına uygun binaları döndürür.
        /// </summary>
        /// <param name="city">Şehir adı</param>
        /// <param name="district">İlçe adı</param>
        /// <param name="startDate">Fuarın başlangıç tarihi</param>
        /// <param name="endDate">Fuarın bitiş tarihi</param>
        /// <returns>Uygun binaların listesi</returns>
        public List<Building> GetAvailableBuildings(string city, string district, DateTime startDate, DateTime endDate)
        {
            // Şehir ve ilçe kriterine uygun binaları al
            List<Building> buildingsInLocation = Where(x => x.Location.City == city && x.Location.District == district).ToList();

            // Belirtilen tarih aralığında uygun binaları kontrol et
            List<Building> availableBuildings = buildingsInLocation.Where(b =>
                !b.Fairs.Any(f =>
                    (f.RequestedStartDate < endDate && f.EndDate > startDate) // Tarihler çakışıyor mu kontrol et
                )).ToList();

            return availableBuildings;
        }

        public decimal CalculateFairCost(Building building)
        {
            decimal costPerSquareMeter = 1000; // Her metrekare için temel fiyat
            decimal roomCost = 3000;          // Her oda için sabit fiyat

            // Hesaplama
            decimal totalCost = (building.FloorSize * costPerSquareMeter * building.NumberOfFloor) +
                                (building.RoomPerFloor * roomCost * building.NumberOfFloor);

            return totalCost;
        }

        public List<Building> GetBuildingsByCriteria(string city, int floors, int rooms, int minFloorSize)
        {
            return GetAll()
                .Where(b => b.Location.City == city &&
                            b.NumberOfFloor == floors &&
                            b.RoomPerFloor == rooms &&
                            b.FloorSize >= minFloorSize)
                .ToList();
        }

        public bool ValidateBuildingCriteria(int floors, int rooms, int minFloorSize)
        {
            return IsFloorCountValid(floors) &&
                   IsRoomCountValid(rooms) &&
                   IsFloorSizeValid(minFloorSize);
        }
    }
}
