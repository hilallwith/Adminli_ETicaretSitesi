using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Entity
{
    public class Kullanıcı
    {

        [Key]
        public string ID { get; set; }
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyadınız")]
        public string Surname { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adınız")]
        public string Username { get; set; }



        [Required]
        [DisplayName("Mail Adresiniz")]
        [EmailAddress(ErrorMessage = "Geçersiz Mail Adres...")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Kiralama Sayısı")]
        public string Uyelik { get; set; }
 
       
        public bool Durum { get; set; }
        [Required]
        [DisplayName("Şifreniz")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Şifreler uyumsuz...")]
        [DisplayName("Şifre Tekrar")]
        public string RePassword { get; set; }
    }
}