using LinqToDB.Mapping;

namespace Module5Linq2db.Models
{
	[Table(Name = "Order Details")]
    public class OrderDetail
    {
        [PrimaryKey(1), NotNull] 
        public int OrderID { get; set; } 
        [PrimaryKey(2), NotNull] 
        public int ProductID { get; set; }
        [Column, NotNull] public decimal UnitPrice { get; set; } 
        [Column, NotNull] public short Quantity { get; set; }
        [Column, NotNull] public float Discount { get; set; } 

       
        [Association(ThisKey = "OrderID", OtherKey = "OrderID", 
            CanBeNull = false, 
            Relationship = Relationship.ManyToOne, 
            KeyName = "FK_Order_Details_Orders", 
            BackReferenceName = "OrderDetails")]
        public Order Order { get; set; }

       
        [Association(ThisKey = "ProductID", OtherKey = "ProductID",
            CanBeNull = false, Relationship = Relationship.ManyToOne, 
            KeyName = "FK_Order_Details_Products", 
            BackReferenceName = "OrderDetails")]
        public Product Product { get; set; }

    }
}