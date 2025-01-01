using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Options
{
    public class ServiceProviderServiceValueConfiguration : BaseConfiguration<ServiceProviderServiceValue>
    {
        public ServiceProviderServiceValueConfiguration()
        {
            Ignore(x => x.Id);

            HasKey(x => new
            {
                x.ServiceProviderId,
                x.ServiceValueId
            });
        }
    }
}
