using DALContracts.Models;
using DALContracts.Repositories;

namespace DALContracts
{
    public interface IDbContext
    {
        IRepository<Category> Categories { get; }
        IRepository<Supplier> Suppliers { get; }
        IRepository<Product> Products { get; }
        IRepository<Customer> Customers { get; }
        IRepository<Employee> Employees { get; }
        IOrderRepository Orders { get; }
        
    }
}