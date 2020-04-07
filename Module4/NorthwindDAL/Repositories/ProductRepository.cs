using System.Collections.Generic;
using System.Data.SqlClient;
using DALContracts.Models;

namespace NorthwindDAL.Repositories
{
    internal class ProductRepository : BaseRepository<Product>
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly SupplierRepository _supplierRepository;

        private const string SqlSelectById =
            @"SELECT [ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued] FROM [Northwind].[dbo].[Products] WHERE [ProductID] = @IdEntity;";
        private const string SqlSelectAll =
            @"SELECT [ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued] FROM [Northwind].[dbo].[Products];";

        public ProductRepository(string connectionString, CategoryRepository categoryRepository, SupplierRepository supplierRepository) : base(connectionString, SqlSelectAll, SqlSelectById)
        {
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
        }

       
        protected override IEnumerable<Product> MapEntities(SqlDataReader reader)
        {
            var listResults = new List<Product>();

            while (reader.Read())
            {
                var product = new Product
                {
                    ProductId = reader.GetInt32(0),
                    ProductName = reader.SafeGetString(1),
                    Supplier = _supplierRepository.SelectById(reader.GetInt32(2)),
                    Category = _categoryRepository.SelectById(reader.GetInt32(3)),
                    QuantityPerUnit = reader.SafeGetString(4),
                    UnitPrice = reader.GetDecimal(5),
                    UnitsInStock = reader.GetInt16(6),
                    UnitsOnOrder = reader.GetInt16(7),
                    ReorderLevel = reader.GetInt16(8),
                    Discontinued = reader.GetBoolean(9)
                };

                listResults.Add(product);
            }
            return listResults;
        }
    }
}
