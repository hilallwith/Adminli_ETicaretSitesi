using Site.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class CariMesajController : Controller
    {
        DataContext db = new DataContext();
        // GET: CariMesaj
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GelenMesajlar()
        {

            var mail = (string)Session["KullaniciAD"];

            var mesaj = db.Carilers.Where(x=>x.CariSoyad==mail).ToList();
            return View(mesaj);
        }
        [HttpGet]
        public ActionResult YeniMesajlar()
        {
            return View();
        }
        // [HttpPost]
        //  public ActionResult YeniMesajlar()
        // {
        //     return View();
        // }
    
}

}