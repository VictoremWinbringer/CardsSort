using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FirsPurchase
{
    class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateCreated { get; set; }
    }
    class FirstSale
    {
        public int ProductId { get; set; }
        public int FirstPurchasedCount { get; set; }
    }
    class MyDbContext : DbContext
    {
        static MyDbContext()
        {
            using (var db = new MyDbContext())
            {
                db.Sales.Add(new Sale
                {
                    ProductId =1,
                    CustomerId=1,
                    DateCreated=DateTime.Now
                });
                db.Sales.Add(new Sale
                {
                    ProductId = 2,
                    CustomerId = 1,
                    DateCreated = DateTime.Now
                });
                db.Sales.Add(new Sale
                {
                    ProductId = 3,
                    CustomerId = 3,
                    DateCreated = DateTime.Now
                });
                db.Sales.Add(new Sale
                {
                    ProductId = 3,
                    CustomerId = 4,
                    DateCreated = DateTime.Now
                });
                db.SaveChanges();
            }
        }
        public DbSet<Sale> Sales { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                var arr = db.Sales.Where(x => x.DateCreated == db.Sales.Where(y => y.CustomerId == x.CustomerId).Min(z => z.DateCreated))
                    .GroupBy(a => a.ProductId)
                    .Select(b => new FirstSale
                    {
                        ProductId = b.Key,
                        FirstPurchasedCount = b.Count()
                    }).ToArray();

                foreach (var a in arr)
                {
                    Console.WriteLine($"{a.ProductId} -- {a.FirstPurchasedCount}");

                }
            }
            Console.ReadLine();
        }
    }
}
