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
    public interface IProductService<Product,ProductDto>
    {
        IDataResult<List<ProductDto>> GetAll();
        IDataResult<ProductDto> Find(int productId);
        IResult Add(ProductDto product);
        IResult Delete(ProductDto product);
        IResult Update(ProductDto product);
    }
}
