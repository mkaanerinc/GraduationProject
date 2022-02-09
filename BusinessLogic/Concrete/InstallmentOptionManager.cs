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
            _installmentOptionDal.Delete(MapperTool.Mapper.Map<InstallmentOptionDto, InstallmentOption>(item));

            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<InstallmentOptionDto> Find(int itemId)
        {
            var result = MapperTool.Mapper.Map<InstallmentOption, InstallmentOptionDto>(_installmentOptionDal.Find(itemId));

            return new SuccessDataResult<InstallmentOptionDto>(result, Messages.ItemListed);
        }

        public IDataResult<List<InstallmentOptionDto>> GetAll()
        {
            var resultList = MapperTool.Mapper.Map<List<InstallmentOption>, List<InstallmentOptionDto>>(_installmentOptionDal.GetAll());

            return new SuccessDataResult<List<InstallmentOptionDto>>(resultList, Messages.ItemListed);
        }

        public IResult Update(InstallmentOptionDto item)
        {
            _installmentOptionDal.Update(MapperTool.Mapper.Map<InstallmentOptionDto, InstallmentOption>(item));

            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
