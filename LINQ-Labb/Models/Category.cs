using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LINQ_Labb.Models
{
    internal class Category
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }

        // Navigation property
        public ICollection<Product>? Products { get; set; }
    }
}
