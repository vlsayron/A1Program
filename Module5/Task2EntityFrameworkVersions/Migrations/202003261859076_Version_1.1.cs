using System.Data.Entity.Migrations;

namespace Task2EntityFrameworkVersions.Migrations
{
    public partial class Version_11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.EmployeeCreditCardDatas",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(),
                        ExpirationDate = c.DateTime(nullable: false),
                        CardHolderName = c.String(),
                        LinkToEmployee = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.EmployeeCreditCardDatas");
        }
    }
}
