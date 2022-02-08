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
    public class InsuredPersonManager : GenericService<InsuredPerson, InsuredPersonDto>, IInsuredPersonService
    {
        protected readonly IInsuredPersonDal _insuredPersonDal;

        public InsuredPersonManager(IInsuredPersonDal insuredPersonDal) : base(insuredPersonDal)
        {
            _insuredPersonDal = insuredPersonDal;
        }
    }
}
