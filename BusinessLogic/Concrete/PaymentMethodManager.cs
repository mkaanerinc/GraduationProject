using BusinessLogic.Abstract;
using BusinessLogic.Constants;
using BusinessLogic.MappingRules.AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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
    public class PaymentMethodManager : IPaymentMethodService<PaymentMethod, PaymentMethodDto>
    {
        protected readonly IPaymentMethodDal _paymentMethodDal;

        public PaymentMethodManager(IPaymentMethodDal paymentMethodDal)
        {
            _paymentMethodDal = paymentMethodDal;
        }

        public IResult Add(PaymentMethodDto item)
        {
            _paymentMethodDal.Add(MapperTool.Mapper.Map<PaymentMethodDto, PaymentMethod>(item));

            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(PaymentMethodDto item)
        {
            _paymentMethodDal.Delete(MapperTool.Mapper.Map<PaymentMethodDto, PaymentMethod>(item));

            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<PaymentMethodDto> Find(int itemId)
        {
            var result = MapperTool.Mapper.Map<PaymentMethod, PaymentMethodDto>(_paymentMethodDal.Find(itemId));

            return new SuccessDataResult<PaymentMethodDto>(result, Messages.ItemListed);
        }

        public IDataResult<List<PaymentMethodDto>> GetAll()
        {
            var resultList = MapperTool.Mapper.Map<List<PaymentMethod>, List<PaymentMethodDto>>(_paymentMethodDal.GetAll());

            return new SuccessDataResult<List<PaymentMethodDto>>(resultList, Messages.ItemListed);
        }

        public IResult Update(PaymentMethodDto item)
        {
            _paymentMethodDal.Update(MapperTool.Mapper.Map<PaymentMethodDto, PaymentMethod>(item));

            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
