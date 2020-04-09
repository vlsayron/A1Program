using LinqToDB;
using LinqToDB.Data;
using Module5Linq2db.Models;

namespace Module5Linq2db
{
    public class DbNorthwind : DataConnection
    {
        public DbNorthwind() : base("Northwind")
        { }

        public ITable<Employee> Employees => GetTable<Employee>();
        public ITable<Order> Orders => GetTable<Order>();
        public ITable<Product> Products => GetTable<Product>();
        public ITable<Region> Regions => GetTable<Region>();
        public ITable<Category> Categories => GetTable<Category>();
        public ITable<Supplier> Suppliers => GetTable<Supplier>();
        public ITable<Shipper> Shippers => GetTable<Shipper>();
        public ITable<OrderDetail> OrderDetails => GetTable<OrderDetail>();
        public ITable<Customer> Customers => GetTable<Customer>();
        public ITable<CustomerCustomerDemo> CustomerCustomerDemo => GetTable<CustomerCustomerDemo>();
        public ITable<CustomerDemographic> CustomerDemographics => GetTable<CustomerDemographic>();
        public ITable<EmployeeTerritory> EmployeeTerritories => GetTable<EmployeeTerritory>();
        public ITable<Territory> Territories => GetTable<Territory>();
    }
}