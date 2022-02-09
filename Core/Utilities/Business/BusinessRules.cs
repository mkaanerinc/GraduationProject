using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    // Burada Business katmanı için bir manager'da gereken iş kodları sonucu
    // oluşacak iç içe if kontrolleri manager içine yazmak yerine static
    // class ile kod yazımını kısalttık.
    // Her projede kullanılabileceği için Core katmanına eklendi.

    // Çalışma prensibi => IResult dönen iş kodlarını array ile alıp foreach içerisinde
    // her birinin kontrolünü gerçekleştirirken o iş için false dönerse
    // İş içindeki ErrorResult döndürülüyor. Diğer türlü ise null.

    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
