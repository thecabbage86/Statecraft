using Statecraft.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statecraft.Common.Models;
using Statecraft.Common.Enums;
using Statecraft.Services.DB.DBOs;

namespace Statecraft.Services.Repositories
{
    public class GameRepositoryFake : IGameRepository
    {

        public GameDbo CreateNewGame(GameDbo game)
        {
            game.Id = Guid.NewGuid();
            return game;
        }

        public GameDbo GetGameById(Guid id)
        {
            return new GameDbo() { Id = id, GermanyPlayerId = Guid.NewGuid(), HasBegun = true,
                GameRoundId = 2, 
                IsRankedOption = true, RoundLengthOption = new TimeSpan(10, 0, 0) };
        }

        public IList<GameDbo> GetGamesByPlayerId(Guid playerId)
        {
            return new List<GameDbo>() { new GameDbo() { Id = new Guid("00000000-0000-0000-0000-000000000010"), AustriaPlayerId = playerId, CreatorPlayerId = playerId, HasBegun = false },
                new GameDbo() { Id = new Guid("00000000-0000-0000-0000-000000000100"), GermanyPlayerId = playerId, HasBegun = true, GameRoundId = 1, IsRankedOption = true, RoundLengthOption = new TimeSpan(10, 0, 0) },
                new GameDbo() { Id = new Guid("00000000-0000-0000-0000-000000000103"), EnglandPlayerId = playerId, HasBegun = true, IsFinished = true, IsRankedOption = true, RoundLengthOption = new TimeSpan(10, 0, 0) }
            };
        }

        public GameDbo UpdateGame(GameDbo game)
        {
            return game;
        }
    }
}