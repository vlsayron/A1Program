using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Module5Linq2db.Models
{
	[Table(Schema = "dbo", Name = "Suppliers")]
    public class Supplier
    {
        [Column(Name = "SupplierID"), PrimaryKey, NotNull]
        public int Id { get; set; }
        [Column, NotNull] 
        public string CompanyName { get; set; }
        [Column, Nullable] 
        public string ContactName { get; set; } 
        [Column, Nullable] 
        public string ContactTitle { get; set; } 
        [Column, Nullable] 
        public string Address { get; set; } 
        [Column, Nullable] 
        public string City { get; set; }
        [Column, Nullable] 
        public string Region { get; set; } 
        [Column, Nullable] 
        public string PostalCode { get; set; } 
        [Column, Nullable] 
        public string Country { get; set; } 
        [Column, Nullable] 
        public string Phone { get; set; } 
        [Column, Nullable] 
        public string Fax { get; set; } 
        [Column, Nullable] 
        public string HomePage { get; set; } 

       
        [Association(ThisKey = "SupplierID", OtherKey = "SupplierID", 
            CanBeNull = true, 
            Relationship = Relationship.OneToMany, 
            IsBackReference = true)]
        public IEnumerable<Product> Products { get; set; }

        
    }
}