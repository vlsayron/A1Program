using System.ComponentModel.DataAnnotations;

namespace DALContracts.Models
{
    public class OrderDetail
    {
        [Required]
        public Order Order { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public short Quantity { get; set; }

        [Required]
        public float Discount { get; set; }
    }
}
