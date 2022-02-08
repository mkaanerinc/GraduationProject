using Core.Entity.Abstract;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    // Her Dto  işlemi için temel business işlemleri ortak  olduğu için bir interface'e yazıldı.
    // Burada Generic verirken sınırlama sırasında;
    // class => Reference Type
    // IEntity => veritabanı referansı olan bir class
    // IDto =>  data transfer object olan bir class
    // new() => IEntity koyulamaması için eklendi.

    public interface IGenericService<TEntity,TDto>
        where TEntity : class, IEntity, new()
        where TDto : class, IDto, new()
    {
        IDataResult<List<TDto>> GetAll();
        IDataResult<TDto> Find(int itemId);
        IResult Add(TDto item);
        IResult Delete(TDto item);
        IResult Update(TDto item);
    }
}
