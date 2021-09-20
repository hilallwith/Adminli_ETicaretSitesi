using Site.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class MesajlarKController : Controller
    {
        // GET: MesajlarK
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View();
        }



        
        public ActionResult GelenMesaj()
        {

            var mail = User.Identity.Name;

            var mesajlar = db.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajID).ToList();
            var gelensayisi = db.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidensayisi = db.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            ViewBag.d1 = gelensayisi;
            return View(mesajlar);
        }
        public ActionResult Sil(int id)
        {
            var mesaj = db.Mesajlars.Find(id);

            db.Mesajlars.Remove(mesaj);
            db.SaveChanges();
            return RedirectToAction("GelenMesaj");
        }



        public ActionResult GidenMesaj()
        {
            var mail = User.Identity.Name;


            var mesajlar = db.Mesajlars.Where(x => x.Gonderici == mail).ToList();
            var gelensayisi = db.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidensayisi = db.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            ViewBag.d1 = gelensayisi;
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id, Mesajlar m)
        {
            var deger = db.Mesajlars.Where(i => i.MesajID == id).ToList();




            var mail = User.Identity.Name;
            var gelensayisi = db.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidensayisi = db.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            ViewBag.d1 = gelensayisi;

            var s = db.Mesajlars.Find(id);
            s.Tarih = "2";
            db.SaveChanges();




            return View(deger);
           
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = User.Identity.Name;
            var gelensayisi = db.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidensayisi = db.Mesajlars.Count(x => x.Gonderici == mail).ToString();

            ViewBag.d2 = gidensayisi;
            ViewBag.d1 = gelensayisi;
            return View();
        }


        public ActionResult YeniMesaj(Mesajlar m)
        {
            var c = "0";
            var mail = User.Identity.Name;
            m.Gonderici = mail;
            m.Alici = "admin";
            m.Tarih = c;

            db.Mesajlars.Add(m);
            db.SaveChanges();


            return View();
        }

        [HttpGet]
        public ActionResult İlet(int id)
        {
            var mail = User.Identity.Name;

            var gelensayisi = db.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidensayisi = db.Mesajlars.Count(x => x.Gonderici == mail).ToString();

            ViewBag.d2 = gidensayisi;
            ViewBag.d1 = gelensayisi;

            db.SaveChanges();

            return View();
        }


        public ActionResult İlet(int id, Mesajlar m)
        {
            var c = "0";
            var mail = User.Identity.Name;
            m.Gonderici = mail;
            var s = db.Mesajlars.Find(id);

            m.Alici = s.Gonderici;
            s.Alici = m.Alici;




            m.Tarih = c;




            db.Mesajlars.Add(m);
            db.SaveChanges();


            return View();
        }
















    }
}