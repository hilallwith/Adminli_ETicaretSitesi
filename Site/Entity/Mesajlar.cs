using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Site.Entity
{
    public class Mesajlar
    {


        [Key]
        public int MesajID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string Gonderici{ get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string Alici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string Konu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1000)]
        public string İçerik{ get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string Tarih { get; set; }
    }
}