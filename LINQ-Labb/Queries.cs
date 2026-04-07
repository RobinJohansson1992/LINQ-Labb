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
        }
        //Lista alla leverantörer som har produkter med ett lagersaldo under 10 enheter
        public static void FilteredSuppliers()
        {
            using (var context = new EShopContext())
            {
                var lowInStock = 10;

                var suppliers = context.Suppliers
                    .Include(s => s.Products)
                    .Where(s => s.Products.Any(p => p.StockQuantity < lowInStock))
                    .ToList();

                foreach (var s in suppliers)
                {
                    var lowStockProducts = s.Products.Where(p => p.StockQuantity < lowInStock).ToList();
                    
                    Console.WriteLine($"{s.Name}: ");
                    foreach (var p in lowStockProducts)
                    {
                        Console.WriteLine($"{p.Name}: {p.StockQuantity} i lager");
                    };
                    Console.WriteLine();
                }
            }
        }
    }
}
