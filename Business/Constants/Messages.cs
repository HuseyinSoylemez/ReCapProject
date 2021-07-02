using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Ekleme işlemi başarılı";
        public static string NameInvalid = "Geçersiz İsim";
        public static string Deleted = "Silme işlemi başarılı";
        public static string Updated = "Güncelleme işlemi başarılı ";
        public static string Listed = "Listeleme işlemi başarılı";
        public static string MaintenanceTime = "Sistem bakımda";

        public static string RentalAddedError = "Araç teslim edilmedi, tekrar kiraya verilemez";

        public static string FailedCarImageAdd = "Araç resim ekleme limitini aşamazsınız";

        public static string AuthorizationDenied = "Yetkiniz Yok";

        public static string UserRegistered = "Kayıt Oldu";

        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Parola Hatası";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";

        public static string AccessTokenCreated = "Token Oluşturuldu.";
    }
}
