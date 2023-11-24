namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_coursewatchlist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseWatchLists",
                c => new
                    {
                        CourseWatchListID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        VideoUrl = c.String(),
                    })
                .PrimaryKey(t => t.CourseWatchListID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseWatchLists", "CourseID", "dbo.Courses");
            DropIndex("dbo.CourseWatchLists", new[] { "CourseID" });
            DropTable("dbo.CourseWatchLists");
        }
    }
}
