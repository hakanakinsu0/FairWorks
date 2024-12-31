using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFConcRep
{
    public class EmployeeProfileRepository : BaseRepository<EmployeeProfile>
    {
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 11) return false;

            foreach (char c in phoneNumber)
            {
                if (c < '0' || c > '9') return false;
            }
            return true;
        }
        
    }

}
