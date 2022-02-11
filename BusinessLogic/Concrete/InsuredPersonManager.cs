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
    public class InsuredPersonManager : IInsuredPersonService<InsuredPerson, InsuredPersonDto>
    {
        protected readonly IInsuredPersonDal _insuredPersonDal;
        protected readonly ICustomerService<Customer, CustomerDto> _customerService;

        public InsuredPersonManager(IInsuredPersonDal insuredPersonDal, ICustomerService<Customer, CustomerDto> customerService)
        {
            _insuredPersonDal = insuredPersonDal;
            _customerService = customerService;
        }

        #region Methods

        public IResult Add(InsuredPersonDto item)
        {
            try
            {
                ValidationTool.Validate(new InsuredPersonValidator(), item);

                IResult result = BusinessRules.Run(
                    CheckIfInsuredPersonIdentityNoExists(item.InsuredPersonIdentityNo),
                    CheckIfInsuredPersonEmailExists(item.InsuredPersonEmail),
                    CheckIfInsuredPersonGSMExists(item.InsuredPersonGSM),
                    CheckIfInsuredPersonGenderValid(item.InsuredPersonGender,item.CustomerId,item.InsuredPersonRelationshipId)
                    );

                if(result is not null)
                {
                    return result;
                }

                _insuredPersonDal.Add(MapperTool.Mapper.Map<InsuredPersonDto, InsuredPerson>(item));

                return new SuccessResult(Messages.ItemAdded);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
            
        }

        public IResult Delete(InsuredPersonDto item)
        {
            try
            {
                _insuredPersonDal.Delete(MapperTool.Mapper.Map<InsuredPersonDto, InsuredPerson>(item));

                return new SuccessResult(Messages.ItemDeleted);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }

        }

        public IDataResult<InsuredPersonDto> Find(int itemId)
        {
            try
            {
                var result = MapperTool.Mapper.Map<InsuredPerson, InsuredPersonDto>(_insuredPersonDal.Find(itemId));

                if (result is null)
                {
                    return new ErrorDataResult<InsuredPersonDto>(Messages.NotFound);
                }

                return new SuccessDataResult<InsuredPersonDto>(result, Messages.ItemListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<InsuredPersonDto>(ex.Message);
            }

        }

        public IDataResult<List<InsuredPersonDto>> GetAll()
        {
            try
            {
                var resultList = MapperTool.Mapper.Map<List<InsuredPerson>, List<InsuredPersonDto>>(_insuredPersonDal.GetAll());

                if (resultList is null)
                {
                    return new ErrorDataResult<List<InsuredPersonDto>>(Messages.NotFound);
                }

                return new SuccessDataResult<List<InsuredPersonDto>>(resultList, Messages.ItemListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<InsuredPersonDto>>(ex.Message);
            }

        }

        public IDataResult<List<InsuredPersonDetailDto>> GetInsuredPersonDetails()
        {
            try
            {
                var resultList = _insuredPersonDal.GetInsuredPersonDetails();

                if(resultList is null)
                {
                    return new ErrorDataResult<List<InsuredPersonDetailDto>>(Messages.NotFound);
                }

                return new SuccessDataResult<List<InsuredPersonDetailDto>>(resultList, Messages.ItemListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<InsuredPersonDetailDto>>(ex.Message);
            }
            
        }

        public IResult Update(InsuredPersonDto item)
        {
            try
            {
                ValidationTool.Validate(new InsuredPersonValidator(), item);

                IResult result = BusinessRules.Run(
                    CheckIfInsuredPersonIdentityNoExists(item.InsuredPersonIdentityNo),
                    CheckIfInsuredPersonEmailExists(item.InsuredPersonEmail),
                    CheckIfInsuredPersonGSMExists(item.InsuredPersonGSM),
                    CheckIfInsuredPersonGenderValid(item.InsuredPersonGender, item.CustomerId, item.InsuredPersonRelationshipId)
                    );

                if (result is not null)
                {
                    return result;
                }

                _insuredPersonDal.Update(MapperTool.Mapper.Map<InsuredPersonDto, InsuredPerson>(item));

                return new SuccessResult(Messages.ItemUpdated);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
            
        }

        #endregion

        #region BusinessRules

        private IResult CheckIfInsuredPersonIdentityNoExists(string insuredPersonIdentityNo)
        {
            bool result = _insuredPersonDal.GetAll(c => c.InsuredPersonIdentityNo == insuredPersonIdentityNo).Any();

            if (result)
            {
                return new ErrorResult(Messages.InfoIsExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfInsuredPersonEmailExists(string insuredPersonEmail)
        {
            bool result = _insuredPersonDal.GetAll(c => c.InsuredPersonEmail == insuredPersonEmail).Any();

            if (result)
            {
                return new ErrorResult(Messages.InfoIsExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfInsuredPersonGSMExists(string insuredPersonGSM)
        {
            bool result = _insuredPersonDal.GetAll(c => c.InsuredPersonGSM == insuredPersonGSM).Any();

            if (result)
            {
                return new ErrorResult(Messages.InfoIsExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfInsuredPersonGenderValid(bool insuredPersonGender, int insuredPersonCustomerId, int insuredPersonRelationshipId)
        {
            var customer = _customerService.Find(insuredPersonCustomerId);

            var customerGender = customer.Data.CustomerGender;

            if (insuredPersonRelationshipId == 2) // Eşi ise cinsiyetleri farklı olmalıdır.
            {        

                if (customerGender == insuredPersonGender)
                {
                    return new ErrorResult(Messages.GenderInvalid);
                }
                

            } else if (insuredPersonRelationshipId == 1) // Kendisi ise cinsiyetleri aynı olmalıdır.
            {

                if (customerGender != insuredPersonGender)
                {
                    return new ErrorResult(Messages.GenderInvalid);
                }

            }

            return new SuccessResult();

        }      

        #endregion
    }
}
