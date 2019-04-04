namespace Ums.Persistancis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBaseModelinStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "CreateBy", c => c.String());
            AddColumn("dbo.Students", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "EditBy", c => c.String());
            AddColumn("dbo.Students", "EditDate", c => c.DateTime());
            AddColumn("dbo.Students", "DeleteBy", c => c.String());
            AddColumn("dbo.Students", "DeleteDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "DeleteDate");
            DropColumn("dbo.Students", "DeleteBy");
            DropColumn("dbo.Students", "EditDate");
            DropColumn("dbo.Students", "EditBy");
            DropColumn("dbo.Students", "CreateDate");
            DropColumn("dbo.Students", "CreateBy");
            DropColumn("dbo.Students", "IsDeleted");
        }
    }
}
