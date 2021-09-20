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
    public class YapilacaklarController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Yapilacaklar
        public ActionResult Index()
        {
            return View(db.Giderlers.ToList());
        }

        // GET: Yapilacaklar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giderler giderler = db.Giderlers.Find(id);
            if (giderler == null)
            {
                return HttpNotFound();
            }
            return View(giderler);
        }

        // GET: Yapilacaklar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yapilacaklar/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GiderID,Aciklama,Tarih,Tutar,Durum")] Giderler giderler)
        {
            if (ModelState.IsValid)
            {
                db.Giderlers.Add(giderler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(giderler);
        }

        // GET: Yapilacaklar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giderler giderler = db.Giderlers.Find(id);
            if (giderler == null)
            {
                return HttpNotFound();
            }
            return View(giderler);
        }

        // POST: Yapilacaklar/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GiderID,Aciklama,Tarih,Tutar,Durum")] Giderler giderler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giderler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giderler);
        }

        // GET: Yapilacaklar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giderler giderler = db.Giderlers.Find(id);
            if (giderler == null)
            {
                return HttpNotFound();
            }
            return View(giderler);
        }

        // POST: Yapilacaklar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Giderler giderler = db.Giderlers.Find(id);
            db.Giderlers.Remove(giderler);
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
        public ActionResult Takvim()
        {
            return View();
        }
        public ActionResult Sil(int id)
        {
            var yapilacak = db.Giderlers.Find(id);

            db.Giderlers.Remove(yapilacak);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Gün(int id,Giderler m)
        {

            var s = db.Giderlers.Find(id);
            if (s.Durum == true)
            {
                s.Durum = false;
            }
            else
            {
                s.Durum = true;
            }
           
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }


    }
}
