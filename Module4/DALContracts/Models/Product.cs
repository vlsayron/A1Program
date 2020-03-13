﻿using System.ComponentModel.DataAnnotations;

namespace DALContracts.Models
{
    public class Product
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string ProductName { get; set; }

        public Supplier Supplier { get; set; }

        public Category Category { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}
