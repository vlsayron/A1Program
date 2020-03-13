using DALContracts.Models;
using DALContracts.Repositories;

namespace DALContracts
{
    public interface IDbContext
    {
        IRepository<CustomerDemographic> CustomerDemographics { get; }
        IRepository<Shipper> Shippers { get; }
        IRepository<Customer> Customers { get; }


        IRepository<Region> Regions { get; }
        IRepository<Territory> Territories { get; }
        IRepository<Employee> Employees { get; }


        IRepository<Category> Categories { get; }
        IRepository<Supplier> Suppliers { get; }
        IRepository<Product> Products { get; }

        IOrderRepository Orders { get; }
        // IRepository<OrderDetail> OrderDetails { get; }
    }
}