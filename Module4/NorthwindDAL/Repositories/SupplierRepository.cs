using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    public class SupplierRepository : ExecuteCommandBase, IRepository<Supplier>
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {
        }

        public Supplier SelectById<T2>(T2 id)
        {
            var sqlSelectById =
                @"SELECT [SupplierID], [CompanyName], [ContactName], [ContactTitle], [Address], [City] ,[Region], [PostalCode], [Country], [Phone], [Fax], [HomePage] FROM [dbo].[Suppliers] WHERE SupplierID = @IdEntity;";

            return SelectById(sqlSelectById, id, GetEntities);
        }

        public IEnumerable<Supplier> SelectAll()
        {
            var sqlSelectAll =
                @"SELECT [SupplierID], [CompanyName], [ContactName], [ContactTitle], [Address], [City] ,[Region], [PostalCode], [Country], [Phone], [Fax], [HomePage] FROM [dbo].[Suppliers];";

            return SelectAll(sqlSelectAll, GetEntities);
        }

        public IEnumerable<Supplier> Find(Func<Supplier, bool> predicate)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Supplier> GetEntities(SqlDataReader reader)
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
