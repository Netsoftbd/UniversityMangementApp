namespace Ums.Persistancis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegInStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Reg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Reg");
        }
    }
}
