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
    public interface ICustomerService<Customer, CustomerDto>
    {
        IDataResult<List<CustomerDto>> GetAll();
        IDataResult<CustomerDto> Find(int customerId);
        IResult Add(CustomerDto customer);
        IResult Delete(CustomerDto customer);
        IResult Update(CustomerDto customer);
    }
}
