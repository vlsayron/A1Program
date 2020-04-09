using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Module5Linq2db.Models
{
	[Table(Schema = "dbo", Name = "Region")]
    public class Region
    {
        [Column(Name = "RegionID"), PrimaryKey, NotNull] 
        public int Id { get; set; }
        [Column, NotNull] 
        public string RegionDescription { get; set; }

       
        [Association(ThisKey = "RegionID", OtherKey = "RegionID", 
            CanBeNull = true, 
            Relationship = Relationship.OneToMany, 
            IsBackReference = true)]
        public IEnumerable<Territory> Territories { get; set; }

       
    }

}