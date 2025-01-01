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

        public decimal CalculateTotalCostForServices(List<int> selectedServiceValueIds, int days)
        {
            // Seçilen hizmet değerlerine göre maliyet hesaplama
            var selectedServices = GetAll()
                .Where(psv => selectedServiceValueIds.Contains(psv.ServiceValueId))
                .Select(psv => psv.ServiceValue.Cost)
                .ToList();

            // Seçilen gün sayısı ile çarpıp toplamı döndür
            return selectedServices.Sum() * days;
        }



    }
}
