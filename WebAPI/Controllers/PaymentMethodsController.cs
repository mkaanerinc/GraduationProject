using BusinessLogic.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        protected readonly IPaymentMethodService<PaymentMethod, PaymentMethodDto> _paymentMethodService;

        public PaymentMethodsController(IPaymentMethodService<PaymentMethod, PaymentMethodDto> paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _paymentMethodService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("Find")]
        public IActionResult Find(int itemId)
        {
            var result = _paymentMethodService.Find(itemId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(PaymentMethodDto item)
        {
            var result = _paymentMethodService.Add(item);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(PaymentMethodDto item)
        {
            var result = _paymentMethodService.Update(item);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(PaymentMethodDto item)
        {
            var result = _paymentMethodService.Delete(item);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
