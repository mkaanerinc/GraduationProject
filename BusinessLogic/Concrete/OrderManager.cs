using BusinessLogic.Abstract;
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
    public class OrderManager : GenericService<Order, OrderDto>, IOrderService
    {
        protected readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal) : base(orderDal)
        {
            _orderDal = orderDal;
        }
    }
}
