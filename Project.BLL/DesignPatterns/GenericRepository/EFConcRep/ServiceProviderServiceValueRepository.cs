using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFConcRep
{
    public class ServiceProviderServiceValueRepository : BaseRepository<ServiceProviderServiceValue>
    {
        public bool IsServiceValueLinkedToProvider(int providerId, int valueId)
        {
            return Any(psv => psv.ServiceProviderId == providerId && psv.ServiceValueId == valueId);
        }

        public List<ServiceProviderServiceValue> GetProviderServiceValues()
        {
            return GetAll().ToList();
        }

     
    }
}
