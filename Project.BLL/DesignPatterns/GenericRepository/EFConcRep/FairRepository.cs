using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            Save();
            return fair; // Eklenen fuar zaten parametre olarak gelen nesnedir.
        }

        public decimal CalculateFinalOffer(decimal totalCost, decimal customerOffer)
        {
            decimal discountedPrice = totalCost * 0.9m;
            return discountedPrice >= customerOffer
                ? discountedPrice
                : (discountedPrice + customerOffer) / 2;
        }

        public List<string> GetFormattedFairList()
        {
            return Where(f => f.Status != DataStatus.Deleted)
                   .Select(f => $"Fuar ID: {f.Id} - Adı: {f.Name} - Başlangıç Tarihi: {f.RequestedStartDate:dd/MM/yyyy} - Bitiş Tarihi: {f.EndDate:dd/MM/yyyy} - Maliyet: {f.TotalCost:C2}")
                   .ToList();
        }

        public List<string> GetFormattedFairPayments()
        {
            var paymentRepo = new PaymentRepository();
            return GetAll().Select(fair =>
            {
                var payment = paymentRepo.FirstOrDefault(p => p.FairId == fair.Id);
                string paymentStatus = payment?.PaymentStatus.ToString() ?? "Ödenmemiş";
                string paymentMethod = payment?.PaymentMethod.ToString() ?? "Belirtilmemiş";
                return $"Fuar Adı: {fair.Name} - Ödeme Durumu: {paymentStatus} - Ödeme Şekli: {paymentMethod}";
            }).ToList();
        }

       
    }
}
