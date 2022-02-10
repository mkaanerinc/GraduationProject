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
    public class ProductManager : IProductService<Product, ProductDto>
    {
        protected readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(ProductDto item)
        {
            _productDal.Add(MapperTool.Mapper.Map<ProductDto, Product>(item));

            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(ProductDto item)
        {
            try
            {
                _productDal.Delete(MapperTool.Mapper.Map<ProductDto, Product>(item));

                return new SuccessResult(Messages.ItemDeleted);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
            
        }

        public IDataResult<ProductDto> Find(int itemId)
        {
            try
            {
                var result = MapperTool.Mapper.Map<Product, ProductDto>(_productDal.Find(itemId));

                if(result is null)
                {
                    return new ErrorDataResult<ProductDto>(Messages.NotFound);
                }

                return new SuccessDataResult<ProductDto>(result, Messages.ItemListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<ProductDto>(ex.Message);
            }
            
        }

        public IDataResult<List<ProductDto>> GetAll()
        {
            try
            {
                var resultList = MapperTool.Mapper.Map<List<Product>, List<ProductDto>>(_productDal.GetAll());

                if(resultList is null)
                {
                    return new ErrorDataResult<List<ProductDto>>(Messages.NotFound);
                }

                return new SuccessDataResult<List<ProductDto>>(resultList, Messages.ItemListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<ProductDto>>(ex.Message);
            }
            
        }

        public IResult Update(ProductDto item)
        {
            _productDal.Update(MapperTool.Mapper.Map<ProductDto, Product>(item));

            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
