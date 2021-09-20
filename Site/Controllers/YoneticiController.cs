using Site.Entity;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class YoneticiController : Controller
    {
        DataContext db = new DataContext();
        // GET: Yonetici
        public ActionResult Index()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "M" || Session["Yetki"].ToString() == "K")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            StateModel model = new StateModel();
            model.BeklenenSiparisSayisi = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList().Count();
            model.KargolanSiparisSayisi = db.Orders.Where(i => i.OrderState == OrderState.Kargolandı).ToList().Count();
            model.TamamlananSiparisSayisi = db.Orders.Where(i => i.OrderState == OrderState.Tamamlandı).ToList().Count();
            model.PaketlenenSiparisSayisi = db.Orders.Where(i => i.OrderState == OrderState.Paketlendi).ToList().Count();
        
            model.FilmSayisi = db.Products.Count();
            model.SiparisSayisi = db.Orders.Count();
            model.BeklenenKiralıkSayisi = db.Order1s.Where(i => i.OrderState == OrderState.Bekleniyor).ToList().Count();
            model.KargolanKiralıkSayisi= db.Order1s.Where(i => i.OrderState == OrderState.Kargolandı).ToList().Count();
            model.PaketlenenKiralıkSayisi = db.Order1s.Where(i => i.OrderState == OrderState.Paketlendi).ToList().Count();
            model.TamamlananKiralananSayisi = db.Order1s.Where(i => i.OrderState == OrderState.Tamamlandı).ToList().Count();
            model.KiralanasSayisi = db.Order1s.Count();
            return View(model);
        }
         public PartialViewResult BildirimMenüsü()
         {
            var bildirim = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return PartialView(bildirim);
         }
         public PartialViewResult FaturaBildirimMenüsü()
         {
            var bildirim = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return PartialView(bildirim);
         }
        public PartialViewResult KBildirimMenüsü()
        {
            var bildirim = db.Order1s.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return PartialView(bildirim);
        }

    }
}