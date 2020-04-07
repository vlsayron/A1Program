using DALContracts;
using DALContracts.Models;
using DALContracts.Repositories;
using NorthwindDAL.Repositories;

namespace NorthwindDAL
{
    public class DbContext : IDbContext
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly SupplierRepository _supplierRepository;
        private readonly ProductRepository _productRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly OrderRepository _orderRepository;
       

        public IRepository<Category> Categories => _categoryRepository;
        public IRepository<Supplier> Suppliers => _supplierRepository;
        public IRepository<Product> Products => _productRepository;
        public IRepository<Customer> Customers => _customerRepository;
        public IRepository<Employee> Employees => _employeeRepository;
        public IOrderRepository Orders => _orderRepository;
       


        public DbContext(string stringConnection)
        {
            _categoryRepository = new CategoryRepository(stringConnection);
            _supplierRepository = new SupplierRepository(stringConnection);
            _productRepository = new ProductRepository(stringConnection, _categoryRepository, _supplierRepository);
            _customerRepository = new CustomerRepository(stringConnection);
            _employeeRepository = new EmployeeRepository(stringConnection);
            _orderRepository = new OrderRepository(stringConnection, _employeeRepository, _customerRepository,
                new OrderDetailRepository(stringConnection, _productRepository));

        }

    }
}
