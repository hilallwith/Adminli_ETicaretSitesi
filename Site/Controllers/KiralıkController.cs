using Site.Entity;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class KiralıkController : Controller
    {

        DataContext db = new DataContext();
        // GET: Kiralık
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult KiralıkEkle(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.ID == Id);
            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
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
        public Kiralık GetCart()
        {
            var kiralık = (Kiralık)Session["Kiralık"];
            if (kiralık == null)
            {
                kiralık = new Kiralık();
                Session["Kiralık"] = kiralık;
            }
            return kiralık;
        }
        public PartialViewResult Adet()
        {

            return PartialView(GetCart());
        }
        public ActionResult Checkout()
        {
            return View(new KiralamaDetails());
        }
        [HttpPost]
        public ActionResult Checkout(KiralamaDetails model)
        {
            var kiralık = GetCart();
            //&& kiralık.Kiralıklines.Count<10
            if (kiralık.Kiralıklines.Count == 0 )
            {
                ModelState.AddModelError("Film Yok", "Sepetinizde Ürün yok veya (10) Adetten Az ürün var ");
                return View("FilmYok");
            }
            if (User == null)
            {
                return View("KayıtYok");
            }
            if (ModelState.IsValid)
            {
                SaveOrder(kiralık, model);
                kiralık.clear();
                return View("KiralıkTamamlandi");
            }
            else
            {
                return View(model);
            }
        }
        private void SaveOrder(Kiralık kiralık, KiralamaDetails model)
        {
            var order = new order1();
            order.OrderNumber = "A" + (new Random()).Next(1111, 9999).ToString();
            order.Total = kiralık.Total();
            order.OrderDate = DateTime.Now;
            order.UserName = User.Identity.Name;
            order.OrderState = OrderState.Bekleniyor;
            order.Adres = model.Adres;
            order.Mahalle = model.Mahalle;
            order.Sehir = model.Sehir;
            order.Semt = model.Semt;
            order.PostaKodu = model.PostaKodu;
            order.OrderLines1 = new List<OrderLine1>();
            foreach (var item in kiralık.Kiralıklines)
            {
                var orderline1 = new OrderLine1();
                orderline1.Quantity = item.Quantity;
                orderline1.FIYAT = item.Quantity * item.Product.PIXEL;
               
                orderline1.ProductId = item.Product.ID;
                order.OrderLines1.Add(orderline1);
            }
            db.Order1s.Add(order);
            db.SaveChanges();
        }

    }
}