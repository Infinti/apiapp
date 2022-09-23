using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string ProductsListed = "Ürünler listelendi.";
        public static string MaintenanceTime = "Sistem bakımda!";
        public static string ProductCountOfCategoryError = "Kategoride en fazla 10 ürün olabilir.";
        public static string ProductNameAlreadyExits = "Bu isimde zaten başka bir ürün var.";
        public static string CategoryLimitExceeded = "Kategori limiti aşıldı, yeni ürün eklenemiyor.";
        public static string AuthorizationDenied = "Bu işleme yetkin yok.";
        public static string UserRegistered="Kullacı kayıt oldu.";
        public static string UserNotFound="Kullanıcı bulunamadı.";
        public static string PasswordError="Hatalı parola!";
        public static string SuccessfulLogin="Başarılı giriş.";
        public static string UserAlreadyExists="Kullanıcı zaten var.";
        public static string AccessTokenCreated="Giriş tokenı oluşturuldu.";
    }
}
