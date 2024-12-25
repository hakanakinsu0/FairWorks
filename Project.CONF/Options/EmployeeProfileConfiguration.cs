﻿using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Options
{ 
    // EmployeeProfileentity'si için veritabanı yapılandırma ayarlarını tanımlayan sınıftır. BaseConfiguration sınıfından türetilmiştir ve EmployeeProfile entity'sine özel yapılandırmalarını içerir.
   
    public class EmployeeProfileConfiguration:BaseConfiguration<EmployeeProfile>
    {
        //Classa ait ayarlamaları sınıf tetiklendiğinde yapılsın istediğimiz için costructora belirli görevler yazılır..
        public EmployeeProfileConfiguration()
        {

        }
    }
}
