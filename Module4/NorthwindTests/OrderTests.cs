using System;
using System.Collections.Generic;
using DALContracts;
using DALContracts.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindDAL;

namespace NorthwindTest
{
    [TestClass]
    public class OrderTests
    {
        private static IDbContext _dbContext;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            _dbContext = new DbContext(@"data source=.; database = Northwind; integrated security=SSPI");
        }

        [TestMethod]
        public void Order_PrintAllOrders()
        {
            var orders = _dbContext.Orders.SelectAll();

            Console.WriteLine("Print all orders: \n");

            foreach (var order in orders)
            {
                Console.WriteLine($"Order id: {order.OrderId}; date: {order.OrderDate.ToString()}; status: {order.OrderStatus}");
            }
        }

        [TestMethod]
        public void Order_PrintSearch()
        {
            var orders = _dbContext.Orders.Find(t=>t.OrderDate == new DateTime(1996, 11, 11));

            Console.WriteLine("Print orders 11-11-1996: \n");

            foreach (var order in orders)
            {
                Console.WriteLine($"Order id: {order.OrderId}; date: {order.OrderDate.ToString()}; status: {order.OrderStatus}");
            }
        }

        [TestMethod]
        public void Order_PrintById()
        {
            const int id = 10248;

            var order = _dbContext.Orders.SelectById(id);

            Console.WriteLine($"Print information for order №{id}\n");

            Console.WriteLine($"Date: '{order.OrderDate}'; status: '{order.OrderStatus}'; freight: {order.Freight}; address: '{order.ShipAddress}'");
            Console.WriteLine($"Customer: '{order.Customer.ContactName}'; phone: {order.Customer.Phone}");
            Console.WriteLine($"Employee: '{order.Employee.FirstName + " "+order.Employee.LastName}'");
            Console.WriteLine("Order details:");

            foreach (var details in order.OrderDetails)
            {
                Console.WriteLine($"Product name: '{details.Product.ProductName}'; price: '{details.Product.UnitPrice}'; category: {details.Product.Category.CategoryName}");
            }
        }

        [TestMethod]
        public void Order_Insert()
        {
            var order = new Order
            {
                Employee = _dbContext.Employees.SelectById(1),
                Customer = _dbContext.Customers.SelectById("RATTC"),
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now,
                ShippedDate = DateTime.Now,
                OrderStatus = OrderStatusEnum.New,
                Freight = 123,
                ShipName = "ShipName test",
                ShipAddress = "ShipAddress test",
                ShipCity = "ShipCity test",
                ShipRegion = "ShipRegion",
                ShipPostalCode = "PostalCode",
                ShipCountry = "ShipCountry",
                OrderDetails = new List<OrderDetail>
                {
                    new OrderDetail
                    {
                        Product = _dbContext.Products.SelectById(1),
                        UnitPrice = 123,
                        Quantity = 1,
                        Discount = 0.11f
                    },
                    new OrderDetail
                    {
                        Product = _dbContext.Products.SelectById(2),
                        UnitPrice = 234,
                        Quantity = 2,
                        Discount = 0.22f
                    }
                }


            };

            var result = _dbContext.Orders.SaveNewOrder(order);

            Assert.IsTrue(result.HasValue && result.Value > 0);
            
            var orderDb = _dbContext.Orders.SelectById(result.Value);

            Console.WriteLine($"Print information for new order №{result.Value}\n");

            Console.WriteLine($"Date: '{order.OrderDate}'; status: '{order.OrderStatus}'; freight: {order.Freight}; address: '{order.ShipAddress}'");
            Console.WriteLine($"Customer: '{order.Customer.ContactName}'; phone: {order.Customer.Phone}");
            Console.WriteLine($"Employee: '{order.Employee.FirstName + " " + order.Employee.LastName}'");
            Console.WriteLine("Order details:");

            foreach (var details in order.OrderDetails)
            {
                Console.WriteLine($"Product name: '{details.Product.ProductName}'; price: '{details.Product.UnitPrice}'; category: {details.Product.Category.CategoryName}");
            }

        }





    }
}