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
    public interface IInstallmentOptionService<InstallmentOption, InstallmentOptionDto>
    {
        IDataResult<List<InstallmentOptionDto>> GetAll();
        IDataResult<InstallmentOptionDto> Find(int installmentOptionId);
        IResult Add(InstallmentOptionDto installmentOption);
        IResult Delete(InstallmentOptionDto installmentOption);
        IResult Update(InstallmentOptionDto installmentOption);
    }
}
