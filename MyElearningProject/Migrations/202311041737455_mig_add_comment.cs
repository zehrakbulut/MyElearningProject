namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_comment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                        CommentStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
