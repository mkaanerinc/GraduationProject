using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Abstract
{
    // Bu Interface WebAPI için herhangi bir data göndermeden (void) kullanılacak dönüş yöntemi.
    // Her projede kullanılabileceği için Core katmanına eklendi.

    public interface IResult
    {
        public bool Success { get;}
        public string Message { get;}
    }
}
