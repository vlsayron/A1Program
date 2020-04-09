using System.Collections.Generic;
using LinqToDB.Mapping;

namespace Module5Linq2db.Models
{
	public class Territory
    {
        [Column(Name = "TerritoryID"), PrimaryKey, NotNull] 
        public string Id { get; set; } 
        [Column, NotNull] 
        public string TerritoryDescription { get; set; }
        [Column, NotNull] 
        public int RegionID { get; set; }

       
        [Association(ThisKey = "TerritoryID", OtherKey = "TerritoryID", 
            CanBeNull = true, 
            Relationship = Relationship.OneToMany, 
            IsBackReference = true)]
        public IEnumerable<EmployeeTerritory> EmployeeTerritories { get; set; }

        
        [Association(ThisKey = "RegionID", OtherKey = "RegionID", 
            CanBeNull = false, 
            Relationship = Relationship.ManyToOne, 
            KeyName = "FK_Territories_Region", 
            BackReferenceName = "Territories")]
        public Region Region { get; set; }

        
    }
}
