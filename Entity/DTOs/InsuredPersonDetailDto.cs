using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    // Frontend uygulama 2 tablo listeleme için yapılan Dto class'ı.
    // DataAccess katmanında 3'lü join yapılacak.
    public class InsuredPersonDetailDto : IDto
    {
        public int InsuredPersonId { get; set; }
        public string InsuredPersonFirstName { get; set; }
        public string InsuredPersonLastName { get; set; }
        public string ProductName { get; set; }
        public string InstallmentOptionName { get; set; }
        public decimal OrderPrice { get; set; }
        public bool OrderStatus { get; set; }
    }
}
