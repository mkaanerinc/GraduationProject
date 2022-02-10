using BusinessLogic.Abstract;
using BusinessLogic.Constants;
using BusinessLogic.MappingRules.AutoMapper;
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
    public class CustomerManager :  ICustomerService<Customer,CustomerDto>
    {
        protected readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        #region Methods

        public IResult Add(CustomerDto item)
        {
            try
            {
                IResult result = BusinessRules.Run(
                    CheckIfCustomerIdentityNoExists(item.CustomerIdentityNo),
                    CheckIfCustomerEmailExists(item.CustomerEmail),
                    CheckIfCustomerGSMExists(item.CustomerGSM)
                    );

                if(result is not null)
                {
                    return result;
                }

                _customerDal.Add(MapperTool.Mapper.Map<CustomerDto, Customer>(item));

                return new SuccessResult(Messages.ItemAdded);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }

            
        }

        public IResult Delete(CustomerDto item)
        {
            try
            {
                _customerDal.Delete(MapperTool.Mapper.Map<CustomerDto, Customer>(item));

                return new SuccessResult(Messages.ItemDeleted);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }

        }

        public IDataResult<CustomerDto> Find(int itemId)
        {
            try
            {
                var result = MapperTool.Mapper.Map<Customer, CustomerDto>(_customerDal.Find(itemId));

                if (result is null)
                {
                    return new ErrorDataResult<CustomerDto>(Messages.NotFound);
                }

                return new SuccessDataResult<CustomerDto>(result, Messages.ItemListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<CustomerDto>(ex.Message);
            }

        }

        public IDataResult<List<CustomerDto>> GetAll()
        {
            try
            {
                var resultList = MapperTool.Mapper.Map<List<Customer>, List<CustomerDto>>(_customerDal.GetAll());

                if (resultList is null)
                {
                    return new ErrorDataResult<List<CustomerDto>>(Messages.NotFound);
                }

                return new SuccessDataResult<List<CustomerDto>>(resultList, Messages.ItemListed);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<CustomerDto>>(ex.Message);

            }

        }

        public IResult Update(CustomerDto item)
        {
            try
            {
                IResult result = BusinessRules.Run(
                    CheckIfCustomerIdentityNoExists(item.CustomerIdentityNo),
                    CheckIfCustomerEmailExists(item.CustomerEmail),
                    CheckIfCustomerGSMExists(item.CustomerGSM)
                    );

                if(result is not null)
                {
                    return result;
                }

                _customerDal.Update(MapperTool.Mapper.Map<CustomerDto, Customer>(item));

                return new SuccessResult(Messages.ItemUpdated);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
            
        }

        #endregion

        #region BusinessRules

        private IResult CheckIfCustomerIdentityNoExists(string customerIdentityNo)
        {
            bool result = _customerDal.GetAll(c => c.CustomerIdentityNo == customerIdentityNo).Any();

            if(result)
            {
                return new ErrorResult(Messages.InfoIsExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCustomerEmailExists(string customerEmail)
        {
            bool result = _customerDal.GetAll(c => c.CustomerEmail == customerEmail).Any();

            if (result)
            {
                return new ErrorResult(Messages.InfoIsExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCustomerGSMExists(string customerGSM)
        {
            bool result = _customerDal.GetAll(c => c.CustomerGSM == customerGSM).Any();

            if (result)
            {
                return new ErrorResult(Messages.InfoIsExists);
            }

            return new SuccessResult();
        }

        #endregion
    }
}
