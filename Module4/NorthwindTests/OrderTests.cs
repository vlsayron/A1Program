using System;
using DALContracts;
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
        public void TestMethod1()
        {
            var s = _dbContext.Categories.SelectById(1);

            Console.WriteLine($"CategoryId: {s.CategoryId}, CategoryName: {s.CategoryName}, Description: {s.Description}");
        }
    }
}