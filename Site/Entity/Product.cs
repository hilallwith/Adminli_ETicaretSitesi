using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Entity
{
    public class Product
    {
        public int ID { get; set; }
        public string OAD { get; set; }
        public string YONET { get; set; }
        public int PIXEL { get; set; }
        public string SES { get; set; }
        public string RESIM { get; set; }
        public int YORUM { get; set; }
        public double FIYAT { get; set; }
        public string KONU { get; set; }
        public int TOPLAM { get; set; }
        public int KAT { get; set; }
        public double ALIS { get; set; }
        public bool IsHome { get; set; }
        public string Desctription { get; set; }
        public bool Slider { get; set; }
   
        public bool IsFeatured { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public string SAAT { get; set; }
        public bool IsApproved { get; set; }
        public int artis1 { get; set; }
        public int artis2 { get; set; }
        public int artis3 { get; set; }
        public int artis4 { get; set; }
        public List<Yorum> Yorums { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}