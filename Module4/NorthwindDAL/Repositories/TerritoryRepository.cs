using System;
using System.Collections.Generic;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    public class TerritoryRepository : ExecuteCommandBase, IRepository<Territory>
    {
        private readonly string _connectionString;
        public TerritoryRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Territory> Find(Func<Territory, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int GetCountDependencies(int id)
        {
            throw new NotImplementedException();
        }

        public int? Insert(Territory item)
        {
            throw new NotImplementedException();
        }

        public List<Territory> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Territory SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Territory item)
        {
            throw new NotImplementedException();
        }
    }
}
