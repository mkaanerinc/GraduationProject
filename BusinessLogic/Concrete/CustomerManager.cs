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
    public class CustomerManager : GenericService<Customer, CustomerDto>, ICustomerService
    {
        protected readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal) : base(customerDal)
        {
            _customerDal = customerDal;
        }
    }
}
