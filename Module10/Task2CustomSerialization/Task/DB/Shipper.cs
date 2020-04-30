namespace Task.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public sealed class Shipper
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }

        [DataMember]
        public int ShipperId { get; set; }

        [Required]
        [StringLength(40)]
        [DataMember]
        public string CompanyName { get; set; }

        [StringLength(24)]
        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public ICollection<Order> Orders { get; set; }
    }
}