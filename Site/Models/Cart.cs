using Site.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();
        public List<Product> c = new List<Product>();
        public List<CartLine> CartLines
        {
            get { return _cartLines; }
        }
        public void AddProduct(Product product ,int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.Product.ID == product.ID);
            if (line==null)
            {
                _cartLines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void DeleteProduct(Product product)
        {
            _cartLines.RemoveAll(i => i.Product.ID == product.ID);
        }
        public double Total()
        {
            return _cartLines.Sum(i => i.Product.FIYAT * i.Quantity);
        }
        public void clear()
        {
            _cartLines.Clear();
        }
     


    }
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}