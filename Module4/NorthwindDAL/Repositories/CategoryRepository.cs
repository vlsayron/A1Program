using System;
using System.Collections.Generic;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    public class CustomerRepository : ExecuteCommandBase, IRepository<Customer>
    {
        private readonly string _connectionString;
        public CustomerRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> Find(Func<Customer, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int GetCountDependencies(int id)
        {
            throw new NotImplementedException();
        }

        public int? Insert(Customer item)
        {
            throw new NotImplementedException();
        }

        public List<Customer> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Customer SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
