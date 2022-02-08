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

    public class SuccessDataResult<T> : DataResult<T>
    {       

        public SuccessDataResult(T data, string message) : base(data,true,message)
        {

        }

        public SuccessDataResult(T data) : base(data,true)
        {

        }

        public SuccessDataResult(string message) : base(default,true,message)
        {

        }

        public SuccessDataResult() : base(default,true)
        {

        }
    }
}
