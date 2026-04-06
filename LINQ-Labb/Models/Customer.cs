using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LINQ_Labb.Models
{
    internal class Customer
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [MaxLength(100)]
        public string? Address { get; set; }

        // Navigation property
        public ICollection<Order>? Orders { get; set; }
    }
}
