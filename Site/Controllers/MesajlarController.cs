using Site.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class MesajlarController : Controller
    {
        DataContext db = new DataContext();
        // GET: Mesajlar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GelenMesaj()
        {
            var mail = (string)Session["KullaniciAD"];
    
            var mesajlar = db.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x=>x.MesajID).ToList();
            var gidensayisi = db.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            var gelensayisi = db.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        public ActionResult GidenMesaj()
        {
            var mail = (string)Session["KullaniciAD"];
            var mesajlar = db.Mesajlars.Where(x => x.Gonderici == mail).ToList();
            var gelensayisi = db.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidensayisi = db.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            ViewBag.d1 = gelensayisi;
            return View(mesajlar);
        }
    
        public ActionResult MesajDetay(int id,Mesajlar m)
        {
            var deger = db.Mesajlars.Where(i => i.MesajID == id).ToList();
            var mail = (string)Session["KullaniciAD"];
            var gelensayisi = db.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidensayisi = db.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            ViewBag.d1 = gelensayisi;
            m.MesajID = deger.Count();
            m.Tarih = "1";
            var s = db.Mesajlars.Find(id);
            s.Tarih = "1";
            db.SaveChanges();
            return View(deger);
        }
        public ActionResult Sil(int id)
        {
            var mesaj = db.Mesajlars.Find(id);
            db.Mesajlars.Remove(mesaj);
            db.SaveChanges();
            return RedirectToAction("GelenMesaj");
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["KullaniciAD"];
            var gelensayisi = db.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidensayisi = db.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            ViewBag.d1 = gelensayisi;
            return View();
        }
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var c = "0";
            var mail = (string)Session["KullaniciAD"];
            m.Gonderici = mail;
            m.Tarih = c;
            db.Mesajlars.Add(m);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult İlet(int id)
        {
            var mail = (string)Session["KullaniciAD"];
            var gelensayisi = db.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidensayisi = db.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            ViewBag.d1 = gelensayisi;    
            db.SaveChanges();
            return View();
        }
        public ActionResult İlet(int id,Mesajlar m)
        {
            var c = "0";
            var mail = (string)Session["KullaniciAD"];
            var s = db.Mesajlars.Find(id);
            m.Alici = s.Gonderici;
            s.Alici = m.Alici;
            m.Gonderici = mail;
            m.Tarih = c;
            db.Mesajlars.Add(m);
            db.SaveChanges();
            return View();
        }



























    }
}