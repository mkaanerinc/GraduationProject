using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IPaymentMethodService<PaymentMethod, PaymentMethodDto>
    {
        IDataResult<List<PaymentMethodDto>> GetAll();
        IDataResult<PaymentMethodDto> Find(int paymentMethodId);
        IResult Add(PaymentMethodDto paymentMethod);
        IResult Delete(PaymentMethodDto paymentMethod);
        IResult Update(PaymentMethodDto paymentMethod);
    }
}
