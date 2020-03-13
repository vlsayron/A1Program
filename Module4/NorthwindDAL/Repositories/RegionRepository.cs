using System;
using System.Collections.Generic;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    public class RegionRepository : ExecuteCommandBase, IRepository<Region>
    {
        private readonly string _connectionString;
        public RegionRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Region> Find(Func<Region, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int GetCountDependencies(int id)
        {
            throw new NotImplementedException();
        }

        public int? Insert(Region item)
        {
            throw new NotImplementedException();
        }

        public List<Region> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Region SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Region item)
        {
            throw new NotImplementedException();
        }
    }
}
