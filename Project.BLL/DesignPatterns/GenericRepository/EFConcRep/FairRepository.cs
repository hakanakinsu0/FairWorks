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
        // Giriş yapan müşteriye ait tüm aktif fuarları getir
        public List<Fair> GetFairsByCustomer(int customerId)
        {
            return Where(f => f.CustomerId == customerId && f.Status != DataStatus.Deleted);
        }

        // Giriş yapan müşteriye ait gecikmiş fuarları getir
        public List<Fair> GetDelayedFairsByCustomer(int customerId)
        {
            return Where(f => f.CustomerId == customerId && f.IsDelayed == true);
        }

        public Fair AddFair(Fair fair)
        {
            Add(fair);
            Save(); // Kaydı veritabanına işle
            return FirstOrDefault(f => f.Id == fair.Id); // Eklenen fuarı geri döndür
        }

        public decimal CalculateFinalOffer(decimal totalCost, decimal customerOffer)
        {
            decimal discountedPrice = totalCost * 0.9m;
            return discountedPrice >= customerOffer
                ? discountedPrice
                : (discountedPrice + customerOffer) / 2;
        }
    }
}
