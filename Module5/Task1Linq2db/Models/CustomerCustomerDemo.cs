using LinqToDB.Mapping;

namespace Task1Linq2db.Models
{
	[Table(Name = "CustomerCustomerDemo")]
    public class CustomerCustomerDemo
    {
        [PrimaryKey(1), NotNull] 
        public string CustomerID { get; set; }
        [PrimaryKey(2), NotNull] 
        public string CustomerTypeID { get; set; }

       
        [Association(ThisKey = "CustomerID", OtherKey = "CustomerID", 
            CanBeNull = false, 
            Relationship = Relationship.ManyToOne, 
            KeyName = "FK_CustomerCustomerDemo_Customers", 
            BackReferenceName = "CustomerCustomerDemoes")]
        public Customer Customer { get; set; }

       
        [Association(ThisKey = "CustomerTypeID", OtherKey = "CustomerTypeID", 
            CanBeNull = false, 
            Relationship = Relationship.ManyToOne, 
            KeyName = "FK_CustomerCustomerDemo", 
            BackReferenceName = "CustomerCustomerDemoes")]
        public CustomerDemographic CustomerType { get; set; }


    }
}
