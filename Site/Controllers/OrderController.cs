using Site.Entity;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "K")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            var orders = db.Orders.Select(i => new AdminOrder()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.OrderLines.Count
            }).OrderByDescending(i => i.OrderDate).ToList();
            return View(orders);
            
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
            var model = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetails()
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
                OrderLines = i.OrderLines.Select(x => new OrderLineModel()
                {
                    ProductId = x.ProductId,
                    RESIM = x.Product.RESIM,
                    ProductName = x.Product.OAD,
                    Quantity = x.Quantity,
                   FIYAT=x.Product.TOPLAM
                   
                }).ToList()
            }).FirstOrDefault();
          
            return View(model);
        }

        

        public ActionResult UpdateOrderState(int OrderId, OrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);
          
           
            if (order != null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();
                TempData["mesaj"] = "Bilgiler Kaydedildi";

                return RedirectToAction("Details", new { id = OrderId });
            }
            return RedirectToAction("Index");
        }

      

        public ActionResult BekleyenSiparisler()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "K")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            var model = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return View(model);
        }
        public ActionResult KargolananSiparisler()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "K")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            var orders = db.Orders.Where(i => i.OrderState == OrderState.Kargolandı).ToList();
            return View(orders);
        }
        public ActionResult TamamlananSiparisler()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "K")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            var orders = db.Orders.Where(i => i.OrderState == OrderState.Tamamlandı).ToList();
            return View(orders);
        }
        public ActionResult PaketlenenSiparisler()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "K")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            var orders = db.Orders.Where(i => i.OrderState == OrderState.Paketlendi).ToList();
            return View(orders);
        }
       

    }
}