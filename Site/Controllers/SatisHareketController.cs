using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Site.Entity;

namespace Site.Controllers
{
    public class SatisHareketController : Controller
    {
        private DataContext db = new DataContext();

        // GET: SatisHareket
        public ActionResult Index()
        {
            var satisHarekets = db.SatisHarekets.Include(s => s.Cariler).Include(s => s.Perso).Include(s => s.Product);
            return View(satisHarekets.ToList());
        }

        // GET: SatisHareket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatisHareket satisHareket = db.SatisHarekets.Find(id);
            if (satisHareket == null)
            {
                return HttpNotFound();
            }
            return View(satisHareket);
        }

        // GET: SatisHareket/Create
        public ActionResult Create()
        {
            ViewBag.CariID = new SelectList(db.Carilers, "CariID", "CariAd");
            ViewBag.PersonelID = new SelectList(db.Persos, "PersonelID", "PersonelAD");
            ViewBag.ProductID = new SelectList(db.Products, "ID", "OAD");
            return View();
        }

        // POST: SatisHareket/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SatisID,Tarih,Adet,Fiyat,ToplamTutar,ProductID,PersonelID,CariID")] SatisHareket satisHareket)
        {
            if (ModelState.IsValid)
            {
                db.SatisHarekets.Add(satisHareket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CariID = new SelectList(db.Carilers, "CariID", "CariAd", satisHareket.CariID);
            ViewBag.PersonelID = new SelectList(db.Persos, "PersonelID", "PersonelAD", satisHareket.PersonelID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "OAD", satisHareket.ProductID);
            return View(satisHareket);
        }

        // GET: SatisHareket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatisHareket satisHareket = db.SatisHarekets.Find(id);
            if (satisHareket == null)
            {
                return HttpNotFound();
            }
            ViewBag.CariID = new SelectList(db.Carilers, "CariID", "CariAd", satisHareket.CariID);
            ViewBag.PersonelID = new SelectList(db.Persos, "PersonelID", "PersonelAD", satisHareket.PersonelID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "OAD", satisHareket.ProductID);
            return View(satisHareket);
        }

        // POST: SatisHareket/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SatisID,Tarih,Adet,Fiyat,ToplamTutar,ProductID,PersonelID,CariID")] SatisHareket satisHareket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(satisHareket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CariID = new SelectList(db.Carilers, "CariID", "CariAd", satisHareket.CariID);
            ViewBag.PersonelID = new SelectList(db.Persos, "PersonelID", "PersonelAD", satisHareket.PersonelID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "OAD", satisHareket.ProductID);
            return View(satisHareket);
        }

        // GET: SatisHareket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatisHareket satisHareket = db.SatisHarekets.Find(id);
            if (satisHareket == null)
            {
                return HttpNotFound();
            }
            return View(satisHareket);
        }

        // POST: SatisHareket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SatisHareket satisHareket = db.SatisHarekets.Find(id);
            db.SatisHarekets.Remove(satisHareket);
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
    }
}
