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
    public class InstallmentOptionsController : ApiBaseController<IInstallmentOptionService, InstallmentOption, InstallmentOptionDto>
    {
        public InstallmentOptionsController(IInstallmentOptionService installmentOptionService) : base(installmentOptionService)
        {

        }
    }
}
