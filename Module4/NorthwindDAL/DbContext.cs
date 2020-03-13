using DALContracts;
using DALContracts.Models;
using DALContracts.Repositories;
using NorthwindDAL.Repositories;

namespace NorthwindDAL
{
    public class DbContext : IDbContext
    {
        private readonly CustomerDemographicRepository _customerDemographicRepository;
        private readonly ShipperRepository _shipperRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly RegionRepository _regionRepository;
        private readonly TerritoryRepository _territoryRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly SupplierRepository _supplierRepository;
        private readonly ProductRepository _productRepository;
        private readonly OrderRepository _orderRepository;

        public IRepository<CustomerDemographic> CustomerDemographics => _customerDemographicRepository;
        public IRepository<Customer> Customers => _customerRepository;
        public IRepository<Shipper> Shippers => _shipperRepository;
        public IRepository<Region> Regions => _regionRepository;
        public IRepository<Territory> Territories => _territoryRepository;
        public IRepository<Employee> Employees => _employeeRepository;
        public IRepository<Category> Categories => _categoryRepository;
        public IRepository<Supplier> Suppliers => _supplierRepository;
        public IRepository<Product> Products => _productRepository;
        public IOrderRepository Orders => _orderRepository;


        public DbContext(string stringConnection)
        {
            _customerDemographicRepository = new CustomerDemographicRepository(stringConnection);
            _shipperRepository = new ShipperRepository(stringConnection);
            _customerRepository = new CustomerRepository(stringConnection);
            _regionRepository = new RegionRepository(stringConnection);
            _territoryRepository = new TerritoryRepository(stringConnection);
            _employeeRepository = new EmployeeRepository(stringConnection);
            _categoryRepository = new CategoryRepository(stringConnection);
            _supplierRepository = new SupplierRepository(stringConnection);
            _productRepository = new ProductRepository(stringConnection);
            _orderRepository = new OrderRepository(stringConnection);
        }

    }
}
