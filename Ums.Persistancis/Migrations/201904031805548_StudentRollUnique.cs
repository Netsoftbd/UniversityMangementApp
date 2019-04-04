namespace Ums.Persistancis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentRollUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Roll", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Students", "Roll", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Students", new[] { "Roll" });
            AlterColumn("dbo.Students", "Roll", c => c.String());
        }
    }
}
