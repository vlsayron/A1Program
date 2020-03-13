using System.ComponentModel.DataAnnotations;

namespace DALContracts.Models
{
    public class Region
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int RegionId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string RegionDescription { get; set; }
    }
}
