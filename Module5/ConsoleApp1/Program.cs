//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using LinqToDB;
//using LinqToDB.Data;
//using Task1Linq2DB;
//using Task1Linq2DB.Models;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            AddListOfProductsWithSupplierAndCategory();

//            Console.WriteLine("!!!!!!");
//            Console.ReadKey();
//        }



//        public static void GetProductsWithCategoryAndSupplier()
//        {
//            using (var connection = new DbNorthwind())
//            {
//                var query = from p in connection.Products
//                            from c in connection.Categories
//                            from s in connection.Suppliers
//                            where p.CategoryId == c.Id && p.SupplierId == s.SupplierId
//                            select new { Product = p.ProductName, Category = c.CategoryName, Supplier = s.CompanyName };
//                foreach (var product in query)
//                    Console.WriteLine($"Product: {product.Product}, Category: {product.Category}, Supplier: {product.Supplier}");
//            };
//        }


//        public static void GetEmployeesWithRegion()
//        {
//            using (var connection = new DbNorthwind())
//            {
//                var query = from e in connection.Employees
//                            where e.Region == "WA"
//                            select e;
//                foreach (var employee in query)
//                    Console.WriteLine($"EmployeeId: {employee.EmployeeId}, Employee First Name: {employee.FirstName}, Employee Last Name: {employee.LastName} " +
//                        $"Employee Title: {employee.Title}, Employee Region: {employee.Region}");
//            };
//        }


//        public static void GetRegionsAndEmployees()
//        {
//            using (var connection = new DbNorthwind())
//            {
//                var query = from e in connection.Employees
//                            group e by e.City into g
//                            select new { City = g.Key, Count = g.Count() };

//                foreach (var employee in query)
//                    Console.WriteLine($"City: {employee.City}, Number of Employees: {employee.Count}");

//            };
//        }


//        public static void GetEmployeesAndShippers()
//        {
//            using (var connection = new DbNorthwind())
//            {
//                var query = from e in connection.Employees
//                            from o in connection.Orders
//                            from s in connection.Shippers
//                            where o.EmployeeId == e.EmployeeId && o.ShipVia == s.ShipperId
//                            select new { Employee = e.FirstName, Order = o.OrderId, Shipper = s.CompanyName };

//                foreach (var employee in query)
//                    Console.WriteLine($"Employee: {employee.Employee} with order No: {employee.Order} worked with Shipper: {employee.Shipper}");
//            };
//        }

//        public static void AddEmployeeWithTerritory()
//        {
//            using (var connection = new DbNorthwind())
//            {
//                connection.Employees
//                    .Value(p => p.FirstName, "First Name")
//                    .Value(p => p.LastName, "Last Name")
//                    .Value(p => p.Title, "Representative")
//                    .Value(p => p.Region, "WA").InsertWithInt32Identity();
//            };
//        }


//        public static void MoveProductToAnotherCategory()
//        {
//            using (var connection = new DbNorthwind())
//            {
//                connection.Products
//                    .Where(p => p.ProductId == 10)
//                    .Set(p => p.CategoryId, 2)
//                    .Update();
//            };
//        }


//        public static void AddListOfProductsWithSupplierAndCategory()
//        {
//            var list = new List<Product>()
//            {
//                new Product() { ProductName = "Product Name1", CategoryId = 3, SupplierId = 15 },
//                new Product() { ProductName = "Product Name2", CategoryId = 35, SupplierId = 18 },
//                new Product() { ProductName = "Product Name3", CategoryId = 11, SupplierId = 33 }
//            };
//            using (var connection = new DbNorthwind())
//            {
//                connection.BulkCopy(list);
//            };
//        }


//        public static void ChangeProduct()
//        {
//            using (var connection = new DbNorthwind())
//            {
//                var orders = from o in connection.Orders
//                             where o.ShippedDate == null
//                             select o;
//                var order = orders.FirstOrDefault();
//                var result = orders.ToList();

//                var notShippedOrders = from od in connection.OrderDetails
//                                       where od.OrderId == result.Select(x => x.OrderId).FirstOrDefault()
//                                       select od;
//                var notShippedOrder = notShippedOrders.FirstOrDefault();
//                var resultNotShippedOrders = notShippedOrders.ToList();
//                var forReplacement = notShippedOrders.ToList();

//                foreach (var item in forReplacement)
//                {
//                    item.ProductId = 22;
//                }

//                connection.OrderDetails
//                    .Where(p => p.OrderId == notShippedOrders.Select(x => x.OrderId).FirstOrDefault())
//                    .Delete();

//                foreach (var unit in forReplacement)
//                {
//                    connection.OrderDetails.Value(p => p.OrderId, unit.OrderId)
//                                           .Value(p => p.ProductId, unit.ProductId)
//                                           .Value(p => p.Quantity, unit.Quantity).Insert();
//                }

//            };
//        }



//    }
//}
