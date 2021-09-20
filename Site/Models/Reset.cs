using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class Reset
    {

        [Required]
        [DisplayName("Mail Adresiniz")]
        [EmailAddress(ErrorMessage = "Geçersiz Mail Adres...")]
        public string Mail { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adınız")]
        public string Username { get; set; }
    }
}