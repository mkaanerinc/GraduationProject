using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    // InstallmentOption (taksit seçenekleri) class'ı veritabanındaki InstallmentOptions tablosunun referansıdır.
    public class InstallmentOption : IEntity
    {
        public int InstallmentOptionId { get; set; }
        public string InstallmentOptionName { get; set; }
    }
}
