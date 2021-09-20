using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Entity;
namespace Site.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Products.Where(i => i.IsHome && i.IsApproved).ToList());
        }
        public ActionResult Product()
        {
            return View(db.Products.ToList());
        }
        public ActionResult ProductDetails(int id, Yorum yorum )
        {
            
            var c = db.Products.Where(i => i.ID == id).FirstOrDefault();
           
            return View(c);
          

        }
        public ActionResult ProductList(int id)
        {
            return View(db.Products.Where(i => i.CategoryID == id).ToList());
        }
        public PartialViewResult _FeaturedProductList()
        {
            return PartialView(db.Products.Where(i => i.IsApproved && i.IsFeatured).Take(5).ToList());
        }
        public PartialViewResult Slider()
        {
            return PartialView(db.Products.Where(i => i.IsApproved && i.Slider).Take(5).ToList());
        }
        public ActionResult Search(string q)
        {
            var p = db.Products.Where(i => i.IsApproved == true);
            if (!string.IsNullOrEmpty(q))
            {
                p = p.Where(i => i.OAD.Contains(q) || i.Desctription.Contains(q));
            }

            return View(p.ToList());
        }
        public ActionResult KiralıkDetails(int id)
        {
            return View(db.Products.Where(i => i.ID == id).FirstOrDefault());
        }
        public ActionResult Adres()
        {
            return View();
        }

        
    }
}