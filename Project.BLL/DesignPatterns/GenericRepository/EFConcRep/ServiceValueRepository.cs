using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFConcRep
{
    public class ServiceValueRepository:BaseRepository<ServiceValue>
    {
        public void AddServiceValue(ServiceValue value)
        {
            Add(value);
        }

        public ServiceValue GetByName(string name)
        {
            return FirstOrDefault(sv => sv.Name == name);
        }

    }
}
