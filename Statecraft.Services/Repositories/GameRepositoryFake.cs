using Statecraft.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statecraft.Common.Models;
using Statecraft.Common.Enums;

namespace Statecraft.Services.Repositories
{
    public class GameRepositoryFake : IGameRepository
    {

        public Game CreateNewGame(Game game)
        {
            game.Id = Guid.NewGuid();
            return game;
        }

        public Game GetGameById(Guid id)
        {
            return new Game() { Id = id, GermanyPlayerId = Guid.NewGuid(), HasBegun = true,
                CurrentGameState = new GameState() { Round = new GameRound() { Phase = Phase.Retreat, Season = Season.Spring, Year = 1901 } },
                Options = new GameOptions() { IsRanked = true, RoundLength = new TimeSpan(10, 0, 0) } };
        }

        public IList<Game> GetGamesByPlayerId(Guid playerId)
        {
            return new List<Game>() { new Game() { Id = new Guid("00000000-0000-0000-0000-000000000010"), AustriaPlayerId = playerId, CreatorPlayerId = playerId, HasBegun = false },
                new Game() { Id = new Guid("00000000-0000-0000-0000-000000000100"), GermanyPlayerId = playerId, HasBegun = true, CurrentGameState = new GameState() { Round = new GameRound() { Phase = Phase.Movement, Season = Season.Spring, Year = 1901 } },
                    Options = new GameOptions() { IsRanked = true, RoundLength = new TimeSpan(10, 0, 0) }  },
                new Game() { Id = new Guid("00000000-0000-0000-0000-000000000103"), EnglandPlayerId = playerId, HasBegun = true, IsFinished = true, CurrentGameState = new GameState(), Options = new GameOptions() { IsRanked = true, RoundLength = new TimeSpan(10, 0, 0) } },
            };
        }

        public Game UpdateGame(Game game)
        {
            return game;
        }
    }
}