﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DALContracts.Models;
using DALContracts.Models.Reports;
using DALContracts.Repositories;
using static System.Decimal;

namespace NorthwindDAL.Repositories
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly string _connectionString;
        private readonly EmployeeRepository _employeeRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly OrderDetailRepository _orderDetailRepository;

        private const string SqlSelectById =
            @"SELECT [OrderID], [CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry] FROM [dbo].[Orders] WHERE [OrderID] = @IdEntity;";
        private const string SqlSelectAll =
            @"SELECT [OrderID], [CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry] FROM [dbo].[Orders];";

        public OrderRepository(string connectionString, EmployeeRepository employeeRepository, CustomerRepository customerRepository, OrderDetailRepository orderDetailRepository) : base(connectionString, SqlSelectAll, SqlSelectById)
        {
            _connectionString = connectionString;
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        
        public int? SaveNewOrder(Order order)
        {
            const string sqlQuery = @"INSERT INTO [dbo].[Orders] ([CustomerID], [EmployeeID], [RequiredDate], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry]) 
                VALUES ( @CustomerID, @EmployeeID, @RequiredDate,  @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry);
                SELECT SCOPE_IDENTITY()";

            var resultOrder = ExecuteCommand(sqlQuery, GetOrderParameters(order));

            int? orderId = null;

            if (resultOrder != null)
            {
                orderId = ToInt32((decimal)resultOrder);
            }

            if (!orderId.HasValue)
            {
                return null;
            }

            const string detailQuery = @"INSERT INTO [dbo].[Order Details] ([OrderID], [ProductID], [UnitPrice], [Quantity], [Discount])
                VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity, @Discount)";

            foreach (var orderDetail in order.OrderDetails)
            {
                ExecuteCommand(detailQuery, GetDetailsParameters(orderDetail, orderId.Value));
            }

            return orderId;
        }

        public void UpdateOrder(Order order)
        {
            if (order.OrderStatus == OrderStatusEnum.Done ||
                order.OrderStatus == OrderStatusEnum.InProgress)
            {
                throw new ArgumentException();
            }

            var updateQuery =
                @"UPDATE [dbo].[Orders] SET [EmployeeID] = @EmployeeID, [RequiredDate] = @RequiredDate, [Freight] = @Freight, [ShipName] = @ShipName, [ShipAddress] = @ShipAddress, [ShipCity] = @ShipCity, [ShipRegion] = @ShipRegion, [ShipPostalCode] = @ShipPostalCode, [ShipCountry] = @ShipCountry
                WHERE [dbo].[Orders].[OrderID] = @OrderID";

            ExecuteCommand(updateQuery, GetOrderParameters(order));

            var deleteDetails = @"DELETE FROM [dbo].[Order Details] WHERE [OrderID] = @OrderID";

            var orderIdParameter = new SqlParameter
            {
                ParameterName = "OrderID", 
                Value = order.OrderId
            };

            ExecuteCommand(deleteDetails, orderIdParameter);

            const string detailQuery = @"INSERT INTO [dbo].[Order Details] ([OrderID], [ProductID], [UnitPrice], [Quantity], [Discount])
                VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity, @Discount)";

            foreach (var orderDetail in order.OrderDetails)
            {
                ExecuteCommand(detailQuery, GetDetailsParameters(orderDetail, order.OrderId));
            }
        }

        public void DeleteOrder(int orderId)
        {
            var order = SelectById(orderId);

            if (order.OrderStatus != OrderStatusEnum.InProgress &&
                order.OrderStatus != OrderStatusEnum.New)
            {
                throw new ArgumentException();
            }


            var deleteDetails = @"DELETE FROM [dbo].[Order Details] WHERE [OrderID] = @OrderID";

            var orderDetailsIdParameter = new SqlParameter
            {
                ParameterName = "OrderID",
                Value = order.OrderId
            };

            ExecuteCommand(deleteDetails, orderDetailsIdParameter);


            var deleteOrder = @"DELETE FROM [dbo].[Orders] WHERE [OrderID] = @OrderID";

            var orderIdParameter = new SqlParameter
            {
                ParameterName = "OrderID",
                Value = order.OrderId
            };

            ExecuteCommand(deleteOrder, orderIdParameter);
        }
        
        public void UpdateToInProgress(int orderId, DateTime date)
        {
            var order = SelectById(orderId);

            if (order.OrderStatus != OrderStatusEnum.New)
            {
                throw new ArgumentException();
            }

            var sqlQuery = @"UPDATE [dbo].[Orders] SET [OrderDate] =@OrderDate WHERE [OrderID] = @OrderID";

            var idParameter = new SqlParameter
            {
                ParameterName = "OrderID", 
                Value = orderId
            };
            var idOrderDate = new SqlParameter
            {
                ParameterName = "OrderDate",
                Value = date
            };

            ExecuteCommand(sqlQuery, idParameter, idOrderDate);

        }

        public void UpdateToDone(int orderId, DateTime date)
        {
            var order = SelectById(orderId);

            if (order.OrderStatus != OrderStatusEnum.InProgress)
            {
                throw new ArgumentException();
            }

            var sqlQuery = @"UPDATE [dbo].[Orders] SET [ShippedDate] =@ShippedDate WHERE [OrderID] = @OrderID";

            var idParameter = new SqlParameter
            {
                ParameterName = "OrderID",
                Value = orderId
            };
            var idOrderDate = new SqlParameter
            {
                ParameterName = "ShippedDate",
                Value = date
            };

            ExecuteCommand(sqlQuery, idParameter, idOrderDate);
        }

        public IEnumerable<CustOrderHist> GetCustOrderHist(string customerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"CustOrderHist", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                var customerIdParameter = new SqlParameter
                {
                    ParameterName = "CustomerID",
                    Value = customerId
                };

                command.Parameters.Add(customerIdParameter);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        var listResults = new List<CustOrderHist>();

                        while (reader.Read())
                        {
                            var report = new CustOrderHist
                            {
                                ProductName = reader.SafeGetString(0),
                                Total = reader.SafeGetInt(1)
                            };
                            listResults.Add(report);
                        }

                        return listResults;
                    }
                }


                connection.Close();
            }

            return null;
        }

        public IEnumerable<CustOrdersDetail> GetCustOrdersDetail(int orderId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(@"CustOrdersDetail", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                var customerId = new SqlParameter
                {
                    ParameterName = "OrderID",
                    Value = orderId
                };

                command.Parameters.Add(customerId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        var listResults = new List<CustOrdersDetail>();

                        while (reader.Read())
                        {
                            var report = new CustOrdersDetail
                            {
                                ProductName = reader.SafeGetString(0),
                                UnitPrice = reader.GetDecimal(1),
                                Quantity = reader.GetInt16(2),
                                Discount = reader.GetInt32(3),
                                ExtendedPrice = reader.GetDecimal(4)
                            };

                            listResults.Add(report);
                        }

                        return listResults;
                    }
                }


                connection.Close();
            }

            return null;
        }

        protected override IEnumerable<Order> MapEntities(SqlDataReader reader)
        {
            var listResults = new List<Order>();

            while (reader.Read())
            {
                var entity = new Order
                {
                    OrderId = reader.GetInt32(0),
                    Customer = _customerRepository.SelectById(reader.SafeGetString(1)),
                    Employee = _employeeRepository.SelectById(reader.SafeGetInt(2)),
                    OrderDate = reader.SafeGetDateTime(3),
                    RequiredDate = reader.SafeGetDateTime(4),
                    ShippedDate = reader.SafeGetDateTime(5),
                    Freight = reader.GetDecimal(6),
                    ShipName = reader.SafeGetString(7),
                    ShipAddress = reader.SafeGetString(8),
                    ShipCity = reader.SafeGetString(9),
                    ShipRegion = reader.SafeGetString(10),
                    ShipPostalCode = reader.SafeGetString(11),
                    ShipCountry = reader.SafeGetString(12)
                };
                entity.OrderDetails = _orderDetailRepository.GetOrderDetails(entity.OrderId);


                if (!entity.OrderDate.HasValue)
                {
                    entity.OrderStatus = OrderStatusEnum.New;
                }
                else if (!entity.ShippedDate.HasValue)
                {
                    entity.OrderStatus = OrderStatusEnum.InProgress;
                }
                else
                {
                    entity.OrderStatus = OrderStatusEnum.Done;
                }

                listResults.Add(entity);
            }
            return listResults;
        }

        private SqlParameter[] GetOrderParameters(Order order)
        {
            return new[]
            {
                new SqlParameter { ParameterName = "OrderID", Value = order.OrderId },
                new SqlParameter { ParameterName = "CustomerID", Value = order.Customer.CustomerId ?? (object)DBNull.Value},
                new SqlParameter { ParameterName = "EmployeeID", Value = order.Employee.EmployeeId },
                new SqlParameter { ParameterName = "OrderDate", Value = order.OrderDate ?? (object)DBNull.Value},
                new SqlParameter { ParameterName = "RequiredDate", Value = order.RequiredDate ?? (object)DBNull.Value},
                new SqlParameter { ParameterName = "ShippedDate",   Value = order.ShippedDate ?? (object)DBNull.Value },
                new SqlParameter { ParameterName = "Freight", Value = order.Freight },
                new SqlParameter { ParameterName = "ShipName", Value = order.ShipName ?? (object)DBNull.Value},
                new SqlParameter { ParameterName = "ShipAddress", Value = order.ShipAddress ?? (object)DBNull.Value},
                new SqlParameter { ParameterName = "ShipCity", Value = order.ShipCity ?? (object)DBNull.Value},
                new SqlParameter { ParameterName = "ShipRegion", Value = order.ShipRegion ?? (object)DBNull.Value},
                new SqlParameter { ParameterName = "ShipPostalCode", Value = order.ShipPostalCode ?? (object)DBNull.Value},
                new SqlParameter { ParameterName = "ShipCountry", Value = order.ShipCountry ?? (object)DBNull.Value},
            };
        }

        private SqlParameter[] GetDetailsParameters(OrderDetail orderDetail, int orderId)
        {
            return new[]
            {
                new SqlParameter { ParameterName = "OrderID", Value = orderId },
                new SqlParameter { ParameterName = "ProductID", Value = orderDetail.Product.ProductId },
                new SqlParameter { ParameterName = "UnitPrice", Value = orderDetail.UnitPrice },
                new SqlParameter { ParameterName = "Quantity", Value = orderDetail.Quantity },
                new SqlParameter { ParameterName = "Discount", Value = orderDetail.Discount }
            };
        }

        
    }
}