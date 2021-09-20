using Site.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Site.Controllers
{
    public class GirisController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Giris
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Partial1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Partial1(Admin c)
        {
            var bilgi = db.Admins.FirstOrDefault(x => x.KullaniciAD == c.KullaniciAD && x.Sifre == c.Sifre);
            if (bilgi!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAD, false);
                Session["KullaniciAD"] = bilgi.KullaniciAD.ToString();
                Session["Yetki"] = bilgi.Yetki.ToString();
                return RedirectToAction("Index", "Yonetici");
            }
            else
            {
                return RedirectToAction("Index", "Giris");
            }
       
        }
        public ActionResult GelenMesajlar()
        {

            var mail = (string)Session["KullaniciAD"];

            var mesaj = db.Admins.Where(x => x.KullaniciAD == mail).ToList();
            return View(mesaj);
        }
    }
}