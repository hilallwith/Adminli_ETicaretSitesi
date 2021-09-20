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
    public class PersoController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Perso
        public ActionResult Index()
        {
            var persos = db.Persos.Include(p => p.Depart);
            return View(persos.ToList());
        }

        // GET: Perso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perso perso = db.Persos.Find(id);
            if (perso == null)
            {
                return HttpNotFound();
            }
            return View(perso);
        }

        // GET: Perso/Create
        public ActionResult Create()
        {
            if (Session["Yetki"].ToString() == "Y")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            ViewBag.DepartmanID = new SelectList(db.Departs, "DepartmanID", "DepartmanAD");
            return View();
        }

        // POST: Perso/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonelID,PersonelAD,PersonelSoyad,Telefon,Mail,PersonelGorsel,DepartmanID")] Perso perso)
        {
            if (ModelState.IsValid)
            {
                db.Persos.Add(perso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmanID = new SelectList(db.Departs, "DepartmanID", "DepartmanAD", perso.DepartmanID);
            return View(perso);
        }

        // GET: Perso/Edit/5
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
            Perso perso = db.Persos.Find(id);
            if (perso == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmanID = new SelectList(db.Departs, "DepartmanID", "DepartmanAD", perso.DepartmanID);
            return View(perso);
        }

        // POST: Perso/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonelID,PersonelAD,PersonelSoyad,Telefon,Mail,PersonelGorsel,DepartmanID")] Perso perso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmanID = new SelectList(db.Departs, "DepartmanID", "DepartmanAD", perso.DepartmanID);
            return View(perso);
        }

        // GET: Perso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Yetki"].ToString() == "Y" )
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
            Perso perso = db.Persos.Find(id);
            if (perso == null)
            {
                return HttpNotFound();
            }
            return View(perso);
        }

        // POST: Perso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perso perso = db.Persos.Find(id);
            db.Persos.Remove(perso);
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
