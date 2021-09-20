using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Site.Entity
{
    public class Yorum
    {
        [Key]
        public int YorumID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KullanıcıAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Mail { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(1000)]
        public string Icerik { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}