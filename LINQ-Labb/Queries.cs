using LINQ_Labb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Labb
{
    internal class Queries
    {
        //Hämta alla produkter i kategorin "Electronics" och sortera dem efter pris (högst först)
        public static void SortedElectronicProducts()
        {
            Console.Clear();
            using (var context = new EShopContext())
            {
                var electronicProducts = context.Products
                    .Where(p => p.Category.Name == "Electronics")
                    .OrderByDescending(p => p.Price)
                    .ToList();

                foreach (var e in electronicProducts)
                {
                    Console.WriteLine($"Produkt: {e.Name}");
                    Console.WriteLine($"Pris: {e.Price}");
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
        //Lista alla leverantörer som har produkter med ett lagersaldo under 10 enheter
        public static void FilteredSuppliers()
        {
            Console.Clear();
            using (var context = new EShopContext())
            {
                var lowStock = 10;

                var suppliers = context.Suppliers
                    .Include(s => s.Products)
                    .Where(s => s.Products.Any(p => p.StockQuantity < lowStock))
                    .ToList();

                foreach (var s in suppliers)
                {
                    var lowStockProducts = s.Products
                        .Where(p => p.StockQuantity < lowStock)
                        .ToList();

                    Console.WriteLine($"{s.Name}: ");
                    foreach (var p in lowStockProducts)
                    {
                        Console.WriteLine($"{p.Name} - Lagersaldo: {p.StockQuantity} st.");
                    }
                    ;
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
        //Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden
        public static void TotalOrderAmount()
        {
            Console.Clear();
            using (var context = new EShopContext())
            {
                var totalAmount = context.Orders
                    .Where(o => o.OrderDate >= DateTime.Now.AddDays(-30))
                    .Sum(o => o.TotalAmount);

                Console.WriteLine($"Det totala ordervädret senaste månaden är {totalAmount} kr. ");
            }
            Console.ReadKey();
        }
        //Hitta de 3 mest sålda produkterna baserat på OrderDetail-data
        public static void MostSoldProducts()
        {
            Console.Clear();
            using (var context = new EShopContext())
            {
                var popularProducts = context.OrderDetails
                    .GroupBy(od => od.ProductId)
                    .Select(g => new
                    {
                        ProductId = g.Key,
                        TotalSold = g.Sum(od => od.Quantity)
                    })
                    .OrderByDescending(p => p.TotalSold)
                    .Join(
                    context.Products,
                    x => x.ProductId,
                    p => p.Id,
                    (x, p) => new
                    {
                        ProductName = p.Name,
                        x.TotalSold
                    }
                    )
                    .Take(3)
                    .ToList();

                foreach (var product in popularProducts)
                {
                    Console.WriteLine($"{product.ProductName}: {product.TotalSold} sålda.");
                }
            }
            Console.ReadKey();
        }
        //Lista alla kategorier och antalet produkter i varje kategori
        public static void CategoryProductCount()
        {
            using (var context = new EShopContext())
            {
                Console.Clear();
                var categories = context.Categories
                    .Include(c => c.Products)
                    .Select(c => new
                    {
                        CategoryName = c.Name,
                        ProductCount = c.Products.Count
                    }).ToList();

                foreach(var c in categories)
                {
                    Console.WriteLine($"{c.CategoryName}: {c.ProductCount} produkter.");
                }
                Console.ReadKey();
            }
        }
        //Hämta alla ordrar med tillhörande kunduppgifter
        //och orderdetaljer där totalbeloppet överstiger 1000 kr
        public static void PrintOrdersWithDetails()
        {
            Console.Clear();
            using (var context = new EShopContext())
            {
                var orders = context.Orders
                    .Include(o => o.OrderDetails)
                    .Select(o => new
                    {
                        OrderId = o.Id,
                        OrderDate = o.OrderDate,
                        OrderStatus = o.Status,
                        TotalAmount = o.TotalAmount,
                        Customer = o.Customer.Name,
                        CustomerId = o.CustomerId
                    })
                    .Where(o => o.TotalAmount > 1000)
                    .ToList();

                foreach(var o in orders)
                {
                    Console.WriteLine($"Order ID: {o.OrderId}");
                    Console.WriteLine($"Order lagd: {o.OrderDate}");
                    Console.WriteLine($"Status: {o.OrderStatus}");
                    Console.WriteLine($"Totalbelopp: {o.TotalAmount}");
                    Console.WriteLine($"Kund: {o.Customer}");
                    Console.WriteLine($"Kund ID: {o.CustomerId}");
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
        }
    }
}
