using BusinessLogic.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuredPersonController : ControllerBase
    {
        protected readonly IInsuredPersonService<InsuredPerson, InsuredPersonDto> _insuredPersonService;

        public InsuredPersonController(IInsuredPersonService<InsuredPerson, InsuredPersonDto> insuredPersonService)
        {
            _insuredPersonService = insuredPersonService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _insuredPersonService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("Find")]
        public IActionResult Find(int itemId)
        {
            var result = _insuredPersonService.Find(itemId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(InsuredPersonDto item)
        {
            var result = _insuredPersonService.Add(item);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(InsuredPersonDto item)
        {
            var result = _insuredPersonService.Update(item);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(InsuredPersonDto item)
        {
            var result = _insuredPersonService.Delete(item);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
