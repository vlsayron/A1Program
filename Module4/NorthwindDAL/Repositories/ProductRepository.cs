using System;
using System.Collections.Generic;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    public class ProductRepository : ExecuteCommandBase, IRepository<Product>
    {
        private readonly string _connectionString;
        public ProductRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> Find(Func<Product, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int GetCountDependencies(int id)
        {
            throw new NotImplementedException();
        }

        public int? Insert(Product item)
        {
            throw new NotImplementedException();
        }

        public List<Product> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Product SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
