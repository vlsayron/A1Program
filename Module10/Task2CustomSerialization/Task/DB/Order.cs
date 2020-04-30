namespace Task.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        [StringLength(5)]
        public string CustomerId { get; set; }

        [DataMember]
        public int? EmployeeId { get; set; }

        [DataMember]
        public DateTime? OrderDate { get; set; }

        [DataMember]
        public DateTime? RequiredDate { get; set; }

        [DataMember]
        public DateTime? ShippedDate { get; set; }

        [DataMember]
        public int? ShipVia { get; set; }

        [DataMember]
        [Column(TypeName = "money")]
        public decimal? Freight { get; set; }

        [DataMember]
        [StringLength(40)]
        public string ShipName { get; set; }

        [DataMember]
        [StringLength(60)]
        public string ShipAddress { get; set; }

        [DataMember]
        [StringLength(15)]
        public string ShipCity { get; set; }

        [DataMember]
        [StringLength(15)]
        public string ShipRegion { get; set; }

        [DataMember]
        [StringLength(10)]
        public string ShipPostalCode { get; set; }

        [DataMember]
        [StringLength(15)]
        public string ShipCountry { get; set; }

        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Shipper Shipper { get; set; }
    }
}
