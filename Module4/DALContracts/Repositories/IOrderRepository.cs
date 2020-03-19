using System;
using System.Collections.Generic;
using DALContracts.Models;
using DALContracts.Models.Reports;

namespace DALContracts.Repositories
{
    public interface IOrderRepository: IRepository<Order>
    {
        int? SaveNewOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
        void UpdateToInProgress(int orderId, DateTime date);
        void UpdateToDone(int orderId, DateTime date);
        IEnumerable<CustOrderHist> GetCustOrderHist(string customerId);
        IEnumerable<CustOrdersDetail> GetCustOrdersDetail(int orderId);

    }
}
