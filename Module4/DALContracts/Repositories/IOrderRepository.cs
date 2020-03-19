using DALContracts.Models;

namespace DALContracts.Repositories
{
    public interface IOrderRepository: IRepository<Order>
    {
        int? SaveNewOrder(Order order);
    }
}
