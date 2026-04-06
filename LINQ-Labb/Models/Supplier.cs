using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LINQ_Labb.Models
{
    internal class Supplier
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(50)]
        public string? ContactPerson { get; set; }
        [MaxLength(50)]
        public string? Email { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }

        // Navigation property
        public ICollection<Product>? Products { get; set; }
    }
}
