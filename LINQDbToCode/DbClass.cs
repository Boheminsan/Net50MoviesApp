using LINQDbToCode.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQDbToCode
{
    namespace DbClass
    {
        public class ProductModel
        {
            public int ProductId { get; set; }

            public string Name { get; set; }
            public decimal? Price { get; set; }
            //public int Quantity { get; set; }
        }

        public class CustomerModel
        {
            public string CustomerId { get; set; }
            public string CustomerName { get; set; }
            public int OrderCount { get; set; }
            public List<OrderModel> Orders { get; set; }
        }
        public class OrderModel
        {
            public int OrderId { get; set; }
            public decimal Total { get; set; }
            public List<ProductModel> Products { get; set; }
        }

        public class Dersler
        {
            public static void Ders1SelectWhere(NorthWindContext db)
            {
                var products = db.Products.ToList();
                Console.WriteLine("1. Product:");
                foreach (var p in products)
                {
                    Console.WriteLine(p.ProductName + ", " + p.UnitPrice);
                }

                var products2 = db.Products.Select(p => new ProductModel { Name = p.ProductName, Price = p.UnitPrice }).ToList();
                Console.WriteLine("2. Product:");
                foreach (var p in products2)
                {
                    Console.WriteLine(p.Name + ", " + p.Price);
                }

                var singleProduct = db.Products.First();
                Console.WriteLine("First ile 1. Tek urun = " + singleProduct.ProductName + ", " + singleProduct.UnitPrice);

                var singleProduct2 = db.Products.Select(p => new { p.ProductName, p.UnitPrice }).FirstOrDefault();
                Console.WriteLine("FindOrDefautl ile 2. Tek urun = " + singleProduct2.ProductName + ", " + singleProduct2.UnitPrice);

                var products3 = db.Products.Select(p => new { p.ProductName, p.UnitPrice, p.CategoryId }).Where(p => p.UnitPrice > 18 && p.UnitPrice <= 30 && p.CategoryId == 2).ToList();
                Console.WriteLine("3. Product:");
                foreach (var p in products3)
                {
                    Console.WriteLine(p.ProductName + ", " + p.UnitPrice);
                }

                var products4 = db.Products.Where(p => p.CategoryId == 1).Select(p => new { p.ProductName, p.UnitPrice, p.CategoryId });
                Console.WriteLine("4. Product:");
                foreach (var p in products4)
                {
                    Console.WriteLine(p.ProductName + ", " + p.UnitPrice);
                }

                var products5 = db.Products.Where(i => i.ProductName.Contains("Sauce")).ToList();
                Console.WriteLine("5. Product:");
                foreach (var p in products5)
                {
                    Console.WriteLine(p.ProductName);
                }
            }
            public static void Ders2Alistirmalar(NorthWindContext db)
            {
                var customers = db.Customers.ToList();
                Console.WriteLine("Customers:");
                foreach (var p in customers)
                {
                    Console.WriteLine(p.ContactName + ", " + p.ContactTitle + ", " + p.Country + ", " + p.Region);
                }

                var customers2 = db.Customers.Select(p => new { p.CustomerId, p.ContactName }).ToList();
                Console.WriteLine("CustomerId ContactName:");
                foreach (var p in customers2)
                {
                    Console.WriteLine(p.CustomerId + ", " + p.ContactName);
                }

                var customers3 = db.Customers.Select(p => new { p.ContactName, p.Country }).Where(p => p.Country == "Germany").ToList();
                Console.WriteLine("Germany:");
                foreach (var p in customers3)
                {
                    Console.WriteLine(p.ContactName);
                }

                var customers4 = db.Customers.Where(p => p.ContactName == "Diego Roel").FirstOrDefault();

                Console.WriteLine("Diego Roel, " + customers4.Country + "'de/da yaşıyor.");


                var products = db.Products.Select(p => new { p.ProductName, p.UnitsInStock }).Where(p => p.UnitsInStock == 0).ToList();
                Console.WriteLine("Out of Stock:");
                foreach (var p in products)
                {
                    Console.WriteLine(p.ProductName);
                }

                var staff = db.Employees.Select(p => new { FullName = p.FirstName + " " + p.LastName }).ToList();
                Console.WriteLine("Employees:");
                foreach (var p in staff)
                {
                    Console.WriteLine(p.FullName);
                }

                var products2 = db.Products.Take(5).ToList();
                Console.WriteLine("Top 5:");
                foreach (var p in products2)
                {
                    Console.WriteLine(p.ProductName);
                }
                var products3 = db.Products.Skip(5).Take(5).ToList();
                Console.WriteLine("Second Top 5:");
                foreach (var p in products3)
                {
                    Console.WriteLine(p.ProductName);
                }
            }
            public static void Ders3CountOrderBy(NorthWindContext db)
            {
                var result1 = db.Products.Count();
                Console.WriteLine("Urun sayisi= " + result1);
                var result2 = db.Products.Count(i => i.UnitPrice > 15 && i.UnitPrice < 40);
                Console.WriteLine("15<x<40 urun sayisi= " + result2);
                var result3 = db.Products.Count(i => !i.Discontinued);
                Console.WriteLine("Devam eden urun sayisi= " + result3);
                var result4 = db.Products.Min(i => i.UnitPrice);
                Console.WriteLine("En dusuk fiyat= " + result4);
                var result5 = db.Products.Max(i => i.UnitPrice);
                Console.WriteLine("En yuksek fiyat= " + result5);
                var result6 = db.Products.Where(i => i.CategoryId == 3).Max(i => i.UnitPrice);
                Console.WriteLine("3. kategorinin en yuksek fiyati=" + result6);
                var result7 = db.Products.Where(i => !i.Discontinued).Average(i => i.UnitPrice);
                Console.WriteLine("Devam eden urunlerin ortalamasi= " + result7);
                var result8 = db.Products.Where(i => !i.Discontinued).Sum(i => i.UnitPrice);
                Console.WriteLine("Devam eden urunlerin toplam fiyati=" + result8);
                var result9 = db.Products.OrderBy(i => i.UnitPrice).ToList();
                Console.WriteLine("Fiyata gore artan sirali liste");
                foreach (var item9 in result9)
                {
                    Console.WriteLine(item9.ProductName + " " + item9.UnitPrice);
                }
                var result10 = db.Products.OrderByDescending(i => i.UnitPrice).ToList();
                Console.WriteLine("Fiyata gore azalan sirali liste");

                foreach (var item10 in result10)
                {
                    Console.WriteLine(item10.ProductName + " " + item10.UnitPrice);
                }
                var result11 = db.Products.OrderByDescending(i => i.UnitPrice).LastOrDefault();
                Console.WriteLine("Fiyata gore azalan listeden en alttakini getirir (en ucuz)" + result11.ProductName + " " + result11.UnitPrice);

            }
            public static void Ders4Add(NorthWindContext db)
            {
                var p1 = new Product()
                {
                    ProductName = "Tavuk Döner",
                    UnitPrice = 5.50M,
                    UnitsInStock = 1500,
                    CategoryId = 2
                };
                var p2 = new Product()
                {
                    ProductName = "Et Döner",
                    UnitPrice = 25.50M,
                    UnitsInStock = 1500,
                    CategoryId = 1
                };
                var p3 = new Product()
                {
                    ProductName = "Cağ Kebabı",
                    UnitPrice = 25.50M,
                    UnitsInStock = 100,
                    CategoryId = 1
                };
                var products = new List<Product>()
            {
                p1,p2,p3
            };
                var category = db.Categories.Where(i => i.CategoryName == "Produce").FirstOrDefault();
                category.Products.Add(p1);
                category.Products.Add(p2);
                category.Products.Add(p3);
                //db.Products.AddRange(products);
                db.SaveChanges();
                Console.WriteLine("Veri eklendi." + p1.ProductName);
                Console.WriteLine("Veri eklendi." + p2.ProductName);
                Console.WriteLine("Veri eklendi." + p3.ProductName);
                Console.WriteLine("Yeni eklendi.");
                Console.WriteLine("Yeni veri daha yeni eklendi.");
            }
            public static void Ders6Delete(NorthWindContext db)
            {
                var p = db.Products.Find(89);
                if (p != null)
                {
                    db.Products.Remove(p);
                    db.SaveChanges();
                }

                //metot2
                var p2 = new Product() { ProductId = 90 };
                db.Entry(p2).State = EntityState.Deleted;
                db.SaveChanges();

                //çoklu silme
                var p3 = new Product() { ProductId = 92 };
                var p4 = new Product() { ProductId = 93 };
                var p5 = new Product() { ProductId = 94 };

                var delproducts = new List<Product>() { p3, p4, p5 };
                db.RemoveRange(delproducts);
                db.SaveChanges();
            }
            public static void Ders7BirdenCok1(NorthWindContext db)
            {
                //var products = db.Products.Where(p => p.Category.CategoryName == "Beverages"); // CategoryName çağırırsan NullReferenceException hatası fırlatır.
                var products1 = db.Products.Include(p => p.Category).Where(p => p.Category.CategoryName == "Beverages");
                Console.WriteLine("Left Join");
                foreach (var p1 in products1)
                {
                    Console.WriteLine(p1.ProductName + " " + p1.CategoryId + " " + p1.Category.CategoryName);
                }

                var products2 = db.Products
                    .Where(p => p.Category.CategoryName == "Beverages")
                    .Select(p => new { p.ProductName, p.CategoryId, p.Category.CategoryName });
                Console.WriteLine("Left Join");
                foreach (var p2 in products2)
                {
                    Console.WriteLine(p2.ProductName + " " + p2.CategoryId + " " + p2.CategoryName);
                }
                //var categories1 = db.Categories.Where(c => c.Products.Count() == 0).ToList();
                var categories2 = db.Categories.Where(c => !c.Products.Any()).ToList();//yine ürün olmayan kategorileri getirir
                Console.WriteLine("Join Yok");
                foreach (var c in categories2)
                {
                    Console.WriteLine(c.CategoryName);
                }

                var products3 = db.Products
                    .Select(s =>
                    new
                    {
                        s.Supplier.CompanyName,
                        s.Supplier.ContactName,
                        s.ProductName
                    })
                    .ToList();
                Console.WriteLine("Left Join");
                foreach (var p3 in products3)
                {
                    Console.WriteLine(p3.ProductName + " " + p3.CompanyName + " " + p3.ContactName);
                }

                var products4 = (from p4 in db.Products
                                 join s in db.Suppliers on p4.SupplierId equals s.SupplierId
                                 select new
                                 {
                                     p4.ProductName,
                                     s.ContactName,
                                     s.CompanyName
                                 }).ToList();
                Console.WriteLine("Inner Join");

                foreach (var p4 in products3)
                {
                    Console.WriteLine(p4.ProductName + " " + p4.CompanyName + " " + p4.ContactName);
                }
            }
            public static void Ders8BirdenCok2(NorthWindContext db)
            {
                //Müşterilerin verdiği sipariş toplamı?
                var customers = db.Customers
                    .Where(c => c.Orders.Any())
                    .Select(cus => new CustomerModel
                    {
                        CustomerId = cus.CustomerId,
                        CustomerName = cus.ContactName,
                        OrderCount = cus.Orders.Count(),
                        Orders = cus.Orders.Select(o => new OrderModel
                        {
                            OrderId = o.OrderId,
                            Total = o.OrderDetails.Sum(od => od.Quantity * od.UnitPrice),
                            Products = o.OrderDetails.Select(od => new ProductModel
                            {
                                ProductId = od.ProductId,
                                Name = od.Product.ProductName,
                                Price = od.UnitPrice,
                                //Quantity = od.Quantity
                            }).ToList()
                        }).ToList()
                    })
                    .OrderBy(i => i.OrderCount)
                    .ToList();
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.CustomerId + " " + customer.CustomerName + " " + customer.OrderCount);
                    foreach (var ord in customer.Orders)
                    {
                        Console.WriteLine("*******************************");
                        Console.WriteLine(ord.OrderId + " " + ord.Total);
                        foreach (var prd in ord.Products)
                        {
                            Console.WriteLine(prd.ProductId + " " + prd.Name + " " + prd.Price /*+ " " + prd.Quantity*/);
                        }
                    }
                }
                var cust = db.Customers
                    .Where(c => c.CustomerId == "MEREP")
                    .Select(cus => new CustomerModel
                    {
                        CustomerId = cus.CustomerId,
                        CustomerName = cus.ContactName,
                        OrderCount = cus.Orders.Count(),
                        Orders = cus.Orders.Select(o => new OrderModel
                        {
                            OrderId = o.OrderId,
                            Total = o.OrderDetails.Sum(od => /*od.Quantity **/ od.UnitPrice),
                            Products = o.OrderDetails.Select(od => new ProductModel
                            {
                                ProductId = od.ProductId,
                                Name = od.Product.ProductName,
                                Price = od.UnitPrice
                            }).ToList()
                        }).ToList()
                    })
                    .OrderBy(i => i.OrderCount)
                    .ToList();
                foreach (var cus in cust)
                {
                    Console.WriteLine(cus.CustomerId + " " + cus.CustomerName + " " + cus.OrderCount);
                    foreach (var ord in cus.Orders)
                    {
                        Console.WriteLine(ord.OrderId + " " + ord.Total);
                        foreach (var prd in ord.Products)
                        {
                            Console.WriteLine(prd.ProductId + " " + prd.Name + " " + prd.Price);
                        }
                    }
                }

            }
            public static void Ders9RawSql(CustomNorthWindContext db)
            {
                //var sonuc =db.Database.ExecuteSqlRaw("delete from products where ProductID=81");//81 nolu kayıt silinir.                
                //var sonuc = db.Database.ExecuteSqlRaw("update products set UnitPrice=Unitprice*1.2 where CategoryId=4");//4 nolu kategorinin fiyatlarına %20 zam yapıldı.
                //var products = db.Products.FromSqlRaw("select * from products where CategoryId=4").ToList();//4 nolu kategorinin

                //var query = 4;
                //var products = db.Products.FromSqlRaw($"select * from products where CategoryId={query}").ToList();//4 nolu kategorinin ürünleri geldi..
                var products = db.ProductModels.FromSqlRaw("select ProductId, ProductName, UnitPrice from products").ToList();//4 nolu kategorinin ürünleri geldi..
                foreach (var prd in products)
                {
                    Console.WriteLine(prd.ProductId + " " + prd.Name + " " + prd.Price);
                }
            }
        }
    }
}
