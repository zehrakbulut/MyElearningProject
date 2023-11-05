namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_boolstatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Testimonials", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Testimonials", "Status", c => c.String());
        }
    }
}
