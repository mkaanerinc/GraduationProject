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
    public interface IInsuredPersonService<InsuredPerson, InsuredPersonDto>
    {
        IDataResult<List<InsuredPersonDto>> GetAll();
        IDataResult<InsuredPersonDto> Find(int insuredPersonId);
        IResult Add(InsuredPersonDto insuredPerson);
        IResult Delete(InsuredPersonDto insuredPerson);
        IResult Update(InsuredPersonDto insuredPerson);
    }
}
