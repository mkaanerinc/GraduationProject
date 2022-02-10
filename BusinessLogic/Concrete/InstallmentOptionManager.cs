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
    public class InstallmentOptionManager : IInstallmentOptionService<InstallmentOption, InstallmentOptionDto>
    {
        protected readonly IInstallmentOptionDal _installmentOptionDal;

        public InstallmentOptionManager(IInstallmentOptionDal installmentOptionDal)
        {
            _installmentOptionDal = installmentOptionDal;
        }

        public IResult Add(InstallmentOptionDto item)
        {
            _installmentOptionDal.Add(MapperTool.Mapper.Map<InstallmentOptionDto, InstallmentOption>(item));

            return new SuccessResult(Messages.ItemAdded);
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

                if(result is null)
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

                if(resultList is null)
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
            _installmentOptionDal.Update(MapperTool.Mapper.Map<InstallmentOptionDto, InstallmentOption>(item));

            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
