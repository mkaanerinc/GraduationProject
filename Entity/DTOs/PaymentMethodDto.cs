using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    // PaymentMethodDto class'ı veritabanındaki PaymentMethods tablosunun Data Transfer Object'tidir.
    public class PaymentMethodDto : IDto
    {
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
    }
}
