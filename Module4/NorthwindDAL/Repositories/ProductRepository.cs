using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    internal class ProductRepository : ExecuteCommandBase, IRepository<Product>
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly SupplierRepository _supplierRepository;
        
        public ProductRepository(string connectionString, CategoryRepository categoryRepository, SupplierRepository supplierRepository) : base(connectionString)
        {
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
        }

        public Product SelectById<T2>(T2 id)
        {
            var sqlSelectById =
                @"SELECT [ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued] FROM [Northwind].[dbo].[Products] WHERE [ProductID] = @IdEntity";

            return SelectById(sqlSelectById, id, GetEntities);
        }

        public IEnumerable<Product> SelectAll()
        {
            var sqlSelectAll =
                @"SELECT [ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued] FROM [Northwind].[dbo].[Products]";

            return SelectAll(sqlSelectAll, GetEntities);
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Product> GetEntities(SqlDataReader reader)
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
