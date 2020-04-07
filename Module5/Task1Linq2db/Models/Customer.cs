using System.Collections.Generic;
using LinqToDB.Mapping;
using Task1Linq2DB.Models;

namespace Task1Linq2db.Models
{
    [Table(Name = "Customers")]
    public class Customer
    {
        
        [Column(Name = "CustomerID"), PrimaryKey, NotNull]
        public string Id { get; set; }
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

       
        [Association(ThisKey = "CustomerID", OtherKey = "CustomerID",
            CanBeNull = true, 
            Relationship = Relationship.OneToMany, 
            IsBackReference = true)]
        public IEnumerable<CustomerCustomerDemo> CustomerCustomerDemoes { get; set; }

        [Association(ThisKey = "CustomerID", OtherKey = "CustomerID", 
            CanBeNull = true, 
            Relationship = Relationship.OneToMany, 
            IsBackReference = true)]
        public IEnumerable<Order> Orders { get; set; }

    }
}
