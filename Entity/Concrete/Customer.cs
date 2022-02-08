using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    // Customer class'ı veritabanındaki Customers tablosunun referansıdır.
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerIdentityNo { get; set; }
        public bool CustomerGender { get; set; }
        public DateTime CustomerBirthdate { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerGSM { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerAddress { get; set; }
    }
}
