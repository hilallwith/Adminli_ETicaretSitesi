using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category (){AD="EDİTÖR", Descrtription="editörün seçtikleri", },
                new Category (){AD="ROMANTİK", Descrtription="FANTASTİK FİLMLER", },
                new Category (){AD="ÖDÜLLÜ", Descrtription="ÖDÜLLÜ FİLMLER", }



    };
            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product (){OAD="wonder Women ",YONET="petty chavges", FIYAT=10 , IsHome=true, IsApproved=true, IsFeatured=false,Slider=true, CategoryID=1 ,RESIM="1.jpg"  },
                new Product (){OAD="Batman ",YONET="petty chavges", FIYAT=18 , IsHome=true, IsApproved=true, IsFeatured=true,Slider=true, CategoryID=2 ,RESIM="2.jpg"   },
               new Product (){OAD="Hulk ",YONET="petty chavges", FIYAT=14 , IsHome=false, IsApproved=true, IsFeatured=false,Slider=false, CategoryID=1 ,RESIM="1.jpg"   },
               new Product (){OAD="superman ",YONET="petty chavges", FIYAT=13 , IsHome=true, IsApproved=true, IsFeatured=true,Slider=true, CategoryID=1 ,RESIM="2.jpg"   }
            };

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();





            var admin = new List<Admin>()
            {
                new Admin (){KullaniciAD="mehmet", Sifre="123456",Yetki="yönetici" },
                new Admin (){KullaniciAD="selma", Sifre="654321",Yetki="yönetici" }



    };
            foreach (var adminler in admin)
            {
                context.Admins.Add(adminler);
            }


            var Depart = new List<Depart>()
            {
                new Depart (){DepartmanAD="Satış", Durum=true},
                new Depart (){DepartmanAD="Muhasebe", Durum=true}



    };
            foreach (var depart in Depart)
            {
                context.Departs.Add(depart);
            }

            var personel = new List<Perso>()
            {
                new Perso (){PersonelAD="cemal",PersonelSoyad="can",PersonelGorsel="test",DepartmanID=2,Mail="cemall@",Telefon="123456"},
               new Perso (){PersonelAD="cemal",PersonelSoyad="can",PersonelGorsel="test",DepartmanID=1},



    };

            var kFaturalar = new List<KFaturalar>()
            {
                new KFaturalar (){FaturaSeriNo="A",FaturaSıraNo="100000",AdetSayısı=3,VergiDairesi="Şişli",Toplamtutar=4,TeslimAlan="A12345",TeslimEden="Ali"}
               



    };
            foreach (var Kfaturalar in kFaturalar)
            {
                context.KFaturalars.Add(Kfaturalar);
            }

            var kullanıcılar = new List<Kullanıcı>()
            {
                new Kullanıcı (){Name="Hilal",Surname="Can",Username="hilall",Durum=true, Email="hilal@com", Password="123456",RePassword="123456" }
                



    };
            foreach (var kullanıcı in kullanıcılar )
            {
                context.Kullanıcıs.Add(kullanıcı);
            }

           




            base.Seed(context);
        }
    }
}