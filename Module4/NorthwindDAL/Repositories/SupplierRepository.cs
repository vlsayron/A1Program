using System.Collections.Generic;
using System.Data.SqlClient;
using DALContracts.Models;

namespace NorthwindDAL.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>
    {
        private const string SqlSelectById =
            @"SELECT [SupplierID], [CompanyName], [ContactName], [ContactTitle], [Address], [City] ,[Region], [PostalCode], [Country], [Phone], [Fax], [HomePage] FROM [dbo].[Suppliers] WHERE SupplierID = @IdEntity;";
        private const string SqlSelectAll =
            @"SELECT [SupplierID], [CompanyName], [ContactName], [ContactTitle], [Address], [City] ,[Region], [PostalCode], [Country], [Phone], [Fax], [HomePage] FROM [dbo].[Suppliers];";

        public SupplierRepository(string connectionString) : base(connectionString, SqlSelectAll, SqlSelectById)
        {
        }

        protected override IEnumerable<Supplier> MapEntities(SqlDataReader reader)
        {
            var listResults = new List<Supplier>();

            while (reader.Read())
            {
                var entity = new Supplier
                {
                    SupplierId = reader.GetInt32(0),
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
                    HomePage = reader.SafeGetString(11)
                };

                listResults.Add(entity);
            }
            return listResults;
        }
    }
}
