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



    }
}
