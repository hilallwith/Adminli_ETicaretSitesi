using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ShippingDetails
    {

    
        public string UserName { get; set; }

        [Required (ErrorMessage ="Lütfen Adres Bilgilerini Giriniz...")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Lütfen Şehir Bilgilerini Giriniz...")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Lütfen Semt Bilgilerini Giriniz...")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Lütfen Mahalle  Bilgilerini Giriniz...")]
        public string Mahalle { get; set; }

        [Required(ErrorMessage = "Lütfen Posta Kodu  Bilgilerini Giriniz...")]
        public string  PostaKodu{ get; set; }

    }
}