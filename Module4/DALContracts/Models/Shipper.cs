using System.ComponentModel.DataAnnotations;

namespace DALContracts.Models
{
    public class Shipper
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ShipperId { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string CompanyName { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }
    }
}
