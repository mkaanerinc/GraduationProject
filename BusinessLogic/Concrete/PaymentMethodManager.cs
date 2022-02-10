using BusinessLogic.Abstract;
using BusinessLogic.Constants;
using BusinessLogic.MappingRules.AutoMapper;
using BusinessLogic.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Business;
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
        #region Methods

        public IResult Add(PaymentMethodDto item)
        {
            try
            {
                ValidationTool.Validate(new PaymentMethodValidator(), item);

                IResult result = BusinessRules.Run(
                    CheckIfPaymentMethodNameExists(item.PaymentMethodName)
                    );

                if(result is not null)
                {
                    return result;
                }

                _paymentMethodDal.Add(MapperTool.Mapper.Map<PaymentMethodDto, PaymentMethod>(item));

                return new SuccessResult(Messages.ItemAdded);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
            
        }

        public IResult Delete(PaymentMethodDto item)
        {
            try
            {
                _paymentMethodDal.Delete(MapperTool.Mapper.Map<PaymentMethodDto, PaymentMethod>(item));

                return new SuccessResult(Messages.ItemDeleted);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }

        }

        public IDataResult<PaymentMethodDto> Find(int itemId)
        {
            try
            {
                var result = MapperTool.Mapper.Map<PaymentMethod, PaymentMethodDto>(_paymentMethodDal.Find(itemId));

                if (result is null)
                {
                    return new ErrorDataResult<PaymentMethodDto>(Messages.NotFound);
                }

                return new SuccessDataResult<PaymentMethodDto>(result, Messages.ItemListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<PaymentMethodDto>(ex.Message);
            }

        }

        public IDataResult<List<PaymentMethodDto>> GetAll()
        {
            try
            {
                var resultList = MapperTool.Mapper.Map<List<PaymentMethod>, List<PaymentMethodDto>>(_paymentMethodDal.GetAll());

                if (resultList is null)
                {
                    return new ErrorDataResult<List<PaymentMethodDto>>(Messages.NotFound);
                }

                return new SuccessDataResult<List<PaymentMethodDto>>(resultList, Messages.ItemListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<PaymentMethodDto>>(ex.Message);
            }

        }

        public IResult Update(PaymentMethodDto item)
        {
            try
            {
                ValidationTool.Validate(new PaymentMethodValidator(), item);

                IResult result = BusinessRules.Run(
                    CheckIfPaymentMethodNameExists(item.PaymentMethodName)
                    );

                if(result is not null)
                {
                    return result;
                }

                _paymentMethodDal.Update(MapperTool.Mapper.Map<PaymentMethodDto, PaymentMethod>(item));

                return new SuccessResult(Messages.ItemUpdated);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
            
        }

        #endregion

        #region Business Rules

        private IResult CheckIfPaymentMethodNameExists(string paymentMethodName)
        {
            bool result = _paymentMethodDal.GetAll(p => p.PaymentMethodName == paymentMethodName).Any();

            if(result)
            {
                return new ErrorResult(Messages.NameIsExists);
            }

            return new SuccessResult();
        }

        #endregion
    }
}
