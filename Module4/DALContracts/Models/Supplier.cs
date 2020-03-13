using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DALContracts.Models
{
    public class Supplier
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int SupplierId { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string CompanyName { get; set; }

        [StringLength(30, MinimumLength = 0)]
        public string ContactName { get; set; }

        [StringLength(30, MinimumLength = 0)]
        public string ContactTitle { get; set; }

        [StringLength(60, MinimumLength = 0)]
        public string Address { get; set; }

        [StringLength(15, MinimumLength = 0)]
        public string City { get; set; }

        [StringLength(15, MinimumLength = 0)]
        public string Region { get; set; }

        [StringLength(10, MinimumLength = 0)]
        public string PostalCode { get; set; }

        [StringLength(15, MinimumLength = 0)]
        public string Country { get; set; }

        [StringLength(24, MinimumLength = 0)]
        public string Phone { get; set; }

        [StringLength(24, MinimumLength = 0)]
        public string Fax { get; set; }

        public string HomePage { get; set; }

        public IEnumerable<CustomerDemographic> CustomerDemographics { get; set; }
    }
}
