using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IOrderService<Order, OrderDto>
    {
        IDataResult<List<OrderDto>> GetAll();
        IDataResult<OrderDto> Find(int orderId);
        IResult Add(OrderDto order);
        IResult Delete(OrderDto order);
        IResult Update(OrderDto order);
    }
}
