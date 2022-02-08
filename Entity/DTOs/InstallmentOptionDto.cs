using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    // InstallmentOptionDto class'ı veritabanındaki InstallmentOptions tablosunun Data Transfer Object'tidir.
    public class InstallmentOptionDto : IDto
    {
        public int InstallmentOptionId { get; set; }
        public string InstallmentOptionName { get; set; }
    }
}
