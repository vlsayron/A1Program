using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DALContracts.Models
{
    public class Order
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int OrderId { get; set; }

        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime ShippedDate { get; set; }

        public Shipper ShipVia { get; set; }

        public decimal Freight { get; set; }

        [StringLength(40)]
        public string ShipName { get; set; }

        [StringLength(60)]
        public string ShipAddress { get; set; }

        [StringLength(15)]
        public string ShipCity { get; set; }

        [StringLength(15)]
        public string ShipRegion { get; set; }

        [StringLength(10)]
        public string ShipPostalCode { get; set; }

        [StringLength(15)]
        public string ShipCountry { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }

    }
}
