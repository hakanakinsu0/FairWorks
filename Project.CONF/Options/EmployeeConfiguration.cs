using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Options
{
    // Employee entity'si için veritabanı yapılandırma ayarlarını tanımlayan sınıftır. BaseConfiguration sınıfından türetilmiştir ve Employee entity'sine özel yapılandırmalarını içerir.
    public class EmployeeConfiguration:BaseConfiguration<Employee>
    {
        //Classa ait ayarlamaları sınıf tetiklendiğinde yapılsın istediğimiz için costructora belirli görevler yazılır..
        public EmployeeConfiguration()
        {
            // Employee ile EmployeeProfil arasında birebir bir ilişki kurar. EmployeeProfil, Employee'ye bağlı olarak, isteğe bağlı (optional) olarak tanımlanmıştır.
            HasOptional(x => x.Profile).WithRequired(x => x.Employee);
        }
    }
}
