using System;
using DALContracts;
using NorthwindDAL;

namespace ForTest
{
    class Program
    {
        static IDbContext _dbContext = new DbContext(@"data source=.; database = Northwind; integrated security=SSPI");
        static void Main(string[] args)
        {
            var all = _dbContext.Orders.SelectAll();

            foreach (var res in all)
            {
                Console.WriteLine($"{res.Customer.CompanyName}; {res.Employee.LastName}; {res.ShipCity}");
            }

            {
                var res = _dbContext.Categories.SelectById(2);
                Console.WriteLine();
                Console.WriteLine($"{res.CategoryId}; {res.CategoryName}; {res.Description}");
            }
            

            Console.WriteLine("===== Finish =====");
            Console.ReadKey();
        }


    }
}
