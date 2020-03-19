using System.Collections.Generic;
using System.Data.SqlClient;
using DALContracts.Models;

namespace NorthwindDAL.Repositories
{
    internal class CategoryRepository : BaseRepository<Category>
    {
        private const string SqlSelectById =
            @"SELECT [CategoryID],[CategoryName],[Description],[Picture] FROM [dbo].[Categories] WHERE [CategoryID] = @IdEntity";
        private const string SqlSelectAll =
            @"SELECT [CategoryID],[CategoryName],[Description],[Picture] FROM [dbo].[Categories]";

        public CategoryRepository(string connectionString) : base(connectionString, SqlSelectAll, SqlSelectById)
        {
        }

        protected override IEnumerable<Category> MapEntities(SqlDataReader reader)
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
