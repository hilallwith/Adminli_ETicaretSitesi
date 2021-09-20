using Site.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class UserKiralama
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public OrderState OrderState { get; set; }
        public DateTime OrderDate { get; set; }
    }
}