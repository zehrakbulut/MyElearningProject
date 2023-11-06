namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_about : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        AboutName = c.String(),
                        Title = c.String(),
                        Description1 = c.String(),
                        Description2 = c.String(),
                    })
                .PrimaryKey(t => t.AboutID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Abouts");
        }
    }
}
