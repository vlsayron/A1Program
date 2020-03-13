using System.ComponentModel.DataAnnotations;

namespace DALContracts.Models
{
    public class CustomerDemographic
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int SupplierId { get; set; }

        public string CustomerDesc { get; set; }
    }
}
