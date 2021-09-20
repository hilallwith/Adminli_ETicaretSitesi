using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Entity
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }


        public DateTime Tarih { get; set; }

        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }


        public int ProductID { get; set; }
        public int PersonelID { get; set; }
        public int CariID { get; set; }



        public virtual Product Product { get; set; }

        public virtual Perso Perso { get; set; }

        public virtual Cariler Cariler { get; set; }


    }
}