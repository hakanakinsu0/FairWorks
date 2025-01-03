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

        public List<(string ProviderName, decimal Cost, int ServiceValueId)> GetProvidersForService(int serviceValueId)
        {
            return Where(psv => psv.ServiceValueId == serviceValueId)
                .Select(psv => new
                {
                    ProviderName = psv.ServiceProvider.ProviderName,
                    Cost = psv.ServiceValue.Cost,
                    ServiceValueId = psv.ServiceValueId
                })
                .Select(x => (x.ProviderName, x.Cost, x.ServiceValueId))
                .ToList();
        }

        public decimal CalculateTotalCostForServices(List<int> selectedServiceValueIds, int days)
        {
            var selectedServiceValues = Where(psv => selectedServiceValueIds.Contains(psv.ServiceValueId))
                .Select(psv => psv.ServiceValue.Cost)
                .ToList();

            return selectedServiceValues.Sum() * days;
        }





    }
}
