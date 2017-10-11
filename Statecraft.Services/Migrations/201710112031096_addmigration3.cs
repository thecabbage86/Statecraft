namespace Statecraft.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayerDtoes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlayerDtoes", "Name");
        }
    }
}
