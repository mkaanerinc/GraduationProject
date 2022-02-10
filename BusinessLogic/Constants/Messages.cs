using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Constants
{
    public static class Messages
    {
        public readonly static string ItemAdded = "Başarılı bir şekilde eklendi.";
        public readonly static string ItemDeleted = "Başarılı bir şekilde silindi.";
        public readonly static string ItemUpdated = "Başarılı bir şekilde güncellendi.";
        public readonly static string ItemListed = "Başarılı bir şekilde listelendi.";
        public readonly static string NotFound = "Ürün bulunamadı.";

        public readonly static string NameIsExists = "Ürün ismi kullanılmaktadır.";
        public readonly static string ProductPriceInvalid = "Ürün fiyatı geçersizdir.";
    }
}
