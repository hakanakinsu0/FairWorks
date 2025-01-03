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

        public List<Building> GetAvailableBuildings(string city, string district, DateTime startDate, DateTime endDate)
        {
            return Where(x =>
                x.Location.City == city &&
                x.Location.District == district &&
                !x.Fairs.Any(f => f.RequestedStartDate < endDate && f.EndDate > startDate))
                .ToList();
        }

        public decimal CalculateFairCost(Building building, DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
                throw new ArgumentException("Bitiş tarihi başlangıç tarihinden önce olamaz.");

            int days = (endDate - startDate).Days + 1; // Fuarın süresi (gün sayısı)

            decimal costPerSquareMeter = 1000; // Her metrekare için temel fiyat
            decimal roomCost = 3000;          // Her oda için sabit fiyat

            // Binanın toplam maliyet hesaplaması:
            decimal totalCost = ((building.FloorSize * costPerSquareMeter * building.NumberOfFloor) +
                                 (building.RoomPerFloor * roomCost * building.NumberOfFloor)) * days;

            return totalCost;
        }

        public List<Building> GetBuildingsByCriteria(string city, int floors, int rooms, int minFloorSize)
        {
            return Where(b => b.Location.City == city &&
                              b.NumberOfFloor == floors &&
                              b.RoomPerFloor == rooms &&
                              b.FloorSize >= minFloorSize)
                .ToList();
        }
    }
}
