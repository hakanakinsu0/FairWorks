using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class CustomerDetail : BaseEntity
    {
        //Müşteri Bilgileri
        public string FirstName { get; set; }             // Müşterinin adı
        public string LastName { get; set; }              // Müşterinin soyadı
        public string CompanyName { get; set; }           // Müşterinin bağlı olduğu şirket adı
        public string ContactPhoneNumber { get; set; }    // İletişim için telefon numarası

        //Relational Properties
        public virtual Customer Customer { get; set; }    //Yön: // 1 CustomerDetail 1 Customer, 1 Customer 1 CustomerDetail

    }
}
