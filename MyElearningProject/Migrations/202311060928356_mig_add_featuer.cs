namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_featuer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        FeatureID = c.Int(nullable: false, identity: true),
                        Title1 = c.String(),
                        Title2 = c.String(),
                        shortDescription = c.String(),
                        longDescription = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.FeatureID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Features");
        }
    }
}
