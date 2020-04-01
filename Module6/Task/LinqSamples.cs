using System;
using System.Linq;
using SampleSupport;
using Task.Data;

namespace Task
{
    [Title("LINQ Module")]
    [Prefix("Task")]
    public class LinqSamples : SampleHarness
    {
        private readonly DataSource _dataSource = new DataSource();


        [Category("Restriction Operators")]
        [Title("Task 1")]
        [Description("This sample returns all customers with a total order over value")]
        public void Task1()
        {
            var turnovers = new[] { 10000, 50000, 100000, 150000 };

            var resultList = turnovers.Select(turnover => new
            {
                Turnover = turnover,
                Customers = _dataSource.Customers.Where(c => c.Orders.Sum(o => o.Total) > turnover).ToList()
            });

            foreach (var result in resultList)
            {
                Console.WriteLine($"Customer turnover: {result.Turnover}; Count customer: {result.Customers.Count}");

                foreach (var customer in result.Customers)
                {
                    Console.WriteLine($"CustomerID: '{customer.CustomerID}'; Company name: '{customer.CompanyName}'; " +
                                      $"Orders sum: '{customer.Orders.Sum(o => o.Total)}'");
                }

                Console.WriteLine();
            }
        }


        [Category("Restriction Operators")]
        [Title("Task 2.1- Without grouping")]
        [Description("This sample returns all suppliers from the same city and country as customer without grouping")]
        public void Task2_1()
        {
            foreach (var customer in _dataSource.Customers)
            {
                var suppliers = _dataSource.Suppliers
                    .Where(supplier => supplier.City == customer.City && supplier.Country == customer.Country);

                if (suppliers.Any())
                {
                    Console.WriteLine($"Suppliers for Customer: '{customer.CompanyName}' " +
                                      $"(City: '{customer.City}', Country: '{customer.Country}'): ");

                    foreach (var supplier in suppliers)
                    {
                        Console.WriteLine($"Supplier name: '{supplier.SupplierName}'; " +
                                          $"City: '{supplier.City}', country: '{supplier.Country}'");
                    }

                    Console.WriteLine();
                }

            }
        }


        [Category("Restriction Operators")]
        [Title("Task 2.2- With grouping")]
        [Description("This sample returns all suppliers from the same city and country as customer with grouping")]
        public void Task2_2()
        {
            var groupResult = _dataSource.Customers
                .GroupJoin(
                    _dataSource.Suppliers,
                    customer => new
                    {
                        customer.City,
                        customer.Country
                    },
                    supplier => new
                    {
                        supplier.City,
                        supplier.Country
                    },
                    (customer, suppliers) => new
                    {
                        customer, 
                        suppliers
                    })
                .Where(group => group.suppliers.Any());

            foreach (var customerResult in groupResult)
            {
                Console.WriteLine($"Suppliers for Customer: '{customerResult.customer.CompanyName}' " +
                                  $"(City: '{customerResult.customer.City}', Country: '{customerResult.customer.Country}'): ");

                foreach (var supplier in customerResult.suppliers)
                {
                    Console.WriteLine($"Supplier name: {supplier.SupplierName}; " +
                                      $"City:{supplier.City}, country:{supplier.Country}");
                }

                Console.WriteLine();
            }
        }


        [Category("Restriction Operators")]
        [Title("Task 3")]
        [Description("This sample returns customers who have orders with amount greater than X")]
        public void Task3()
        {
            var orderAmounts = new[] { 5000, 10000, 15000 };

            var resultList = orderAmounts.Select(amount => new
            {
                orderAmount = amount,
                customers = _dataSource.Customers
                    .Where(customer => customer.Orders.Any(order => order.Total > amount)).ToList()
            });


            foreach (var result in resultList)
            {
                Console.WriteLine($"Customer order amounts : '{result.orderAmount}'; " +
                                  $"Count customer: '{result.customers.Count}'");

                foreach (var customer in result.customers)
                {
                    Console.WriteLine($"CustomerId: '{customer.CustomerID}'; {customer.CompanyName}'; " +
                                      $"Orders max: '{customer.Orders.Max(o => o.Total)}'");
                }

                Console.WriteLine();
            }
        }


        [Category("Restriction Operators")]
        [Title("Task 4")]
        [Description("This sample returns ordered list of customers in according their first order date")]
        public void Task4()
        {
            var resultList = _dataSource.Customers
                .Where(customer => customer.Orders.Any())
                .OrderBy(customer => customer.Orders.Min(ord => ord.OrderDate));

            foreach (var customer in resultList)
            {
                Console.WriteLine($"CustomerID: '{customer.CustomerID}'; Company name: '{customer.CompanyName}'; " +
                                  $"First order: '{customer.Orders.Min(ord => ord.OrderDate).ToShortDateString()}'");
            }
        }


        [Category("Restriction Operators")]
        [Title("Task 5")]
        [Description("This sample returns ordered list of customers by year, month, turnover and name")]
        public void Task5()
        {
            var resultList = _dataSource.Customers
                .Where(customer => customer.Orders.Any())
                .OrderByDescending(customer => customer.Orders.Min(ord => ord.OrderDate).Year)
                .ThenByDescending(customer => customer.Orders.Min(ord => ord.OrderDate).Month)
                .ThenByDescending(customer => customer.Orders.Sum(ord => ord.Total))
                .ThenByDescending(customer => customer.CompanyName);

            foreach (var customer in resultList)
            {
                Console.WriteLine($"First order: '{customer.Orders.Min(ord => ord.OrderDate).ToShortDateString()}'; " +
                                  $"Turnover: '{customer.Orders.Sum(ord => ord.Total)}'; Name: '{customer.CompanyName}'");
            }
        }


