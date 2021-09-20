using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Entity
{
    public class DataContext:DbContext
    {
        public DataContext():base("dataConnection")
        {
            Database.SetInitializer(new DataInitializer());

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<order1> Order1s { get; set; }
        public DbSet<OrderLine1> OrderLine1s { get; set; }
        public DbSet<Kullanıcı> Kullanıcıs { get; set; }
       
        public DbSet<KFaturalar> KFaturalars { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cariler> Carilers { get; set; }
       
        public DbSet<Depart> Departs { get; set; }
        public DbSet<Faturalar> Faturalars { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Giderler> Giderlers { get; set; }
        public DbSet<Perso> Persos { get; set; }
        public DbSet<SatisHareket> SatisHarekets { get; set; }
        public DbSet<Mesajlar> Mesajlars { get; set; }
        public DbSet<Yorum>Yorums { get; set; }

     
        public DbSet<GiderHesap> GiderHesaps { get; set; }
        public DbSet<Toplamlar> Toplamlars { get; set; }
       




























    }
}