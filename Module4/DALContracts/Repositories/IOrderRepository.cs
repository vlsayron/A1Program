using System;
using System.Collections.Generic;
using DALContracts.Models;

namespace DALContracts.Repositories
{
    public interface IOrderRepository
    {
        Order SelectById(int id);
        IEnumerable<Order> SelectAll();
        IEnumerable<Order> Find(Func<Order, bool> predicate);
    }
}
