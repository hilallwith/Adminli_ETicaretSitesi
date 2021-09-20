using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Site.Entity
{
    public class Depart
    {

        [Key]
        public int DepartmanID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmanAD { get; set; }

        public bool Durum { get; set; }

        public List<Perso> Persos { get; set; }

        





    }
}