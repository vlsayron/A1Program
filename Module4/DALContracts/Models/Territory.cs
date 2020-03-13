using System.ComponentModel.DataAnnotations;

namespace DALContracts.Models
{
    public class Territory
    {
        [Required]
        [Range(1, 20)]
        public string TerritoryId { get; set; }

        [Required]
        [Range(1, 50)]
        public string TerritoryDescription { get; set; }

        [Required]
        public Region Region { get; set; }
    }
}
