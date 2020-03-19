using System.Collections.Generic;
using System.Data.SqlClient;
using DALContracts.Models;
using DALContracts.Repositories;

namespace NorthwindDAL.Repositories
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        
        private readonly EmployeeRepository _employeeRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly OrderDetailRepository _orderDetailRepository;

        private const string SqlSelectById =
            @"SELECT [OrderID], [CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry] FROM [dbo].[Orders] WHERE [OrderID] = @IdEntity;";
        private const string SqlSelectAll =
            @"SELECT [OrderID], [CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry] FROM [dbo].[Orders];";

        public OrderRepository(string connectionString, EmployeeRepository employeeRepository, CustomerRepository customerRepository, OrderDetailRepository orderDetailRepository) : base(connectionString, SqlSelectAll, SqlSelectById)
        {
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
            _orderDetailRepository = orderDetailRepository;
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
                entity.OrderDetails = _orderDetailRepository.GetOrderDetails(entity.OrderId);

               
                if (!entity.OrderDate.HasValue)
                {
                    entity.OrderStatus = OrderStatusEnum.New;
                }
                else if(!entity.ShippedDate.HasValue)
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

       
    }
}