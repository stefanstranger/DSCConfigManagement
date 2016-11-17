namespace DSCConfigurationManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyGuids",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FQDN = c.String(nullable: false),
                        DSCGuid = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyGuids");
        }
    }
}
