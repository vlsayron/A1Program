using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Module5Linq2db.Models
{
	public class CustomerDemographic
    {
        [Column(Name = "CustomerTypeID"), PrimaryKey, NotNull] 
        public string Id { get; set; } 
        [Column, Nullable] 
        public string CustomerDesc { get; set; }

       
        [Association(ThisKey = "CustomerTypeID", OtherKey = "CustomerTypeID", 
            CanBeNull = true, 
            Relationship = Relationship.OneToMany, IsBackReference = true)]
        public IEnumerable<CustomerCustomerDemo> CustomerCustomerDemoes { get; set; }

       
    }
}
