using BusinessLogic.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BaseController;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ApiBaseController<IOrderService, Order, OrderDto>
    {
        public OrdersController(IOrderService orderService) : base(orderService)
        {

        }
    }
}
