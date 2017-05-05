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
        private Random rand = new Random(55);

        public Game CreateNewGame(Game game)
        {
            game.Id = rand.Next(100, int.MaxValue);
            return game;
        }

        public Game GetGameById(int id)
        {
            return new Game() { Id = id, GermanyPlayerId = Guid.NewGuid(), HasBegun = true,
                CurrentGameState = new GameState() { Round = new GameRound() { Phase = Phase.Retreat, Season = Season.Spring, Year = 1901 } },
                Options = new GameOptions() { IsRanked = true, RoundLength = new TimeSpan(10, 0, 0) } };
        }

        public IList<Game> GetGamesByPlayerId(Guid playerId)
        {
            return new List<Game>() { new Game() { Id = 10, AustriaPlayerId = playerId, CreatorPlayerId = playerId, HasBegun = false },
                new Game() { Id = 100, GermanyPlayerId = playerId, HasBegun = true, CurrentGameState = new GameState() { Round = new GameRound() { Phase = Phase.Movement, Season = Season.Spring, Year = 1901 } },
                    Options = new GameOptions() { IsRanked = true, RoundLength = new TimeSpan(10, 0, 0) }  },
                new Game() { Id = 103, EnglandPlayerId = playerId, HasBegun = true, IsFinished = true, CurrentGameState = new GameState(), Options = new GameOptions() { IsRanked = true, RoundLength = new TimeSpan(10, 0, 0) } },
            };
        }

        public Game UpdateGame(Game game)
        {
            return game;
        }
    }
}