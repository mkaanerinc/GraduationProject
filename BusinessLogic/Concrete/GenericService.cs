using BusinessLogic.Abstract;
using BusinessLogic.Constants;
using BusinessLogic.MappingRules.AutoMapper;
using Core.DataAccess;
using Core.Entity.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    // IDto ile işlem yapıldığı için static olarak oluşturduğumuz MapperTool'u
    // mapleme işleminde kullandık.

    public class GenericService<TEntity,TDto> : IGenericService<TEntity, TDto>
        where TEntity : class, IEntity, new()
        where TDto : class, IDto, new()
    {

        protected readonly IEntityRepository<TEntity> _entityRepository;

        public GenericService(IEntityRepository<TEntity> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public IResult Add(TDto item)
        {
            _entityRepository.Add(MapperTool.Mapper.Map<TDto,TEntity>(item));

            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(TDto item)
        {
            _entityRepository.Delete(MapperTool.Mapper.Map<TDto, TEntity>(item));

            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<TDto> Find(int itemId)
        {
            var result = MapperTool.Mapper.Map <TEntity, TDto> (_entityRepository.Find(itemId));

            return new SuccessDataResult<TDto>(result, Messages.ItemListed);
        }

        public IDataResult<List<TDto>> GetAll()
        {
            var resultList = MapperTool.Mapper.Map<List<TEntity>,List<TDto>>(_entityRepository.GetAll());

            return new SuccessDataResult<List<TDto>>(resultList, Messages.ItemListed);
        }

        public IResult Update(TDto item)
        {
            _entityRepository.Update(MapperTool.Mapper.Map<TDto, TEntity>(item));

            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
