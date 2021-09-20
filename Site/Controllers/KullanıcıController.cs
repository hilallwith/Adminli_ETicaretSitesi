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
    public class KullanıcıController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Kullanıcı
        public ActionResult Index()
        {
            return View(db.Kullanıcıs.ToList());
        }

        // GET: Kullanıcı/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanıcı kullanıcı = db.Kullanıcıs.Find(id);
            if (kullanıcı == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı);
        }

        // GET: Kullanıcı/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kullanıcı/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Surname,Username,Email,Uyelik,Durum,Password,RePassword")] Kullanıcı kullanıcı)
        {
            if (ModelState.IsValid)
            {
                db.Kullanıcıs.Add(kullanıcı);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kullanıcı);
        }

        // GET: Kullanıcı/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanıcı kullanıcı = db.Kullanıcıs.Find(id);
            if (kullanıcı == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı);
        }

        // POST: Kullanıcı/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Surname,Username,Email,Uyelik,Durum,Password,RePassword")] Kullanıcı kullanıcı)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanıcı).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kullanıcı);
        }

        // GET: Kullanıcı/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanıcı kullanıcı = db.Kullanıcıs.Find(id);
            if (kullanıcı == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı);
        }

        // POST: Kullanıcı/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Kullanıcı kullanıcı = db.Kullanıcıs.Find(id);
            db.Kullanıcıs.Remove(kullanıcı);
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
