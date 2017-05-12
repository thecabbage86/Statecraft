namespace Statecraft.Services.Migrations
{
    using Common.DTOs;
    using Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Statecraft.Services.DB.GameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Statecraft.Services.DB.GameContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //Add players
            List<Guid> playerIds = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            var players = new List<PlayerDto>()
            {
                new PlayerDto() { Id = playerIds[0], RankScore = 10, Reliability = 10 },
                new PlayerDto() { Id = playerIds[1], RankScore = 10, Reliability = 10 },
                new PlayerDto() { Id = playerIds[2], RankScore = 10, Reliability = 10 },
                new PlayerDto() { Id = playerIds[3], RankScore = 10, Reliability = 10 },
                new PlayerDto() { Id = playerIds[4], RankScore = 10, Reliability = 10 },
                new PlayerDto() { Id = playerIds[5], RankScore = 10, Reliability = 10 },
                new PlayerDto() { Id = playerIds[6], RankScore = 10, Reliability = 10 }
            };
            players.ForEach(pl => context.Players.AddOrUpdate(p => p.Id, pl));
            context.SaveChanges();

            //Add games
            var games = new List<GameDto>() { new GameDto() { Id = new Guid("00000000-0000-0000-0000-000000000010"), AustriaPlayerId = playerIds[0], CreatorPlayerId = playerIds[0], HasBegun = false },
                new GameDto() { Id = new Guid("00000000-0000-0000-0000-000000000100"), GermanyPlayerId = playerIds[0], AustriaPlayerId = playerIds[1], CreatorPlayerId = playerIds[0],
                    EnglandPlayerId = playerIds[2], FrancePlayerId = playerIds[3], ItalyPlayerId = playerIds[4], RussiaPlayerId = playerIds[5], TurkeyPlayerId = playerIds[6], HasBegun = true,
                    GameRoundId = 1, IsRankedOption = true, RoundLengthOption = new TimeSpan(10, 0, 0) },
                new GameDto() { Id = new Guid("00000000-0000-0000-0000-000000000103"), EnglandPlayerId = playerIds[0], GermanyPlayerId = playerIds[2], AustriaPlayerId = playerIds[1], CreatorPlayerId = playerIds[0],
                    FrancePlayerId = playerIds[3], ItalyPlayerId = playerIds[4], RussiaPlayerId = playerIds[5], TurkeyPlayerId = playerIds[6],
                    HasBegun = true, IsFinished = true, IsRankedOption = true, RoundLengthOption = new TimeSpan(10, 0, 0) } };

            var startedGame = new Game(games[1]);
            startedGame.CurrentGameState = new GameState();
            startedGame.CurrentGameState.InitializeMap();
            games[1] = startedGame.ToDto();

            games.ForEach(ga => context.Games.AddOrUpdate(g => g.Id, ga));
            context.SaveChanges();

            //Add territories
            var territories = new List<TerritoryDto>();
            foreach(var territory in startedGame.CurrentGameState.Map.Territories)
            {
                territories.Add(territory.ToDto(startedGame.Id, startedGame.CurrentGameState.Round.GameRoundId));
            }
            foreach(var territory in territories)
            {
                var territoryInDb = context.Territories.Where(t => t.Id == territory.Id && t.GameId == territory.GameId && t.GameRoundId == territory.GameRoundId);
                if(territoryInDb == null)
                {
                    context.Territories.Add(territory);
                }
            }
            context.SaveChanges();

        }
    }
}
