using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace NorthwindDAL
{
    public abstract class ExecuteCommandBase
    {
        public delegate IEnumerable<T> BaseMapperDelegate<out T>(SqlDataReader reader);

        private readonly string _connectionString;
        protected ExecuteCommandBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected object ExecuteCommand(string storedProcedureName, params SqlParameter[] sqlParameters)
        {
            object commandResult;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                foreach (var sqlParameter in sqlParameters)
                {
                    command.Parameters.Add(sqlParameter);
                }

                commandResult = command.ExecuteScalar();

                connection.Close();
            }

            return commandResult;
        }

        protected T SelectById<T, T2>(string sqlQuery, T2 id, BaseMapperDelegate<T> mapper)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(sqlQuery, connection)
                {
                    CommandType = System.Data.CommandType.Text
                };

                var idParam = new SqlParameter
                {
                    ParameterName = "@IdEntity",
                    Value = id
                };

                command.Parameters.Add(idParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return mapper.Invoke(reader).FirstOrDefault();
                    }
                }

                connection.Close();
            }

            return default;

        }
        protected IEnumerable<T> SelectAll<T>(string sqlQuery, BaseMapperDelegate<T> mapper)
        {
            
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(sqlQuery, connection)
                {
                    CommandType = System.Data.CommandType.Text
                };

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        var result = mapper.Invoke(reader);
                        return result;
                    }
                }

                connection.Close();
            }

            return null;

        }

    }
}