using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Abstract
{
    // Bu Interface WebAPI için ek olarak data göndereleceği zaman kullanılacak dönüş yöntemi.
    // Message ve Success Property'leri aynı olduğu için tekrardan yazılmadan IResult'dan alındı.
    // Ayrıca geri dönülecek data'nın ne olacağı belli olmadığı için generic olarak 'T' verildi.
    // Her projede kullanılabileceği için Core katmanına eklendi.

    public interface IDataResult<T> : IResult
    {
        public T Data { get;}
    }
}
