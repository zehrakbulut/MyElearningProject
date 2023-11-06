namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_updatecolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "TeacherName", c => c.String());
            AddColumn("dbo.Courses", "StudentCount", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "CourseCategoryName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "CourseCategoryName");
            DropColumn("dbo.Courses", "StudentCount");
            DropColumn("dbo.Courses", "TeacherName");
        }
    }
}
