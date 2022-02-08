using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    //  Dönüş yöntemi ya başarılıdır ya da hatalıdır. O yüzden bunu yaparak yazılımcıya ekstra
    // constructor'dan true ya da false göndermesine gerek kalmadan  otomatik verildi.
    // Eğer data verilmezse default ile varsayılan değerlerini alırız. Örneğin;
    // int = 0, string, class = null, boolean = false

    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data,false,message)
        {

        }

        public ErrorDataResult(T data) : base(data,false)
        {

        }

        public ErrorDataResult(string message) : base(default,false,message)
        {

        }

        public ErrorDataResult() : base(default,false)
        {

        }
    }
}
