using System.Collections.Generic;
using System.Data.SqlClient;
using DALContracts.Models;

namespace NorthwindDAL.Repositories
{
    internal class EmployeeRepository : BaseRepository<Employee>
    {
        private const string SqlSelectById =
            @"SELECT [EmployeeID] ,[LastName] ,[FirstName] ,[Title] ,[TitleOfCourtesy] ,[BirthDate] ,[HireDate] ,[Address] ,[City] ,[Region] ,[PostalCode] ,[Country] ,[HomePhone] ,[Extension] ,[Notes], [PhotoPath] FROM [dbo].[Employees] WHERE [EmployeeID] = @IdEntity";
        private const string SqlSelectAll =
            @"SELECT [EmployeeID] ,[LastName] ,[FirstName] ,[Title] ,[TitleOfCourtesy] ,[BirthDate] ,[HireDate] ,[Address] ,[City] ,[Region] ,[PostalCode] ,[Country] ,[HomePhone] ,[Extension] ,[Notes], [PhotoPath] FROM [dbo].[Employees]";

        public EmployeeRepository(string connectionString) : base(connectionString, SqlSelectAll, SqlSelectById)
        {
        }

        protected override IEnumerable<Employee> MapEntities(SqlDataReader reader)
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
