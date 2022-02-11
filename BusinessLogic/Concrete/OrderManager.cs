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
    public class OrderManager : IOrderService<Order, OrderDto>
    {
        protected readonly IOrderDal _orderDal;
        protected readonly IProductService<Product, ProductDto> _productService;
        protected readonly IInstallmentOptionService<InstallmentOption, InstallmentOptionDto> _installmentOptionService;
        protected readonly IInsuredPersonService<InsuredPerson, InsuredPersonDto> _insuredPersonService;

        public OrderManager(IOrderDal orderDal, 
            IProductService<Product, ProductDto> productService, 
            IInsuredPersonService<InsuredPerson, InsuredPersonDto> insuredPersonService,
            IInstallmentOptionService<InstallmentOption, InstallmentOptionDto> installmentOptionService)
        {
            _orderDal = orderDal;
            _productService = productService;
            _insuredPersonService = insuredPersonService;
            _installmentOptionService = installmentOptionService;
        }

        #region Methods

        public IResult Add(OrderDto item)
        {
            try
            {
                ValidationTool.Validate(new OrderValidator(), item);

                IResult result = BusinessRules.Run(
                    CheckIfOrderPriceCorrect(item.ProductId, item.CustomerId, item.OrderPrice)
                    );

                if (result is not null)
                {
                    return result;
                }

                OrderDto newItem = CalculateOrderPriceForInstallmentOption(item);

                _orderDal.Add(MapperTool.Mapper.Map<OrderDto, Order>(newItem));

                return new SuccessResult(Messages.ItemAdded);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }

        }

        public IResult Delete(OrderDto item)
        {
            try
            {
                _orderDal.Delete(MapperTool.Mapper.Map<OrderDto, Order>(item));

                return new SuccessResult(Messages.ItemDeleted);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }

        }

        public IDataResult<OrderDto> Find(int itemId)
        {
            try
            {
                var result = MapperTool.Mapper.Map<Order, OrderDto>(_orderDal.Find(itemId));

                if (result is null)
                {
                    return new ErrorDataResult<OrderDto>(Messages.NotFound);
                }

                return new SuccessDataResult<OrderDto>(result, Messages.ItemListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<OrderDto>(ex.Message);
            }

        }

        public IDataResult<List<OrderDto>> GetAll()
        {
            try
            {
                var resultList = MapperTool.Mapper.Map<List<Order>, List<OrderDto>>(_orderDal.GetAll());

                if (resultList is null)
                {
                    return new ErrorDataResult<List<OrderDto>>(Messages.NotFound);
                }

                return new SuccessDataResult<List<OrderDto>>(resultList, Messages.ItemListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<OrderDto>>(ex.Message);
            }

        }

        public IResult Update(OrderDto item)
        {
            try
            {
                ValidationTool.Validate(new OrderValidator(), item);

                IResult result = BusinessRules.Run(
                    CheckIfOrderPriceCorrect(item.ProductId,item.CustomerId,item.OrderPrice)
                    );

                if(result is not null)
                {
                    return result;
                }

                OrderDto newItem = CalculateOrderPriceForInstallmentOption(item);

                _orderDal.Update(MapperTool.Mapper.Map<OrderDto, Order>(newItem));

                return new SuccessResult(Messages.ItemUpdated);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }

        }

        #endregion

        #region BusinessRules

        private IResult CheckIfOrderPriceCorrect(int productId, int customerId, decimal orderPrice) // Fiyat kontrolü
        {
            decimal productPrice = _productService.Find(productId).Data.ProductPrice; // Seçilen ürün fiyatını alırız.

            int insuredPersonCount = _insuredPersonService.GetAll().Data.Where(i => i.CustomerId == customerId).Count(); // Sigorta edilen kişi sayısı

            if(orderPrice < (productPrice*insuredPersonCount)) // Toplam fiyat hesabı peşin ödemeye göre kontrolü yapılıyor.
            {
                return new ErrorResult(Messages.OrderPriceInvalid);
            }

            return new SuccessResult();
        } 

        private OrderDto CalculateOrderPriceForInstallmentOption(OrderDto item) // Seçilen takside göre fiyatın güncellenmesi
        {
            if(item.InstallmentOptionId != 1) // Peşin ise fiyat güncellenmesine gerek kalmaz.
            {
                string installment = _installmentOptionService.Find(item.InstallmentOptionId).Data.InstallmentOptionName;

                int installmentInt = int.Parse(installment); // Seçilen taksiti alırız.

                decimal newOrderPrice = item.OrderPrice + (15 * installmentInt); // Yeni fiyat hesaplanması

                item.OrderPrice = newOrderPrice;
            }

            return item;
        }

        #endregion
    }
}
