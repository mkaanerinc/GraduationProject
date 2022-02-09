using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IInsuredPersonRelationshipService<InsuredPersonRelationship, InsuredPersonRelationshipDto>
    {
        IDataResult<List<InsuredPersonRelationshipDto>> GetAll();
        IDataResult<InsuredPersonRelationshipDto> Find(int insuredPersonRelationshipId);
        IResult Add(InsuredPersonRelationshipDto insuredPersonRelationship);
        IResult Delete(InsuredPersonRelationshipDto insuredPersonRelationship);
        IResult Update(InsuredPersonRelationshipDto insuredPersonRelationship);
    }
}
