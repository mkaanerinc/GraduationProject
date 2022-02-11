using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // Angular 2. proje tablo listeleme için 3'lü join işlemi yapıldı.
    // using kullanıldı GraduationProjectContext DbContext'den türetildi
    // ve DbContext IDisposable'dan bu sayede using kullandık.
    // using blouğundan çıktığında dispose edilecek.

    public class EFInsuredPersonDal : EFEntityRepository<InsuredPerson, GraduationProjectContext>, IInsuredPersonDal
    {
        public List<InsuredPersonDetailDto> GetInsuredPersonDetails()
        {
            using (GraduationProjectContext context = new GraduationProjectContext())
            {
                var result = from insuredPerson in context.InsuredPersons
                             join order in context.Orders
                             on insuredPerson.CustomerId equals order.CustomerId
                             join product in context.Products
                             on order.ProductId equals product.ProductId
                             join installmentOption in context.InstallmentOptions
                             on order.InstallmentOptionId equals installmentOption.InstallmentOptionId
                             select new InsuredPersonDetailDto
                             {
                                 InsuredPersonId = insuredPerson.InsuredPersonId,
                                 InsuredPersonFirstName = insuredPerson.InsuredPersonFirstName,
                                 InsuredPersonLastName = insuredPerson.InsuredPersonLastName,
                                 ProductName = product.ProductName,
                                 InstallmentOptionName = installmentOption.InstallmentOptionName,
                                 OrderPrice = order.OrderPrice,
                                 OrderStatus = order.OrderStatus
                             };

                return result.ToList();
            }
        }
    }
}
