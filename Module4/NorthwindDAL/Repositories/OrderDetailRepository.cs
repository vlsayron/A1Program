using System.Collections.Generic;
using System.Data.SqlClient;
using DALContracts.Models;

namespace NorthwindDAL.Repositories
{
    internal class OrderDetailRepository
    {
        private readonly string _connectionString;
        private readonly ProductRepository _productRepository;

        public OrderDetailRepository(string connectionString, ProductRepository productRepository)
        {
            _connectionString = connectionString;
            _productRepository = productRepository;
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            var listResults = new List<OrderDetail>();

            var sqlQuery =
                @"SELECT [ProductID], [UnitPrice], [Quantity], [Discount] FROM [dbo].[Order Details] where [OrderID] = @OrderId";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(sqlQuery, connection)
                {
                    CommandType = System.Data.CommandType.Text
                };

                var idParam = new SqlParameter
                {
                    ParameterName = "@OrderId",
                    Value = orderId
                };

                command.Parameters.Add(idParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var entity = new OrderDetail
                            {
                                Product = _productRepository.SelectById(reader.SafeGetInt(0)),
                                UnitPrice = reader.GetDecimal(1),
                                Quantity = reader.GetInt16(2),
                                Discount = reader.GetFloat(3)
                            };

                            listResults.Add(entity);
                        }
                    }
                }

                connection.Close();
            }

            return listResults;



        }

        
    }
}
