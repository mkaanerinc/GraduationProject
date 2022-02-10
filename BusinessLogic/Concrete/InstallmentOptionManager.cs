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
    public class InstallmentOptionManager : IInstallmentOptionService<InstallmentOption, InstallmentOptionDto>
    {
        protected readonly IInstallmentOptionDal _installmentOptionDal;

        public InstallmentOptionManager(IInstallmentOptionDal installmentOptionDal)
        {
            _installmentOptionDal = installmentOptionDal;
        }

        #region Methods

        public IResult Add(InstallmentOptionDto item)
        {
            try
            {
                ValidationTool.Validate(new InstallmentOptionValidator(), item);

                IResult result = BusinessRules.Run(
                    CheckIfInstallmentOptionNameExists(item.InstallmentOptionName)
                    );

                if(result is not null)
                {
                    return result;
                }

                _installmentOptionDal.Add(MapperTool.Mapper.Map<InstallmentOptionDto, InstallmentOption>(item));

                return new SuccessResult(Messages.ItemAdded);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
            
        }

        public IResult Delete(InstallmentOptionDto item)
        {
            try
            {
                _installmentOptionDal.Delete(MapperTool.Mapper.Map<InstallmentOptionDto, InstallmentOption>(item));

                return new SuccessResult(Messages.ItemDeleted);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }

        }

        public IDataResult<InstallmentOptionDto> Find(int itemId)
        {
            try
            {
                var result = MapperTool.Mapper.Map<InstallmentOption, InstallmentOptionDto>(_installmentOptionDal.Find(itemId));

                if (result is null)
                {
                    return new ErrorDataResult<InstallmentOptionDto>(Messages.NotFound);
                }

                return new SuccessDataResult<InstallmentOptionDto>(result, Messages.ItemListed);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<InstallmentOptionDto>(ex.Message);

            }

        }

        public IDataResult<List<InstallmentOptionDto>> GetAll()
        {
            try
            {
                var resultList = MapperTool.Mapper.Map<List<InstallmentOption>, List<InstallmentOptionDto>>(_installmentOptionDal.GetAll());

                if (resultList is null)
                {
                    return new ErrorDataResult<List<InstallmentOptionDto>>(Messages.NotFound);
                }

                return new SuccessDataResult<List<InstallmentOptionDto>>(resultList, Messages.ItemListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<InstallmentOptionDto>>(ex.Message);
            }

        }

        public IResult Update(InstallmentOptionDto item)
        {
            try
            {
                ValidationTool.Validate(new InstallmentOptionValidator(), item);

                IResult result = BusinessRules.Run(
                    CheckIfInstallmentOptionNameExists(item.InstallmentOptionName)
                    );

                if(result is not null)
                {
                    return result;
                }

                _installmentOptionDal.Update(MapperTool.Mapper.Map<InstallmentOptionDto, InstallmentOption>(item));

                return new SuccessResult(Messages.ItemUpdated);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
            
        }

        #endregion

        #region BusinessRules

        private IResult CheckIfInstallmentOptionNameExists(string installmentOptionName)
        {
            bool result = _installmentOptionDal.GetAll(i => i.InstallmentOptionName == installmentOptionName).Any();

            if(result)
            {
                return new ErrorResult(Messages.NameIsExists);
            }

            return new SuccessResult();
        }

        #endregion
    }
}
