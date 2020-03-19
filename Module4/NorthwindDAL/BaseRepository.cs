using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DALContracts.Repositories;

namespace NorthwindDAL
{
    public abstract class BaseRepository<T> : IRepository<T> where T: class
    {
        private readonly string _connectionString;
        private readonly string _querySelectAll;
        private readonly string _querySelectById;

        protected BaseRepository(string connectionString, string querySelectAll, string querySelectById)
        {
            _connectionString = connectionString;
            _querySelectAll = querySelectAll;
            _querySelectById = querySelectById;
        }


        public IEnumerable<T> SelectAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(_querySelectAll, connection)
                {
                    CommandType = System.Data.CommandType.Text
                };

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return MapEntities(reader);
                    }
                }

                connection.Close();
            }

            return null;
        }

        public T SelectById<T2>(T2 id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(_querySelectById, connection)
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
                        return MapEntities(reader).FirstOrDefault();
                    }
                }

                connection.Close();
            }

            return default;
        }


        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return SelectAll().Where(predicate);
        }


        protected abstract IEnumerable<T> MapEntities(SqlDataReader reader);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        //private readonly string _connectionString;

        //protected BaseRepository(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        //protected object ExecuteCommand(string storedProcedureName, params SqlParameter[] sqlParameters)
        //{
        //    object commandResult;

        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();

        //        var command = new SqlCommand(storedProcedureName, connection)
        //        {
        //            CommandType = System.Data.CommandType.StoredProcedure
        //        };

        //        foreach (var sqlParameter in sqlParameters)
        //        {
        //            command.Parameters.Add(sqlParameter);
        //        }

        //        commandResult = command.ExecuteScalar();

        //        connection.Close();
        //    }

        //    return commandResult;
        //}

        //protected T SelectById<T2>(string sqlQuery, T2 id)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();

        //        var command = new SqlCommand(sqlQuery, connection)
        //        {
        //            CommandType = System.Data.CommandType.Text
        //        };

        //        var idParam = new SqlParameter
        //        {
        //            ParameterName = "@IdEntity",
        //            Value = id
        //        };

        //        command.Parameters.Add(idParam);

        //        using (var reader = command.ExecuteReader())
        //        {
        //            if (reader.HasRows)
        //            {
        //                return MapEntities(reader).FirstOrDefault();
        //            }
        //        }

        //        connection.Close();
        //    }

        //    return default;

        //}
        //protected IEnumerable<T> SelectAll(string sqlQuery)
        //{

        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();

        //        var command = new SqlCommand(sqlQuery, connection)
        //        {
        //            CommandType = System.Data.CommandType.Text
        //        };

        //        using (var reader = command.ExecuteReader())
        //        {
        //            if (reader.HasRows)
        //            {
        //                return MapEntities(reader);
        //            }
        //        }

        //        connection.Close();
        //    }

        //    return null;

        //}




    }
}