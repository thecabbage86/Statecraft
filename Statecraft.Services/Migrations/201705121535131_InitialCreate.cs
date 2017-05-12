namespace Statecraft.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameDtoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsGunboatOption = c.Boolean(nullable: false),
                        IsRankedOption = c.Boolean(nullable: false),
                        RoundLengthOption = c.Time(nullable: false, precision: 7),
                        HasBegun = c.Boolean(nullable: false),
                        IsFinished = c.Boolean(nullable: false),
                        CreatorPlayerId = c.Guid(nullable: false),
                        EnglandPlayerId = c.Guid(),
                        FrancePlayerId = c.Guid(),
                        ItalyPlayerId = c.Guid(),
                        RussiaPlayerId = c.Guid(),
                        AustriaPlayerId = c.Guid(),
                        TurkeyPlayerId = c.Guid(),
                        GermanyPlayerId = c.Guid(),
                        GameRoundId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TerritoryDtoes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        GameId = c.Guid(nullable: false),
                        GameRoundId = c.Int(nullable: false),
                        OccupyingUnitType = c.Int(),
                        OccupyingUnitCountry = c.Int(),
                        Owner = c.Int(),
                    })
                .PrimaryKey(t => new { t.Id, t.GameId, t.GameRoundId })
                .ForeignKey("dbo.GameDtoes", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.OrdersDtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Guid(nullable: false),
                        GameRoundId = c.Int(nullable: false),
                        OrdersType = c.Int(nullable: false),
                        SelectedTerritoryId = c.Long(nullable: false),
                        SupportedOrConvoyedTerritoryId = c.Long(nullable: false),
                        DestinationTerritoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameDtoes", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.PlayerDtoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RankScore = c.Int(nullable: false),
                        Reliability = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdersDtoes", "GameId", "dbo.GameDtoes");
            DropForeignKey("dbo.TerritoryDtoes", "GameId", "dbo.GameDtoes");
            DropIndex("dbo.OrdersDtoes", new[] { "GameId" });
            DropIndex("dbo.TerritoryDtoes", new[] { "GameId" });
            DropTable("dbo.PlayerDtoes");
            DropTable("dbo.OrdersDtoes");
            DropTable("dbo.TerritoryDtoes");
            DropTable("dbo.GameDtoes");
        }
    }
}
