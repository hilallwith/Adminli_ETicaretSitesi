using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Site.Entity
{
    public class Perso
    {


        [Key]
        public int PersonelID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAD { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(11)]
        public string Telefon { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Mail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }

       

        public ICollection<SatisHareket> SatisHarekets { get; set; }

        public int DepartmanID { get; set; }
        public Depart Depart { get; set; }

    }
}