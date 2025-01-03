using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFConcRep
{
    public class FairRepository : BaseRepository<Fair>
    {
        public List<Fair> GetFairsByCustomer(int customerId)
        {
            return Where(f => f.CustomerId == customerId && f.Status != DataStatus.Deleted);
        }

        public List<Fair> GetDelayedFairsByCustomer(int customerId)
        {
            return Where(f => f.CustomerId == customerId && f.IsDelayed == true);
        }
    }
}
