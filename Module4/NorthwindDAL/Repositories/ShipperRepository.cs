using System;
using System.Collections.Generic;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    public class ShipperRepository : ExecuteCommandBase, IRepository<Shipper>
    {
        private readonly string _connectionString;
        public ShipperRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Shipper> Find(Func<Shipper, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int GetCountDependencies(int id)
        {
            throw new NotImplementedException();
        }

        public int? Insert(Shipper item)
        {
            throw new NotImplementedException();
        }

        public List<Shipper> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Shipper SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Shipper item)
        {
            throw new NotImplementedException();
        }
    }
}
