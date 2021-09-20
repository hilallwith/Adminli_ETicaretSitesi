using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Entity
{
    public class Toplamlar
    {

        [Key]
        public int toplamID { get; set; }

      
        public int toplam1 { get; set; }
        public int toplam2 { get; set; }
        public int toplam3 { get; set; }


    }
}