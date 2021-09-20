using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Site.Entity;
using Site.Models;

namespace Site.Controllers
{
    public class KFaturalarController : Controller
    {
        private DataContext db = new DataContext();

        // GET: KFaturalar
        public ActionResult Index()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "M")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            return View(db.KFaturalars.ToList());
        }

        // GET: KFaturalar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KFaturalar kFaturalar = db.KFaturalars.Find(id);
            if (kFaturalar == null)
            {
                return HttpNotFound();
            }
            return View(kFaturalar);
        }

        // GET: KFaturalar/Create
        public ActionResult Create()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "M")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            return View();
        }

        // POST: KFaturalar/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FaturaID,FaturaSeriNo,FaturaSıraNo,Tarih,AdetSayısı,VergiDairesi,Toplamtutar,Saat,TeslimEden,TeslimAlan")] KFaturalar kFaturalar)
        {
            if (ModelState.IsValid)
            {
                db.KFaturalars.Add(kFaturalar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kFaturalar);
        }

        // GET: KFaturalar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "M")
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
            KFaturalar kFaturalar = db.KFaturalars.Find(id);
            if (kFaturalar == null)
            {
                return HttpNotFound();
            }
            return View(kFaturalar);
        }

        // POST: KFaturalar/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FaturaID,FaturaSeriNo,FaturaSıraNo,Tarih,AdetSayısı,VergiDairesi,Toplamtutar,Saat,TeslimEden,TeslimAlan")] KFaturalar kFaturalar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kFaturalar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kFaturalar);
        }

        // GET: KFaturalar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KFaturalar kFaturalar = db.KFaturalars.Find(id);
            if (kFaturalar == null)
            {
                return HttpNotFound();
            }
            return View(kFaturalar);
        }

        // POST: KFaturalar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KFaturalar kFaturalar = db.KFaturalars.Find(id);
            db.KFaturalars.Remove(kFaturalar);
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
        public ActionResult FaturaGelen()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "M")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            var model = db.Order1s.Where(x => x.OrderState == OrderState.Kargolandı).Select(i => new AdminOrder1()


            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.OrderLines1.Count
            }).OrderByDescending(i => i.OrderDate).ToList();
            return View(model);
        }
        public ActionResult FaturaDetay(int id)
        {
            var deger = db.FaturaKalems.Where(i => i.FaturaID == id).ToList();
            return View(deger);
        }
        public ActionResult FaturaCikti(int id)
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "M")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            var deger = db.KFaturalars.Where(i => i.FaturaID == id).ToList();
            return View(deger);
        }
    }
}
