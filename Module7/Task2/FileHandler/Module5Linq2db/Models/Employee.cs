using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Module5Linq2db.Models
{
	[Table(Name = "Employees")]
	public class Employee
	{
        [Column(Name = "EmployeeID"), PrimaryKey, NotNull] 
        public int Id { get; set; } 
		[Column, NotNull] 
        public string LastName { get; set; } 
		[Column, NotNull] 
        public string FirstName { get; set; }
		[Column, Nullable] 
        public string Title { get; set; } 
		[Column, Nullable] 
        public string TitleOfCourtesy { get; set; } 
		[Column, Nullable] 
        public DateTime? BirthDate { get; set; } 
		[Column, Nullable] 
        public DateTime? HireDate { get; set; } 
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
        public string HomePhone { get; set; } 
		[Column, Nullable] 
        public string Extension { get; set; } 
		[Column, Nullable] 
        public byte[] Photo { get; set; } 
		[Column, Nullable] 
        public string Notes { get; set; } 
		[Column, Nullable] 
        public int? ReportsTo { get; set; } 
		[Column, Nullable] 
        public string PhotoPath { get; set; } 

		
		[Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID", 
            CanBeNull = true, 
            Relationship = Relationship.OneToMany, 
            IsBackReference = true)]
		public IEnumerable<EmployeeTerritory> EmployeeTerritories { get; set; }

		
		[Association(ThisKey = "ReportsTo", OtherKey = "EmployeeID", 
            CanBeNull = true, 
            Relationship = Relationship.ManyToOne, 
            KeyName = "FK_Employees_Employees", 
            BackReferenceName = "FkEmployeesEmployeesBackReferences")]
		public Employee FkEmployeesEmployee { get; set; }

		
		[Association(ThisKey = "EmployeeID", OtherKey = "ReportsTo", 
            CanBeNull = true, 
            Relationship = Relationship.OneToMany, 
            IsBackReference = true)]
		public IEnumerable<Employee> FkEmployeesEmployeesBackReferences { get; set; }

		
		[Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID",
            CanBeNull = true, 
            Relationship = Relationship.OneToMany, 
            IsBackReference = true)]
		public IEnumerable<Order> Orders { get; set; }

		
	}
}