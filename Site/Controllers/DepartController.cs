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
    public class DepartController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Depart
        public ActionResult Index()
        {
            

            var d = db.Departs.Where(i => i.Durum == true).ToList();
            return View(d);
        }

        // GET: Depart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depart depart = db.Departs.Find(id);
            if (depart == null)
            {
                return HttpNotFound();
            }
            return View(depart);
        }

        // GET: Depart/Create
       
        public ActionResult Create()
        {
            if (Session["Yetki"].ToString() == "Y")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            return View();
        }

        // POST: Depart/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmanID,DepartmanAD,Durum")] Depart depart)
        {
            if (ModelState.IsValid)
            {
                db.Departs.Add(depart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(depart);
        }

        // GET: Depart/Edit/5
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
            Depart depart = db.Departs.Find(id);
            if (depart == null)
            {
                return HttpNotFound();
            }
            return View(depart);
        }

        // POST: Depart/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmanID,DepartmanAD,Durum")] Depart depart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(depart);
        }

        // GET: Depart/Delete/5
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
            Depart depart = db.Departs.Find(id);
            if (depart == null)
            {
                return HttpNotFound();
            }
            return View(depart);
        }

        // POST: Depart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Depart depart = db.Departs.Find(id);
            depart.Durum = false;
         
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
        public ActionResult DepartmanDetay(int id)
        {
            if (Session["Yetki"].ToString() == "Y")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            var deger = db.Persos.Where(i => i.DepartmanID == id).ToList();
            var D = db.Departs.Where(i => i.DepartmanID == id).Select(x => x.DepartmanAD).FirstOrDefault();
            ViewBag.d = D;
            return View(deger);
        }
    }
}
