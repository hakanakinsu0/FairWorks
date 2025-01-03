using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFConcRep
{
    public class PaymentRepository:BaseRepository<Payment>
    {
        public Payment AddPayment(Payment payment)
        {
            Add(payment);
            Save();
            return payment;
        }

        public bool ProcessPayment(Payment payment, out string errorMessage)
        {
            try
            {
                Add(payment);
                Save();
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"Hata: {ex.Message}";
                return false;
            }
        }
    }
}
