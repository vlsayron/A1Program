using System.Data.Entity.Migrations;

namespace Task2EntityFrameworkVersions.Migrations
{
    public partial class Version_13 : DbMigration
    {
        public override void Up()
        {
            RenameTable("dbo.Region", "dbo.Regions");
            DropTable("dbo.Customers");

            CreateTable(
                    "dbo.Customers",
                    c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Phone = c.String(),
                        FoundationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
        }

        public override void Down()
        {
            RenameTable("dbo.Regions", "dbo.Region");
            DropColumn("dbo.Customers", "FoundationDate");
        }
    }
}
