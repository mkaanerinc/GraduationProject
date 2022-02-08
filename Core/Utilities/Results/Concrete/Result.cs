using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    // Her zaman mesaj gönderilmek istenmeyebilir. O yüzden constructor overloading yaparak iki farklı imkan sağlandı.
    // Property değerleri constructor'dan parametre olarak alınacağı için sadece 'get' verildi 'set' verilmedi.

    public class Result : IResult
    {      

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}
