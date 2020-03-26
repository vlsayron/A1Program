using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using Task2EntityFramework.Models;
using Task2EntityFramework.Models.Enities;

namespace Task1EntityFramework.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<NorthwindDB>
    {
        protected override void Seed(NorthwindDB context)
        {
            
            var categories = new[] 
            { 
                new Category { CategoryName = "Category1" },
                new Category { CategoryName = "Category2" }, 
                new Category { CategoryName = "Category3" }
            };

            context.Categories.AddRange(categories);

            var products = new[]
            {
                new Product {ProductName = "product1", Category = categories[0]},
                new Product {ProductName = "product2", Category = categories[1]},
                new Product {ProductName = "product3", Category = categories[2]},
                new Product {ProductName = "product4", Category = categories[0]},
                new Product {ProductName = "product5", Category = categories[1]},
                new Product {ProductName = "product6", Category = categories[2]},
                new Product {ProductName = "product7", Category = categories[0]},
                new Product {ProductName = "product8", Category = categories[1]},
                new Product {ProductName = "product9", Category = categories[2]}
            };

            context.Products.AddRange(products);

            var employees = new[]
            {
                new Employee {FirstName = "Ivan", LastName = "Ivanov"},
                new Employee {FirstName = "Fu", LastName = "Lu"}
            };

            context.Employees.AddRange(employees);

            var customers = new[]
            {
                new Customer { CustomerID = "cone", CompanyName = "Company One" },
                new Customer { CustomerID = "ctwo", CompanyName = "Company Two" }
            };

            context.Customers.AddRange(customers);

            var orders = new[]
            {
                new Order{Customer = customers[0], Employee = employees[0]},
                new Order{Customer = customers[0], Employee = employees[1]},
                new Order{Customer = customers[1], Employee = employees[0]},
                new Order{Customer = customers[1], Employee = employees[1]}
            };

            context.Orders.AddRange(orders);

            var orderDetails = new[]
            {
                new Order_Detail{Discount = 1, Order = orders[0], Product = products[0], Quantity = 1, UnitPrice = 1},
                new Order_Detail{Discount = 1, Order = orders[0], Product = products[1], Quantity = 2, UnitPrice = 2},
                new Order_Detail{Discount = 1, Order = orders[0], Product = products[2], Quantity = 3, UnitPrice = 3},
                new Order_Detail{Discount = 1, Order = orders[1], Product = products[3], Quantity = 1, UnitPrice = 1},
                new Order_Detail{Discount = 1, Order = orders[1], Product = products[4], Quantity = 1, UnitPrice = 1},
                new Order_Detail{Discount = 1, Order = orders[2], Product = products[5], Quantity = 1, UnitPrice = 1},
                new Order_Detail{Discount = 1, Order = orders[2], Product = products[6], Quantity = 1, UnitPrice = 1},
                new Order_Detail{Discount = 1, Order = orders[2], Product = products[7], Quantity = 1, UnitPrice = 1},
                new Order_Detail{Discount = 1, Order = orders[3], Product = products[8], Quantity = 1, UnitPrice = 1},
                new Order_Detail{Discount = 1, Order = orders[3], Product = products[1], Quantity = 1, UnitPrice = 1},
                new Order_Detail{Discount = 1, Order = orders[3], Product = products[2], Quantity = 1, UnitPrice = 1},
            };

            context.Order_Details.AddRange(orderDetails);

            
            base.Seed(context);

        }
    }
}
