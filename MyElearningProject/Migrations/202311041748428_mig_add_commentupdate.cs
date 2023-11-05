namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_commentupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommentCourses", "Comment_CommentID", "dbo.Comments");
            DropForeignKey("dbo.CommentCourses", "Course_CourseID", "dbo.Courses");
            DropIndex("dbo.CommentCourses", new[] { "Comment_CommentID" });
            DropIndex("dbo.CommentCourses", new[] { "Course_CourseID" });
            CreateIndex("dbo.Comments", "CourseID");
            AddForeignKey("dbo.Comments", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            DropTable("dbo.CommentCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CommentCourses",
                c => new
                    {
                        Comment_CommentID = c.Int(nullable: false),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Comment_CommentID, t.Course_CourseID });
            
            DropForeignKey("dbo.Comments", "CourseID", "dbo.Courses");
            DropIndex("dbo.Comments", new[] { "CourseID" });
            CreateIndex("dbo.CommentCourses", "Course_CourseID");
            CreateIndex("dbo.CommentCourses", "Comment_CommentID");
            AddForeignKey("dbo.CommentCourses", "Course_CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.CommentCourses", "Comment_CommentID", "dbo.Comments", "CommentID", cascadeDelete: true);
        }
    }
}
