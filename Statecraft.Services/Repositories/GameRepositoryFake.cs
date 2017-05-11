using Statecraft.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statecraft.Common.Models;
using Statecraft.Common.Enums;
using Statecraft.Common.DTOs;

namespace Statecraft.Services.Repositories
{
    public class GameRepositoryFake : IGameRepository
    {

        public GameDto CreateNewGame(GameDto game)
        {
            game.Id = Guid.NewGuid();
            return game;
        }

        public GameDto GetGameById(Guid id)
        {
            var game = new Game() { Id = id, GermanyPlayerId = Guid.NewGuid(), HasBegun = true, Options = new GameOptions() { IsRanked = true, RoundLength = new TimeSpan(10, 0, 0) }, CurrentGameState = new GameState() };
            game.CurrentGameState.InitializeMap();
            var gameDto = game.ToDto();
            gameDto.GameRoundId = 2;
            return gameDto;
       
            //return new GameDto() { Id = id, GermanyPlayerId = Guid.NewGuid(), HasBegun = true,
            //    GameRoundId = 2, 
            //    IsRankedOption = true, RoundLengthOption = new TimeSpan(10, 0, 0) };
        }

        public IList<GameDto> GetGamesByPlayerId(Guid playerId)
        {
            IList<GameDto> games = new List<GameDto>() { new GameDto() { Id = new Guid("00000000-0000-0000-0000-000000000010"), AustriaPlayerId = playerId, CreatorPlayerId = playerId, HasBegun = false },
                new GameDto() { Id = new Guid("00000000-0000-0000-0000-000000000100"), GermanyPlayerId = playerId, HasBegun = true, GameRoundId = 1, IsRankedOption = true, RoundLengthOption = new TimeSpan(10, 0, 0) },
                new GameDto() { Id = new Guid("00000000-0000-0000-0000-000000000103"), EnglandPlayerId = playerId, HasBegun = true, IsFinished = true, IsRankedOption = true, RoundLengthOption = new TimeSpan(10, 0, 0) } };

            var startedGame = new Game(games[1]);
            startedGame.CurrentGameState = new GameState();
            startedGame.CurrentGameState.InitializeMap();
            games[1] = startedGame.ToDto();

            return games;

            //return new List<GameDto>() { new GameDto() { Id = new Guid("00000000-0000-0000-0000-000000000010"), AustriaPlayerId = playerId, CreatorPlayerId = playerId, HasBegun = false },
            //    new GameDto() { Id = new Guid("00000000-0000-0000-0000-000000000100"), GermanyPlayerId = playerId, HasBegun = true, GameRoundId = 1, IsRankedOption = true, RoundLengthOption = new TimeSpan(10, 0, 0) },
            //    new GameDto() { Id = new Guid("00000000-0000-0000-0000-000000000103"), EnglandPlayerId = playerId, HasBegun = true, IsFinished = true, IsRankedOption = true, RoundLengthOption = new TimeSpan(10, 0, 0) }
            //};
        }

        public GameDto UpdateGame(GameDto game)
        {
            return game;
        }
    }
}