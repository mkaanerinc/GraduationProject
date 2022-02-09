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
            _productDal.Delete(MapperTool.Mapper.Map<ProductDto, Product>(item));

            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<ProductDto> Find(int itemId)
        {
            var result = MapperTool.Mapper.Map<Product, ProductDto>(_productDal.Find(itemId));

            return new SuccessDataResult<ProductDto>(result, Messages.ItemListed);
        }

        public IDataResult<List<ProductDto>> GetAll()
        {
            var resultList = MapperTool.Mapper.Map<List<Product>, List<ProductDto>>(_productDal.GetAll());

            return new SuccessDataResult<List<ProductDto>>(resultList, Messages.ItemListed);
        }

        public IResult Update(ProductDto item)
        {
            _productDal.Update(MapperTool.Mapper.Map<ProductDto, Product>(item));

            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
