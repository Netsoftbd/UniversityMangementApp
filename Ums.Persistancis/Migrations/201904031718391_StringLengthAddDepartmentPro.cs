namespace Ums.Persistancis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringLengthAddDepartmentPro : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Departments", "Code", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Code", c => c.String());
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false));
        }
    }
}
