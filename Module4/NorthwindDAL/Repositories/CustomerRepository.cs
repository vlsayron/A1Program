using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    internal class CustomerRepository : ExecuteCommandBase, IRepository<Customer>
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {
        }

        public Customer SelectById<T2>(T2 id)
        {
            var sqlSelectById =
                @"SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax] FROM .[dbo].[Customers] WHERE [CustomerID] = @IdEntity";

            return SelectById(sqlSelectById, id, GetEntities);
        }
        public IEnumerable<Customer> SelectAll()
        {
            var sqlSelectAll =
                @"SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax] FROM .[dbo].[Customers]";

            return SelectAll(sqlSelectAll, GetEntities);
        }

        public IEnumerable<Customer> Find(Func<Customer, bool> predicate)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Customer> GetEntities(SqlDataReader reader)
        {
            var listResults = new List<Customer>();

            while (reader.Read())
            {
                var entity = new Customer
                {
                    CustomerId = reader.SafeGetString(0),
                    CompanyName = reader.SafeGetString(1),
                    ContactName = reader.SafeGetString(2),
                    ContactTitle = reader.SafeGetString(3),
                    Address = reader.SafeGetString(4),
                    City = reader.SafeGetString(5),
                    Region = reader.SafeGetString(6),
                    PostalCode = reader.SafeGetString(7),
                    Country = reader.SafeGetString(8),
                    Phone = reader.SafeGetString(9),
                    Fax = reader.SafeGetString(10),

                };
                listResults.Add(entity);
            }
            return listResults;
        }
    }
}
