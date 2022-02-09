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
    public class InsuredPersonRelationshipManager : IInsuredPersonRelationshipService<InsuredPersonRelationship, InsuredPersonRelationshipDto>
    {
        protected readonly IInsuredPersonRelationshipDal _insuredPersonRelationshipDal;

        public InsuredPersonRelationshipManager(IInsuredPersonRelationshipDal insuredPersonRelationshipDal)
        {
            _insuredPersonRelationshipDal = insuredPersonRelationshipDal;
        }

        public IResult Add(InsuredPersonRelationshipDto item)
        {
            _insuredPersonRelationshipDal.Add(MapperTool.Mapper.Map<InsuredPersonRelationshipDto, InsuredPersonRelationship>(item));

            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(InsuredPersonRelationshipDto item)
        {
            _insuredPersonRelationshipDal.Delete(MapperTool.Mapper.Map<InsuredPersonRelationshipDto, InsuredPersonRelationship>(item));

            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<InsuredPersonRelationshipDto> Find(int itemId)
        {
            var result = MapperTool.Mapper.Map<InsuredPersonRelationship, InsuredPersonRelationshipDto>(_insuredPersonRelationshipDal.Find(itemId));

            return new SuccessDataResult<InsuredPersonRelationshipDto>(result, Messages.ItemListed);
        }

        public IDataResult<List<InsuredPersonRelationshipDto>> GetAll()
        {
            var resultList = MapperTool.Mapper.Map<List<InsuredPersonRelationship>, List<InsuredPersonRelationshipDto>>(_insuredPersonRelationshipDal.GetAll());

            return new SuccessDataResult<List<InsuredPersonRelationshipDto>>(resultList, Messages.ItemListed);
        }

        public IResult Update(InsuredPersonRelationshipDto item)
        {
            _insuredPersonRelationshipDal.Update(MapperTool.Mapper.Map<InsuredPersonRelationshipDto, InsuredPersonRelationship>(item));

            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
