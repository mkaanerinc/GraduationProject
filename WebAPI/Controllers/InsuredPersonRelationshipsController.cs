using BusinessLogic.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuredPersonRelationshipController : ControllerBase
    {
        protected readonly IInsuredPersonRelationshipService<InsuredPersonRelationship, InsuredPersonRelationshipDto> _insuredPersonRelationshipService;

        public InsuredPersonRelationshipController(IInsuredPersonRelationshipService<InsuredPersonRelationship, InsuredPersonRelationshipDto> insuredPersonRelationshipService)
        {
            _insuredPersonRelationshipService = insuredPersonRelationshipService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _insuredPersonRelationshipService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("Find")]
        public IActionResult Find(int itemId)
        {
            var result = _insuredPersonRelationshipService.Find(itemId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(InsuredPersonRelationshipDto item)
        {
            var result = _insuredPersonRelationshipService.Add(item);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(InsuredPersonRelationshipDto item)
        {
            var result = _insuredPersonRelationshipService.Update(item);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(InsuredPersonRelationshipDto item)
        {
            var result = _insuredPersonRelationshipService.Delete(item);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
