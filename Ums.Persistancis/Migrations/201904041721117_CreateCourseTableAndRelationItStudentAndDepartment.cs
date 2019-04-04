namespace Ums.Persistancis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCourseTableAndRelationItStudentAndDepartment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .Index(t => t.DepartmentId);
            
            AddColumn("dbo.Students", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "CourseId");
            AddForeignKey("dbo.Students", "CourseId", "dbo.Courses", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropColumn("dbo.Students", "CourseId");
            DropTable("dbo.Courses");
        }
    }
}
