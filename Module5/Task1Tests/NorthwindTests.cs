using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1Linq2DB;
using Task1Linq2DB.Models;

namespace Task1Tests
{
    [TestClass]
    public class NorthwindTests
    {
        private static DbNorthwind _northwindModel;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            _northwindModel = new DbNorthwind();
        }

        [TestMethod]
        public void GetProductsWithCategoryAndSupplier()
        {
            var result = from p in _northwindModel.Products
                         from c in _northwindModel.Categories
                         from s in _northwindModel.Suppliers
                         where p.CategoryID == c.Id && p.SupplierID == s.Id
                         select new { Product = p.ProductName, Category = c.CategoryName, Supplier = s.CompanyName };

            foreach (var product in result)
            {
                Console.WriteLine($"Product: {product.Product}, category: {product.Category}, supplier: {product.Supplier}");
            }
        }

        [TestMethod]
        public void GetEmployeesWithRegion()
        {
            var result = from e in _northwindModel.Employees
                         where e.Region == "WA"
                         select e;

            foreach (var employee in result)
            {
                Console.WriteLine($"Id: {employee.Id}, name: {employee.FirstName} {employee.LastName}" +
                                  $"title: {employee.Title}, region: {employee.Region}");
            }
        }

        [TestMethod]
        public void GetRegionsAndEmployees()
        {
            var result = from e in _northwindModel.Employees
                        group e by e.City into g
                        select new { City = g.Key, Count = g.Count() };

            foreach (var employee in result)
            {
                Console.WriteLine($"City: {employee.City}, Count of employees: {employee.Count}");
            }
        }

        [TestMethod]
        public void GetEmployeesAndShippers()
        {
            var result = from e in _northwindModel.Employees
                        from o in _northwindModel.Orders
                        from s in _northwindModel.Shippers
                        where o.EmployeeID == e.Id && o.ShipVia == s.Id
                        select new { Employee = e.FirstName, Order = o.Id, Shipper = s.CompanyName };

            foreach (var employee in result)
            {
                Console.WriteLine($"Employee: {employee.Employee} with order No: {employee.Order} worked with Shipper: {employee.Shipper}");
            }
        }

        [TestMethod]
        public void AddEmployeeWithTerritory()
        {
            _northwindModel.Employees
                .Value(p => p.FirstName, "First Name")
                .Value(p => p.LastName, "Last Name")
                .Value(p => p.Title, "Representative")
                .Value(p => p.Region, "WA").InsertWithInt32Identity();
        }

        [TestMethod]
        public void MoveProductToAnotherCategory()
        {
            _northwindModel.Products
                .Where(p => p.Id == 11)
                .Set(p => p.CategoryID, 3)
                .Update();
        }

        [TestMethod]
        public void AddListOfProductsWithSupplierAndCategory()
        {
            var list = new List<Product>()
            {
                new Product() { ProductName = "Product Name 1", 
                    CategoryID = _northwindModel.Categories.First(c=>c.Id == 1).Id, 
                    SupplierID = _northwindModel.Suppliers.First(s=>s.Id==2).Id, 
                    QuantityPerUnit = "100 m",
                    UnitPrice = 123,
                    UnitsInStock = 10,
                    UnitsOnOrder = 1,
                    ReorderLevel = 10,
                    Discontinued = true},

                new Product() { ProductName = "Product Name 2",
                    CategoryID = _northwindModel.Categories.First(c=>c.Id == 2).Id,
                    SupplierID = _northwindModel.Suppliers.First(s=>s.Id==3).Id,
                    QuantityPerUnit = "200 m",
                    UnitPrice = 234,
                    UnitsInStock = 20,
                    UnitsOnOrder = 2,
                    ReorderLevel = 20,
                    Discontinued = true},

                new Product() { ProductName = "Product Name 3",
                    CategoryID = _northwindModel.Categories.First(c=>c.Id == 3).Id,
                    SupplierID = _northwindModel.Suppliers.First(s=>s.Id==4).Id,
                    QuantityPerUnit = "300 m",
                    UnitPrice = 345,
                    UnitsInStock = 30,
                    UnitsOnOrder = 3,
                    ReorderLevel = 30,
                    Discontinued = true},

            };

            _northwindModel.BulkCopy(list);
        }

        [TestMethod]
        public void ChangeProduct()
        {
            var orders = from o in _northwindModel.Orders
                         where o.ShippedDate == null
                         select o;
            var result = orders.ToList();

            var notShippedOrders = from od in _northwindModel.OrderDetails
                                   where od.OrderID == result.Select(x => x.Id).FirstOrDefault()
                                   select od;
           
            var forReplacement = notShippedOrders.ToList();

            foreach (var item in forReplacement)
            {
                item.ProductID = 12;
            }

            _northwindModel.OrderDetails
                .Where(p => p.OrderID == notShippedOrders.Select(x => x.OrderID).FirstOrDefault())
                .Delete();

            foreach (var unit in forReplacement)
            {
                _northwindModel.OrderDetails.Value(p => p.OrderID, unit.OrderID)
                                       .Value(p => p.ProductID, unit.ProductID)
                                       .Value(p => p.Quantity, unit.Quantity).Insert();
            }

        }
    }
}
