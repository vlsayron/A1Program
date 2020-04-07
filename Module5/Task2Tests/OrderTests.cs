using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2EntityFramework.Models;

namespace Task2Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void Order_PrintAll()
        {
            using (var context = new NorthwindDB())
            {
                var result = context.Order_Details;

                foreach (var orderDetail in result)
                {
                    Console.WriteLine($"OrderId: {orderDetail.Order.OrderID};" +
                                      $"Customer name: {orderDetail.Order.Customer.CompanyName};" +
                                      $"Product name: {orderDetail.Product.ProductName};"+
                                      $"Category: {orderDetail.Product.Category.CategoryName}");
                }
            }
        }

        [TestMethod]
        public void Order_PrintByCategory()
        {
            const string categoryName = "Category1";
            Console.WriteLine($"Orders from category: {categoryName}\n");
            
            using (var context = new NorthwindDB())
            {
                var result = context.Order_Details.Where(o => o.Product.Category.CategoryName == categoryName);

                foreach (var orderDetail in result)
                {
                    Console.WriteLine($"OrderId: {orderDetail.Order.OrderID};" +
                                      $"Customer name: {orderDetail.Order.Customer.CompanyName};" +
                                      $"Product name: {orderDetail.Product.ProductName};" +
                                      $"Category: {orderDetail.Product.Category.CategoryName}");

                }
            }
        }


        


    }
}
