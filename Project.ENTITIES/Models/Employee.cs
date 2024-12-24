using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Employee : BaseEntity
    {
        public string Email { get; set; }       // İletişim e-postası
        public string Password { get; set; }    // Giriş için şifre
        public EmployeeRole Role { get; set; }  // Çalışanın rolü (Admin, Organizer, Support vb.)
        public int? ManagerId { get; set; }     // Eğer bir üst yöneticisi varsa, Manager'ın ID'si

        //Relational Properties

        public virtual Employee Manager { get; set; }               // Yön: // 1 Employee 1 Manager, 1 Manager N Subordinate
        public virtual List<Employee> Subordinates { get; set; }    // Yön: // 1 Manager N Subordinate, 1 Subordinate 1 Manager
        public virtual List<FairEmployee> Employees { get; set; }   // Yön: // 1 Employee N Fair, 1 Fair N Employee (Ara tablo: FairEmployee)
        public virtual EmployeeProfile Profile { get; set; }        // Yön: // 1 Employee 1 Profile

    }
}
