using BusinessLogic.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class PaymentMethodManager : GenericService<PaymentMethod, PaymentMethodDto>, IPaymentMethodService
    {
        protected readonly IPaymentMethodDal _paymentMethodDal;

        public PaymentMethodManager(IPaymentMethodDal paymentMethodDal) : base(paymentMethodDal)
        {
            _paymentMethodDal = paymentMethodDal;
        }
    }
}
