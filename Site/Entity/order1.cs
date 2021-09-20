using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Entity
{
    public class order1
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public OrderState OrderState { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserName { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }
        public int KiralamaSayısı { get; set; }

        public virtual List<OrderLine1> OrderLines1 { get; set; }
    }
    public class OrderLine1
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual order1 Order1 { get; set; }
        public int Quantity { get; set; }
        public double FIYAT { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}