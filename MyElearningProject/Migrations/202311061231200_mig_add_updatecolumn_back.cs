namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_updatecolumn_back : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "TeacherName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "TeacherName", c => c.String());
        }
    }
}
