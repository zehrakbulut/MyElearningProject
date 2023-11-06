namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_aboutpurpose : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutPurposes",
                c => new
                    {
                        AboutPurposeID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.AboutPurposeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AboutPurposes");
        }
    }
}
