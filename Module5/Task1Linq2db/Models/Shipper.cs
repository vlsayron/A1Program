using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Task1Linq2DB.Models
{
	[Table(Schema = "dbo", Name = "Shippers")]
    public class Shipper
    {
        [Column(Name = "ShipperID"), PrimaryKey, NotNull] 
        public int Id { get; set; } 
        [Column, NotNull] 
        public string CompanyName { get; set; } 
        [Column, Nullable] 
        public string Phone { get; set; } 

       
        [Association(ThisKey = "ShipperID", OtherKey = "ShipVia", 
            CanBeNull = true, 
            Relationship = Relationship.OneToMany, 
            IsBackReference = true)]
        public IEnumerable<Order> Orders { get; set; }

        
    }
}