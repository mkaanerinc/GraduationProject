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
    public class InsuredPersonManager : IInsuredPersonService<InsuredPerson, InsuredPersonDto>
    {
        protected readonly IInsuredPersonDal _insuredPersonDal;

        public InsuredPersonManager(IInsuredPersonDal insuredPersonDal)
        {
            _insuredPersonDal = insuredPersonDal;
        }

        public IResult Add(InsuredPersonDto item)
        {
            _insuredPersonDal.Add(MapperTool.Mapper.Map<InsuredPersonDto, InsuredPerson>(item));

            return new SuccessResult(Messages.ItemAdded);
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

                if(result is null)
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

                if(resultList is null)
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

        public IResult Update(InsuredPersonDto item)
        {
            _insuredPersonDal.Update(MapperTool.Mapper.Map<InsuredPersonDto, InsuredPerson>(item));

            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
