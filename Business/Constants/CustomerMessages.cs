using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public abstract class CustomerMessages
    {
        public static string CustomerAdded = "Yeni müşteri eklendi";
        public static string CustomerDeleted = "Mevcut müşteri kaydı silindi";
        public static string CustomerUpdated = "Mevcut müşteri kaydı güncellendi";
        public static string CustomerNameInvalid = "Müşteri ismi 2 karakterden fazla olmalıdır";
        public static string Maintenance = "Sistem bakımda";
        public static string CustomersListed = "Mevcut müşteriler listelendi";
        public static string CompanyListed = "Mevcut şirkteler listelendi";
        public static string CompanyNameInvalid = "Şirket adı için lütfen isim giriniz.";

    }
}
