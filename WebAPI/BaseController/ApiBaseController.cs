using BusinessLogic.Abstract;
using Core.Entity.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.BaseController
{
    // CRUD işlemleri aynı olduğu için ortak bir base controller oluşturuldu.


    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController<TInterface,TEntity,TDto> : ControllerBase
        where TInterface : IGenericService<TEntity,TDto>
        where TEntity : class, IEntity, new()
        where TDto : class, IDto, new()
    {
        protected readonly TInterface _service;

        public ApiBaseController(TInterface service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();

            if(result.Success)
            {
                return Ok(result);
            } 

            return BadRequest(result);

        }

        [HttpGet("Find")]
        public IActionResult Find(int itemId)
        {
            var result = _service.Find(itemId);

            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(TDto item)
        {
            var result = _service.Add(item);

            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(TDto item)
        {
            var result = _service.Update(item);

            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(TDto item)
        {
            var result = _service.Delete(item);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
