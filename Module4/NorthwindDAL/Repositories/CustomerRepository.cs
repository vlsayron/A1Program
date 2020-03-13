using System;
using System.Collections.Generic;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    public class CategoryRepository : ExecuteCommandBase, IRepository<Category>
    {
        private readonly string _connectionString;
        public CategoryRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> Find(Func<Category, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int GetCountDependencies(int id)
        {
            throw new NotImplementedException();
        }

        public int? Insert(Category item)
        {
            throw new NotImplementedException();
        }

        public List<Category> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Category SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
