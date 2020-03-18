using System.Collections;
using System.Collections.Generic;
using DALContracts.Models;

namespace NorthwindDAL.Repositories
{
    internal class OrderDetailRepository
    {
        private readonly ProductRepository _productRepository;

        public OrderDetailRepository(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<OrderDetail> GetOrderDetails(int orderId)
        {
            return null;
        }
    }
}
