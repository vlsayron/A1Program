using System.Collections.Generic;
using System.Data.SqlClient;
using DALContracts.Models;

namespace NorthwindDAL.Repositories
{
    internal class CustomerRepository : BaseRepository<Customer>
    {
        private const string SqlSelectById =
            @"SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax] FROM .[dbo].[Customers] WHERE [CustomerID] = @IdEntity";

        private const string SqlSelectAll =
            @"SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax] FROM.[dbo].[Customers]";

        public CustomerRepository(string connectionString) : base(connectionString, SqlSelectAll, SqlSelectById)
        {
        }


        protected override IEnumerable<Customer> MapEntities(SqlDataReader reader)
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
