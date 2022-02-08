using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    // PaymentMethod class'ı veritabanındaki PaymentMethods tablosunun referansıdır.
   public class PaymentMethod : IEntity
    {
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
    }
}
