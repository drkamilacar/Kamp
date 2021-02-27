using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Saat 22.00-22.59 arasında kullanılamaz";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductCountIfCategoryError = "Bir kategoride en fazla 10 ürün bulunabilir";
        public static string ProductNameAlreadyExists = "Aynı isim ile başka bir ürün zaten mevcut";
        public static string CategoryCountExceeded = "Kategori sayısı 15 i geçtiği için ürün eklenemez";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı kaydedildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
