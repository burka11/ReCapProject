using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class UserMessages
    {

        public static string UserAdded = "Yeni kişi eklendi";
        public static string UserDeleted = "Mevcut kişi kaydı silindi";
        public static string UserUpdated = "Mevcut kişi kaydı güncellendi";
        public static string UserNameInvalid = "Kişi ismi 2 karakterden fazla olmalıdır";
        public static string Maintenance = "Sistem bakımda";
        public static string UsersListed = "Mevcut kişiler Listelendi";
        public static string AuthorizationDenied = "Yetkiniz yok! ";


        //public static string CustomerNameInvalid = "Müşteri ismi 2 karakterden fazla olmalıdır";
        //public static string CustomersListed = "Mevcut müşteriler listelendi";
        //public static string CompanyListed = "Mevcut şirkteler listelendi";
        //public static string CompanyNameInvalid = "Şirket adı için lütfen isim giriniz.";

    }
}
