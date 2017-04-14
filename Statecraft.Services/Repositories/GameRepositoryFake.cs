using Statecraft.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Statecraft.Common.Models;

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
            throw new NotImplementedException();
        }

        public Game UpdateGame(Game game)
        {
            return game;
        }
    }
}