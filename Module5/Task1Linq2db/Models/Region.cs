using System.Collections.Generic;
using LinqToDB.Mapping;
using Task1Linq2db.Models;

namespace Task1Linq2DB.Models
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