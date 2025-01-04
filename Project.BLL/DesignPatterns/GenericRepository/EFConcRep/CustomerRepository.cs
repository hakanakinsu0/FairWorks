using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Models;
using Sifrelemeler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFConcRep
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository()
        {
        }

        public bool IsValidEmailFormat(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        public bool IsValidPassword(string password)
        {
            return password.Length >= 8;
        }

        public bool IsEmailRegistered(string email)
        {
            return Any(x => x.ContactEMail == email);
        }

        public Customer GetByEmailAndPassword(string email, string password)
        {
            return FirstOrDefault(x => x.ContactEMail == email && x.Password == password);
        }

        public Customer GetByEmail(string email)
        {
            return FirstOrDefault(x => x.ContactEMail == email);
        }

        public void UpdatePassword(string email, string newPassword)
        {
            var customer = GetByEmail(email);
            if (customer == null)
                throw new Exception("Müşteri bulunamadı.");

            customer.Password = PasswordEncryptor.Encode(newPassword);
            Update(customer);
        }


    }
}
