using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Labb.Models
{
    internal class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }


        // Navigation property
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
