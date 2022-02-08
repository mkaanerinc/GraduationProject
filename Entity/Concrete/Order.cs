using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    // Order class'ı veritabanındaki Orders tablosunun referansıdır.
    // Burada Orders tablosu Customers, PaymentMethods, InstallmentOptions, Products
    // tabloları ile Many to One ilişkidedir.

    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int InstallmentOptionId { get; set; }
        public int PaymentMethodId { get; set; }
        public int ProductId { get; set; }
        public decimal OrderPrice { get; set; }
        public bool OrderStatus { get; set; }
    }
}
