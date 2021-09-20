using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class YorumModel
    {
        public int ID { get; set; }
        public string KullanıcıAd { get; set; }
        public string Mail { get; set; }
        public string Icerik { get; set; }
    }
}