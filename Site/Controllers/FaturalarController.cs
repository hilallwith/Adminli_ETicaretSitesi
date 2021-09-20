using Site.Entity;
using Site.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class FaturalarController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Faturalar
        public ActionResult Index()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "M")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            return View(db.Faturalars.ToList());
        }

        // GET: Faturalar/Details/5
        public ActionResult Details(int? id)
        {
            var model = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetails()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                UserName = i.UserName,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,

                Adres = i.Adres,
                Sehir = i.Sehir,
                Semt = i.Semt,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
                OrderLines = i.OrderLines.Select(x => new OrderLineModel()
                {
                    ProductId = x.ProductId,
                    RESIM = x.Product.RESIM,
                    ProductName = x.Product.OAD,
                    Quantity = x.Quantity,
                    FIYAT = x.Product.TOPLAM

                }).ToList()
            }).FirstOrDefault();

            return View(model);

        }

        // GET: Faturalar/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Faturalar/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FaturaID,FaturaSeriNo,FaturaSıraNo,Tarih,VergiDairesi,Toplamtutar,Saat,TeslimEden,TeslimAlan")] Faturalar faturalar)
        {
            if (ModelState.IsValid)
            {
                db.Faturalars.Add(faturalar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faturalar);
        }

        // GET: Faturalar/Edit/5
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
            Faturalar faturalar = db.Faturalars.Find(id);
            if (faturalar == null)
            {
                return HttpNotFound();
            }
            return View(faturalar);
        }

        // POST: Faturalar/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FaturaID,FaturaSeriNo,FaturaSıraNo,Tarih,VergiDairesi,Toplamtutar,Saat,TeslimEden,TeslimAlan")] Faturalar faturalar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faturalar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faturalar);
        }

        // GET: Faturalar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faturalar faturalar = db.Faturalars.Find(id);
            if (faturalar == null)
            {
                return HttpNotFound();
            }
            return View(faturalar);
        }

        // POST: Faturalar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faturalar faturalar = db.Faturalars.Find(id);
            db.Faturalars.Remove(faturalar);
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
        public ActionResult FaturaDetay(int id)
        {
            var model = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetails()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                UserName = i.UserName,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,

                Adres = i.Adres,
                Sehir = i.Sehir,
                Semt = i.Semt,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
                OrderLines = i.OrderLines.Select(x => new OrderLineModel()
                {
                    ProductId = x.ProductId,
                    RESIM = x.Product.RESIM,
                    ProductName = x.Product.OAD,
                    Quantity = x.Quantity,
                    FIYAT = x.Product.TOPLAM

                }).ToList()
            }).FirstOrDefault();

            return View(model);
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
            var model = db.Orders.Where(x => x.OrderState == OrderState.Kargolandı).Select(i => new AdminOrder()


            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.OrderLines.Count
            }).OrderByDescending(i => i.OrderDate).ToList();
            return View(model);

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
            var deger = db.Faturalars.Where(i => i.FaturaID == id).ToList();
            return View(deger);
        }






        public ActionResult Dinamik()
        {
          
            FaturaYeni cs = new FaturaYeni();
            cs.deger1 = db.Faturalars.ToList();
            cs.deger2 = db.Orders.ToList();
            

            return View(cs);
        }
        public ActionResult FaturaKaydet(string FaturaSeriNo , string FaturaSıraNo,string Tarih, string VergiDairesi, string saat,
            string TeslimEden,string TeslimAlan, string Toplamtutar)
        {

            Faturalar f = new Faturalar();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSıraNo = FaturaSıraNo;
           
            f.VergiDairesi = VergiDairesi;
            f.Saat = saat;
            f.TeslimAlan = TeslimAlan;
            f.TeslimEden = TeslimEden;
            f.Toplamtutar =decimal.Parse( Toplamtutar);
            db.Faturalars.Add(f);
            db.SaveChanges();
            return Json("İşlem Başarılı ", JsonRequestBehavior.AllowGet);
        }

















    }
}
