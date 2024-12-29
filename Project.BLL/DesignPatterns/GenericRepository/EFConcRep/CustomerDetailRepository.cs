using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFConcRep
{
    public class CustomerDetailRepository : BaseRepository<CustomerDetail>
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

        public bool IsFirstNameRegistered(string firstName)
        {
            return Any(x => x.FirstName == firstName);
        }
        public bool IsLastNameRegistered(string lastName)
        {
            return Any(x => x.LastName == lastName);
        }
        public bool IsCompanyNameRegistered(string companyName)
        {
            return Any(x => x.CompanyName == companyName);
        }
    }
}
