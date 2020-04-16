using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Module5Linq2db.Models
{
	[Table(Name = "Products")]
    public class Product
    {
        [Column(Name = "ProductID"), PrimaryKey, NotNull] 
        public int Id { get; set; } 
        [Column, NotNull] 
        public string ProductName { get; set; } 
        [Column, Nullable] 
        public int? SupplierID { get; set; } 
        [Column, Nullable] 
        public int? CategoryID { get; set; } 
        [Column, Nullable] 
        public string QuantityPerUnit { get; set; } 
        [Column, Nullable] 
        public decimal? UnitPrice { get; set; } 
        [Column, Nullable] 
        public short? UnitsInStock { get; set; }
        [Column, Nullable] 
        public short? UnitsOnOrder { get; set; } 
        [Column, Nullable] 
        public short? ReorderLevel { get; set; } 
        [Column, NotNull] 
        public bool Discontinued { get; set; } 

       
        [Association(ThisKey = "CategoryID", OtherKey = "CategoryID", 
            CanBeNull = true, 
            Relationship = Relationship.ManyToOne, 
            KeyName = "FK_Products_Categories", 
            BackReferenceName = "Products")]
        public Category Category { get; set; }

       
        [Association(ThisKey = "ProductID", OtherKey = "ProductID", 
            CanBeNull = true, 
            Relationship = Relationship.OneToMany, 
            IsBackReference = true)]
        public IEnumerable<OrderDetail> OrderDetails { get; set; }

       
        [Association(ThisKey = "SupplierID", OtherKey = "SupplierID", 
            CanBeNull = true, 
            Relationship = Relationship.ManyToOne, 
            KeyName = "FK_Products_Suppliers", 
            BackReferenceName = "Products")]
        public Supplier Supplier { get; set; }

        
    }
}