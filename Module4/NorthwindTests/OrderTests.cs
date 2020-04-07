using System;
using System.Collections.Generic;
using System.Linq;
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
            var orderDb = _dbContext.Orders.SelectAll().First();

            var id = orderDb.OrderId;

            var order = _dbContext.Orders.SelectById(id);

            Console.WriteLine($"Print information for order №{id}\n");

            Console.WriteLine($"Date: '{order.RequiredDate}'; status: '{order.OrderStatus}'; freight: {order.Freight}; address: '{order.ShipAddress}'");
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
                Employee = _dbContext.Employees.SelectAll().First(),
                Customer = _dbContext.Customers.SelectAll().First(),
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
            
            order = _dbContext.Orders.SelectById(result.Value);

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Order_UpdateInvalidStatus()
        {
            var order = _dbContext.Orders.Find(o => o.OrderStatus != OrderStatusEnum.New).First();
            
            _dbContext.Orders.UpdateOrder(order);
        }

        [TestMethod]
        public void Order_Update()
        {
            var order = _dbContext.Orders.Find(o => o.OrderStatus == OrderStatusEnum.New).First();

            order.OrderDetails = new List<OrderDetail>
            {
                new OrderDetail
                {
                    Product = _dbContext.Products.SelectById(1),
                    UnitPrice = 987,
                    Quantity = 3,
                    Discount = 0.99f
                },
                new OrderDetail
                {
                    Product = _dbContext.Products.SelectById(5),
                    UnitPrice = 876,
                    Quantity = 5,
                    Discount = 0.777f
                },
                new OrderDetail
                {
                    Product = _dbContext.Products.SelectById(15),
                    UnitPrice = 5678,
                    Quantity = 11,
                    Discount = 0.22f
                }
            };

            _dbContext.Orders.UpdateOrder(order);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Order_DeleteInvalidStatus()
        {
            var order = _dbContext.Orders.Find(o => o.OrderStatus != OrderStatusEnum.New).First();

            _dbContext.Orders.DeleteOrder(order.OrderId);
        }

        [TestMethod]
        public void Order_Delete()
        {
            var order = _dbContext.Orders.Find(o =>
                o.OrderStatus == OrderStatusEnum.New || o.OrderStatus == OrderStatusEnum.InProgress).First();

            Console.WriteLine(order.OrderId);

            _dbContext.Orders.DeleteOrder(order.OrderId);
        }

        [TestMethod]
        public void Order_UpdateToInProgress()
        {
            var order = _dbContext.Orders.Find(o => o.OrderStatus == OrderStatusEnum.New).First();

            _dbContext.Orders.UpdateToInProgress(order.OrderId, DateTime.Now);
        }

        [TestMethod]
        public void Order_UpdateToDone()
        {
            var order = _dbContext.Orders.Find(o => o.OrderStatus == OrderStatusEnum.InProgress).First();

            _dbContext.Orders.UpdateToDone(order.OrderId, DateTime.Now);
        }

        [TestMethod]
        public void Order_CustomerReport()
        {
            var customer = _dbContext.Customers.SelectAll().First();

            var reports = _dbContext.Orders.GetCustOrderHist(customer.CustomerId);

            Console.WriteLine($"Report for customer id: '{customer.CustomerId}'");

            foreach (var report in reports)
            {
                Console.WriteLine($"ProductName: '{report.ProductName}'; Total: '{report.Total}'");
            }
        }

        [TestMethod]
        public void Order_OrderReport()
        {
            var order = _dbContext.Orders.SelectAll().First();

            var reports = _dbContext.Orders.GetCustOrdersDetail(order.OrderId);

            Console.WriteLine($"Report for order id: '{order.OrderId}'");

            foreach (var report in reports)
            {
                Console.Write($"ProductName: '{report.ProductName}'; UnitPrice: '{report.UnitPrice}'; ");
                Console.WriteLine($"Quantity:'{report.Quantity}'; ExtendedPrice: {report.ExtendedPrice}");
            }
        }



    }
}