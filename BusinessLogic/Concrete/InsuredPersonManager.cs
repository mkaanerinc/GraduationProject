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
            _insuredPersonDal.Delete(MapperTool.Mapper.Map<InsuredPersonDto, InsuredPerson>(item));

            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<InsuredPersonDto> Find(int itemId)
        {
            var result = MapperTool.Mapper.Map<InsuredPerson, InsuredPersonDto>(_insuredPersonDal.Find(itemId));

            return new SuccessDataResult<InsuredPersonDto>(result, Messages.ItemListed);
        }

        public IDataResult<List<InsuredPersonDto>> GetAll()
        {
            var resultList = MapperTool.Mapper.Map<List<InsuredPerson>, List<InsuredPersonDto>>(_insuredPersonDal.GetAll());

            return new SuccessDataResult<List<InsuredPersonDto>>(resultList, Messages.ItemListed);
        }

        public IResult Update(InsuredPersonDto item)
        {
            _insuredPersonDal.Update(MapperTool.Mapper.Map<InsuredPersonDto, InsuredPerson>(item));

            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
