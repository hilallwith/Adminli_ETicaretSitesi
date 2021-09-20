using Site.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori-Film stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Editör", "Korku", "Romantik" },
                yValues: new[] { 300, 140, 200 }

            ).Write();

            return File(grafikciz.ToWebImage().GetBytes(),"image/jpeg");
        }
        DataContext db = new DataContext();

        public ActionResult Index3()
        {

            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();

            var sonuclar = db.Products.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.OAD));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.TOPLAM));
            var grafik = new Chart(width: 800, height: 800).AddTitle("Stoklar").AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);


            return File(grafik.ToWebImage().GetBytes(),"image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {

            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);



        }
        public List<grafik> UrunListesi()
        {
            List<grafik> cls = new List<grafik>();

            using (var c=new DataContext())
            {
                cls = c.Products.Select(x => new grafik
                {
                    Urnad = x.OAD,
                    stk=x.TOPLAM
                    
                }).ToList();

            }

            return cls;


        }

        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult1()
        {

            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);



        }
        public List<grafik2> UrunListesi2()
        {
            List<grafik2> cls1 = new List<grafik2>();

            using (var cd = new DataContext())
            {
                cls1 = cd.Products.Select(x => new grafik2
                {
                    Urnad = x.OAD,
                    fiyat = x.FIYAT

                }).ToList();

            }

            return cls1;


        }
        public ActionResult Index6()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult2()
        {

            return Json(UrunListesi3(), JsonRequestBehavior.AllowGet);



        }
        public List<grafik3> UrunListesi3()
        {
            List<grafik3> cls1 = new List<grafik3>();

            using (var cd = new DataContext())
            {
                cls1 = cd.Products.Select(x => new grafik3
                {
                    Urnad = x.OAD,
                    fiyat = x.PIXEL

                }).ToList();

            }

            return cls1;


        }
        public ActionResult Index7()
        {
            return View();
        }


        public ActionResult VisualizeUrunResult3()
        {

            return Json(UrunListesi4(), JsonRequestBehavior.AllowGet);



        }
        public List<grafik4> UrunListesi4()
        {
            List<grafik4> cls1 = new List<grafik4>();

            using (var cd = new DataContext())
            {
                cls1 = cd.Categories.Select(x => new grafik4
                {
                    ad=x.AD,
                   


                }).ToList();

            }

            return cls1;


        }
        public ActionResult Index8()
        {
            return View();
        }



        public ActionResult Index9()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult4()
        {

            return Json(UrunListesi5(), JsonRequestBehavior.AllowGet);



        }
        public List<grafik5> UrunListesi5()
        {
            List<grafik5> cls1 = new List<grafik5>();

            using (var cd = new DataContext())
            {
                cls1 = cd.Products.Select(x => new grafik5
                {
                    Urnad = x.OAD,
                    satisA = x.artis4

                }).ToList();

            }

            return cls1;


        }

        public ActionResult GrafikCikti()
        {
            if (Session["Yetki"].ToString() == "Y" || Session["Yetki"].ToString() == "M")
            {

            }
            else
            {
                return RedirectToAction("PageError", "Error");
            }
            var deger = db.OrderLines.ToList();
            return View(deger);
        }
        public ActionResult print()
        {

            return View();
        }










        public ActionResult Index10()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult5()
        {

            return Json(UrunListesi6(), JsonRequestBehavior.AllowGet);



        }
        public List<grafik10> UrunListesi6()
        {
            List<grafik10> cls1 = new List<grafik10>();

            using (var cd = new DataContext())
            {
                cls1 = cd.Products.Select(x => new grafik10
                {
                    Urnad = x.OAD,
                    satis = x.artis1

                }).ToList();

            }

            return cls1;


        }





        public ActionResult Index11()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult6()
        {

            return Json(UrunListesi7(), JsonRequestBehavior.AllowGet);



        }
        public List<grafik6> UrunListesi7()
        {
            List<grafik6> cls1 = new List<grafik6>();

            using (var cd = new DataContext())
            {
                cls1 = cd.Products.Select(x => new grafik6
                {
                    Urnad = x.OAD,
                    kiralamaF = x.artis2

                }).ToList();

            }

            return cls1;


        }


        public ActionResult Index12()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult7()
        {

            return Json(UrunListesi8(), JsonRequestBehavior.AllowGet);



        }
        public List<grafik11> UrunListesi8()
        {
            List<grafik11> cls1 = new List<grafik11>();

            using (var cd = new DataContext())
            {
                cls1 = cd.Products.Select(x => new grafik11
                {
                    Urnad = x.OAD,
                    kiralamaA = x.artis3

                }).ToList();

            }

            return cls1;


        }








    }
}