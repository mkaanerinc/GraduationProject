using BusinessLogic.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentOptionsController : ControllerBase
    {
        protected readonly IInstallmentOptionService<InstallmentOption, InstallmentOptionDto> _installmentOptionService;

        public InstallmentOptionsController(IInstallmentOptionService<InstallmentOption, InstallmentOptionDto> installmentOptionService)
        {
            _installmentOptionService = installmentOptionService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _installmentOptionService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("Find")]
        public IActionResult Find(int itemId)
        {
            var result = _installmentOptionService.Find(itemId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(InstallmentOptionDto item)
        {
            var result = _installmentOptionService.Add(item);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(InstallmentOptionDto item)
        {
            var result = _installmentOptionService.Update(item);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(InstallmentOptionDto item)
        {
            var result = _installmentOptionService.Delete(item);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
