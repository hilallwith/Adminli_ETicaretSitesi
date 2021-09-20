using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Entity
{
    public class Category
    {
        public int ID { get; set; }
        public string AD { get; set; }
        public string Descrtription { get; set; }
        public List<Product> Products { get; set; }
    }
}