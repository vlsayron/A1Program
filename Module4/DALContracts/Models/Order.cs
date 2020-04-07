using System;
using System.Collections.Generic;

namespace DALContracts.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
