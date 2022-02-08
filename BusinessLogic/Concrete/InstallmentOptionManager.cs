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
    public class InstallmentOptionManager : GenericService<InstallmentOption, InstallmentOptionDto>, IInstallmentOptionService
    {
        protected readonly IInstallmentOptionDal _installmentOptionDal;

        public InstallmentOptionManager(IInstallmentOptionDal installmentOptionDal) : base(installmentOptionDal)
        {
            _installmentOptionDal = installmentOptionDal;
        }
    }
}
