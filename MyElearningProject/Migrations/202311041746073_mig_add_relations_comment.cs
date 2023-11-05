namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_relations_comment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentCourses",
                c => new
                    {
                        Comment_CommentID = c.Int(nullable: false),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Comment_CommentID, t.Course_CourseID })
                .ForeignKey("dbo.Comments", t => t.Comment_CommentID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID, cascadeDelete: true)
                .Index(t => t.Comment_CommentID)
                .Index(t => t.Course_CourseID);
            
            AddColumn("dbo.Comments", "StudentID", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "CourseID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "StudentID");
            AddForeignKey("dbo.Comments", "StudentID", "dbo.Students", "StudentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.CommentCourses", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.CommentCourses", "Comment_CommentID", "dbo.Comments");
            DropIndex("dbo.CommentCourses", new[] { "Course_CourseID" });
            DropIndex("dbo.CommentCourses", new[] { "Comment_CommentID" });
            DropIndex("dbo.Comments", new[] { "StudentID" });
            DropColumn("dbo.Comments", "CourseID");
            DropColumn("dbo.Comments", "StudentID");
            DropTable("dbo.CommentCourses");
        }
    }
}
