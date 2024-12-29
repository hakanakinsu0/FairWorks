using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFConcRep
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        CustomerDetailRepository _customerDetailRepository;

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

        public void RegisterCustomer(Customer customer, CustomerDetail customerDetail)
        {
            Add(customer); // CustomerRepository'deki Add çağrılır
            customerDetail.Id = customer.Id; // Customer'ın ID'sini kullan
            _customerDetailRepository.Add(customerDetail);
        }

    }
}
