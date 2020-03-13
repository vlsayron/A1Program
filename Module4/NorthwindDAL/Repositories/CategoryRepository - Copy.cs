using System;
using System.Collections.Generic;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    public class OrderRepository : ExecuteCommandBase, IOrderRepository
    {
        private readonly string _connectionString;
        public OrderRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> Find(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int GetCountDependencies(int id)
        {
            throw new NotImplementedException();
        }

        public int? Insert(Order item)
        {
            throw new NotImplementedException();
        }

        public List<Order> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Order SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
