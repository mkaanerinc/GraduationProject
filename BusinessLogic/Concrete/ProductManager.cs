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
    public class ProductManager : IProductService<Product, ProductDto>
    {
        protected readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        #region Methods

        public IResult Add(ProductDto item)
        {
            try
            {
                ValidationTool.Validate(new ProductValidator(), item);

                IResult result = BusinessRules.Run(
                    CheckIfProductNameExists(item.ProductName),
                    CheckIfProductPriceCorrect(item.ProductPrice)
                    );

                if (result is not null)
                {
                    return result;
                }

                _productDal.Add(MapperTool.Mapper.Map<ProductDto, Product>(item));

                return new SuccessResult(Messages.ItemAdded);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }


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

                if (result is null)
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

                if (resultList is null)
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
            try
            {
                ValidationTool.Validate(new ProductValidator(), item);

                IResult result = BusinessRules.Run(
                    CheckIfProductNameExists(item.ProductName),
                    CheckIfProductPriceCorrect(item.ProductPrice)
                    );

                if (result is not null)
                {
                    return result;
                }

                _productDal.Update(MapperTool.Mapper.Map<ProductDto, Product>(item));

                return new SuccessResult(Messages.ItemUpdated);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }

        }

        #endregion

        #region Business Rules

        private IResult CheckIfProductNameExists(string productName)
        {
            bool result = _productDal.GetAll(p => p.ProductName == productName).Any();

            if (result)
            {
                return new ErrorResult(Messages.NameIsExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductPriceCorrect(decimal productPrice)
        {
            if (productPrice < 100 /* && productPrice <= 0 */ )
            {
                return new ErrorResult(Messages.ProductPriceInvalid);
            }

            return new SuccessResult();
        }

        #endregion

    }
}
