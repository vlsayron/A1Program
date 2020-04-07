﻿using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using Task1Linq2db.Models;

namespace Task1Linq2DB.Models
{
	[Table(Name = "Orders")]
	public class Order
	{
        [Column(Name = "OrderID"), PrimaryKey, NotNull] 
        public int Id { get; set; } 
		[Column, Nullable] 
        public string CustomerID { get; set; } 
		[Column, Nullable] 
        public int? EmployeeID { get; set; } 
		[Column, Nullable] 
        public DateTime? OrderDate { get; set; }
		[Column, Nullable] 
        public DateTime? RequiredDate { get; set; }
		[Column, Nullable]
        public DateTime? ShippedDate { get; set; }
		[Column, Nullable] 
        public int? ShipVia { get; set; } 
		[Column, Nullable] 
        public decimal? Freight { get; set; } 
		[Column, Nullable] 
        public string ShipName { get; set; } 
		[Column, Nullable]
        public string ShipAddress { get; set; } 
		[Column, Nullable] 
        public string ShipCity { get; set; } 
		[Column, Nullable] 
        public string ShipRegion { get; set; }
		[Column, Nullable] 
        public string ShipPostalCode { get; set; } 
		[Column, Nullable] 
        public string ShipCountry { get; set; } 

		
		[Association(ThisKey = "CustomerID", OtherKey = "CustomerID", 
            CanBeNull = true, 
            Relationship = Relationship.ManyToOne, 
            KeyName = "FK_Orders_Customers", 
            BackReferenceName = "Orders")]
		public Customer Customer { get; set; }

		
		[Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID", 
            CanBeNull = true, 
            Relationship = Relationship.ManyToOne, 
            KeyName = "FK_Orders_Employees", 
            BackReferenceName = "Orders")]
		public Employee Employee { get; set; }

		
		[Association(ThisKey = "OrderID", OtherKey = "OrderID", 
            CanBeNull = true, 
            Relationship = Relationship.OneToMany, 
            IsBackReference = true)]
		public IEnumerable<OrderDetail> OrderDetails { get; set; }

		
		[Association(ThisKey = "ShipVia", OtherKey = "ShipperID", 
            CanBeNull = true, 
            Relationship = Relationship.ManyToOne, 
            KeyName = "FK_Orders_Shippers", 
            BackReferenceName = "Orders")]
		public Shipper Shipper { get; set; }

		
	}
}