using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFConcRep
{
    public class ServiceProviderRepository:BaseRepository<ServiceProvider>
    {
        public void AddServiceProvider(ServiceProvider provider)
        {
            Add(provider);
        }

        public ServiceProvider GetByName(string name)
        {
            return FirstOrDefault(sp => sp.ProviderName == name);
        }

    }
}
