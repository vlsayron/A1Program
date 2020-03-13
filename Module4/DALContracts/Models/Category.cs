using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace DALContracts.Models
{
    public class Category
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
        
        [Required]
        [StringLength(15, MinimumLength = 1)]
        public string CategoryName { get; set; }
        
        public string Description { get; set; }
        
        public Bitmap Picture { get; set; }
    }
}
