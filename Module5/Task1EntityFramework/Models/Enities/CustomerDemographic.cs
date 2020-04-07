using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task2EntityFramework.Models.Enities
{
    public class CustomerDemographic
    {
        public CustomerDemographic()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        [StringLength(10)]
        public string CustomerTypeID { get; set; }

        [Column(TypeName = "ntext")]
        public string CustomerDesc { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
