using Statecraft.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statecraft.Common.Models;
using Statecraft.Common.DTOs;
using Statecraft.Services.DB;
using System.Data.Entity;

namespace Statecraft.Services.Repositories
{
    public class GameRepository : IGameRepository
    {
        public GameDto CreateNewGame(GameDto game)
        {
            //TODO: create game in DB AND PlayerGame record?

            using (var context = new GameContext())
            {
                context.Games.Add(game);
                context.SaveChanges();
                game = context.Games.FirstOrDefault(g => g.Id == game.Id);
            }

            return game;
        }

        public GameDto GetGameById(Guid id)
        {
            GameDto game = null;

            using (var context = new GameContext())
            {
                game = context.Games.FirstOrDefault(g => g.Id == id);
            }

            return game;
        }

        public IList<GameDto> GetGamesByPlayerId(Guid playerId)
        {
            IList<GameDto> games = null;

            using (var context = new GameContext())
            {
                games = context.Games.Where(g => g.AustriaPlayerId == playerId || g.EnglandPlayerId == playerId || g.FrancePlayerId == playerId || g.GermanyPlayerId == playerId || g.ItalyPlayerId == playerId || g.RussiaPlayerId == playerId || g.TurkeyPlayerId == playerId)
                    .Include(g => g.Map).ToList();
            }

            return games;
        }

        public GameDto UpdateGame(GameDto game)
        {
            using (var context = new GameContext())
            {
                var gameInDb = context.Games.FirstOrDefault(g => g.Id == game.Id);
                if(gameInDb != null)
                {
                    gameInDb = game;
                    context.Entry(gameInDb).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }

            return game;
        }
    }
}