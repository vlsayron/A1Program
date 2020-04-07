using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Task1Linq2DB.Models
{
	[Table(Name = "Categories")]
    public class Category
    {
        [PrimaryKey, Identity]
        [Column(Name = "CategoryID"), NotNull]
        public int Id { get; set; } 
        [Column, NotNull] 
        public string CategoryName { get; set; } 
        [Column, Nullable] 
        public string Description { get; set; } 
        [Column, Nullable] 
        public byte[] Picture { get; set; }


        [Association(ThisKey = "CategoryID", 
            OtherKey = "CategoryID", 
            CanBeNull = true, 
            Relationship = Relationship.OneToMany, 
            IsBackReference = true)]
        public IEnumerable<Product> Products { get; set; }

        
    }
}