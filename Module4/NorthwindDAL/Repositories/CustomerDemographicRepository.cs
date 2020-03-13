using System;
using System.Collections.Generic;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    public class CustomerDemographicRepository : ExecuteCommandBase, IRepository<CustomerDemographic>
    {
        private readonly string _connectionString;
        public CustomerDemographicRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerDemographic> Find(Func<CustomerDemographic, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int GetCountDependencies(int id)
        {
            throw new NotImplementedException();
        }

        public int? Insert(CustomerDemographic item)
        {
            throw new NotImplementedException();
        }

        public List<CustomerDemographic> SelectAll()
        {
            throw new NotImplementedException();
        }

        public CustomerDemographic SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(CustomerDemographic item)
        {
            throw new NotImplementedException();
        }
    }
}
