using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarsListed = "Araçlar listelendi";
        public static string CarDetailsListed = "Araç detayları listelendi";
        public static string ListedByBrand = "Markaya göre listelendi";
        public static string ListedByColor = "Renge göre listelendi";
        public static string CarDescriptionInvalid = "Araç açıklaması geçersiz";
        public static string CarAdded = "Araç kaydedildi";
        public static string CarInfoTaken = "Araç bilgileri alındı";
        public static string CarDailyPriceInvalid = "Araç günlük fiyatı sıfır olamaz";
        public static string BrandsListed = "Markalar listelendi";
        public static string BrandsListedAsInteresting = "Markalar saçma bir şekilde sorgulandı";
        public static string ColorsListed = "Renkler listelendi";
        public static string ColorsListedAsInteresting = "Renkler saçma bir şekilde sorgulandı";
        public static string CarDeleted = "Araç silindi";
        public static string CarUpdated = "Araç güncellendi";
        public static string BrandAdded = "Marka kaydedildi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string ColorAdded = "Renk kaydedildi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string UserAdded = "Kullanıcı kaydedildi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerDetailsListed = "Müşteriler listelendi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string RentalAdded = "Kiralama kaydedildi";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalListCreated = "Kiralamalar listelendi";
        public static string RentalUpdated = "Kiralama güncellendi";
        public static string UserVerified = "Kullanıcı doğrulandı";
        public static string UserNotVerified = "Kullanıcı doğrulanamadı";
        internal static string CarImageAdded = "Araç resmi yüklendi";
        internal static string CarImageDeleted = "Araç resmi silindi";
        internal static string CarsImagesListed="Araç resimleri listelendi";
        internal static string CarImageUpdated="Araç resmi güncellendi";
        internal static string ImageLimitExceededOfTheCar="Bu araç için daha fazla resim eklenemez";
        internal static string FileCannotUploaded="Doaya yüklenemedi";
    }
}
