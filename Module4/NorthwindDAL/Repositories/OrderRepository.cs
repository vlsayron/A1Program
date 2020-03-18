using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    internal class OrderRepository : ExecuteCommandBase, IOrderRepository
    {
        private readonly string _connectionString;
        private readonly EmployeeRepository _employeeRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly OrderDetailRepository _orderDetailRepository;

        public OrderRepository(string connectionString, 
            EmployeeRepository employeeRepository,
            CustomerRepository customerRepository, 
            OrderDetailRepository orderDetailRepository) : base(connectionString)
        {
            _connectionString = connectionString;
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        public Order SelectById(int id)
        {
            var sqlSelectById =
                @"SELECT [OrderID], [CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry] FROM [dbo].[Orders] WHERE [OrderID] = @IdEntity";

            var order = SelectById(sqlSelectById, id, GetEntities);



            return order;
        }

        public IEnumerable<Order> SelectAll()
        {
            var sqlSelectAll =
                @"SELECT [OrderID], [CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry] FROM [dbo].[Orders]";

            var orders = SelectAll(sqlSelectAll, GetEntities).ToList();

            foreach (var order in orders)
            {
                order.OrderDetails = _orderDetailRepository.GetOrderDetails(order.OrderId);
            }

            return orders;

        }
        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Order> GetEntities(SqlDataReader reader)
        {
            var listResults = new List<Order>();

            while (reader.Read())
            {
                var entity = new Order
                {
                    OrderId = reader.GetInt32(0),
                    Customer = _customerRepository.SelectById(reader.SafeGetString(1)),
                    Employee = _employeeRepository.SelectById(reader.SafeGetInt(2)),
                    OrderDate = reader.GetDateTime(3),
                    RequiredDate = reader.GetDateTime(4),
                    ShippedDate = reader.SafeGetDateTime(5),
                    Freight = reader.GetDecimal(6),
                    ShipName = reader.SafeGetString(7),
                    ShipAddress = reader.SafeGetString(8),
                    ShipCity = reader.SafeGetString(9),
                    ShipRegion = reader.SafeGetString(10),
                    ShipPostalCode = reader.SafeGetString(11),
                    ShipCountry = reader.SafeGetString(12)
                };

                listResults.Add(entity);
            }
            return listResults;
        }


    }
}