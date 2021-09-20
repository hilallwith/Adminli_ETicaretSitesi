using Site.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class Kiralık
    {
        private List<KiralıkLine>  _KiralıkLines= new List<KiralıkLine>();
        public List<KiralıkLine> Kiralıklines
        {
            get { return _KiralıkLines; }
        }
        public void AddProduct(Product product, int quantity)
        {
            var line = _KiralıkLines.FirstOrDefault(i => i.Product.ID == product.ID);
            if (line == null)
            {
               _KiralıkLines.Add(new KiralıkLine() { Product = product, Quantity = quantity });
            }
            else
            {
               
            }
        }
        public void DeleteProduct(Product product)
        {
            _KiralıkLines.RemoveAll(i => i.Product.ID == product.ID);
        }
        public double Total()
        {
            return _KiralıkLines.Sum(i => i.Product.FIYAT * i.Quantity);
        }
        public void clear()
        {
            _KiralıkLines.Clear();
        }
    }
  



    public class KiralıkLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}