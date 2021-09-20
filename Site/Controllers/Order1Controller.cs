using Site.Entity;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class Order1Controller : Controller
    {
        DataContext db = new DataContext();
        // GET: Order1
        public ActionResult Index()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "K")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            var order1s = db.Order1s.Select(i => new AdminOrder1()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.OrderLines1.Count
            }).OrderByDescending(i => i.OrderDate).ToList();
            return View(order1s);
        }
        public ActionResult Details(int id)
        {
            if (Session["Yetki"].ToString() == "Y" )
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            var model = db.Order1s.Where(i => i.Id == id).Select(i => new OrderDetails1()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                UserName = i.UserName,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,

                Adres = i.Adres,
                Sehir = i.Sehir,
                Semt = i.Semt,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
               OrderLines1 = i.OrderLines1.Select(x => new OrderLineModel1()
                {
                    ProductId = x.ProductId,
                    RESIM = x.Product.RESIM,
                    ProductName = x.Product.OAD,
                    Quantity = x.Quantity,
                    FIYAT = x.Product.TOPLAM

                }).ToList()
            }).FirstOrDefault();

            return View(model);
        }
        public ActionResult UpdateOrderState(int OrderId, OrderState orderState)
        {
            var order1 = db.Order1s.FirstOrDefault(i => i.Id == OrderId);
            if (order1 != null)
            {
                order1.OrderState = orderState;
                db.SaveChanges();
                TempData["mesaj"] = "Bilgiler Kaydedildi";

                return RedirectToAction("Details", new { id = OrderId });
            }
            return RedirectToAction("Index");
        }
        public ActionResult BekleyenKiralamalar()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "K")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            var model = db.Order1s.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return View(model);
        }
        public ActionResult KargolananKiralamalar()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "K")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            var orders = db.Order1s.Where(i => i.OrderState == OrderState.Kargolandı).ToList();
            return View(orders);
        }
        public ActionResult TamamlananKiralamalar()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "K")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            var orders = db.Order1s.Where(i => i.OrderState == OrderState.Tamamlandı).ToList();
            return View(orders);
        }
        public ActionResult PaketlenenKiralamalar()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "K")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            var orders = db.Order1s.Where(i => i.OrderState == OrderState.Paketlendi).ToList();
            return View(orders);
        }
    }
}