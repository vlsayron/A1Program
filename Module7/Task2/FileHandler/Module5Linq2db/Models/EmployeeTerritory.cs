using LinqToDB.Mapping;

namespace Module5Linq2db.Models
{
	[Table(Schema = "dbo", Name = "EmployeeTerritories")]
    public class EmployeeTerritory
    {
        [PrimaryKey(1), NotNull] 
        public int EmployeeID { get; set; } 
        [PrimaryKey(2), NotNull] 
        public string TerritoryID { get; set; } 

       
        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID",
            CanBeNull = false, 
            Relationship = Relationship.ManyToOne,
            KeyName = "FK_EmployeeTerritories_Employees", 
            BackReferenceName = "EmployeeTerritories")]
        public Employee Employee { get; set; }

        
        [Association(ThisKey = "TerritoryID", OtherKey = "TerritoryID", 
            CanBeNull = false, 
            Relationship = Relationship.ManyToOne, 
            KeyName = "FK_EmployeeTerritories_Territories",
            BackReferenceName = "EmployeeTerritories")]
        public Territory Territory { get; set; }

       
    }
}
