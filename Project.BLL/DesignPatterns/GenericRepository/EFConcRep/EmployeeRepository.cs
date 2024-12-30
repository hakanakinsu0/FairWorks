using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFConcRep
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public Employee GetByEmailAndPassword(string email, string password)
        {
            return FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public bool IsValidPassword(string password)
        {
            return password.Length >= 8;
        }

        public bool IsValidEmailFormat(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
    }
}
