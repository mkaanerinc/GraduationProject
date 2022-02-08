using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    // OrderDto class'ı veritabanındaki Orders tablosunun Data Transfer Object'tidir.
    public class OrderDto : IDto
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
