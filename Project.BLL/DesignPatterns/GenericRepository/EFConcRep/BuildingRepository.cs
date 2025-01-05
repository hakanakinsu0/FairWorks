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

        /// <summary>
        /// Binanın hazırlık süresini hesaplar.
        /// </summary>
        /// <param name="building">Bina bilgisi</param>
        /// <returns>Hazırlık süresi (gün olarak)</returns>
        public int CalculatePreparationDaysForBuilding(Building building)
        {
            int basePreparationDays = 5; // Minimum hazırlık süresi
            basePreparationDays += building.NumberOfFloor * 3; // Her kat için 1 gün
            basePreparationDays += building.RoomPerFloor * 3;  // Her oda için 1 gün
            return basePreparationDays;
        }

        public List<Building> SearchBuildings(string city, string district, DateTime calculatedStartDate, DateTime calculatedEndDate)
        {
            return _db.Buildings
                .Where(b => b.Location.City == city && b.Location.District == district) // Şehir ve ilçe kontrolü
                .Where(b => !_db.Fairs.Any(f =>
                    f.BuildingId == b.Id &&
                    f.CalculatedStartDate < calculatedEndDate &&
                    f.EndDate > calculatedStartDate)) // Tarih çakışması kontrolü
                .ToList();
        }

        /// <summary>
        /// Başlangıç ve bitiş tarihlerinin geçerli olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="startDate">Başlangıç tarihi</param>
        /// <param name="endDate">Bitiş tarihi</param>
        /// <returns>Geçerli ise true, aksi takdirde false döner</returns>
        public bool IsValidDateRange(DateTime startDate, DateTime endDate, out string errorMessage)
        {
            if (endDate <= startDate)
            {
                errorMessage = "Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        public List<string> GetFormattedBuildingReport()
        {
            return GetAll().Select(building =>
            {
                string locationDetails = building.Location != null
                    ? $"{building.Location.City}/{building.Location.District}"
                    : "Bilinmiyor";
                return $"Bina ID: {building.Id} - Adı: {building.Name} - Adres: {building.Address} - Şehir/İlçe: {locationDetails} - Durum: {building.Status}";
            }).ToList();
        }
    }
}
