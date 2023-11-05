namespace MyElearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_columns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        CategoryID = c.Int(nullable: false),
                        InstructorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.InstructorID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.CourseRegisters",
                c => new
                    {
                        CourseRegisterID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CourseRegisterID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        InstructorID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(maxLength: 30),
                        ImageUrl = c.String(),
                        Title = c.String(),
                        CoverImage = c.String(),
                    })
                .PrimaryKey(t => t.InstructorID);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        TestimonialID = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Title = c.String(),
                        ImageUrl = c.String(),
                        Comment = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.TestimonialID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "InstructorID", "dbo.Instructors");
            DropForeignKey("dbo.CourseRegisters", "StudentID", "dbo.Students");
            DropForeignKey("dbo.CourseRegisters", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CategoryID", "dbo.Categories");
            DropIndex("dbo.CourseRegisters", new[] { "CourseID" });
            DropIndex("dbo.CourseRegisters", new[] { "StudentID" });
            DropIndex("dbo.Courses", new[] { "InstructorID" });
            DropIndex("dbo.Courses", new[] { "CategoryID" });
            DropTable("dbo.Testimonials");
            DropTable("dbo.Instructors");
            DropTable("dbo.Students");
            DropTable("dbo.CourseRegisters");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
