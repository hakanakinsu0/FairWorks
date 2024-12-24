using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class EmployeeProfile : BaseEntity
    {
        public string FirstName { get; set; }   // Çalışanın adı
        public string LastName { get; set; }    // Çalışanın soyadı


        //Relational Properties
        public virtual Employee Employee { get; set; } // Yön: // 1 Employee 1 Profile
    }
}
