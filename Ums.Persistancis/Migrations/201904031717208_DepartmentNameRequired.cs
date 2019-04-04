namespace Ums.Persistancis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentNameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String());
        }
    }
}
