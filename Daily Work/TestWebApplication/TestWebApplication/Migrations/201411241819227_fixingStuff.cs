namespace TestWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingStuff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ticket", "Description", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ticket", "Description", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
