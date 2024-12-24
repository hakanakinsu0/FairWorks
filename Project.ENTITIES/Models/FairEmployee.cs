using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class FairEmployee : BaseEntity
    {
        // Foreign Keys
        public int FairId { get; set; }       // Fuar ID'si
        public int EmployeeId { get; set; }   // Çalışan ID'si

        // Relational Properties
        public virtual Fair Fair { get; set; }           // Yön: // 1 Fair N Employee, 1 Employee N Fair
        public virtual Employee Employee { get; set; }   // Yön: // 1 Employee N Fair, 1 Fair N Employee
    }
}