        [Category("Restriction Operators")]
        [Title("Task 6")]
        [Description("This sample returns list of customers who not specified region, code of provider and have incorrect postal code")]
        public void Task6()
        {
            var customers = _dataSource.Customers.Where(customer =>
                !int.TryParse(customer.PostalCode, out _) ||
                string.IsNullOrWhiteSpace(customer.Region) ||
                !customer.Phone.Any(symbol => symbol == '(' || symbol == ')'));

            foreach (var customer in customers)
            {
                Console.WriteLine($"Id: '{customer.CustomerID}'; PostalCode: '{customer.PostalCode}'; " +
                                  $"Region: '{customer.Region}'; Phone: '{customer.Phone}'");
            }
        }


        [Category("Restriction Operators")]
        [Title("Task 7")]
        [Description("This sample groups products by Category, UnitsInStock and UnitPrice")]
        public void Task7()
        {
            var listResult = _dataSource.Products
                .GroupBy(cat => cat.Category)
                .Select(group => new
                {
                    Category = group.Key,
                    UnitsInStock = group
                        .GroupBy(y => y.UnitsInStock)
                        .Select(stock => new
                        {
                            UnitsInStock = stock.Key,
                            Products = stock.OrderBy(z => z.UnitPrice)
                        }).OrderBy(o => o.UnitsInStock)
                }).OrderBy(o => o.Category);

            foreach (var gp in listResult)
            {
                Console.WriteLine($"Category: '{gp.Category}'");
                foreach (var uis in gp.UnitsInStock)
                {
                    Console.WriteLine($"  Units in stock: {uis.UnitsInStock}");
                    foreach (var product in uis.Products)
                    {
                        Console.WriteLine($"    Product name: '{product.ProductName}' - Price: {product.UnitPrice}");
                    }
                }

            }
        }


        [Category("Restriction Operators")]
        [Title("Task 8")]
        [Description("This sample returns list grouped by groups( cheap, middle, expensive)")]
        public void Task8()
        {
            var groups = new[] {
                new { Name = "Cheap", startCost = 0, endCost = 25 },
                new {Name = "Middle", startCost = 25, endCost = 50 },
                new {Name = "Expensive", startCost = 50, endCost = int.MaxValue }
            };

            var resultList = groups.Select(group => new
            {
                Group = group.Name,
                Values = _dataSource.Products
                    .Where(prod => group.startCost < prod.UnitPrice && prod.UnitPrice < group.endCost)
                    .OrderBy(o => o.UnitPrice)
            });

            foreach (var result in resultList)
            {
                Console.WriteLine($"{result.Group} products:");
                foreach (var product in result.Values)
                {
                    Console.WriteLine($"    Product name: '{product.ProductName}' - Price: {product.UnitPrice}");
                }
            }
        }


        [Category("Restriction Operators")]
        [Title("Task 9")]
        [Description("This sample returns average profitability of city and average intensity")]
        public void Task9()
        {
            var resultList = _dataSource.Customers
                .GroupBy(customer => customer.City).Select(cityGroup => new
                {
                    CityName = cityGroup.Key,
                    AverageProfitability = cityGroup.SelectMany(customer => customer.Orders)
                        .Average(order => order.Total),
                    AverageIntensity = cityGroup.Select(customer => customer.Orders.Count()).Average()
                });

            foreach (var result in resultList)
            {
                Console.WriteLine($"City: '{result.CityName}'; " +
                                  $"Profitability: '{result.AverageProfitability:0.00}'; " +
                                  $"Intensity: '{result.AverageIntensity:0.00}'");
            }
        }


        [Category("Restriction Operators")]
        [Title("Task 10.1")]
        [Description("This sample returns average statistics of clients activity grouped by Month")]
        public void Task10_1()
        {
            var result = _dataSource.Customers
                .SelectMany(customer => customer.Orders, (customer, order) => new { customer, order })
                .GroupBy(t => t.order.OrderDate.Month, t => t.customer)
                .Select(g => new
                {
                    YearKey = g.Key,
                    OrdersCount = g.Count()
                }).OrderBy(o => o.YearKey);

            foreach (var order in result)
            {
                Console.WriteLine($"In '{order.YearKey}' clients activity was equal: '{order.OrdersCount}'");
            }

        }


        [Category("Restriction Operators")]
        [Title("Task 10.2")]
        [Description("This sample returns average statistics of clients activity grouped by Year")]
        public void Task10_2()
        {
            var result = _dataSource.Customers
                .SelectMany(customer => customer.Orders, (customer, order) => new { customer, order })
                .GroupBy(@t => @t.order.OrderDate.Year, @t => @t.customer)
                .Select(g => new
                {
                    YearKey = g.Key,
                    ordersNumber = g.Count()
                }).OrderBy(o => o.YearKey);

            foreach (var order in result)
            {
                Console.WriteLine($"In '{order.YearKey}' clients activity was equal: '{order.ordersNumber}'");
            }

        }


        [Category("Restriction Operators")]
        [Title("Task 10.3")]
        [Description("This sample returns average statistics of clients activity grouped by Year and Month")]
        public void Task10_3()
        {
            var result = _dataSource.Customers.SelectMany(t => t.Orders)
                .GroupBy(g => g.OrderDate.Year)
                .Select(y => new
                {
                    Year = y.Key,
                    Details = y
                        .GroupBy(t => t.OrderDate.Month)
                        .Select(r => new
                        {
                            Month = r.Key,
                            Count = r.Count()
                        }).OrderBy(o => o.Month)
                }).OrderBy(o => o.Year);

            foreach (var report in result)
            {
                Console.WriteLine($"Year: {report.Year}");
                foreach (var detail in report.Details)
                {
                    Console.WriteLine($"Month: {detail.Month}; Count: {detail.Count}");
                }
            }

        }

    }
}
