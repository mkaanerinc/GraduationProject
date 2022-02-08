using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    //  Dönüş yöntemi ya başarılıdır ya da hatalıdır. O yüzden bunu yaparak yazılımcıya ekstra
    // constructor'dan true ya da false göndermesine gerek kalmadan  otomatik verildi.

    public class ErrorResult : Result
    {       

        public ErrorResult(string message) : base(false,message)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
