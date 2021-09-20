using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Site.Entity
{
    public class Unvan
    {
        [Key]
        public int UnvanID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UnvanAD { get; set; }




    }
}