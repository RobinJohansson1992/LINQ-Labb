using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LINQ_Labb.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        [Precision(18,2)]
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public int CustomerId { get; set; }


        // Navigation property
        public Customer? Customer { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
