using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string[] ValidImageFileTypes = { ".jpg", ".jpeg", ".png" };

        public static string ProductAdded = "ürün eklendi";
        public static string ProductDelete = "ürün silindi";
        public static string ProductUpdate = "ürün güncellendi";
        public static string ProductNameInvalid = "ürün ismi gecersiz";
        public static List<Car> MaintenanceTime;
        public static string ProductListed = "ürünler listelendi";
        public static string CarAdd = "resim eklendi";
        public static string CarHaveNoImage = "resim yok";
        public static string pictureNotFound = "resim bulunamadı";
        public static string ImageExtensionInvalid = "geçersiz";
        public static string MaxProduct = "En çok 5 ürün eklenebilir";
        public static string AuthorizationDenied = "yetkilenme reddedildi";
        public static string UserRegistered = "kayıtlı kullanıcı";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string PasswordError = "parola hatası";
        public static string SuccessfulLogin = "başarılı giriş";
        public static string UserAlreadyExists = "kullanıcı zaten var";
        public static string AccessTokenCreated = "Başarıyla Giriş Yapıldı";
        public static string OperationClaimsListed="listelendi";
        public static string ErrorListed="listelenemedi";
        public static string AlreadyExist="kiralanamaz";
        public static string CarImageUpdated="güncellendi";
        public static string CarAlreadyRented="araç kiralanmış";
        public static string Rented="kiralandı";
        public static string FindeksDeleted="findeks silindi";
        public static string FindeksUpdated="findeks güncellendi";
        public static string FindeksAdded="findeks eklendi";
        public static string NotFound="Bankanız bilgileri doğrulamadı";
        public static string CardMatched="kart bulundu";
        public static string CustomerUpdated="güncellendi";
        public static string CustomersListed="müşteriler listelendi";
    }
}
