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
    public class OrderManager : IOrderService<Order, OrderDto>
    {
        protected readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult Add(OrderDto item)
        {
            _orderDal.Add(MapperTool.Mapper.Map<OrderDto, Order>(item));

            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(OrderDto item)
        {
            _orderDal.Delete(MapperTool.Mapper.Map<OrderDto, Order>(item));

            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<OrderDto> Find(int itemId)
        {
            var result = MapperTool.Mapper.Map<Order, OrderDto>(_orderDal.Find(itemId));

            return new SuccessDataResult<OrderDto>(result, Messages.ItemListed);
        }

        public IDataResult<List<OrderDto>> GetAll()
        {
            var resultList = MapperTool.Mapper.Map<List<Order>, List<OrderDto>>(_orderDal.GetAll());

            return new SuccessDataResult<List<OrderDto>>(resultList, Messages.ItemListed);
        }

        public IResult Update(OrderDto item)
        {
            _orderDal.Update(MapperTool.Mapper.Map<OrderDto, Order>(item));

            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
