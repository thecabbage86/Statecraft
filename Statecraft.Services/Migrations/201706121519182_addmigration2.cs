namespace Statecraft.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrdersDtoes", "SelectedTerritoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrdersDtoes", "SupportedOrConvoyedTerritoryId", c => c.Int());
            AlterColumn("dbo.OrdersDtoes", "DestinationTerritoryId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrdersDtoes", "DestinationTerritoryId", c => c.Long(nullable: false));
            AlterColumn("dbo.OrdersDtoes", "SupportedOrConvoyedTerritoryId", c => c.Long(nullable: false));
            AlterColumn("dbo.OrdersDtoes", "SelectedTerritoryId", c => c.Long(nullable: false));
        }
    }
}
