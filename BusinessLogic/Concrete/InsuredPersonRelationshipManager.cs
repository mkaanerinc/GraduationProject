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
    public class InsuredPersonRelationshipManager : IInsuredPersonRelationshipService<InsuredPersonRelationship, InsuredPersonRelationshipDto>
    {
        protected readonly IInsuredPersonRelationshipDal _insuredPersonRelationshipDal;

        public InsuredPersonRelationshipManager(IInsuredPersonRelationshipDal insuredPersonRelationshipDal)
        {
            _insuredPersonRelationshipDal = insuredPersonRelationshipDal;
        }

        #region Methods

        public IResult Add(InsuredPersonRelationshipDto item)
        {
            try
            {
                IResult result = BusinessRules.Run(
                    CheckIfInsuredPersonRelationshipExists(item.InsuredPersonRelationshipName)
                    );

                if(result is not null)
                {
                    return result;
                }

                _insuredPersonRelationshipDal.Add(MapperTool.Mapper.Map<InsuredPersonRelationshipDto, InsuredPersonRelationship>(item));

                return new SuccessResult(Messages.ItemAdded);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
            
        }

        public IResult Delete(InsuredPersonRelationshipDto item)
        {
            try
            {
                _insuredPersonRelationshipDal.Delete(MapperTool.Mapper.Map<InsuredPersonRelationshipDto, InsuredPersonRelationship>(item));

                return new SuccessResult(Messages.ItemDeleted);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }

        }

        public IDataResult<InsuredPersonRelationshipDto> Find(int itemId)
        {
            try
            {
                var result = MapperTool.Mapper.Map<InsuredPersonRelationship, InsuredPersonRelationshipDto>(_insuredPersonRelationshipDal.Find(itemId));

                if (result is null)
                {
                    return new ErrorDataResult<InsuredPersonRelationshipDto>(Messages.NotFound);
                }

                return new SuccessDataResult<InsuredPersonRelationshipDto>(result, Messages.ItemListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<InsuredPersonRelationshipDto>(ex.Message);
            }

        }

        public IDataResult<List<InsuredPersonRelationshipDto>> GetAll()
        {
            try
            {
                var resultList = MapperTool.Mapper.Map<List<InsuredPersonRelationship>, List<InsuredPersonRelationshipDto>>(_insuredPersonRelationshipDal.GetAll());

                if (resultList is null)
                {
                    return new ErrorDataResult<List<InsuredPersonRelationshipDto>>(Messages.NotFound);
                }

                return new SuccessDataResult<List<InsuredPersonRelationshipDto>>(resultList, Messages.ItemListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<InsuredPersonRelationshipDto>>(ex.Message);
            }

        }

        public IResult Update(InsuredPersonRelationshipDto item)
        {
            try
            {
                IResult result = BusinessRules.Run(
                    CheckIfInsuredPersonRelationshipExists(item.InsuredPersonRelationshipName)
                    );

                if(result is not null)
                {
                    return result;
                }

                _insuredPersonRelationshipDal.Update(MapperTool.Mapper.Map<InsuredPersonRelationshipDto, InsuredPersonRelationship>(item));

                return new SuccessResult(Messages.ItemUpdated);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
            
        }

        #endregion

        #region Business Rules

        private IResult CheckIfInsuredPersonRelationshipExists(string insuredPersonRelationshipName)
        {
            bool result = _insuredPersonRelationshipDal.GetAll(i => i.InsuredPersonRelationshipName == insuredPersonRelationshipName).Any();

            if(result)
            {
                return new ErrorResult(Messages.NameIsExists);
            }

            return new SuccessResult();
        }

        #endregion
    }
}
