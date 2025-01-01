using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFConcRep
{
    public class ServiceDescriptorRepository:BaseRepository<ServiceDescriptor>
    {
        public void AddServiceDescriptor(ServiceDescriptor descriptor)
        {
            Add(descriptor); // GenericRepository'nin Add metodu çağrılır.
        }

        public ServiceDescriptor GetByName(string name)
        {
            return FirstOrDefault(sd => sd.Name == name);
        }
    }
}
