using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Entity;
namespace Site.Controllers
{
    public class YapılacaklarController : Controller
    {
        DataContext db = new DataContext();
        // GET: Yapılacaklar
        public ActionResult Index()
        {
            var yapilacaklar = db.Giderlers.ToList();
            return View(yapilacaklar);
        }
    }
}