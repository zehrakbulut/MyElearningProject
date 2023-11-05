namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_process : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Processes",
                c => new
                    {
                        ProcessID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProcessID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Processes", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Processes", "CourseID", "dbo.Courses");
            DropIndex("dbo.Processes", new[] { "CourseID" });
            DropIndex("dbo.Processes", new[] { "StudentID" });
            DropTable("dbo.Processes");
        }
    }
}
