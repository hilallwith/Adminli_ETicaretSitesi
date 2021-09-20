using Site.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class OrderDetails1
    {
        public int OrderId { get; set; }

        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderState OrderState { get; set; }
        public string UserName { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }

        public virtual List<OrderLineModel1> OrderLines1 { get; set; }
    }
    public class OrderLineModel1
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double FIYAT { get; set; }
        public string RESIM { get; set; }


    }
}