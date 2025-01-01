using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class ServiceProviderServiceValue : BaseEntity
    {
        public int ServiceProviderId { get; set; }
        public int ServiceValueId { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
        public virtual ServiceValue ServiceValue { get; set; }
    }
}
