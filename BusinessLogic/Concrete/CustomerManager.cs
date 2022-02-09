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
    public class CustomerManager :  ICustomerService<Customer,CustomerDto>
    {
        protected readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(CustomerDto item)
        {
            _customerDal.Add(MapperTool.Mapper.Map<CustomerDto, Customer>(item));

            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(CustomerDto item)
        {
            _customerDal.Delete(MapperTool.Mapper.Map<CustomerDto, Customer>(item));

            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<CustomerDto> Find(int itemId)
        {
            var result = MapperTool.Mapper.Map<Customer, CustomerDto>(_customerDal.Find(itemId));

            return new SuccessDataResult<CustomerDto>(result, Messages.ItemListed);
        }

        public IDataResult<List<CustomerDto>> GetAll()
        {
            var resultList = MapperTool.Mapper.Map<List<Customer>, List<CustomerDto>>(_customerDal.GetAll());

            return new SuccessDataResult<List<CustomerDto>>(resultList, Messages.ItemListed);
        }

        public IResult Update(CustomerDto item)
        {
            _customerDal.Update(MapperTool.Mapper.Map<CustomerDto, Customer>(item));

            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
