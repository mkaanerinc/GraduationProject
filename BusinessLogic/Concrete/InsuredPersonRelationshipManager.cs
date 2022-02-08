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
    public class InsuredPersonRelationshipManager : GenericService<InsuredPersonRelationship, InsuredPersonRelationshipDto>, IInsuredPersonRelationshipService
    {
        protected readonly IInsuredPersonRelationshipDal _insuredPersonRelationShipDal;

        public InsuredPersonRelationshipManager(IInsuredPersonRelationshipDal insuredPersonRelationShipDal) : base(insuredPersonRelationShipDal)
        {
            _insuredPersonRelationShipDal = insuredPersonRelationShipDal;
        }
    }
}
