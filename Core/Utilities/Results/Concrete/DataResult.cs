using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    // Message ve Success Result ile ortak olduğu için bu Property'ler base ile Result'da gönderildi.
    // Her zaman mesaj gönderilmek istenmeyebilir. O yüzden constructor overloading yaparak iki farklı imkan sağlandı.
    // Property değerleri constructor'dan parametre olarak alınacağı için sadece 'get' verildi 'set' verilmedi.


    public class DataResult<T> : Result, IDataResult<T>
    {       

        public DataResult(T data, bool success, string message) : base(success,message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data=data;
        }

        public T Data { get; }
    }
}
