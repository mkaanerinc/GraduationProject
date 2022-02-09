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
    public class InsuredPersonRelationshipsController : ApiBaseController<IInsuredPersonRelationshipService, InsuredPersonRelationship, InsuredPersonRelationshipDto>
    {
        public InsuredPersonRelationshipsController(IInsuredPersonRelationshipService insuredPersonRelationshipService) : base(insuredPersonRelationshipService)
        {

        }
    }
}
