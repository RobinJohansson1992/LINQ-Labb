using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LINQ_Labb.Models
{
    internal class Product
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        // Navigation properties
        public Category? Category { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
