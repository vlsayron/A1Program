using System;
using System.Collections.Generic;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    public class EmployeeRepository : ExecuteCommandBase, IRepository<Employee>
    {
        private readonly string _connectionString;
        public EmployeeRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Find(Func<Employee, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int GetCountDependencies(int id)
        {
            throw new NotImplementedException();
        }

        public int? Insert(Employee item)
        {
            throw new NotImplementedException();
        }

        public List<Employee> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Employee SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee item)
        {
            throw new NotImplementedException();
        }
    }
}
