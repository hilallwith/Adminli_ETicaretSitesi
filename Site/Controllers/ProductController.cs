using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Site.Entity;

namespace Site.Controllers
{
 
    public class ProductController : Controller
    {
        private DataContext db = new DataContext();
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
          
            return View(products.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult Create()
        {
            if (Session["Yetki"].ToString() == "Y")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "AD");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Product product , HttpPostedFileBase File)
        {
            string path = Path.Combine("/Content/image/" + File.FileName);
            File.SaveAs(Server.MapPath(path));
            product.RESIM = File.FileName.ToString();
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (Session["Yetki"].ToString() == "Y")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "AD", product.CategoryID);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OAD,YONET,PIXEL,SES,RESIM,YORUM,FIYAT,KONU,TOPLAM,KAT,ALIS,IsHome,Desctription,Slider,IsFeatured,CategoryID,SAAT,IsApproved")] Product product)
        {

            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "AD", product.CategoryID);
            return View(product);
        }
        public ActionResult Delete(int? id)
        {
            if (Session["Yetki"].ToString() == "Y")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Depo()
        {
            var products = db.Products.Include(p => p.Category);

            return View(products.ToList());
        }

      

    }
}
