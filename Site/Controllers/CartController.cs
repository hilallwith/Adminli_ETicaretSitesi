
using Site.Entity;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class CartController : Controller
    {
        DataContext db = new DataContext();

        // GET: Cart
        public ActionResult Index()
        {
           
            return View(GetCart());
        }
        private void SaveOrder(Cart cart,ShippingDetails model)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(1111, 9999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.UserName = User.Identity.Name;
            order.OrderState = OrderState.Bekleniyor;
            order.Adres = model.Adres;
            order.Mahalle = model.Mahalle;
            order.Sehir = model.Sehir;
            order.Semt = model.Semt;
            order.PostaKodu = model.PostaKodu;
          
           
            order.OrderLines = new List<OrderLine>();
            foreach (var item in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = item.Quantity;
                orderline.FIYAT = item.Quantity * item.Product.FIYAT;
             
                orderline.ProductId = item.Product.ID;
                order.OrderLines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
        public PartialViewResult Sumary()
        {

            return PartialView(GetCart());
        }
        public PartialViewResult Sumary1()
        {

            return PartialView(GetCart());
        }
        public ActionResult Checkout()
        {
           
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails model )
        {
            var cart = GetCart();

            if (cart.CartLines.Count== 0)
            {
                ModelState.AddModelError("Film Yok", "Sepetinizde Ürün" +
               " yok veya (10) Adetten Az ürün var ");
                return View("FilmYok");
            }
            if (User.Identity.Name=="")
            {
                return View("KayıtYok");
            }
            if (ModelState.IsValid)
            {
                SaveOrder(cart,model);
                cart.clear();
                return View("SiparisTamamlandi");
            }
            else
            {
                return View(model);
            }

        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.ID == Id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.ID==Id);
            if (product!=null  )
            {
                GetCart().AddProduct(product, 1);
            }
            
            return RedirectToAction("Index");
        }
        public Cart GetCart()
        { 

            
            var cart = (Cart)Session["Cart"];
            if (cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            } 
            return cart;
        }
       
    }
}