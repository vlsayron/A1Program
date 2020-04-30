namespace Task.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            CustomerDemographics = new HashSet<CustomerDemographic>();
        }

        [StringLength(5)]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [StringLength(40)]
        [DataMember]
        public string CompanyName { get; set; }

        [StringLength(30)]
        [DataMember]
        public string ContactName { get; set; }

        [StringLength(30)]
        [DataMember]
        public string ContactTitle { get; set; }

        [StringLength(60)]
        [DataMember]
        public string Address { get; set; }

        [StringLength(15)]
        [DataMember]
        public string City { get; set; }

        [StringLength(15)]
        [DataMember]
        public string Region { get; set; }

        [StringLength(10)]
        [DataMember]
        public string PostalCode { get; set; }

        [StringLength(15)]
        [DataMember]
        public string Country { get; set; }

        [StringLength(24)]
        [DataMember]
        public string Phone { get; set; }

        [StringLength(24)]
        [DataMember]
        public string Fax { get; set; }

        [DataMember]
        public ICollection<Order> Orders { get; set; }

        [DataMember]
        public ICollection<CustomerDemographic> CustomerDemographics { get; set; }
    }
}
