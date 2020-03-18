using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    internal class EmployeeRepository : ExecuteCommandBase, IRepository<Employee>
    {
        public EmployeeRepository(string connectionString) : base(connectionString)
        {
        }

        public Employee SelectById<T2>(T2 id)
        {
            var sqlSelectById =
                @"SELECT [EmployeeID] ,[LastName] ,[FirstName] ,[Title] ,[TitleOfCourtesy] ,[BirthDate] ,[HireDate] ,[Address] ,[City] ,[Region] ,[PostalCode] ,[Country] ,[HomePhone] ,[Extension] ,[Notes], [PhotoPath] FROM [dbo].[Employees] WHERE [EmployeeID] = @IdEntity";

            return SelectById(sqlSelectById, id, GetEntities);
        }

        public IEnumerable<Employee> SelectAll()
        {
            var sqlSelectAll =
                @"SELECT [EmployeeID] ,[LastName] ,[FirstName] ,[Title] ,[TitleOfCourtesy] ,[BirthDate] ,[HireDate] ,[Address] ,[City] ,[Region] ,[PostalCode] ,[Country] ,[HomePhone] ,[Extension] ,[Notes], [PhotoPath] FROM [dbo].[Employees]";

            return SelectAll(sqlSelectAll, GetEntities);
        }

        public IEnumerable<Employee> Find(Func<Employee, bool> predicate)
        {
            throw new NotImplementedException();
        }


        private static IEnumerable<Employee> GetEntities(SqlDataReader reader)
        {
            var listResults = new List<Employee>();

            while (reader.Read())
            {
                var entity = new Employee
                {
                    EmployeeId = reader.GetInt32(0),
                    LastName = reader.SafeGetString(1),
                    FirstName = reader.SafeGetString(2),
                    Title = reader.SafeGetString(3),
                    TitleOfCourtesy = reader.SafeGetString(4),
                    BirthDate = reader.GetDateTime(5),
                    HireDate = reader.GetDateTime(6),
                    Address = reader.SafeGetString(7),
                    City = reader.SafeGetString(8),
                    Region = reader.SafeGetString(9),
                    PostalCode = reader.SafeGetString(10),
                    Country = reader.SafeGetString(11),
                    HomePhone = reader.SafeGetString(12),
                    Extension = reader.SafeGetString(13),
                    Notes = reader.SafeGetString(14),
                    PhotoPath = reader.SafeGetString(15)
                };

                listResults.Add(entity);
            }
            return listResults;
        }
    }
}
