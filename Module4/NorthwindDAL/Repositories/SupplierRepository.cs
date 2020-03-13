using System;
using System.Collections.Generic;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    public class SupplierRepository : ExecuteCommandBase, IRepository<Supplier>
    {
        private readonly string _connectionString;
        public SupplierRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Supplier> Find(Func<Supplier, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int GetCountDependencies(int id)
        {
            throw new NotImplementedException();
        }

        public int? Insert(Supplier item)
        {
            throw new NotImplementedException();
        }

        public List<Supplier> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Supplier SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Supplier item)
        {
            throw new NotImplementedException();
        }
    }
}
