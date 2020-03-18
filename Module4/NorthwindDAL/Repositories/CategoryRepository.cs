using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    internal class CategoryRepository : ExecuteCommandBase, IRepository<Category>
    {
        public CategoryRepository(string connectionString) : base(connectionString)
        {
        }

        public Category SelectById<T2>(T2 id)
        {
            var sqlSelectById =
                @"SELECT [CategoryID],[CategoryName],[Description],[Picture] FROM [dbo].[Categories] WHERE [CategoryID] = @IdEntity";

            return SelectById(sqlSelectById, id, GetEntities);
        }

        public IEnumerable<Category> SelectAll()
        {
            var sqlSelectAll =
                @"SELECT [CategoryID],[CategoryName],[Description],[Picture] FROM [dbo].[Categories]";

            return SelectAll(sqlSelectAll, GetEntities);
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Category> GetEntities(SqlDataReader reader)
        {
            var listResults = new List<Category>();

            while (reader.Read())
            {
                var entity = new Category
                {
                    CategoryId = reader.GetInt32(0),
                    CategoryName = reader.SafeGetString(1),
                    Description = reader.SafeGetString(2)
                };

                listResults.Add(entity);
            }
            return listResults;
        }
    }
}
