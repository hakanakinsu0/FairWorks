using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFConcRep
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public bool IsValidEmailFormat(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        public bool IsValidPassword(string password)
        {
            return password.Length >= 8;
        }

        public bool IsEmailRegistered(string email)
        {
            return Any(x => x.ContactEMail == email);
        }
        
    }
}
