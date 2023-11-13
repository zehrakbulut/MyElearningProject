namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_informationAddress : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.InformationAddresses", "mail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InformationAddresses", "mail", c => c.String());
        }
    }
}
