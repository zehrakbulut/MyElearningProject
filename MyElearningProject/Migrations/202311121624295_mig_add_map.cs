namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_map : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Maps",
                c => new
                    {
                        MapID = c.Int(nullable: false, identity: true),
                        EmbedLink = c.String(),
                    })
                .PrimaryKey(t => t.MapID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Maps");
        }
    }
}
